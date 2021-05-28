using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Order
    {
        public int OrderID { get; set; }

        // total VAT price (all VATS combined in an order)
        public double VATTotal { get; set; }
        public DateTime PaymentDate { get; set; }
        public Table Table { get; set; }
        public Employee Employee { get; set; }

        // status of the transaction (finished or not finished)
        public bool PaymentStatus { get; set; }
        public double Tip { get; set; }
        public List<OrderItem> OrderItem { get; set; }

        public OrderStatus Status { get; set; }

        public Table table { get; set; }

        public PaymentMethod paymentMethod { get; set; }
        public Employee employee { get; set; }

        // total price including the VAT
        public double Total { get; set; }

        // total price for a certain item (depending on quantity) excluding the VAT
        public double TotalPrice
        {
            get 
            {
                double tp = 0;

                foreach(OrderItem orderItem in OrderItem)
                {
                    tp += orderItem.menuItem.item_price * orderItem.Quantity;
                }
                return tp;
            }
        }
    }

    public enum OrderStatus { Pending = 1, Preparing, Ready, Served}

    public enum PaymentMethod { CreditCard = 1, Pin, Cash }
}