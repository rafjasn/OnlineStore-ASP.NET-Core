using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels.ItemModels
{
    public class ItemIndexModel
    {
        public IEnumerable<ItemListingModel> Items { get; set; }

        public string CurrentCategory { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
