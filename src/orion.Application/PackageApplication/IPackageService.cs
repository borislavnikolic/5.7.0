using Abp.Application.Services;
using orion.PackageApplication.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace orion.PackageApplication
{
    public interface IPackageService : IApplicationService
    {
         Task<List<PackageDTO>> GetAllPackages();

        Task InsertPackage(InputCreatePackage input);

        Task UpdatePackage(InputCreatePackage input);

        Task<bool> DeletePackage(int id);

        Task<InputCreatePackage> GetPackage(int id);

        Task<List<PackageDTO>[]> GetChoosenAndRestPackages(int id);
       
    }
}
