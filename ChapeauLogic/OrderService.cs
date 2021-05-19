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

      
        public List<Order> GetAllOrders()
        {
             
            return orderDAO.GetAllOrders();
        }

        public List<Order> GetAllKitchen()
        {
            List<Order> kitchen = orderDAO.GetAllOrdersKitchen();
            return kitchen;
        }

        //public List<MenuItem> GetAllBar()
        //{
          
        //    return orderDAO.GetAllOrdersBar();
        //}
    }
}