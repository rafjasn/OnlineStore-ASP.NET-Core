using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class OrderService : IOrder
    {
        private readonly ApplicationDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderService(ApplicationDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
         
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            var total = 0.0;

            _context.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach ( var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    ItemId = item.Item.ItemId,
                    OrderId = order.OrderId,
                    Quantity = item.Quantity,
                    Price = item.Item.Price
                };

                item.Item.InStock = item.Item.InStock - item.Quantity;
              
                total += orderDetail.Price * orderDetail.Quantity;
               
            if(item.Item.InStock > 0)
                {
                    _context.OrderDetails.Add(orderDetail);
                }
               

            }
            order.OrderTotal = total;
            
            _context.SaveChanges();
        }

        public IEnumerable<OrderDetail> Details(int orderId)
        {
            return _context.OrderDetails.Include(i => i.Item).Where(o => o.OrderId == orderId);
        }

        public IEnumerable<Order> Orders()
        {
            return _context.Orders;
        }
    }
}
