using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Components
{
    public class CategoryMenu : ViewComponent
    {

        private readonly ICategory _category;
        private readonly IItem _item;


        public CategoryMenu(ICategory category, IItem item)
        {
            _category = category;
            _item = item;
        }


        public IViewComponentResult Invoke()
        {
            var cat = _category.Categories();

            return View(cat); 
        }
    }
}
