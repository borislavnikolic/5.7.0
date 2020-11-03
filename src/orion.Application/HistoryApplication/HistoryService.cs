using Abp.Application.Services;
using Abp.Domain.Repositories;
using orion.HistoryApplication.DTO;
using orion.Model;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace orion.HistoryApplication
{
    public class HistoryService : ApplicationService, IHistoryService
    {
        private readonly IRepository<History> _repositoryHistory;

        public HistoryService(IRepository<History> repositoryHistory)
        {
            _repositoryHistory = repositoryHistory;
        }
        public async Task<List<HistoryDTO>> ContractHistories(int id)
        {
            var histories = await _repositoryHistory.GetAll().Where(h => h.ConcractID == id).ToListAsync();
            return new List<HistoryDTO>(ObjectMapper.Map<List<HistoryDTO>>(histories));
        }
    }
}
