using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace orion.Model
{
    [Table("Package")]
    public class Package : Entity, IHasCreationTime
    {
        public const int MaxNameLength = 255;

        public const int MaxDescriptionLength = 64*1024;
        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,3)")]
        public decimal Price { get; set; }
        [Required]
        public CategoryType Category { get; set; }
        public DateTime CreationTime { get ; set ; }

        public  ICollection <PackageXConcract> packageXConcracts;


        public Package ()
        {
            CreationTime = Clock.Now;
            packageXConcracts = new HashSet<PackageXConcract>();
        }

        public Package(string name,string description,decimal price,CategoryType category) 
            : this()
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }

       
    }
    public enum CategoryType : byte
    {
        NET = 0,
        IPTV = 1,
        VOICE = 2
    }
}
