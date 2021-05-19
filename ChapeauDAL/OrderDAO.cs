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
            string query = "SELECT [order_id], [item_code], [table_code], [quantity], [order_time], [order_price], [order_status], [employee_code] FROM ORDER;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        // Read the selected tablerows from the database and add it to the list
        private List<Order> ReadTables(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();

            foreach (DataRow dr in dataTable.Rows)
            {
                int order_id = (int)dr["order_id"];
                int item_id = (int)dr["item_id"];
                int table_code = (int)dr["table_code"];
               int quantity = (int)dr["quantity"];
               DateTime order_time = (DateTime)dr["order_time"];
                double order_price = (double)dr["order_price"];
                int order_status = (int)dr["order_status"];
                int employee_code = (int)dr["employee_code"];

                Order order = new Order(order_id, item_id, table_code, quantity, order_time, order_price, order_status, employee_code);
               orders.Add(order);
            }
            return orders;
        }
    }
}
