using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceDAL.Entities
{
    public class User: IdentityUser
    {
        //[InverseProperty("User")]
        public ICollection<Order> Orders { get; set; }
        public ICollection<Shop> Shops { get; set; }
    }
}
