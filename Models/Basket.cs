using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SepetApi.Models
{
    public class Basket:EntityBase
    {
        public int Quantity { get; set; }
        public decimal Amount { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }
    }
}