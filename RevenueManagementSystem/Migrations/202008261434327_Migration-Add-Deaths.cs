namespace RevenueManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationAddDeaths : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deaths", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Deaths", "Email");
        }
    }
}
