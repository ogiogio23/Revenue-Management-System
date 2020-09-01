using System;

namespace RevenueManagementSystem.Models
{
    internal class SqlDefaultValueAttribute : Attribute
    {
        public string DefaultValue { get; set; }
    }
}