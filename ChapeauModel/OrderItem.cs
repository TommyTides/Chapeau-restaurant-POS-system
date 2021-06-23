using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{	
    public enum OrderItemStatus { Pending = 1, Preparing , Ready, Delivered }

    public class OrderItem
    {
        public int OrderID { get; set; }
        public OrderItemStatus Status { get; set; } // status of the order(single)
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




        public OrderItem()
        {
            menuItem = new MenuItem();
        }

        public override string ToString()
        {
            return $"{menuItem.item_name}";
        }
    }
}