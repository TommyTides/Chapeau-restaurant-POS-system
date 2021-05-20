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
        // This method passes the query to the ExecuteSelectQuery METHOD
        public List<Order> GetAllOrders()
        {
            string query = "SELECT [order_id], [item_code], [table_code], [quantity], [order_time], [order_price], [order_status], [employee_code] FROM [ORDER];";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Order> GetAllOrdersBar()
        {
            string query = "select m.menu_type, m.item_name,o.quantity,o.order_time,o.order_status from [ORDER] as o JOIN [MENU_ITEM] as m ON o.item_code=m.item_id where m.menu_type = 'drinks' ORDER BY o.order_time asc;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadKitchen(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Order> GetAllOrdersKitchen()
        {
            string query = "select m.menu_type, m.item_name,o.quantity,o.order_time,o.order_status from [ORDER] as o JOIN [MENU_ITEM] as m ON o.item_code=m.item_id where m.menu_type = 'lunch' OR m.menu_type = 'dinner' ORDER BY o.order_time asc;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadKitchen(ExecuteSelectQuery(query, sqlParameters));
        }



        // Read the selected tablerows from the database and add it to the list
        private List<Order> ReadTables(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();

            foreach (DataRow dr in dataTable.Rows)
            {
                int order_id = (int)dr["order_id"];
                int item_code = (int)dr["item_code"];
                int table_code = (int)dr["table_code"];
               int quantity = (int)dr["quantity"];
               DateTime order_time = (DateTime)dr["order_time"];
                double order_price = (double)dr["order_price"];
                int order_status = (int)dr["order_status"];
                int employee_code = (int)dr["employee_code"];

                Order order = new Order(order_id, item_code, table_code, quantity, order_time, order_price, order_status, employee_code);
               orders.Add(order);
            }
            return orders;
        }
       

        private List<Order> ReadKitchen(DataTable dataTable)
        {
            List<Order> Kitchen = new List<Order>();

            foreach (DataRow dr in dataTable.Rows)
            {
                //string menu_type = (string)dr["menu_type"];
                //string item_name = (string)dr["item_name"];
                MenuItem item = new MenuItem();             

                item.menu_type = (string)dr["menu_type"];
                item.item_name = (string)dr["item_name"];
                Order kitchenorder = new Order(item, (int)dr["quantity"]);                

                //kitchenorders.menu_type = (string)dr["menu_type"];
                //kitchenorders.item_name = (string)dr["item_name"];
                Kitchen.Add(kitchenorder);
                
            }
            return Kitchen;
        }
    }
}
