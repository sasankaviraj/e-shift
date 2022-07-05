namespace e_shift.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Locations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeliveryLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false),
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
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PickupLocations");
            DropTable("dbo.DeliveryLocations");
        }
    }
}
