using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCKO.Models
{
    public class KOProductSold
    {
        public KOProductSold()
        {
            //ProductName = new List<KOProduct>();
            //CustomerName = new List<KOCustomer>();
            //StoreName = new List<KOStore>();
        }
        public int ID { get; set; }
        public Nullable<System.DateTime> DateSold { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> StoreId { get; set; }

        //public virtual List<KOProduct> ProductName { get; set; }
        //public virtual List<KOCustomer> CustomerName { get; set; }
        //public virtual List<KOStore> StoreName { get; set; }

        public virtual KOProduct KOProduct { get; set; }
        public virtual KOCustomer KOCustomer { get; set; }
        public virtual KOStore KOStore { get; set; }
        public string ProductName { get; internal set; }
        public string CustomerName { get; internal set; }
        public string StoreName { get; internal set; }
    }
}