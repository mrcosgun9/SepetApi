using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SepetApi.Models
{
    public class Product: EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}