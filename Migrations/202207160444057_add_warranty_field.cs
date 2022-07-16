namespace HTLElectronics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_warranty_field : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Waarranty", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Waarranty");
        }
    }
}
