using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class MenuItem
    {
        public int item_id { get; set; }

        public string menu_type { get; set; }

        public string item_type { get; set; }

        public string item_name { get; set; }

        public double item_price { get; set; }

        public int stock { get; set; }

        public int vat { get; set; }

        public MenuItem() { }

        public MenuItem(int item_id, string menu_type, string item_type, string item_name, double item_price, int stock, int vat)
        {
            this.item_id = item_id;
            this.menu_type = menu_type;
            this.item_type = item_type;
            this.item_name = item_name;
            this.item_price = item_price;
            this.stock = stock;
            this.vat = vat;
        }
    }
}
