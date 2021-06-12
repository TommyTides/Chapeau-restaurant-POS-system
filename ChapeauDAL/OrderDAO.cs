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
            string query = "select m.menu_type, m.item_name,o.orderID,o.quantity,o.orderTime,o.itemStatus,o.comment,r.tableID from [ORDER_ITEM] as o JOIN [MENU_ITEM] as m ON o.item_id = m.item_id JOIN [ORDER] as R ON o.orderID = r.orderID where PlaceID = 2";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadKitchenBar(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Order> GetAllOrdersKitchen()
        {
            string query = "select m.menu_type, m.item_name,o.orderID,o.quantity,o.orderTime,o.itemStatus,o.comment,r.tableID from [ORDER_ITEM] as o JOIN [MENU_ITEM] as m ON o.item_id = m.item_id JOIN [ORDER] as R ON o.orderID = r.orderID where PlaceID = 1 ";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadKitchenBar(ExecuteSelectQuery(query, sqlParameters));
        }

        public void UpdateOrderReady(OrderItem order)
        {
            string query = "Update [ORDER_ITEM] Set itemStatus = 2 Where orderID = @orderID AND comment = @comment AND orderTime = @orderTime";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@orderID", order.OrderID);
            sqlParameters[1] = new SqlParameter("@itemStatus", order.Status);
            sqlParameters[2] = new SqlParameter("@comment", order.Comment);
            sqlParameters[3] = new SqlParameter("@orderTime", order.OrderTime);
            ExecuteEditQuery(query,sqlParameters);
        }

        public void UpdateOrderPreparing(OrderItem order)
        {
            string query = "Update [ORDER_ITEM] Set itemStatus = 1 Where orderID = @orderID AND comment = @comment AND orderTime = @orderTime";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@orderID", order.OrderID);
            sqlParameters[1] = new SqlParameter("@itemStatus", order.Status);
            sqlParameters[2] = new SqlParameter("@comment", order.Comment);
            sqlParameters[3] = new SqlParameter("@orderTime", order.OrderTime);
            ExecuteEditQuery(query, sqlParameters);
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
                order.OrderItems = new List<OrderItem>(); //I did it because the list will be null otherwise.
                table.TableID = (int)dr["tableID"];
                order.Table = table;
                order.OrderItems.Add(orderItem);



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

    #region Alex's part
        private List<OrderItem> ReadOrderItems(DataTable dataTable)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                // read from menu item
                // note to self: next time fill out all the fields in order to avoid errors with retrieving data
                MenuItem menu = new MenuItem()
                {
                    item_id = (int)dr["item_id"],
                    item_name = (string)dr["item_name"],
                    item_price = (double)dr["item_price"],
                    menu_type = (MenuCategory)dr["menu_type"],
                    item_type = (MenuSubCategory)dr["item_type"],
                };

                // read from order item
                OrderItem orderItem = new OrderItem();
                {
                    // store menu item in the order item object (menuItem)
                    orderItem.menuItem = menu;
                    orderItem.Quantity = (int)dr["quantity"];
                    if (dr["comment"] != System.DBNull.Value) orderItem.Comment = (string)dr["comment"]; // comment can be left null in database
                    orderItem.Status = (ItemStatus)dr["itemStatus"];
                };

                orderItems.Add(orderItem);
            }
            return orderItems;
        }

        // gets the right orderitem that is related to the orderID
        public List<OrderItem> GetOrderItemsForOrderID(int orderID)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            string query =
                 "SELECT I.item_id, I.quantity, I.orderTime, I.itemStatus, I.comment, M.item_name, M.item_price, M.menu_type, M.item_type "
                + "FROM ORDER_ITEM AS I JOIN MENU_ITEM AS M on M.item_id = I.item_id WHERE I.orderID = @id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", orderID);

            return ReadOrderItems(ExecuteSelectQuery(query, sqlParameters));
        }

        // this is for the rounding up for an order and paying with a method
        // this query inserts into the PAYMENT table after the paymnet has been completed
        // this information can be used for storage
        public bool SaveOrderPaymentInfo(Order order)
        {
            try
            {
                string query = "INSERT INTO [PAYMENT](orderID, paymentmethodID, paymentTotal, vatTotal, tip, employeeID, feedback) " +
                "VALUES(@id, @method, @payment, @vat, @tip, @empID, @feedback)";
                SqlParameter[] sqlParameters = new SqlParameter[7];
                sqlParameters[0] = new SqlParameter("@id", order.OrderID);
                sqlParameters[1] = new SqlParameter("@method", order.paymentMethod);
                sqlParameters[2] = new SqlParameter("@payment", order.Total);
                sqlParameters[3] = new SqlParameter("@vat", order.VATTotal);
                sqlParameters[4] = new SqlParameter("@tip", order.Tip);
                sqlParameters[5] = new SqlParameter("@empID", order.Employee.employeeID);
                sqlParameters[6] = new SqlParameter("@feedback", order.Feedback);


                ExecuteEditQuery(query, sqlParameters);

                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        // gets the right order corresponding to the tableID
        public Order GetOrderForTableByTableID(int tableID)
        {
            string query = 
                "SELECT O.orderID, O.paymentDate, O.totalPrice, O.tableID, O.employeeID, O.orderStatus, O.tip, O.vat, O.paymentStatus, "+
                "T.capacity, T.statusID, "+
                "E.employeeID, E.firstName, E.lastName, E.roleID, E.PIN " +
                "FROM [ORDER] AS O " +
                "JOIN [TABLE] AS T ON T.table_id = O.tableID "+
                "JOIN [EMPLOYEE] AS E ON E.employeeID = O.employeeID " +
                "WHERE O.tableID = @id AND O.paymentStatus = 0";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", tableID);

            return ReadFromOrder(ExecuteSelectQuery(query, sqlParameters));
        }

        // information that reads from the orders (used for GetOrderForTableByTableID method)
        private Order ReadFromOrder(DataTable dataTable)
        {
            Order order = null;
            foreach (DataRow dr in dataTable.Rows)
            {
                // used DBNull because otherwise it would give me an error regarding having nulls (specifically for VAT and TIP since they have to be empty)
                // due to the fact that they have to be filled out within the form and then updated to the database
                order = new Order();
                order.OrderID = (int)dr["orderID"];
                if (dr["paymentStatus"] != System.DBNull.Value) order.PaymentStatus = (bool)dr["paymentStatus"];
                if (dr["orderStatus"] != System.DBNull.Value) order.Status = (OrderStatus)dr["orderStatus"];
                if (dr["totalPrice"] != System.DBNull.Value) order.Total = (double)dr["totalPrice"];
                if (dr["paymentDate"] != System.DBNull.Value) order.PaymentDate = (DateTime)dr["paymentDate"];
                if (dr["tip"] != System.DBNull.Value) order.Tip = (double)dr["tip"];
                if (dr["vat"] != System.DBNull.Value) order.VATTotal = (double)dr["vat"];


                // order.Table = GetTableByID(tmp_tableID);
                order.Table = new Table()
                {
                    TableID = (int)dr["tableID"]
                    // the rest of fields are UNINITIALIZED! But it is OK because we do not need the rest in this module.
                };

                // order.Employee = GetEmployeeByID(tmp_employeeID);
                order.Employee = new Employee();
                order.Employee.employeeID = (int)dr["employeeID"];
                order.Employee.FirstName = (string)dr["firstName"];
                order.Employee.LastName = (string)dr["lastName"];
                order.Employee.Role = (Role)dr["roleID"];
                order.Employee.LoginCode = (int)dr["PIN"];

                order.OrderItems = GetOrderItemsForOrderID(order.OrderID);
                order.paymentMethod = PaymentMethod.Cash; // PaymentMethod { get; set; }
            }
            return order;
        }

        // when the order has been paid for, the payment status changes to true in the database
        public void ChangePaymentStatus(Order order, bool newOrderIsPaidStatus)
        {
            string query = "UPDATE [ORDER] SET paymentStatus = @status, VAT = @vat, tip = @tip, totalPrice = @totalPrice  WHERE orderID = @ID";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@status", newOrderIsPaidStatus);
            sqlParameters[1] = new SqlParameter("@ID", order.OrderID);
            sqlParameters[2] = new SqlParameter("@vat", order.VATTotal);
            sqlParameters[3] = new SqlParameter("@tip", order.Tip);
            sqlParameters[4] = new SqlParameter("@totalPrice", order.Total);

            ExecuteEditQuery(query, sqlParameters);
            order.PaymentStatus = newOrderIsPaidStatus;
        }
   #endregion

        // Tommy's DAO parts---------------------------------------------------------------------------
        public int GetNewestOrder() // Get newest order form the database
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
            // Test id for table
            order.Table.TableID = 1;
            //
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
            // Test id for table
            order.Table.TableID = 1;
            //
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

    }
}