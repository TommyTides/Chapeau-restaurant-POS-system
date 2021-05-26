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
        public List<OrderItem> GetOrderItemForOrderID(int orderID)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            string query = "SELECT I.item_id, I.quantity, I.orderTime, I.itemStatus, I.comment, M.item_name, M.item_price FROM ORDER_ITEM AS I JOIN MENU_ITEM AS M on M.item_id = I.item_id WHERE I.orderID = @id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", orderID);

            return ReadOrderItem(ExecuteSelectQuery(query, sqlParameters));
        }


        public List<Order> GetOrdersForPayment()
        {
            List<Order> ordersToBePaid = new List<Order>();

            string query = "SELECT O.orderID, O.paymentDate, O.tableID, O.orderStatus, O.totalPrice, O.paymentStatus, T.capacity, T.statusID FROM [ORDER] AS O JOIN [TABLE] AS T on T.tableID = O.tableID WHERE O.paymentStatus = 0";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadUOrdersForPayment(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Order> ReadUOrdersForPayment(DataTable dataTable)
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


        //private Order ReadOrder(DataTable dataTable)
        //{
        //    foreach(DataRow dr in dataTable.Rows)
        //    {
        //        Order order = new Order
        //        {
        //            OrderID = (int)dr["orderID"],
        //            Status = (OrderStatus)dr["orderStatus"],
        //            PaymentDate = (DateTime)dr["paymentDate"]
        //        };

        //        Employee employee = new Employee
        //        {
        //            FirstName = (string)dr["firstName"],
        //            LastName = (string)dr["lastName"],
        //            employeeID = (int)dr["employeeID"]
        //        };

        //        Table table = new Table
        //        {
        //            TableID = (int)dr["tableID"],
        //            Capacity = (int)dr["capacity"],
        //            Status = (TableStatus)dr["tableStatus"]

        //        };

        //        order.Table = table;
        //        order.Employee = employee;

        //        return order;
        //    }
        //}



        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            // joining with the table and the employee
            string query = "SELECT orderID, employeeID, tableID FROM [ORDER] WHERE paymentStatus = 0";

            return

        }

        private List<OrderItem> ReadOrderItem(DataTable dataTable)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                // read from menu item
                MenuItem menu = new MenuItem()
                {
                    item_id = (int)dr["itemID"],
                    item_name = (string)dr["itemName"],
                    item_price = (double)dr["itemPrice"]
                };

                // read from order item
                OrderItem orderItem = new OrderItem
                {
                    // store menu item in the order item object (menuItem)
                    menuItem = menu,
                    Quantity = (int)dr["quantity"],
                    Comment = (string)dr["comment"],
                    Status = (ItemStatus)dr["statusID"]
                };

                orderItems.Add(orderItem);
            }
            return orderItems;
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


        public Order GetOrderForTable(Table table)
        {
            SqlCommand cmd = new SqlCommand("SELECT O.orderID, O.paymentDate, O.totalPrice, O.tableID, O.orderStatus, " +
                "O.tip, O.vat, O.paymentStatus, T.capacity, T.statusID " +
                "FROM ORDER AS O JOIN TABLE AS T ON T.tableID = O.tableID WHERE O.tableID = 1 AND O.paymentStatus = 0");
        }
    }
}
