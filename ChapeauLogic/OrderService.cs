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

        public void UpdateOrderPreparing(OrderItem order)
        {
            //Get selected information
            orderDAO.UpdateOrderPreparing(order);
        }

        public void UpdateOrderReady(OrderItem order)
        {
            //Get selected information
            orderDAO.UpdateOrderReady(order);
        }

        public List<Order> GetAllKitchen()
        {
            //send info for kitchen to UI
            return orderDAO.GetAllOrdersKitchen();
        }

        public List<Order> GetAllBar()
        {
            //send info for Bar to UI
            return orderDAO.GetAllOrdersBar();
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