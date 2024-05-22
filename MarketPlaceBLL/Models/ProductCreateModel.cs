using Microsoft.AspNetCore.Http;

namespace MarketPlaceBLL.Models
{
    public class ProductCreateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockAvailability { get; set; }
        public int CategoryId { get; set; }
        public List<string> Tags { get; set; }
        public List<byte[]> Images { get; set; }
    }
}
