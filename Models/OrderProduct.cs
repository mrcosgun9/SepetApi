﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SepetApi.Models
{
    public class OrderProduct:EntityBase
    {
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int? BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}