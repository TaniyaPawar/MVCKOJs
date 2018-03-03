namespace MVCKO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbnew2 : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.KOCustomers", new[] { "KOProductSold_ID" });
            //DropIndex("dbo.KOProducts", new[] { "KOProductSold_ID" });
            //DropIndex("dbo.KOStores", new[] { "KOProductSold_ID" });
            //DropColumn("dbo.KOProductSolds", "CustomerId");
            //DropColumn("dbo.KOProductSolds", "ProductId");
            //DropColumn("dbo.KOProductSolds", "StoreId");
            //RenameColumn(table: "dbo.KOProductSolds", name: "KOProductSold_ID", newName: "CustomerId");
            //RenameColumn(table: "dbo.KOProductSolds", name: "KOProductSold_ID", newName: "ProductId");
            //RenameColumn(table: "dbo.KOProductSolds", name: "KOProductSold_ID", newName: "StoreId");
            //CreateIndex("dbo.KOProductSolds", "ProductId");
            //CreateIndex("dbo.KOProductSolds", "CustomerId");
            //CreateIndex("dbo.KOProductSolds", "StoreId");
            //DropColumn("dbo.KOCustomers", "KOProductSold_ID");
            //DropColumn("dbo.KOProducts", "KOProductSold_ID");
            //DropColumn("dbo.KOStores", "KOProductSold_ID");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.KOStores", "KOProductSold_ID", c => c.Int());
            //AddColumn("dbo.KOProducts", "KOProductSold_ID", c => c.Int());
            //AddColumn("dbo.KOCustomers", "KOProductSold_ID", c => c.Int());
            //DropIndex("dbo.KOProductSolds", new[] { "StoreId" });
            //DropIndex("dbo.KOProductSolds", new[] { "CustomerId" });
            //DropIndex("dbo.KOProductSolds", new[] { "ProductId" });
            //RenameColumn(table: "dbo.KOProductSolds", name: "StoreId", newName: "KOProductSold_ID");
            //RenameColumn(table: "dbo.KOProductSolds", name: "ProductId", newName: "KOProductSold_ID");
            //RenameColumn(table: "dbo.KOProductSolds", name: "CustomerId", newName: "KOProductSold_ID");
            //AddColumn("dbo.KOProductSolds", "StoreId", c => c.Int());
            //AddColumn("dbo.KOProductSolds", "ProductId", c => c.Int());
            //AddColumn("dbo.KOProductSolds", "CustomerId", c => c.Int());
            //CreateIndex("dbo.KOStores", "KOProductSold_ID");
            //CreateIndex("dbo.KOProducts", "KOProductSold_ID");
            //CreateIndex("dbo.KOCustomers", "KOProductSold_ID");
        }
    }
}
