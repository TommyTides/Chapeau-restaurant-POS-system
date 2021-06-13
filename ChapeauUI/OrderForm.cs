using ChapeauLogic;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class OrderForm : Form
    {
        private OrderService orderService;
        private Employee employee;

        public OrderForm(Employee employee)
        {
            //receive the information who sign in login
            InitializeComponent();
            orderService = new OrderService();
            this.employee = employee;
     
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 2000, WinAPI.BLEND);

            ListViewKitchenBar();
            pictureBox4.Controls.Add(pictureBox1);
            pictureBox4.Controls.Add(pictureBox3);
            pictureBox1.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
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
            }
            else if (employee.Role == Role.KitchenStaff)
            {
                orderKitchenBar = orderService.GetAllKitchen();
                lblEmployee.Text = " OrderView Kitchen";
            }

            return orderKitchenBar;
        }

        private void ListViewKitchenBar()
        {

            List<Order> orderKitchenBar = Employee();
            //foreach to display the orderitems, I used the foreach to access TableID
            foreach (Order O in orderKitchenBar)
            {
                foreach (OrderItem I in O.OrderItems)
                {
                    if (I.Status.ToString() == "Ready")
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
                    ListViewKitch.Items.Add(li);
                }
            }
        }



        private void btnstatus_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Do you want to change the orderstatus", "Confirm Order Status",  MessageBoxButtons.YesNo);

            if (ListViewKitch.SelectedItems.Count <= 0)
            {
                MessageBox.Show($"Order is not selected");
                return;
                //if nothing is selected it shows the message
            }

            if(confirmResult == DialogResult.Yes)
            { 
                StatusChange();
            }
            ListViewKitch.Items.Clear();
            ListViewKitchenBar();
        }


        public void StatusChange()
        {
            for (int i = 0; i < ListViewKitch.Items.Count; i++)
            {
               
                //it goes thorugh the list of items in the listview
                if (ListViewKitch.Items[i].Selected)
                {
                   OrderItem item = (OrderItem)ListViewKitch.Items[i].Tag;
                    
                    if(item.Status.ToString() == "Ordered")
                    {
                        orderService.UpdateOrderPreparing((OrderItem)ListViewKitch.Items[i].Tag);
                    }
                    else if (item.Status.ToString() == "Preparing")
                    {
                        orderService.UpdateOrderReady((OrderItem)ListViewKitch.Items[i].Tag);
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) 
        {
            //Refresh for the Button for ListView
            ListViewKitch.Items.Clear();
            ListViewKitchenBar();
        }
    }
}