using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public interface IItem
    {
        IEnumerable<Item> Items();
        IEnumerable<Item> SpecialOffers();

        Item GetItemById(int itemId);
    }

}
