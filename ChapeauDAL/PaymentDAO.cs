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
    public class PaymentDAO : BaseDao
    {
        private List<OrderItem> ReadOrderItem(DataTable dataTable)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                // read from menu item
                MenuItem menu = new MenuItem()
                {
                    item_id = (int)dr["item_id"],
                    item_name = (string)dr["item_name"],
                    item_price = (double)dr["item_price"]
                };

                // read from order item
                OrderItem orderItem = new OrderItem
                {
                    // store menu item in the order item object (menuItem)
                    menuItem = menu,
                    Quantity = (int)dr["quantity"],
                    Comment = (string)dr["comment"],
                    Status = (ItemStatus)dr["itemStatus"]
                };

                orderItems.Add(orderItem);
            }
            return orderItems;
        }
        

        // gets the right orderitem that is related to the orderID
        public List<OrderItem> GetOrderItemForOrderID(int orderID)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            string query = 
                 "SELECT I.item_id, I.quantity, I.orderTime, I.itemStatus, I.comment, M.item_name, M.item_price "
                +"FROM ORDER_ITEM AS I JOIN MENU_ITEM AS M on M.item_id = I.item_id WHERE I.orderID = @id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", orderID);

            return ReadOrderItem(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Order> ReadOrdersForPayment(DataTable dataTable)
        {
            List<Order> unpaidOrders = new List<Order>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Table table = new Table
                {
                    TableID = (int)dr["tableID"]
                };

                Order order = new Order
                {
                    OrderID = (int)dr["orderID"],
                    PaymentDate = (DateTime)dr["paymentDate"],
                    Total = (double)dr["totalPrice"],
                    PaymentStatus = (bool)dr["paymentStatus"]
                };
                order.Table = table;
                unpaidOrders.Add(order);
            }
            return unpaidOrders;
        }

        // get orders for the payment
        public List<Order> GetOrdersForPayment()
        {
            List<Order> ordersToBePaid = new List<Order>();
            // remove O.orderStatus from query
            string query = "SELECT O.orderID, O.paymentDate, O.tableID, O.orderStatus, O.totalPrice, O.paymentStatus, O.employeeID , T.capacity, T.statusID FROM [ORDER] AS O JOIN [TABLE] AS T on T.table_id = O.tableID WHERE O.paymentStatus = 0";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadOrdersForPayment(ExecuteSelectQuery(query, sqlParameters));
        }


        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            // joining with the table and the employee
            string query = "SELECT orderID, employeeID, tableID FROM [ORDER] WHERE paymentStatus = 0";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadOrders(ExecuteSelectQuery(query, sqlParameters));
        }


        public List<Order> ReadOrders(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Order order = new Order
                {
                    OrderID = (int)dr["orderID"]                   
                };

                Employee employee = new Employee
                {
                    employeeID = (int)dr["employeeID"]
                }; 

                Table table = new Table
                {
                    TableID = (int)dr["tableID"],
                };
                //store table data in order object reference
                order.Table = table;
                order.Employee = employee;
                orders.Add(order);
            }
            return orders;
        }



        // this is for the rounding up for an order and paying with a method
        public void OrderPayment(Order order)
        {
            try
            {
                string query = "INSERT INTO PAYMENT(orderID, paymentmethodID, paymentTotal, vatTotal, tip, employeeID) " +
                "VALUES(@id, @method, @payment, @vat, @tip, @empID)";
                SqlParameter[] sqlParameters = new SqlParameter[6];
                sqlParameters[0] = new SqlParameter("@id", order.OrderID);
                sqlParameters[1] = new SqlParameter("@method", order.paymentMethod);
                sqlParameters[2] = new SqlParameter("@payment", order.Total);
                sqlParameters[3] = new SqlParameter("@vat", order.VATTotal);
                sqlParameters[4] = new SqlParameter("@tip", order.Tip);
                sqlParameters[5] = new SqlParameter("@empID", order.Employee.employeeID);

                ExecuteEditQuery(query, sqlParameters);
            }
            catch (Exception exp)
            {
                throw new Exception("Failed loading orders for the payment");
            }
        }

        //public int PayOrder(Order order, PaymentMethod paymentMethod) //roundng up order to make payment with a method
        //{
        //    SqlCommand sqlCommand = new SqlCommand("INSERT INTO Payments(orderID, methodID, billAmount, vatAmount, tip, employeeID) " +
        //        "VALUES(@id, @method, @bill, @vat, @tip, @empID)", dbConnection);
        //    sqlCommand.Parameters.AddWithValue("@id", order.OrderID);
        //    sqlCommand.Parameters.AddWithValue("@method", paymentMethod);
        //    sqlCommand.Parameters.AddWithValue("@bill", order.Total);
        //    sqlCommand.Parameters.AddWithValue("@vat", order.TotalVat);
        //    sqlCommand.Parameters.AddWithValue("@tip", order.Tip);
        //    sqlCommand.Parameters.AddWithValue("empid", order.Employee.EmployeeID);

        //    dbConnection.Open();
        //    int payOrders = sqlCommand.ExecuteNonQuery();
        //    dbConnection.Close();

        //    return payOrders;
        
        //}

        // when the order has been paid for, the payment status changes to true in the database
        public void ChangePaymentStatus(Order order)
        {
            string query = "UPDATE [ORDER] SET paymentStatus = @status, VAT = @vat, tip = @tip WHERE orderID = @ID";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@status", order.PaymentStatus);
            sqlParameters[1] = new SqlParameter("@ID", order.OrderID);
            sqlParameters[2] = new SqlParameter("@vat", order.VATTotal);
            sqlParameters[3] = new SqlParameter("@tip", order.Tip);

            ExecuteEditQuery(query, sqlParameters);
        }

        // gets the right order related to the table??
        public Order GetOrderForTable(Table table)
        {
            return GetOrderForTableByTableID(table.TableID);
        }

        // gets the right order corresponding to the tableID
        public Order GetOrderForTableByTableID(int tableID)
        {
            string query = "SELECT O.orderID, O.paymentDate, O.totalPrice, O.tableID, O.employeeID, O.orderStatus, O.tip, O.vat, O.paymentStatus, T.capacity, T.statusID FROM [ORDER] AS O JOIN [TABLE] AS T ON T.table_id = O.tableID WHERE O.tableID = @id AND O.paymentStatus = 0";
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
                 order = new Order()
                 {
                    OrderID = (int)dr["orderID"],
                    PaymentStatus = (bool)dr["paymentStatus"],
                    Status = (OrderStatus)dr["orderStatus"],
                    Total = (double)dr["totalPrice"],
                    PaymentDate=(DateTime)dr["paymentDate"],
                    Tip= (double)dr["tip"],
                    VATTotal = (double)dr["vat"],

                 };

                // order.Table = GetTableByID(tmp_tableID);
                order.Table = new Table()
                {
                    TableID = (int)dr["tableID"]
                    // the rest of fields are UNINITIALIZED! But it is OK because we do not need the rest in this module.
                };

                // order.Employee = GetEmployeeByID(tmp_employeeID);
                order.Employee = new Employee()
                {
                    employeeID = (int)dr["employeeID"]
                    // the rest of fields are UNINITIALIZED! But it is OK because we do not need the rest in this module.
                };
                
                order.OrderItem = GetOrderItemForOrderID(order.OrderID);
                order.paymentMethod = PaymentMethod.Cash; // PaymentMethod { get; set; }
            }
            return order; 
        }

        // after the order has been paid for, order status gets updated to paid
        public void UpdateOrderStatus(Order order)
        {
            string query = $"UPDATE [ORDER] SET PaymentStatus=@status, WHERE orderID=@orderID";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@orderID", order.OrderID);
            sqlParameters[0] = new SqlParameter("@status", 1);

            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
