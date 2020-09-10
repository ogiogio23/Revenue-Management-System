using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RevenueManagementSystem.Models
{
    public class Report
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }


        public string Email { get; set; }


        public string TransactionRef { get; set; }


        public string AmountPaid { get; set; }


        public string Bank { get; set; }


        public string LicenseType { get; set; }

        public DateTime DateRegistered { get; set; }
    }
}