using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RevenueManagementSystem.Models
{
    public class Birth
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


        [Required(ErrorMessage = "Name of Child is required!")]
        public string NameOfBaby { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string DOB { get; set; }

        [Required(ErrorMessage = "Place of Birth is required!")]
        public string PlaceOfBirth { get; set; }

        [SqlDefaultValue(DefaultValue = "getdate()")]
        public DateTime DateRegistered { get; set; } = DateTime.Now;

        public string Email { get; set; }
        public int CitizenId { get; set; }
        public Citizen Citizen { get; set; }
    }
}