using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using orion.ConcractApplication.DTO;
using orion.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace orion.ConcractApplication
{
    public class ConcractService : ApplicationService,IConcractService
    {
        private readonly IRepository<Concract> _repositoryConcract;

        private readonly IRepository<PackageXConcract> _repositoryConcractXPackage;

        private const int SIZE = 5;
        
        
        public ConcractService(IRepository<Concract> repositoryConcract,IRepository<PackageXConcract> repositoryConcractXPackage)
        {
            _repositoryConcract = repositoryConcract;
            _repositoryConcractXPackage = repositoryConcractXPackage;
        }
        public async Task<List<ConcractDTO>> GetConcracts()
        {
            var concracts = await _repositoryConcract.GetAll().Where(c => c.Status == StatusType.OPEN).ToListAsync();

            return new List<ConcractDTO>(ObjectMapper.Map<List<ConcractDTO>>(concracts));
        }

        public async Task<ConcractDTO> GetConcract(int id)
        {
            var concract = await _repositoryConcract.GetAll().Where(c => c.Id == id).FirstOrDefaultAsync();
            return ObjectMapper.Map<ConcractDTO>(concract);

        }

        public async Task<List<ConcractDTO>> GetRecentConcrats()
        {
            var concrats = await _repositoryConcract.GetAll()
                .Where(c => c.Status == StatusType.OPEN)
                .OrderByDescending( c => c.StartDate).Take(SIZE).ToListAsync();

            return new List<ConcractDTO>(ObjectMapper.Map<List<ConcractDTO>>(concrats));
        }

        public async Task<int[]> GetStatusConcractCounts()
        {
            var active = await _repositoryConcract.GetAll().Where(c => c.Status == StatusType.OPEN).CountAsync();
            var closed = await _repositoryConcract.GetAll().Where(c => c.Status == StatusType.CLOSED).CountAsync();
            
            
            return new int[2] { active,closed};
            
        }

        public async Task<List<ConcractSumDTO>> GetActiveSum()
        {
          
            var concracts =  await _repositoryConcractXPackage.GetAll()
                .Include(pxc => pxc.Package)
                .Include(pxc => pxc.Concract)
                .Where(pxc => pxc.Concract.Status == StatusType.OPEN)
                .Select(pxc => new { id=pxc.ConcractID,duration =( (byte)pxc.Concract.Duration-(byte)pxc.Concract.Gratis),discount =pxc.Concract.Discount }).Distinct().ToListAsync();
           
            List<ConcractSumDTO> result = new List<ConcractSumDTO>();
            foreach(var concract in concracts)
            {
                var total = await _repositoryConcractXPackage.GetAll()
                    .Where(pxc => pxc.ConcractID == concract.id).Select(pxc => pxc.Package.Price).SumAsync();
                total *= concract.duration;
                total -= (total * concract.discount / 100);
                result.Add(new ConcractSumDTO() { Id = concract.id,Total = total});
            }

            return result;
        }
    }
}
