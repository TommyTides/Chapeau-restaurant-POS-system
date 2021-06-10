using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;
namespace ChapeauDAL
{
    public class TableDAO: BaseDao
    {
        public Dictionary<int, Table> GetAllTables()
        {
            string query = "SELECT t.table_id, t.statusID, os.description, oi.orderTime " +
            " FROM[TABLE] as t " +
            " LEFT JOIN[ORDER] as o ON t.table_id = o.tableID " +
            " LEFT JOIN[ORDER_ITEM] as oi ON o.orderID = oi.orderID " +
            " LEFT JOIN[ORDER_STATUS] as os ON oi.itemStatus = os.orderstatusID ";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadAllTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public Dictionary<int, Table> ReadAllTables(DataTable dataTable)
        {
            Dictionary<int, Table> tables = new Dictionary<int, Table>();

            foreach (DataRow dr in dataTable.Rows)
            {
                int? tableID = (dr["table_id"]) as int?;
                int? tableStatusId = (dr["statusID"]) as int?;
                string orderstatus = (dr["description"]) as string;
                DateTime? timestamp = (dr["orderTime"]) as DateTime?;

                if (tableID.HasValue)
                {
                    // if value not present in dictionry or new value available 
                    if (!tables.ContainsKey(tableID.Value) || (tables.ContainsKey(tableID.Value) && tables[tableID.Value].TimeStamp < timestamp))
                    {
                        tables[tableID.Value] = new Table()
                        {
                            TableID = tableID.Value,
                            TableStatus = (TableStatus)tableStatusId,
                            OrderStatus = orderstatus,
                            TimeStamp = timestamp
                        };
                    }
                    
                }
            }
            return tables;
        }

        public List<Order> GetAllRunningOrders()
        {
            string query = "select ord.orderID, ord.totalPrice, ord.tableID, ord.orderStatus, ord.tip, ord.vat, ord.employeeID, ord.paymentStatus, ord_s.description " +
                            " FROM[ORDER] as ord " +
                            " JOIN ORDER_STATUS as ord_s ON ord.orderStatus = ord_s.orderstatusID " +
                            " WHERE ord.paymentStatus = @paymentStatus";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@paymentStatus", false);
            return CreateOrders(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Order> CreateOrders(DataTable orderdata)
        {
            List<Order> orders = new List<Order>();
            EmployeeDAO employeeDAO = new EmployeeDAO();
            foreach (DataRow dr in orderdata.Rows)
            {
                Order order = new Order()
                {
                    Table = new Table((int)dr["tableID"]),
                    Status = (OrderStatus)(dr["orderStatus"]),
                    PaymentStatus = (bool)(dr["paymentStatus"]),
                    OrderID = (int)(dr["orderID"]),
                    Employee = employeeDAO.GetEmployee((int)dr["employeeID"])
                };
                orders.Add(order);
            }
            return orders;
        }

        public void ChangeTableStatus(int Tableid, int TableStatus)
        {
            string query = "UPDATE [TABLE] " +
                " SET statusID = @statusID " +
                " WHERE table_id = @table_id";

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@statusID", TableStatus);
            sqlParameters[1] = new SqlParameter("@table_id", Tableid);
            ExecuteEditQuery(query, sqlParameters);
        }

        public void ChangeTableStatusAfterPayment(Table table)
        {
            string query = " UPDATE [TABLE] " +
                           " SET statusID = @statusID " +
                           " WHERE table_id = @table_id ";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@statusID", (int)table.TableStatus);
            sqlParameters[1] = new SqlParameter("@table_id", table.TableID);
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
