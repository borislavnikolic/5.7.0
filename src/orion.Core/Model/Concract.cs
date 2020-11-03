using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace orion.Model
{
    [Table("Concract")]
    public class Concract : Entity, IHasCreationTime
    {
        public const int MaxUsernameLength = 255;
        public const int MinDiscount = 0;
        public const int MaxDiscount = 100;

        [Required]
        [StringLength(MaxUsernameLength)]
        public string Username { get; set; }

        [Required]
        public DurationTime Duration { get; set; }


        [Required]
        public int Discount { get; set; }


        [Required]
        [Range(MinDiscount, MaxDiscount)]
        public GratisTime Gratis { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public StatusType Status { get; set; }

        public DateTime CreationTime { get; set; }

        public ICollection<PackageXConcract> packageXConcracts;

        public ICollection<History> histories;
        public Concract()
        {
            Status = StatusType.OPEN;
            CreationTime = Clock.Now;
            StartDate = Clock.Now;
            packageXConcracts = new HashSet<PackageXConcract>();
            histories = new HashSet<History>();

        }
        public Concract(string username, DurationTime duration, int discount, GratisTime gratis) : this()
        {
            Username = username;
            Duration = duration;
            Discount = discount;
            Gratis = gratis;
            //StartDate = startDate;
        }
    }

    public enum StatusType : byte
    {
        [Display(Name = "AKTIVAN")]
        OPEN = 0,
        [Display(Name = "ZATVOREN")]
        CLOSED = 1
    }

    public enum DurationTime : byte
    {
        [Display(Name = "jednogodisnji")]
        ONE_YEAR = 12,
        [Display(Name = "dvogodisnji")]
        TWO_YEAR = 24
    }
    public enum GratisTime : byte
    {
        [Display(Name = "jednomesecni")]
        ONE_MONTH = 1,
        [Display(Name = "dvomesecni")]
        TWO_MONTH = 2,
        [Display(Name = "tromesecni")]
        THREE_MONTH = 3,
        [Display(Name = "cetvoromesecni")]
        FOUR_MONTH = 4,
        [Display(Name = "petomesecni")]
        FIFTH_MONTH = 5,
        [Display(Name = "sestomesecni")]
        SIX_MONTH = 6,

    }

}
