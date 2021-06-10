using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ChapeauDAL
{
    public class MenuItemDAO : BaseDao
    {
        // This method passes the query to the ExecuteSelectQuery METHOD
        public List<MenuItem> GetAllMenuItems()
        {
            string query = "SELECT [item_id], [menu_type], [item_type], [item_name], [item_price], [stock], [place] FROM MENU_ITEM;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public int GetNewestOrder()
        {
            string query = "SELECT TOP 1 orderID FROM [ORDER] ORDER BY orderID DESC;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadOrderID(ExecuteSelectQuery(query, sqlParameters));
        }

        private int ReadOrderID(DataTable dataTable)
        {
            int newestOrder = 0;
            foreach (DataRow dr in dataTable.Rows)
            {
                newestOrder = (int)dr["orderID"];
            }
            return newestOrder;
        }

        public int AddOrder(Order order)
        {
            string query = $"INSERT INTO [ORDER](tableID, employeeID, paymentStatus) " +
                    $"VALUES(@paymentDate, @totalPrice, @tableID, #employeeID, #paymentStatus);";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[2] = new SqlParameter("@tableID", order.Table.TableID);
            sqlParameters[3] = new SqlParameter("@employeeID", order.Employee.employeeID);
            sqlParameters[4] = new SqlParameter("@paymentStatus", order.PaymentStatus);
            ExecuteEditQuery(query, sqlParameters);
            return GetNewestOrder();
        }

        public void AddOrderItem(Order order)
        {
            foreach (OrderItem orderItem in order.OrderItems)
            {
                string query = $"INSERT INTO ORDER_ITEM(orderID, item_id, quantity, totalPrice, comment, orderTime, placeID) " +
                    $"VALUES(@orderID, @item_id, @quantity, @totalPrice, @comment, @orderTime, @placeID);";
                SqlParameter[] sqlParameters = new SqlParameter[6];
                sqlParameters[0] = new SqlParameter("@orderID", order.OrderID);
                sqlParameters[1] = new SqlParameter("@item_id", orderItem.menuItem.item_id);
                sqlParameters[2] = new SqlParameter("@quantity", order.Table.TableID);
                sqlParameters[3] = new SqlParameter("@comment", orderItem.Comment);
                sqlParameters[4] = new SqlParameter("@orderTime", orderItem.OrderTime);
                sqlParameters[5] = new SqlParameter("@placeID", orderItem.menuItem.place);
                ExecuteEditQuery(query, sqlParameters);
            }
        }
            
        // Read the selected tablerows from the database and add it to the list
        private List<MenuItem> ReadTables(DataTable dataTable)
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                int item_id = (int)dr["item_id"];
                MenuCategory menu_type = (MenuCategory)dr["menu_type"];
                MenuSubCategory item_type = (MenuSubCategory)dr["item_type"];
                string item_name = (string)dr["item_name"];
                double item_price = (double)dr["item_price"];
                int stock = (int)dr["stock"];
                Place place = (Place)dr["place"];

                MenuItem menuItem = new MenuItem(item_id, menu_type, item_type, item_name, item_price, stock, place);
                menuItems.Add(menuItem);
            }
            return menuItems;
        }
    }
}