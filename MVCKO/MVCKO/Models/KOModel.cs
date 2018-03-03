namespace MVCKO.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class KOModel : DbContext
    {
        // Your context has been configured to use a 'KOModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MVCKO.Models.KOModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'KOModel' 
        // connection string in the application configuration file.
        public KOModel()
            : base("name=KOModel")
        {
        }

        public DbSet<KOProduct> KOProducts { get; set; }
        public DbSet<KOCustomer> KOCustomers { get; set; }
        public DbSet<KOStore> KOStores { get; set; }
        public DbSet<KOProductSold> KOProductsSold { get; set; }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}