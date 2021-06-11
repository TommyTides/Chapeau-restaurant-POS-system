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

        public OrderForm()
        {
            InitializeComponent();
            orderService = new OrderService();
            employeeService = new EmployeeService();
            orderItem = new OrderItem();
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

        //private List<Order> Employee()
        //{
        //    List<Order> orderKitchen = null;
        //    if (employee.Role == Role.Barman)
        //    {
        //         orderKitchen = orderService.GetAllKitchen();
        //lblEmployee.Text = " OrderView Kitchen";
        //    }
        //    else if (employee.Role == Role.KitchenStaff)
        //    {
        //        orderKitchen = orderService.GetAllBar();
        //lblEmployee.Text = " OrderView Bar";
        //    }

        //    return orderKitchen;
        //}

        private void ListViewKitchenBar()
        {

            List<Order> orderKitchen = orderService.GetAllKitchen();



            foreach (Order O in orderKitchen)
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
            }
            if(confirmResult == DialogResult.Yes)
            {
                for (int i = 0; i < ListViewKitch.Items.Count; i++)
                {
                    ListViewKitch.SelectedItems[0].ForeColor = Color.Green;
                   

                    if (ListViewKitch.Items[i].Selected)
                    {
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