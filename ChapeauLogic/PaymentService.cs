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

        //public int PayOrder(Order order, PaymentMethod paymentMethod) //paying an order with a payment method
        //{
        //    try
        //    {
        //        order.Payment = true;
        //        orderDAO.ChangePaymentState(order);

        //        return orderDAO.PayOrder(order, paymentMethod);

        //    }
        //    catch (Exception e)
        //    {

        //        return -1;
        //    }
        //}

        public List<OrderItem> GetOrderItems(int orderID)
        {
            return paymentDAO.GetOrderItemForOrderID(orderID);
        }

        public List<Order> GetOrders()
        {
            return paymentDAO.GetOrders();
        }

        public Order GetOrderForTable(Table table)
        {
            return paymentDAO.GetOrderForTable(table);
        }

        public List<Order> GetOrdersToPay()
        {
            List<Order> orders = paymentDAO.GetOrdersForPayment();

            foreach(Order order in orders)
            {
                order.OrderItem = paymentDAO.GetOrderItemForOrderID(order.OrderID);
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
