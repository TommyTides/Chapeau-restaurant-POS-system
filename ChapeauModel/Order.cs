using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Order
    {
        public int order_id { get; set; }
        public int item_code { get; set; }
        public int table_code { get; set; }
        public int quantity { get; set; }
        public DateTime order_time { get; set; }
        public double order_price { get; set; }
        public int order_status { get; set; }
        public int employee_code { get; set; }
        public MenuItem menu { get; set; }

        public Order()
        {

        }
        public Order(MenuItem menu, int quantity)
        {
            this.menu = menu;
            this.quantity = quantity;
        }
        public Order(MenuItem menu)
        {
            this.menu = menu;
        }
        public Order(int order_id, int item_code, int table_code, int quantity, DateTime order_time, double order_price, int order_status, int employee_code)
        {
            this.order_id = order_id;
            this.item_code = item_code;
            this.table_code = table_code;
            this.quantity = quantity;
            this.order_price = order_price;
            this.order_status = order_status;
            this.employee_code = employee_code;
        }
    }
}