using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
   public class OrderDAO : BaseDao
    {
     
        public List<OrderItem> GetAllOrdersBar()
        {
            string query = "select m.menu_type, m.item_name,o.quantity,o.orderTime,o.ItemStatus,o.comment from [ORDER_ITEM] as o JOIN [MENU_ITEM] as m ON o.item_code=m.item_id where m.menu_type = 'drinks' ORDER BY o.order_time asc;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadKitchen(ExecuteSelectQuery(query, sqlParameters));
        }
        //read 
        public List<OrderItem> GetAllOrdersKitchen()
        {
            string query = "select m.menu_type, m.item_name,o.quantity,o.orderTime,o.ItemStatus,o.comment from [ORDER_ITEM] as o JOIN [MENU_ITEM] as m ON o.item_code=m.item_id where m.menu_type = 'lunch' OR m.menu_type = 'dinner' ORDER BY o.order_time asc;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadKitchen(ExecuteSelectQuery(query, sqlParameters));
        }

        public void UpdateOrderStatus(OrderItem order)
        {
            SqlCommand cmd = new SqlCommand("Update [ORDER_ITEM] Set Status = 2 Where orderID = orderID");
            cmd.Parameters.AddWithValue("@ID", order.Status);
           
        }


        //Read the selected tablerows from the database and add it to the list
        //private List<Order> ReadTables(DataTable dataTable)
        //{
        //    List<Order> orders = new List<Order>();

        //    foreach (DataRow dr in dataTable.Rows)
        //    {
        //        int order_id = (int)dr["order_id"];
        //        int item_code = (int)dr["item_code"];
        //        int table_code = (int)dr["table_code"];
        //        int quantity = (int)dr["quantity"];
        //        DateTime order_time = (DateTime)dr["order_time"];
        //        double order_price = (double)dr["order_price"];
        //        int order_status = (int)dr["order_status"];
        //        int employee_code = (int)dr["employee_code"];

        //        //Order order = new Order(order_id, item_code, table_code, quantity, order_time, order_price, order_status, employee_code);
        //        //orders.Add(order);
        //    }
        //    return orders;
        //}


        private List<OrderItem> ReadKitchen(DataTable dataTable)
        {
            List<OrderItem> Kitchen = new List<OrderItem>();

            foreach (DataRow dr in dataTable.Rows)
            {

                MenuItem item = new MenuItem();

                item.menu_type = (MenuCategory)dr["menu_type"];
                item.item_name = (string)dr["item_name"];

                OrderItem orderItem = new OrderItem();
                orderItem.Comment = (string)dr["comment"];
                orderItem.Quantity = (int)dr["quantity"];
                orderItem.Status = (ItemStatus)dr["ItemStatus"];
                orderItem.OrderTime = (DateTime)dr["orderTime"];
                //kitchenorders.menu_type = (string)dr["menu_type"];
                //kitchenorders.item_name = (string)dr["item_name"];
                Kitchen.Add(orderItem);
                
            }
            return Kitchen;
        }



    }
}
