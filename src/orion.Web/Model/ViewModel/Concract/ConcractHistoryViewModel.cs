using orion.ConcractApplication.DTO;
using orion.HistoryApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orion.Web.Model.ViewModel.Concract
{
    public class ConcractHistoryViewModel
    {
        public List<HistoryDTO> Histories { get; set; }
        public ConcractDTO Concract { get; set; }
    }
}
