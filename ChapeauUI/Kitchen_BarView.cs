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
        public List<Order> RunningOrders;
        private Place place;

        public Kitchen_BarView(Employee employee)
        {
            InitializeComponent();
            orderService = new OrderService();
            this.employee = employee;
            order = new Order();

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

        private List<Order> GetRunningOrders()
        {
            List<Order> RunningOrders = orderService.GetAllOrders(place);
            return RunningOrders;
        }

        private void FillOrderView()
        {
            RunningOrders = GetRunningOrders();

            foreach (Order O in RunningOrders)
            {
                foreach (OrderItem I in O.OrderItems)
                {
                    ListViewItem li = new ListViewItem(I.OrderID.ToString());
                    li.SubItems.Add(I.menuItem.item_name);
                    li.SubItems.Add(I.Comment.ToString());
                    li.SubItems.Add(I.Quantity.ToString());
                    li.SubItems.Add(I.OrderTime.ToString("HH:mm"));
                    li.SubItems.Add(O.Table.TableID.ToString());
                    li.SubItems.Add(I.Status.ToString());
                    li.SubItems.Add(I.menuItem.item_id.ToString());
                    li.Tag = I; 

                    if (I.Status == OrderItemStatus.Preparing)
                    {
                        li.ForeColor = Color.Blue;
                    }

                    ListViewOrders.Items.Add(li);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ListViewOrders.Items.Clear();
            FillOrderView();
        }

        private void btnPreparing_Click(object sender, EventArgs e)
        {
            if (ListViewOrders.SelectedItems.Count <= 0)
            {
                MessageBox.Show($"Order is not selected");
                return;
                //if nothing is selected it shows the message
            }
            else
            {
                OrderItemStatusChange(true);
                ListViewOrders.Items.Clear();
                FillOrderView();
            }
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            if (ListViewOrders.SelectedItems.Count <= 0)
            {
                MessageBox.Show($"Order is not selected");
                return;
            }
            else
            {
                OrderItemStatusChange(false);
                ListViewOrders.Items.Clear();
                FillOrderView();
            }
        }

      

        private void OrderItemStatusChange(bool OrderItemChange)
        {
            for (int i = 0; i < ListViewOrders.SelectedItems.Count; i++)
            {
                OrderItem orderItem = (OrderItem)ListViewOrders.SelectedItems[i].Tag;

                if (orderItem.Status == OrderItemStatus.Pending && OrderItemChange)
                {
                    //selected item preparing it will update
                    orderItem.Status = OrderItemStatus.Preparing;
                    orderService.UpdateOrderItemStatus(orderItem);

                    //-------------------------------------------------
                    order.OrderID = orderItem.OrderID;
                    order.Status = OrderStatus.Preparing;
                    orderService.UpdateOrderStatus(order);
                    //-------------------------------------------------
                }
                else if (orderItem.Status == OrderItemStatus.Preparing && OrderItemChange == false)
                {
                    orderItem.Status = OrderItemStatus.Ready;
                    orderService.UpdateOrderItemStatus(orderItem);
                    OrderStatusReady(orderItem.OrderID);
                }
                else
                    MessageBox.Show($"Wrong button selected");
            }
        }

        private void OrderStatusReady(int orderID)
        {
            Order order = orderService.GetOrderByID(orderID, place);
            bool ReadyStatus = true;
            foreach (OrderItem I in order.OrderItems)
            {
                if (I.Status != OrderItemStatus.Ready)
                {
                    ReadyStatus = false;
                    break;
                }
            }
            if (ReadyStatus)
            {
                order.OrderID = orderID;
                order.Status = OrderStatus.Ready;
                orderService.UpdateOrderStatus(order);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            Application.Exit();
        }
    }
}