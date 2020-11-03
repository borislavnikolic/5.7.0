using Abp.Application.Services;
using orion.ConcractApplication.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace orion.ConcractApplication
{
    public interface IConcractService :  IApplicationService
    {
        Task<List<ConcractDTO>> GetConcracts();

        Task<List<ConcractDTO>> GetRecentConcrats();

        Task<int[]> GetStatusConcractCounts();

        Task<List<ConcractSumDTO>> GetActiveSum();

        Task<ConcractDTO> GetConcract(int id);

        
    }
}
