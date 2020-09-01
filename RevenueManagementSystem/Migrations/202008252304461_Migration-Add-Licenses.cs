namespace RevenueManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationAddLicenses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Licenses", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Licenses", "Email");
        }
    }
}
