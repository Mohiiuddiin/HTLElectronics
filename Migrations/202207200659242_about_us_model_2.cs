namespace HTLElectronics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class about_us_model_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AboutUs", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AboutUs", "Content", c => c.String());
        }
    }
}
