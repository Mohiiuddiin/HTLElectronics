namespace HTLElectronics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addiconcategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategories", "Icon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductCategories", "Icon");
        }
    }
}
