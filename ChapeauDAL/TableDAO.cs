﻿using System;
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
        public List<Table> GetAllTables()
        {
            string query = "SELECT t.table_id, ts.description, oi.ItemStatus " +
            "FROM[TABLE] as t " +
            " JOIN TABLE_STATUS as ts on t.statusID = ts.tablestatusID " +
            " JOIN [ORDER] as o ON t.table_id = o.tableID " +
            " JOIN [ORDER_ITEM] as oi ON o.orderID = oi.orderID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadAllTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Table> ReadAllTables(DataTable dataTable)
        {
            List<Table> tables = new List<Table>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Table table = new Table()
                {
                    TableID = (int)dr["tableID"],
                    TableStatus = (TableStatus)(dr["description"]),
                    TableStatusId = (int)(dr["statusID"])
                    
                };
                tables.Add(table);
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

        private void ChangeTableStatus(Table table)
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
