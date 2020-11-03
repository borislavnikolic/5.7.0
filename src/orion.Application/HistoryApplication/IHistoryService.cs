using Abp.Application.Services;
using orion.HistoryApplication.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace orion.HistoryApplication
{
    public interface IHistoryService : IApplicationService
    {
        Task<List<HistoryDTO>> ContractHistories(int id);
    }
}
