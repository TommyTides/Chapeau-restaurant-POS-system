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


        //public List<Order> GetAllOrders()
        //{  
        //    return orderDAO.GetAllOrders();
        //}

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
    }
}
