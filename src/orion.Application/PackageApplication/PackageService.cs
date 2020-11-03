using Abp.Domain.Repositories;
using orion.PackageApplication.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using orion.Model;
using System.Runtime.Serialization;
using AutoMapper;
using Abp.Application.Services;
using System.Linq.Dynamic.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace orion.PackageApplication
{
    public class PackageService : ApplicationService,IPackageService
    {
        private readonly IRepository<Package> _repositoryPackage;
        private readonly IRepository<PackageXConcract> _repositoryPackageXConcract;

        public PackageService(IRepository<Package> repositoryPackage,IRepository<PackageXConcract> repositoryPackageXConcract)
        {
            _repositoryPackage = repositoryPackage;
            _repositoryPackageXConcract = repositoryPackageXConcract;
        }

    public async Task<bool> DeletePackage(int id)
        {
            var pxc = await _repositoryPackageXConcract.GetAll().Where(pxc => pxc.PackageID == id).ToListAsync();
            if (pxc.Count == 0)
            {
                await _repositoryPackage.DeleteAsync(id);
                return true;
            }
            return false;
        }

        public async Task<List<PackageDTO>> GetAllPackages()
        {
            var packages = await _repositoryPackage.GetAllListAsync();

            return new List<PackageDTO>(ObjectMapper.Map<List<PackageDTO>>(packages));
        }

        public async Task<List<PackageDTO>[]> GetChoosenAndRestPackages(int id)
        {
            var choosenPackages = await _repositoryPackageXConcract.GetAll().Where(pxc => pxc.ConcractID == id).Select(pxc => pxc.Package).ToListAsync();
            var restPackages = await _repositoryPackage.GetAll().Where(p => !choosenPackages.Contains(p)).ToListAsync();

            var choosenDTO = new List<PackageDTO>(ObjectMapper.Map<List<PackageDTO>>(choosenPackages));
            var restnDTO = new List<PackageDTO>(ObjectMapper.Map<List<PackageDTO>>(restPackages));
            return new List<PackageDTO>[2] { restnDTO, choosenDTO };
        }

        public async Task<InputCreatePackage> GetPackage(int id)
        {
            var package = await _repositoryPackage.GetAsync(id);
            return ObjectMapper.Map<InputCreatePackage>(package);
        }

        public async Task InsertPackage(InputCreatePackage input)
        {
            var package = ObjectMapper.Map<Package>(input);
            await _repositoryPackage.InsertAsync(package);
        }

        public async Task UpdatePackage(InputCreatePackage input)
        {
            await _repositoryPackage.UpdateAsync(ObjectMapper.Map<Package>(input));
        }
    }
}
