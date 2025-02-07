﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceDAL.Entities
{
    public class OrderProduct: BaseEntity
    {
        //[ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        //[ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
