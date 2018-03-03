namespace MVCKO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.KOProductSolds", "ProductId", "dbo.KOProducts");
            DropIndex("dbo.KOProductSolds", new[] { "ProductId" });
            AddColumn("dbo.KOProductSolds", "KOProduct_ID", c => c.Int());
            CreateIndex("dbo.KOProductSolds", "KOProduct_ID");
            AddForeignKey("dbo.KOProductSolds", "KOProduct_ID", "dbo.KOProducts", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KOProductSolds", "KOProduct_ID", "dbo.KOProducts");
            DropIndex("dbo.KOProductSolds", new[] { "KOProduct_ID" });
            DropColumn("dbo.KOProductSolds", "KOProduct_ID");
            CreateIndex("dbo.KOProductSolds", "ProductId");
            AddForeignKey("dbo.KOProductSolds", "ProductId", "dbo.KOProducts", "ID");
        }
    }
}
