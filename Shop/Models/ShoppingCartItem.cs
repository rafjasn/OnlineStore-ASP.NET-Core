using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ShoppingCartItem
    {
        public string Id { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public string CartId { get; set; }
    }
}
