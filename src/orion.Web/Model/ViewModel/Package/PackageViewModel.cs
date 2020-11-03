using orion.PackageApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orion.Web.ViewModel
{
    public class PackageViewModel
    {
        public List<PackageDTO> Packages { get; set; }

        public PackageViewModel(List<PackageDTO> packages)
        {
            Packages = packages;
        }
    }
}
