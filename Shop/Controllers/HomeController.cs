using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;
using Shop.ViewModels.HomeModels;
using Shop.ViewModels.ItemModels;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItem _item; 
        private readonly ICategory _category; 
        public HomeController(IItem item, ICategory category)
        {
            _item = item;
            _category = category;
        }


        public IActionResult Index()
        {

            var items = _item.SpecialOffers().Select(i => new ItemListingModel
            {
                ItemId = i.ItemId,
                Name = i.Name,
                Description = i.Description,
                ShortDescription = i.ShortDescription,
                Category = i.Category,
                ImageUrl = i.ImageUrl,
                CategoryId = i.CategoryId,
                InStock = i.InStock,
                IsSpecialOffer = i.IsSpecialOffer,
                Price = i.Price
            });




            var model = new HomeModel
            {
                SpecialOffers = items,
                Categories = _category.Categories()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
