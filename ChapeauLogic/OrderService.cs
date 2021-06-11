using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            orderDAO.UpdateOrderPreparing(order);
        }

        public void UpdateOrderReady(OrderItem order)
        {
            orderDAO.UpdateOrderReady(order);

        }
        public List<Order> GetAllKitchen()
        { 

            return orderDAO.GetAllOrdersKitchen();
        }

        public List<Order> GetAllBar()
        {
            return orderDAO.GetAllOrdersBar();
        }




        /// Alex's part
        /// 


        public bool OrderPayment(Order order)
        {
            try
            {
                order.PaymentStatus = true;
                orderDAO.ChangePaymentStatus(order);

                orderDAO.OrderPayment(order);

                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        public List<Order> GetOrdersToPay()
        {
            List<Order> orders = orderDAO.GetOrdersForPayment();

            foreach (Order order in orders)
            {
                order.OrderItems = orderDAO.GetOrderItemForOrderID(order.OrderID);
            }
            return orders;
        }

        //public List<OrderItem> GetOrderItemForOrderID(int orderID)
        //{
        //    return orderDAO.GetOrderItemForOrderID(orderID);
        //}

        public void UpdateOrderStatus(Order order)
        {
            orderDAO.UpdateOrderStatus(order);
        }

        public Order GetOrderForTableByTableID(int tableID)
        {
            return orderDAO.GetOrderForTableByTableID(tableID);
        }

        // Tommy Service parts
        public void SendOrder(Order order)
        {
            order.OrderID = orderDAO.AddOrder(order);
            orderDAO.AddOrderItem(order);
        }

        public List<OrderItem> GroupOrderItem()
        {
            return null;
        }
    }
}
