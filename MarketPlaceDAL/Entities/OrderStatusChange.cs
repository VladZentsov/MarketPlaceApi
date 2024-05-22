using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceDAL.Entities
{
    public class OrderStatusChange:BaseEntity
    {
        //[ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime Date { get; set; }

    }
    public enum OrderStatus : int
    {
        Created = 0,
        PendingConfirmation = 1,
        Processing = 2,
        Shipped = 3,
        Archived = 4,
        Canceled = 5,
        Refunded = 6,
        Returned = 7
    }
}
