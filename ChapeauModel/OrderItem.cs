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
        public ItemStatus Status { get; set; } // status of the order(single)
        public List<MenuItem> menuItem { get; set; } // List of menuItems

        public int Quantity { get; set; }

        public string Comment { get; set; }

        public double TotalPrice // calculate property
        { 
            get 
            {
                double totalCalculated = 0;
                foreach (MenuItem item in menuItem)
                {
                    totalCalculated += item.item_price;
                }
                return totalCalculated;
            }
        }      
    }  
}