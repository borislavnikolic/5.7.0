using orion.PackageApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orion.Web.Model.ViewModel.Concract
{
    public class ConcractPackagesViewModel
    {
        public List<PackageDTO> RestPackages;
        public List<PackageDTO> ChoosenPackages = new List<PackageDTO>();

        public ConcractPackagesViewModel() { }
        public ConcractPackagesViewModel(List<PackageDTO> restPackages, List<PackageDTO> choosenPackages)
        {
            RestPackages = restPackages;
            ChoosenPackages = choosenPackages;
        }
    }
}
