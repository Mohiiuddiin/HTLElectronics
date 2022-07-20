namespace HTLElectronics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDABOUT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutPageContents",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        About = c.String(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Status = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AboutPageContents", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.AboutPageContents", new[] { "ApplicationUserId" });
            DropTable("dbo.AboutPageContents");
        }
    }
}
