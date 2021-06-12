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
        private EmployeeService employeeService;
        private OrderItem orderItem;
        private Employee employee;
        private Order order;

        public OrderForm(Employee employee)
        {
            InitializeComponent();
            orderService = new OrderService();
            orderItem = new OrderItem();
            this.employee = employee;
            order = new Order();
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
            List<Order> orderKitchen = null;
            if (employee.Role == Role.Barman)
            {
                orderKitchen = orderService.GetAllBar();
                lblEmployee.Text = " OrderView Bar";
            }
            else if (employee.Role == Role.KitchenStaff)
            {
                orderKitchen = orderService.GetAllKitchen();
                lblEmployee.Text = " OrderView Kitchen";
            }

            return orderKitchen;
        }

        private void ListViewKitchenBar()
        {

            List<Order> orderKitchen = Employee();
            //foreach to display the orderitems, I used the foreach to access TableID
            foreach (Order O in orderKitchen)
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

        private void btnReady_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Do you want to mark the order Ready??",
                               "Confirm Order Status",
                               MessageBoxButtons.YesNo);

            if (ListViewKitch.SelectedItems.Count <= 0)
            {
                MessageBox.Show($"Order is not marked");
                return;
                //if nothing is selected it shows the message
            }
            if(confirmResult == DialogResult.Yes)
            {
                for (int i = 0; i < ListViewKitch.Items.Count; i++)
                {
            //it goes thorugh the list of items in the listview
                    if (ListViewKitch.Items[i].Selected)
                    {
                        //if item is selected it turns the selected item to listview
                        orderService.UpdateOrderReady((OrderItem)ListViewKitch.Items[i].Tag);
                  
                        
                    }
                }
                ListViewKitch.Items.Clear();
                ListViewKitchenBar();
            }
        }

        private void btnPreparing_Click_1(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Do you want to mark the order Ready??",
                               "Confirm Order Status",
                               MessageBoxButtons.YesNo);

            if (ListViewKitch.SelectedItems.Count <= 0)
            {
                MessageBox.Show($"Order is not marked");
                return;
            }

            if (confirmResult == DialogResult.Yes)
            {
                for (int i = 0; i < ListViewKitch.Items.Count; i++)
                {
                    if (ListViewKitch.Items[i].Selected)
                    {
                        orderService.UpdateOrderPreparing((OrderItem)ListViewKitch.Items[i].Tag);
                     
                    }
                }
                ListViewKitch.Items.Clear();
                ListViewKitchenBar();
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