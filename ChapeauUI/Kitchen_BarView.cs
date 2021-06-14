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

        public Kitchen_BarView(Employee employee)
        {
            //receive the information who sign in login in the construct from loginform
            InitializeComponent();
            orderService = new OrderService();
            this.employee = employee;
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 2000, WinAPI.BLEND);
            //load in instantly ListViewKitchenBar
            ListViewKitchenBar();
            //pictureBox4.Controls.Add(pictureBox1);
            pictureBox4.Controls.Add(pictureBox3);
            //pictureBox1.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //if exit button is clicked,
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            Application.Exit();
        }

        private List<Order> Employee()
        {
            List<Order> orderKitchenBar = null;
            if (employee.Role == Role.Barman)
            {
                orderKitchenBar = orderService.GetAllBar();
                lblEmployee.Text = " OrderView Bar";
                //if Barman employee sign in it will receive the Bar orders
            }
            else if (employee.Role == Role.KitchenStaff)
            {
                orderKitchenBar = orderService.GetAllKitchen();
                lblEmployee.Text = " OrderView Kitchen";
                //if kitchen employee sign in it will receive the kitchen orders
            }

            return orderKitchenBar;
        }

        private void ListViewKitchenBar()
        {
            //get employee information for kitchen or bar
            List<Order> orderKitchenBar = Employee();
            //foreach to display the orderitems, I used the double foreach to access TableID
            foreach (Order O in orderKitchenBar)
            {
                foreach (OrderItem I in O.OrderItems)
                {
                    if (I.Status == OrderItemStatus.Ready)
                    {
                        //if status is ready it will skip it
                        continue;
                    }

                    ListViewItem li = new ListViewItem(I.OrderID.ToString());
                    li.SubItems.Add(I.menuItem.item_name);
                    li.SubItems.Add(I.Comment.ToString());
                    li.SubItems.Add(I.Quantity.ToString());
                    li.SubItems.Add(I.OrderTime.ToString("HH:mm"));
                    li.SubItems.Add(O.Table.TableID.ToString());
                    li.SubItems.Add(I.Status.ToString());
                    li.Tag = I; // this is saving our object to the Item tag
                    if (I.Status == OrderItemStatus.Preparing)
                    {
                        li.ForeColor = Color.Blue;
                    }
                    ListViewKitchBar.Items.Add(li);
                }
            }
        }

        private void btnready_Click(object sender, EventArgs e)
        {

            if (ListViewKitchBar.SelectedItems.Count <= 0)
            {
                MessageBox.Show($"Order is not selected");
                return;
                //if nothing is selected it shows the message
            }

            //message box will be saved in confirmResult
            var confirmResult = MessageBox.Show("Do you want to mark it as ready", "Confirm Order Status", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                OrderItemChange();
                //if status is selected
                //refresh the list if its needed.
                ListViewKitchBar.Items.Clear();
                ListViewKitchenBar();
            }
        }

        public void OrderItemChange()
        {

            for (int i = 0; i < ListViewKitchBar.Items.Count; i++)
            {
                //it goes thorugh the list of items in the listview
                if (ListViewKitchBar.Items[i].Selected)
                {
                    //convert selected item to a orderitem object
                    OrderItem orderItem = (OrderItem)ListViewKitchBar.Items[i].Tag;

                    if (orderItem.Status == OrderItemStatus.Preparing)
                    {
                        //selected item preparing it will update
                        orderService.UpdateOrderReady((OrderItem)ListViewKitchBar.Items[i].Tag);
                        //if preparing ic changed to ready call methode
                        OrderStatusChange();
                    }
                }
            }
        }

        public void OrderStatusChange()
        {
            List<Order> orderKitchenBar = Employee();
            Order order = new Order();

            // all our order
            foreach (Order O in orderKitchenBar)
            {
                //count of items in side order
                int item = 0;

                //count of  items which is ready inside order
                int readyItem = 0;

                // all items inside 1 order
                foreach (OrderItem I in O.OrderItems)
                {
                    item++;

                    if (I.Status != OrderItemStatus.Ready)
                    {
                        //if status is not ready it will skip it
                        continue;
                    }

                    readyItem++;
                    //store orderitem in order object
                    order.OrderID = I.OrderID;
                }
                //if its equal store ready status
                if (item == readyItem)
                {
                    order.Status = OrderStatus.Ready;
                    orderService.UpdateOrderStatus(order);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //Refresh for the Button for ListView
            ListViewKitchBar.Items.Clear();
            ListViewKitchenBar();
        }

        private void btnPreparing_Click(object sender, EventArgs e)
        {
            Order order = new Order();

            //message box will be saved in confirmResult
            var confirmResult = MessageBox.Show("Do you want to mark it as Preparing", "Confirm Order Status", MessageBoxButtons.YesNo);

            if (ListViewKitchBar.SelectedItems.Count <= 0)
            {
                MessageBox.Show($"Order is not selected");
                return;
                //if nothing is selected it shows the message
            }

            if (confirmResult == DialogResult.Yes)
            {
                for (int i = 0; i < ListViewKitchBar.Items.Count; i++)
                {
                    //it goes thorugh the list of items in the listview
                    if (ListViewKitchBar.Items[i].Selected)
                    {
                        //convert selected item to a orderitem object
                        OrderItem orderItem = (OrderItem)ListViewKitchBar.Items[i].Tag;

                        if (orderItem.Status == OrderItemStatus.Ordered)
                        {
                            //selected item preparing it will update
                            orderService.UpdateOrderPreparing((OrderItem)ListViewKitchBar.Items[i].Tag);

                            //Store the ordid and orderstatus and send to change status
                            order.OrderID = orderItem.OrderID;
                            order.Status = OrderStatus.Preparing;
                            orderService.UpdateOrderStatus(order);
                        }
                        //refresh the list if its needed.
                        ListViewKitchBar.Items.Clear();
                        ListViewKitchenBar();
                    }
                }
            }

        }
    }
}