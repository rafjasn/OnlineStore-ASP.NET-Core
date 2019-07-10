using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.ViewModels.ItemModels;

namespace Shop.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItem _item;
        private readonly ICategory _category;

        public ItemsController(IItem item, ICategory category)
        {
            _item = item;
            _category = category;
        }



        public IActionResult Index(string category)
        {


            var items = _item.Items().Select(i => new ItemListingModel
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


            var model = new ItemIndexModel();

            ViewBag.CatName = category; 


            if (category == null)
            {


                 model = new ItemIndexModel
                {
                    Items = items,
                    Categories = _category.Categories()

                };
            }
            else
            {
                 model = new ItemIndexModel
                {
                    Items = items.Where(c => c.Category.CategoryName == category),
                     Categories = _category.Categories()
                 };
            }



            return View(model);
        }



        public IActionResult Details(int itemId)
        {
            var i = _item.GetItemById(itemId);

            var model = new ItemListingModel
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
            };

            return View(model);
            
            
    

        }
    }
}