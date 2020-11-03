using Abp.Domain.Repositories;
using orion.Model;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using orion.Exceptions;
using Abp.Application.Services;
using Abp.Domain.Uow;

namespace orion.ConcractApplication.DTO
{
    public class ConcractCreationService : ApplicationService,IConcractCreationService
    {
        private readonly IRepository<Concract> _repositoryConcract;
        private readonly IRepository<PackageXConcract> _repostoryPackageXConcract;
        private readonly IRepository<Package>_repositoryPackage;
        private readonly IRepository<History> _repositoryHistory;

        public ConcractCreationService(IRepository<Concract> repositoryConcract
            , IRepository<PackageXConcract> repostoryPackageXConcract
            ,IRepository<Package> repositoryPackage
            ,IRepository<History> repositoryHistory)
        {
            _repositoryConcract = repositoryConcract;
            _repostoryPackageXConcract = repostoryPackageXConcract;
            _repositoryPackage = repositoryPackage;
            _repositoryHistory = repositoryHistory;
        }

        [UnitOfWork] 
        public async Task CreateConcract(List<int> input,ConcractDTO partConcract,bool mode)
        {
            if(input.Count <= 0 || input.Count > 3)
            {
                throw new ConcractCreationSizeException();
            }

            HashSet<CategoryType> types = new HashSet<CategoryType>();
            foreach(var packageID in input)
            {
                var package = await _repositoryPackage.GetAll().Where(p => p.Id == packageID).FirstOrDefaultAsync();
                
                if (types.Contains(package.Category) == true)
                    throw new ConcractCreationTypeException();
                types.Add(package.Category);
            }
            
            var concract = ObjectMapper.Map<Concract>(partConcract);
            var concractID =mode==true?partConcract.Id:await _repositoryConcract.InsertAndGetIdAsync(concract);

            if (mode == true)
            {
                var price = await ConcractPrice(concractID);
                var history = new History() { ConcractID = concractID, Status = partConcract.Status, Price = price }; 
                await _repositoryHistory.InsertAsync(history);
                _repostoryPackageXConcract.Delete(pxc => pxc.ConcractID == concractID);
               
                await CurrentUnitOfWork.SaveChangesAsync();

                await _repositoryConcract.UpdateAsync(concract);
            }
            foreach (var packageID in input)
            {
                var pxc = new PackageXConcract() { ConcractID = concractID,PackageID = packageID};
                await _repostoryPackageXConcract.InsertAsync(pxc);
            }


            
        }

        public async Task DeleteConcract(int id)
        {
            var listPXC = await _repostoryPackageXConcract.GetAll().Where(pxc => pxc.ConcractID == id).ToListAsync();
            foreach (var pxc in listPXC)
            {
                await _repostoryPackageXConcract.DeleteAsync(pxc);
            }

            await _repositoryConcract.DeleteAsync(id);
        }

        public async Task<string> GetPDF(int idConcract)
        {
            var sb = new StringBuilder();
            var concract = await _repositoryConcract.GetAll().Where(c => c.Id == idConcract).FirstOrDefaultAsync();

            var packages = await _repostoryPackageXConcract.GetAll().Where(pxc => pxc.ConcractID == idConcract).Select(pxc => pxc.Package).ToListAsync();
            
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div><h1 style='text-align:center'>Osnovni podaci o ugovoru</h1></div>
                                <table>"
                                    );
            sb.AppendFormat(@"
                    <tr>
                       <td>Broj Korisnickog ugovora<td><td>{0}</td>
                    </tr>
            ",concract.Id);
            sb.AppendFormat(@"
                    <tr>
                       <td>korisnicko Ime<td><td>{0}</td>
                    </tr>
            ", concract.Username);
            sb.AppendFormat(@"
                    <tr>
                       <td>Trajanje<td><td>{0}</td>
                    </tr>
            ", concract.Duration);
            sb.AppendFormat(@"
                    <tr>
                       <td>Gratis<td><td>{0}</td>
                    </tr>
               </table>
            ", concract.Gratis);
            sb.Append("<div><h1 style='text-align:center'>Paketi</h1></div>");
            sb.Append("<table><tr><th>Naziv</th><th>Kategorija</th><th>Cena</th></tr>");
            decimal sum = 0;
            foreach(var package in packages)
            {
                var cost = ((byte)concract.Duration - (byte)concract.Gratis) * package.Price;
                cost -= cost * concract.Discount / 100;
                sum += cost;
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>",package.Name,package.Category,cost);
            }
            sb.AppendFormat("<tr><td colspan='2'>Sum</td><td>{0}</td></tr>",sum);
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();

        }

        public async Task UserPartCreation(ConcractDTO input)
        {
            var concract = await _repositoryConcract.GetAll().Where(c => c.Username.Equals(input.Username) && c.Status == StatusType.OPEN).FirstOrDefaultAsync();
            if (concract != null)
            {
                throw new UserExistsException(concract.Id);
            }

        }

        private async Task<decimal> ConcractPrice(int id)
        {
            var packages = await _repostoryPackageXConcract.GetAll().Where(pxc => pxc.ConcractID == id).Select(pxc => pxc.Package).ToListAsync();
            var concract = await _repositoryConcract.GetAll().AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
            decimal sum = 0;
            foreach(var package in packages)
            {
                var cost = ((byte)concract.Duration - (byte)concract.Gratis) * package.Price;
                cost -= cost * concract.Discount / 100;
                sum += cost;
            }
            return sum;
        }
    }
}
