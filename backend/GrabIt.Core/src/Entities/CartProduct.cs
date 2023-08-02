using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabIt.Core.src.Entities
{
    public class CartProduct : BaseEntity
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}