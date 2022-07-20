namespace HTLElectronics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class about_us_model_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AboutUs", "About", c => c.String(nullable: false));
            DropColumn("dbo.AboutUs", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AboutUs", "Content", c => c.String(nullable: false));
            DropColumn("dbo.AboutUs", "About");
        }
    }
}
