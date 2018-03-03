using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCKO.Models
{
    public partial class KOCustomer
    {
        public KOCustomer()
        {

        }
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }

        [ForeignKey(name: "CustomerId")]
        public ICollection<KOProductSold> ProductsSold { get; set; }
    }
}