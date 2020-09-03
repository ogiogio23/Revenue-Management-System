namespace RevenueManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationAddMarriages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Marriages", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Marriages", "Email");
        }
    }
}
