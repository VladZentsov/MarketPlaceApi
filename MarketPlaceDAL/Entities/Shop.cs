using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlaceDAL.Entities
{
    public class Shop:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
