using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public enum ItemStatus { Preparing = 1, Ready, Delivered }

    public class OrderItem
    {
        public int OrderID { get; set; }
        public ItemStatus Status { get; set; } // status of the order(single)
        public MenuItem menuItem { get; set; } // List of menuItems

        public int Quantity { get; set; }
        public DateTime OrderTime { get; set; }
        public string Comment { get; set; }

        public double TotalPrice
        {
            get
            {
                return menuItem.item_price * Quantity;
            }
        }

        public OrderItem(MenuItem menuItem, int Quantity)
        {
            this.menuItem = menuItem;
            this.Quantity = Quantity;
        }

        public OrderItem() { } // Empty constructor

        public override string ToString()
        {
            return $"{menuItem.item_name}";
        }
    }
}