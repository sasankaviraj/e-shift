namespace e_shift.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        NIC = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false, maxLength: 10),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeliveryLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false),
                        UnitsFromColombo = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromAddress = c.String(nullable: false),
                        ToAddress = c.String(nullable: false),
                        IsDelivered = c.Boolean(nullable: false),
                        IsSuccess = c.Boolean(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        DeliveryLocation_Id = c.Int(nullable: false),
                        PickupLocation_Id = c.Int(nullable: false),
                        Transport_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeliveryLocations", t => t.DeliveryLocation_Id, cascadeDelete: true)
                .ForeignKey("dbo.PickupLocations", t => t.PickupLocation_Id, cascadeDelete: true)
                .ForeignKey("dbo.Transports", t => t.Transport_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.DeliveryLocation_Id)
                .Index(t => t.PickupLocation_Id)
                .Index(t => t.Transport_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Loads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product = c.String(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        Job_Id = c.Int(nullable: false),
                        ProductType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.Job_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductType_Id)
                .Index(t => t.Job_Id)
                .Index(t => t.ProductType_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Charges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PickupLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false),
                        UnitsFromColombo = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vehicle = c.String(),
                        RegNo = c.String(),
                        Driver = c.String(),
                        ChargesPerKm = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        NIC = c.String(nullable: false),
                        UserName = c.String(),
                        Password = c.String(nullable: false),
                        Address = c.String(),
                        ContactNumber = c.String(nullable: false, maxLength: 10),
                        UserType = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        UserType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserType_Id)
                .Index(t => t.UserType_Id);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserType_Id", "dbo.UserTypes");
            DropForeignKey("dbo.Jobs", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Jobs", "Transport_Id", "dbo.Transports");
            DropForeignKey("dbo.Jobs", "PickupLocation_Id", "dbo.PickupLocations");
            DropForeignKey("dbo.Loads", "ProductType_Id", "dbo.Products");
            DropForeignKey("dbo.Loads", "Job_Id", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "DeliveryLocation_Id", "dbo.DeliveryLocations");
            DropIndex("dbo.Users", new[] { "UserType_Id" });
            DropIndex("dbo.Loads", new[] { "ProductType_Id" });
            DropIndex("dbo.Loads", new[] { "Job_Id" });
            DropIndex("dbo.Jobs", new[] { "User_Id" });
            DropIndex("dbo.Jobs", new[] { "Transport_Id" });
            DropIndex("dbo.Jobs", new[] { "PickupLocation_Id" });
            DropIndex("dbo.Jobs", new[] { "DeliveryLocation_Id" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.Users");
            DropTable("dbo.Transports");
            DropTable("dbo.PickupLocations");
            DropTable("dbo.Products");
            DropTable("dbo.Loads");
            DropTable("dbo.Jobs");
            DropTable("dbo.DeliveryLocations");
            DropTable("dbo.Customers");
        }
    }
}
