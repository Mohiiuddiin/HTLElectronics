namespace HTLElectronics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DELABOUT : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AboutUs", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.AboutUs", new[] { "ApplicationUserId" });
            DropTable("dbo.AboutUs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AboutUs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        About = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Status = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.AboutUs", "ApplicationUserId");
            AddForeignKey("dbo.AboutUs", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
