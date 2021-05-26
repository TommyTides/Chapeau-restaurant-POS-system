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
     
        //public List<OrderItem> GetAllOrdersBar()
        //{
        //    string query = "select m.menu_type, m.item_name,o.quantity,o.orderTime,o.itemStatus,o.comment from [ORDER_ITEM] as o JOIN [MENU_ITEM] as m ON o.item_id = m.item_id where m.menu_type = 'drinks' ORDER BY o.order_time asc;";
        //    SqlParameter[] sqlParameters = new SqlParameter[0];
        //    return ReadKitchen(ExecuteSelectQuery(query, sqlParameters));
        //}
         
        public List<OrderItem> GetAllOrdersKitchen()
        {
            string query = "select m.menu_type, m.item_name,o.quantity,o.orderTime,o.itemStatus,o.comment from [ORDER_ITEM] as o JOIN [MENU_ITEM] as m ON o.item_id = m.item_id";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadKitchen(ExecuteSelectQuery(query, sqlParameters));
        }

        public void UpdateOrderStatus(OrderItem order)
        {
            SqlCommand cmd = new SqlCommand("Update [ORDER_ITEM] Set Status = 2 Where orderID = orderID");
            cmd.Parameters.AddWithValue("@orderID", order.Status);

        }

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
                orderItem.Status = (ItemStatus)dr["itemStatus"];
                orderItem.OrderTime = (DateTime)dr["orderTime"];
                orderItem.menuItem = item;

        
                Kitchen.Add(orderItem);
                
            }
            return Kitchen;
        }



    }
}
