using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int OrderitemCode { get; set; }
        public PaymentStatus paymentStatus { get; set; }
        public PaymentMethod paymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }

    }
    public enum PaymentMethod { CreditCard = 1, Pin, Cash }
    public enum PaymentStatus { Finished = 1, NotFinished }
}
