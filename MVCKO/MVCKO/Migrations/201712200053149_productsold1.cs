namespace MVCKO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productsold1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KOProductSolds", "ProductName", c => c.String());
            AddColumn("dbo.KOProductSolds", "CustomerName", c => c.String());
            AddColumn("dbo.KOProductSolds", "StoreName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KOProductSolds", "StoreName");
            DropColumn("dbo.KOProductSolds", "CustomerName");
            DropColumn("dbo.KOProductSolds", "ProductName");
        }
    }
}
