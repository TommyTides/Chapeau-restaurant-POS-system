using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Payment
    {
        public DateTime PaymentDate { get; set; }
        public bool PaymentStatus { get; set; }
        public decimal Tip { get; set; }
        public PaymentMethod paymentMethod { get; set; }
        // All of the VATs combined in an order
        public decimal Total { get; set; }
    }

    public enum PaymentMethod { CreditCard = 1, Pin, Cash }
}
