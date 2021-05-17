using System;

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
        public MenuItem() { } // to create an empty item
    }
}
