using System;
using System.Collections.Generic;

namespace EshopApi.Models
{
    public partial class Products
    {
        public Products()
        {
            OrdersItems = new HashSet<OrdersItems>();
        }

        public int ProductsId { get; set; }
        public string ProductsName { get; set; }
        public int? Size { get; set; }
        public string Varienty { get; set; }
        public double? Price { get; set; }
        public string Status { get; set; }

        public virtual ICollection<OrdersItems> OrdersItems { get; set; }
    }
}
