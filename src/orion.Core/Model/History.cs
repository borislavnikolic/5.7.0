using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace orion.Model
{
    [Table("History")]
    public class History : Entity,IHasCreationTime
    {
        [Required]
        public StatusType Status { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Concract Concract { get; set; }

        [ForeignKey("Concract")]
        public int ConcractID { get; set; }
        public DateTime CreationTime { get; set; }

        public History() { CreationTime = Clock.Now; }

        public History(StatusType status, decimal price, int concractID) :this()
        {
            Status = status;
            Price = price;
            ConcractID = concractID;
            
        }
    }
}
