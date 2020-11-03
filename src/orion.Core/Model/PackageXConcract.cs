using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace orion.Model
{
    [Table("PackageXConcract")]
    public class PackageXConcract : Entity, IHasCreationTime
    {
        public Concract Concract { get; set; }

        [ForeignKey("Concract")]

        public int ConcractID { get; set; }
        
        public Package Package { get; set; }

        [ForeignKey("Package")]
        public int PackageID { get; set; }

        public DateTime CreationTime { get; set; }

        public PackageXConcract()
        {
            CreationTime = Clock.Now;
        }

        public PackageXConcract(int concractID, int packageID) : this()
        {
            ConcractID = concractID;
            PackageID = packageID;
        }
    }
}
