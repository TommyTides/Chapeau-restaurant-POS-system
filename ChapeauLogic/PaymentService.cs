using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauDAL;

namespace ChapeauLogic
{
    class PaymentService
    {
        private PaymentDAO paymentDAO;

        public PaymentService()
        {
            paymentDAO = new PaymentDAO();
        }
        public void OrderPayment(Order order)
        {
            try
            {
                order.PaymentStatus = true;
                paymentDAO.ChangePaymentStatus(order);

                paymentDAO.OrderPayment(order);
            }
            catch (Exception exp)
            {
                throw new Exception("Failed loading orders for the payment");
            }
        }

        public List<OrderItem> GetOrderItems(int orderID)
        {
            return paymentDAO.GetOrderItemForOrderID(orderID);
        }
    }
}
