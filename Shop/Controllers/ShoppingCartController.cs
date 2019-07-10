using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;
using Shop.ViewModels.ShoppingCardModels;

namespace Shop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IItem _item;

        public ShoppingCartController(ShoppingCart shoppingCart, IItem item)
        {
            _shoppingCart = shoppingCart;
            _item = item;
        }


        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var model = new ShoppingCardModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCardTotal()
            };

            return View(model);
        }

        public RedirectToActionResult AddToShoppingCart(int itemId )
        {
            var item = _item.Items()
                .FirstOrDefault(i => i.ItemId == itemId);

            if (item != null)
            {
                _shoppingCart.AddToCart(item, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int itemId)
        {
            var item = _item.Items()
            .FirstOrDefault(i => i.ItemId == itemId);

            if (item != null)
            {
                _shoppingCart.RemoveFromCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}