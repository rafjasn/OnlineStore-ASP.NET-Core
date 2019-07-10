using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;
using Shop.ViewModels.OrderModels;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrder _order;

        public OrderController(  ShoppingCart shoppingCart, IOrder order)
        {
            _shoppingCart = shoppingCart;
            _order = order;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if( _shoppingCart.ShoppingCartItems.Count() == 0 )
            {
                ModelState.AddModelError("", "Your cart is empty");

            }
            if (ModelState.IsValid)
            {
                _order.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");

            }
            return RedirectToAction("CheckoutFailed");


        }
        public IActionResult CheckoutComplete()
        {
            return View();
        }


        //Admin Actions

        [Authorize]
        public IActionResult Index(string id)
        {
            var orderId = 0;

            if(id != null)
            {
                orderId = Convert.ToInt32(id);
            }



            var model = new OrderListingModel
            {
                Orders = _order.Orders(),
               
              Details = _order.Details(orderId)
                    

        };
            return View(model);
        }
        [Authorize]
        public IActionResult Details(int orderId)
        {
            var model = new OrderListingModel
            {
                
                Details = _order.Details(orderId)
            };

            return View(model);

        }

    }
}