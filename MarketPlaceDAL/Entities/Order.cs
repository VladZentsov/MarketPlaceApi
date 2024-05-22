using System.ComponentModel.DataAnnotations;

namespace MarketPlaceDAL.Entities
{
    public class Order:BaseEntity
    {
        //[ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        //[InverseProperty("Order")]
        public ICollection<OrderStatusChange> OrderStatusChanges { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }

}
