using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Timing;
using orion.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace orion.ConcractApplication.DTO
{
    [AutoMap(typeof(Concract))]
    public class ConcractDTO : EntityDto
    {
        [Required]
        [StringLength(Concract.MaxUsernameLength,ErrorMessage = "duzina username je iznad dozvoljenog")]
        public string Username { get; set; }
        
        [Required]
        public DurationTime Duration { get; set; }
        
        [Required]
        [Range(Concract.MinDiscount,Concract.MaxDiscount,ErrorMessage ="Popust je u nevalidnom rasponu")]
        
        public int Discount { get; set; }
        
        [Required]
        public GratisTime Gratis { get; set; }

        public DateTime StartDate { get; set; } = Clock.Now;

        [Required]
        public StatusType Status { get; set; }

        public DateTime CreationTime { get; set; } = Clock.Now;



    }
}
