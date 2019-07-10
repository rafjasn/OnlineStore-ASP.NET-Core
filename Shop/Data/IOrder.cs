using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
   public interface IOrder
    {
        void CreateOrder(Order order);
         IEnumerable<Order> Orders();
         IEnumerable<OrderDetail> Details(int orderId);

    }
}
