﻿using MarketPlaceDAL.Entities;

namespace MarketPlaceBLL.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockAvailability { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
