namespace RevenueManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationAddCitizens : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citizens",
                c => new
                    {
                        CitizenId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                        LGA = c.String(nullable: false),
                        DateRegistered = c.DateTime(nullable: false),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.CitizenId);
            
            CreateTable(
                "dbo.Births",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Occupation = c.String(nullable: false),
                        AmountPaid = c.String(),
                        Bank = c.String(nullable: false),
                        NameOfBaby = c.String(nullable: false),
                        DOB = c.String(),
                        PlaceOfBirth = c.String(nullable: false),
                        DateRegistered = c.DateTime(nullable: false),
                        CitizenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Citizens", t => t.CitizenId, cascadeDelete: true)
                .Index(t => t.CitizenId);
            
            CreateTable(
                "dbo.Deaths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Occupation = c.String(nullable: false),
                        AmountPaid = c.String(),
                        Bank = c.String(nullable: false),
                        NameOfDeceased = c.String(nullable: false),
                        DateOfDeath = c.String(),
                        PlaceOfDeath = c.String(nullable: false),
                        DateRegistered = c.DateTime(nullable: false),
                        CitizenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Citizens", t => t.CitizenId, cascadeDelete: true)
                .Index(t => t.CitizenId);
            
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bank = c.String(nullable: false),
                        AmountPaid = c.String(),
                        TransactionRef = c.String(nullable: false),
                        LicenseType = c.String(nullable: false),
                        DateRegistered = c.DateTime(nullable: false),
                        CitizenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Citizens", t => t.CitizenId, cascadeDelete: true)
                .Index(t => t.CitizenId);
            
            CreateTable(
                "dbo.Marriages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Occupation = c.String(nullable: false),
                        AmountPaid = c.String(),
                        Bank = c.String(nullable: false),
                        NameOfCouple = c.String(nullable: false),
                        Date = c.String(),
                        DateRegistered = c.DateTime(nullable: false),
                        CitizenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Citizens", t => t.CitizenId, cascadeDelete: true)
                .Index(t => t.CitizenId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Marriages", "CitizenId", "dbo.Citizens");
            DropForeignKey("dbo.Licenses", "CitizenId", "dbo.Citizens");
            DropForeignKey("dbo.Deaths", "CitizenId", "dbo.Citizens");
            DropForeignKey("dbo.Births", "CitizenId", "dbo.Citizens");
            DropIndex("dbo.Marriages", new[] { "CitizenId" });
            DropIndex("dbo.Licenses", new[] { "CitizenId" });
            DropIndex("dbo.Deaths", new[] { "CitizenId" });
            DropIndex("dbo.Births", new[] { "CitizenId" });
            DropTable("dbo.Marriages");
            DropTable("dbo.Licenses");
            DropTable("dbo.Deaths");
            DropTable("dbo.Births");
            DropTable("dbo.Citizens");
        }
    }
}
