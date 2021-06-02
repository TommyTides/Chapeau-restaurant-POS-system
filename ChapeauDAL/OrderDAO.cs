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

        public List<Order> GetAllOrdersBar()
        {
            string query = "select m.menu_type, m.item_name,o.quantity,o.orderTime,o.itemStatus,o.comment from [ORDER_ITEM] as o JOIN [MENU_ITEM] as m ON o.item_id = m.item_id where m.menu_type = 'drinks' ORDER BY o.order_time asc;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadKitchenBar(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Order> GetAllOrdersKitchen()
        {
            string query = "select m.menu_type, m.item_name,o.orderID,o.quantity,o.orderTime,o.itemStatus,o.comment,r.tableID from [ORDER_ITEM] as o JOIN [MENU_ITEM] as m ON o.item_id = m.item_id JOIN [ORDER] as R ON o.orderID = r.orderID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadKitchenBar(ExecuteSelectQuery(query, sqlParameters));
        }

        public void UpdateOrderStatus(OrderItem order)
        {
            string query = "Update [ORDER_ITEM] Set itemStatus = 1 Where orderID = @orderID AND comment = @comment AND orderTime = @orderTime";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@orderID", order.OrderID);
            sqlParameters[1] = new SqlParameter("@itemStatus", order.Status);
            sqlParameters[2] = new SqlParameter("@comment", order.Comment);
            sqlParameters[3] = new SqlParameter("@orderTime", order.OrderTime);
            ExecuteEditQuery(query,sqlParameters);
        }

        private List<Order> ReadKitchenBar(DataTable dataTable)
        {
            List<Order> KitchenBarOrders = new List<Order>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Table table = new Table();
               

                MenuItem item = new MenuItem();

                item.menu_type = (MenuCategory)dr["menu_type"];
                item.item_name = (string)dr["item_name"];



                OrderItem orderItem = new OrderItem();
                orderItem.OrderID = (int)dr["orderID"];
                orderItem.Comment = (string)dr["comment"];
                orderItem.Quantity = (int)dr["quantity"];
                orderItem.Status = (ItemStatus)dr["itemStatus"];
                orderItem.OrderTime = (DateTime)dr["orderTime"];
                orderItem.menuItem = item;

                Order order = new Order();
                order.OrderItem = new List<OrderItem>(); //I did it because the list will be null otherwise.
                table.TableID = (int)dr["tableID"];
                order.Table = table;
                order.OrderItem.Add(orderItem);



                KitchenBarOrders.Add(order);

            }
            return KitchenBarOrders;
        }

        //private List<Order> ReadKitchen(DataTable dataTable)
        //{
        //    List<Order> Kitchen = new List<Order>();
        //    foreach (DataRow dr in dataTable.Rows)
        //    {

        //        Order order = new Order();
        //        order.Table.TableID = (int)dr["tableID"];
        //        order.OrderID = (int)dr["orderID"];
        //        foreach (DataRow dr in dataTable.Rows)
        //        {

        //        }

        //        MenuItem item = new MenuItem();

        //        item.menu_type = (MenuCategory)dr["menu_type"];
        //        item.item_name = (string)dr["item_name"];



        //        OrderItem orderItem = new OrderItem();

        //        orderItem.Comment = (string)dr["comment"];
        //        orderItem.Quantity = (int)dr["quantity"];
        //        orderItem.Status = (ItemStatus)dr["itemStatus"];
        //        orderItem.OrderTime = (DateTime)dr["orderTime"];
        //        orderItem.menuItem = item;



        //        Kitchen.Add(orderItem);

        //    }
        //    return Kitchen;

        //}



    }
}