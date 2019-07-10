using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class ItemService : IItem
    {
        private readonly ApplicationDbContext _context;

        public ItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Item GetItemById(int itemId)
        {
            return _context.Items.Include(c => c.Category).FirstOrDefault(i => i.ItemId == itemId);
        }

        public IEnumerable<Item> Items()
        {
            return _context.Items.Include(c => c.Category).Where(a => a.InStock > 0);
        }

        public IEnumerable<Item> SpecialOffers()
        {
            return _context.Items.Where(i => i.IsSpecialOffer).Include(c => c.Category).Where(a => a.InStock > 0);
        }
    }
}
