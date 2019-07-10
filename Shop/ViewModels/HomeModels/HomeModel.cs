using Shop.Models;
using Shop.ViewModels.ItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels.HomeModels
{
    public class HomeModel
    {
        public IEnumerable<ItemListingModel> SpecialOffers { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
