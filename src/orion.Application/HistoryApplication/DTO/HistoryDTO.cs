using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Localization;
using orion.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace orion.HistoryApplication.DTO
{
    [AutoMapFrom(typeof(History))]
    public class HistoryDTO : EntityDto
    {
        
        public StatusType Status { get; set; }

       
        public decimal Price { get; set; }

       
        public int ConcractID { get; set; }
       
        public DateTime CreationTime { get; set; }
    }
}
