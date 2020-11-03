using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using orion.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace orion.PackageApplication.DTO
{
    [AutoMapFrom(typeof(Package))]
    public class PackageDTO : EntityDto//, IHasCreationTime
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        public decimal Price { get; set; }

        public CategoryType Category { get; set; }
        //public DateTime CreationTime { get ; set ; }
    }
}
