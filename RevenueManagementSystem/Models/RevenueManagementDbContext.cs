using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RevenueManagementSystem.Models
{
    public class RevenueManagementDbContext : DbContext
    {
        public RevenueManagementDbContext() : base("MyConn") { }

        public DbSet <Admin> Admins { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Birth> Births { get; set; }
        public DbSet<Death> Deaths { get; set; }
        public DbSet<Marriage> Marriages { get; set; }

    }
}