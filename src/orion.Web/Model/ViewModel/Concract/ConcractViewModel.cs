using orion.ConcractApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orion.Web.ViewModel
{
    public class ConcractViewModel
    {
        public int[] ConcractActiveStatistics { get; set; }
        public List<ConcractDTO> RecentConcracts { get; set; }
        public List<ConcractSumDTO> ActiveConcracts { get; set; }

        public ConcractViewModel(int[] concractActiveStatistics,List<ConcractDTO> recentConcracts,List<ConcractSumDTO> activeConcracts)
        {
            ConcractActiveStatistics = concractActiveStatistics;
            RecentConcracts = recentConcracts;
            ActiveConcracts = activeConcracts;
        }
    }
}
