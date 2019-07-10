using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels.OrderModels
{
    public class OrderListingModel
    {
       public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderDetail> Details { get; set; }
        public int orderId { get; set; }
    }
}
