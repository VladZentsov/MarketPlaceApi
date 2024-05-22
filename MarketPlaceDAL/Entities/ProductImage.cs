using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceDAL.Entities
{
    public class ProductImage:BaseEntity
    {
        //[ForeignKey("Product")]
        public int ProductId {  get; set; }
        public byte[] ImageData { get; set; }
        public Product Product { get; set; }
    }
}
