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
                int? TableID = (dr["table_id"]) as int?;
                int? TableStatusId = (dr["statusID"]) as int?;
                string CurrentOrderInfo = (dr["description"]) as string;
                DateTime? TimeStamp = (dr["orderTime"]) as DateTime?;

                if (TableID.HasValue)
                {
                    // if value not present in dictionry or new value available 
                    if (!tables.ContainsKey(TableID.Value) || (tables.ContainsKey(TableID.Value) && tables[TableID.Value].TimeStamp < TimeStamp))
                    {
                        tables[TableID.Value] = new Table()
                        {
                            TableID = TableID.Value,
                            TableStatus = (TableStatus)TableStatusId,
                            CurrentOrderInfo = CurrentOrderInfo,
                            TimeStamp = TimeStamp
                        };
                    }
                    
                }
            }
            return tables;
        }

        public List<Order> GetAllRunningOrders()
        {
            string query = "SELECT * FROM [ORDER] WHERE isPaid = @isPaid";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@isPaid", false);
            return CreateOrders(ExecuteSelectQuery(query, sqlParameters));
        }


        public List<Order> CreateOrders(DataTable orderData)
        {
            List<Order> orders = new List<Order>();
            EmployeeDAO employeeDAO = new EmployeeDAO();

            foreach (DataRow dr  in orderData.Rows)
            {
                Order order = new Order()
                {
                    Table = new Table((int)dr["tableID"]),
                    Status = (OrderStatus)(dr["orderStatus"]),
                    isPaid = (bool)(dr["paidOrders"]),
                    OrderID = (int)(dr["orderID"]),
                    Employee = employeeDAO.GetEmployeeId((int)dr["employeeID"])
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
    }
}
