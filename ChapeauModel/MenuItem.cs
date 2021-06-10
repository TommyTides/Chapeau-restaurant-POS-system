using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public enum Place { Kitchen = 1, Bar }
    public enum MenuCategory { Lunch = 1, Dinner, Drinks }
    public enum MenuSubCategory { lunchMain = 1, specials, bites, starters, mains, desserts, soft, hot, alcohol }

    public class MenuItem
    {
        public int item_id { get; set; }

        public MenuCategory menu_type { get; set; }

        public MenuSubCategory item_type { get; set; }

        public string item_name { get; set; }

        public double item_price { get; set; }

        public int stock { get; set; }

        public Place place { get; set; }

        public MenuItem() { } // to create empty menuItem

        public MenuItem(int item_id, MenuCategory menu_type, MenuSubCategory item_type, string item_name, double item_price, int stock, Place place)
        {
            this.item_id = item_id;
            this.menu_type = menu_type;
            this.item_type = item_type;
            this.item_name = item_name;
            this.item_price = item_price;
            this.stock = stock;
            this.place = place;
        }
        public override string ToString()
        {
            return $"{item_name}";
        }
    }
}
