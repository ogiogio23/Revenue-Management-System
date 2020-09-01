using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RevenueManagementSystem.Models
{
    public class Death
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Occupation is required!")]
        public string Occupation { get; set; }

        [Range(1, 100000)]
        [DataType(DataType.Currency)]
        public string AmountPaid { get; set; }

        [Required(ErrorMessage = "Bank Name is required!")]
        public string Bank { get; set; }

        [Required(ErrorMessage = "Name of Deceased is required!")]
        public string NameOfDeceased { get; set; }

        [Display(Name = "Date of Death")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string DateOfDeath { get; set; }

        [Required(ErrorMessage = "Place of Death is required!")]
        public string PlaceOfDeath { get; set; }

        [SqlDefaultValue(DefaultValue = "getdate()")]
        public DateTime DateRegistered { get; set; } = DateTime.Now;

        public string Email { get; set; }
        public int CitizenId { get; set; }
        public Citizen Citizen { get; set; }
    }
}