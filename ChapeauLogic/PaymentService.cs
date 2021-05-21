using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauLogic
{
    public class PaymentService
    {
        PaymentDAO paymentdb;

        public PaymentService()
        {
            paymentdb = new PaymentDAO();
        }

        public List<Payment> GetAllPayments()
        {
            List<Payment> payments = paymentdb.GetAllPayments();
            return payments;
        }


    }
}
