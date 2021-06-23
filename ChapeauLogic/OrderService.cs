using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;

namespace ChapeauLogic
{
    public class OrderService
    {
        private OrderDAO orderDAO;

        public OrderService()
        {
            orderDAO = new OrderDAO();
        }

        public void UpdateOrderItemStatus(OrderItem orderItem)
        {
            //Get selected information
            orderDAO.UpdateOrderItemStatus(orderItem);
        }

        public List<Order> GetAllOrders(Place place)
        {
            //send info for kitchen to UI
            return orderDAO.GetAllOrders(place);
        }

        public void UpdateOrderStatus(Order order)
        {
            //Get selected information
            orderDAO.UpdateOrderStatus(order);
        }

        #region Alex's part

        public bool ExecuteOrderPayment(Order order)
        {
            try
            {
                // in real life - we need to perform interaction with PaymentSystem here to get payment processed by bank and confirmed
                // if(PerformBankTransaction() == false) throw new Exception("Payment refused by bank");
                orderDAO.SaveOrderPaymentInfo(order);
                orderDAO.UpdateOrderDetails(order,/*newStatus=*/true);
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        public Order GetOrderForTableByTableID(int tableID)
        {
            return orderDAO.GetOrderForTableByTableID(tableID);
        }

        #endregion Alex's part

        // Tommy Service parts
        public void SendOrder(Order order)
        {
            order.OrderID = orderDAO.AddOrder(order);
            orderDAO.AddOrderItem(order);
        }

        public int GroupOrderItem(int amount1, int amount2)
        {
            return (amount1 + amount2);
        }
    }
}