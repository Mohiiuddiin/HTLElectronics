namespace HTLElectronics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class about_us_model_4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AboutUs", "About", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AboutUs", "About", c => c.String(nullable: false));
        }
    }
}
