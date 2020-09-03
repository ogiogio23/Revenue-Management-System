using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RevenueManagementSystem.Models
{
    public class License
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Transaction Reference is required!")]
        public string TransactionRef { get; set; }

        [Range(1, 100000)]
        [DataType(DataType.Currency)]
        public string AmountPaid { get; set; }

        [Required(ErrorMessage = "Bank Name is required!")]
        public string Bank { get; set; }

        [Required(ErrorMessage = "License is required!")]
        public string LicenseType { get; set; }

        [SqlDefaultValue(DefaultValue = "getdate()")]
        public DateTime DateRegistered { get; set; } = DateTime.Now;

        public int CitizenId { get; set; }
        public Citizen Citizen { get; set; }
    }
}