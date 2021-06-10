using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauDAL;

namespace ChapeauLogic
{
    public class PaymentService
    {
        private PaymentDAO paymentDAO;

        public PaymentService()
        {
            paymentDAO = new PaymentDAO();
        }
        public bool OrderPayment(Order order)
        {
            try
            {
                order.PaymentStatus = true;
                paymentDAO.ChangePaymentStatus(order);

                paymentDAO.OrderPayment(order);

                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        public List<Order> GetOrdersToPay()
        {
            List<Order> orders = paymentDAO.GetOrdersForPayment();

            foreach (Order order in orders)
            {
                order.OrderItems = paymentDAO.GetOrderItemForOrderID(order.OrderID);
            }
            return orders;
        }

        public List<OrderItem> GetOrderItemForOrderID(int orderID)
        {
            return paymentDAO.GetOrderItemForOrderID(orderID);
        }

        public void UpdateOrderStatus(Order order)
        {
            paymentDAO.UpdateOrderStatus(order);
        }

        public Order GetOrderForTableByTableID(int tableID)
        {
            return paymentDAO.GetOrderForTableByTableID(tableID);
        }
    }
}
