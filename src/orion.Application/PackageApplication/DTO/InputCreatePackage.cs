using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using orion.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace orion.PackageApplication.DTO
{
    [AutoMap(typeof (Package))]
    public class InputCreatePackage : EntityDto
    {
        [Required]
        [StringLength(Package.MaxNameLength,ErrorMessage ="Unesite Ime")]
        public string Name { get; set; }

        [Required]
        [StringLength(Package.MaxDescriptionLength, ErrorMessage = "Unesite Opis")]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue,ErrorMessage ="Cena mora biti pozitivna"), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 3)")]
        public decimal Price { get; set; }

        public CategoryType Category { get; set; }

        
    }
}
