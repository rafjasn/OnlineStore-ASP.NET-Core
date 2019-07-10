using System.Collections.Generic;

namespace Shop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}