using ChapeauLogic;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class Kitchen_BarView : Form
    {
        private OrderService orderService;
        private Employee employee;
        private Order order;
        private Place place;

        public Kitchen_BarView(Employee employee)
        {
            InitializeComponent();
            orderService = new OrderService();
            this.employee = employee;
            order = new Order();
            //It will give the label and the place depends who signed in
            if (employee.Role == Role.KitchenStaff)
            {
                lblEmployee.Text = " OrderView Kitchen";
                place = Place.Kitchen;
            }
            else if (employee.Role == Role.Barman)
            {
                lblEmployee.Text = " OrderView Bar";
                place = Place.Bar;
            }
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 2000, WinAPI.BLEND);
            FillOrderView();
            pictureBox4.Controls.Add(pictureBox3);
            pictureBox3.BackColor = Color.Transparent;
        }

        private void FillOrderView()
        {
            //clear the list
            ListViewOrders.Items.Clear();
            //get the place orders 
            List<Order> RunningOrders = orderService.GetAllOrders(place);

            //double foreach to get the table 
            foreach (Order O in RunningOrders)
            {
                foreach (OrderItem I in O.OrderItems)
                {
                    ListViewItem li = new ListViewItem(I.OrderID.ToString());
                    li.SubItems.Add(I.menuItem.item_name);

                    if (I.Comment == "no comment")
                    {
                        I.Comment = "";
                    }

                    li.SubItems.Add(I.Comment.ToString());
                    li.SubItems.Add(I.Quantity.ToString());
                    li.SubItems.Add(I.OrderTime.ToString("HH:mm"));
                    li.SubItems.Add(O.Table.TableID.ToString());
                    li.SubItems.Add(I.Status.ToString());
                    li.SubItems.Add(I.menuItem.item_id.ToString());
                    li.Tag = I;
                    //if its equal to preparing  make it blue
                    if (I.Status == OrderItemStatus.Preparing)
                    {
                        li.ForeColor = Color.Blue;
                    }
                    //fill the items in the listview
                    ListViewOrders.Items.Add(li);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //refresh button will call the methode so the list will be new
            FillOrderView();
        }

        private void btnPreparing_Click(object sender, EventArgs e)
        {
            //if nothing is selected return the message
            if (ListViewOrders.SelectedItems.Count <= 0)
            {
                MessageBox.Show($"Order is not selected");
                return;
            }
            else
            {
                //if preparing is selected it gives true
                OrderItemStatusChange(true);
                FillOrderView();
            }
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            //if nothing is selected return the message
            if (ListViewOrders.SelectedItems.Count <= 0)
            {
                MessageBox.Show($"Order is not selected");
                return;
            }
            else
            {
                //if preparing is selected it gives false
                OrderItemStatusChange(false);
                FillOrderView();
            }
        }

        private void OrderItemStatusChange(bool OrderItemsState)
        {
            //loop over the selected items int the listview
            for (int i = 0; i < ListViewOrders.SelectedItems.Count; i++)
            {
                //convert selecteditems to object orderitem
                OrderItem orderItem = (OrderItem)ListViewOrders.SelectedItems[i].Tag;

                //if methode gives true and order is ordered 
                if (orderItem.Status == OrderItemStatus.Pending && OrderItemsState)
                {
                    //selected item will be updated to preparing
                    orderItem.Status = OrderItemStatus.Preparing;
                    orderService.UpdateOrderItemStatus(orderItem);

                    //-------------------------------------------------
                    //orderitem will give the orderstatus that its preparing.
                    order.OrderID = orderItem.OrderID;
                    order.Status = OrderStatus.Preparing;
                    orderService.UpdateOrderStatus(order);
                    //-------------------------------------------------
                }
                //if methode gives false and order is preparing
                else if (orderItem.Status == OrderItemStatus.Preparing && OrderItemsState == false)
                {
                    //selected item will be updated to ready
                    orderItem.Status = OrderItemStatus.Ready;
                    orderService.UpdateOrderItemStatus(orderItem);
                    OrderStatusReady(orderItem.OrderID);
                }
                else
                    //if nothing is selected that is with the condition it will show the messagebox
                    MessageBox.Show($"Wrong button selected");
            }
        }

        private void OrderStatusReady(int orderID)
        {
            //get the order from the database
            Order order = orderService.GetOrderByID(orderID, place);
            //if all items with the orderid has ready(true) it will change the orderstatus to ready
            bool ReadyStatus = true;
            foreach (OrderItem I in order.OrderItems)
            {
                if (I.Status != OrderItemStatus.Ready)
                {
                    //if one item is not ready it will give false and stop the loop
                    ReadyStatus = false;
                    break;
                }
            }
            if (ReadyStatus)
            {
                //if every item with the orderid is true it will give the 
                order.OrderID = orderID;
                order.Status = OrderStatus.Ready;
                orderService.UpdateOrderStatus(order);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //if exit button is selected go to loginform
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            Application.Exit();
        }
    }
}