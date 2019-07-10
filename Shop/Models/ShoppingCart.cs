using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCart(ApplicationDbContext context)
        {
            _context = context;
        }

        public string ShoppingCartId { get; set; }
        public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }



        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<ApplicationDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId};
        }

        public void AddToCart(Item item, int quantity)
        {
            var shoppingCartItem = _context.ShoppingCartItems.Include(i =>i.Item)
                .SingleOrDefault(i => i.Item.ItemId == item.ItemId && i.CartId == ShoppingCartId);

            if( shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    CartId = ShoppingCartId,
                    Item = item,
                    Quantity = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);

            }
            else
            {
                shoppingCartItem.Quantity++;
            }
            _context.SaveChanges();
        }

        public int RemoveFromCart(Item item)
        {
            var shoppingCartItem = _context.ShoppingCartItems
         .SingleOrDefault(i => i.Item.ItemId == item.ItemId && i.CartId == ShoppingCartId);

            var localAmount = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localAmount = shoppingCartItem.Quantity;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();

            return localAmount;

        }


        public IEnumerable<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems = _context.ShoppingCartItems
                .Where(i => i.CartId == ShoppingCartId)
                .Include(i => i.Item).ToList());

        }

        public double GetShoppingCardTotal()
        {
            return _context.ShoppingCartItems
                .Where(i => i.CartId == ShoppingCartId)
                .Select(i => i.Item.Price * i.Quantity).Sum();

        }

        public void ClearCart()
        {
            var items = _context.ShoppingCartItems
                .Where(c => c.CartId == ShoppingCartId);

            _context.ShoppingCartItems.RemoveRange(items);
            _context.SaveChanges();
        }



    }
}
