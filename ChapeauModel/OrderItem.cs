using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class OrderItem
    {
        public MenuItem menuItem { get; set; }
        public int Quantity { get; set; }
        public string Comment { get; set; }

        public double TotalPrice
        {
            get
            {
                return menuItem.item_price * Quantity;
            }
        }

        public ItemStatus Status { get; set; }
    }

    public enum ItemStatus { Ready = 1, Preparing, Delivered }
}
