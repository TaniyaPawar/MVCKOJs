using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCKO.Models
{
    public partial class KOStore
    {
        public int ID { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }

        [ForeignKey("StoreId")]
        public ICollection<KOProductSold> ProductsSold { get; set; }
    }
}