using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCKO.Models
{
    public partial class KOProduct
    {
        public KOProduct()
        {

        }
        public int ID { get; set; }
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }

        //[ForeignKey("ProductId")]
        //public ICollection<KOProductSold> ProductsSold { get; set; }

    }
}