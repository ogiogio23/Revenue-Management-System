namespace RevenueManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationAddBirths : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Births", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Births", "Email");
        }
    }
}
