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
        private  OrderItem orderItem; 
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

        //private List<OrderItem> Employee(Employee employee)
        //{
        //    List<OrderItem> orderKitchen;
        //   if (employee.Role == Role.Barman)
        //    {
        //       return orderKitchen = orderService.GetAllKitchen();
        //    }
        //   else if (employee.Role == Role.KitchenStaff)
        //    {
        //     return  orderKitchen = orderService.GetAllKitchen();
        //    }

        //}

        private void ListViewKitchenBar()
        {
            // if login works i can fix this
            //Employee employee = new Employee();
            List<Order> orderKitchen = orderService.GetAllKitchen();
            //if (employee.Role == Role.Barman)
            //{
            //    orderKitchen = orderService.GetAllKitchen();
            //}
            //else if (employee.Role == Role.KitchenStaff)
            //{
            //     orderKitchen = orderService.GetAllKitchen();
            //}

            foreach (Order O in orderKitchen)
            {
                foreach (OrderItem I in O.OrderItem)
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

        private void btnReady_Click_1(object sender, EventArgs e)
        {
            if (ListViewKitch.SelectedItems.Count <= 0)
            {
                MessageBox.Show($"Order is not marked");
            }
            else if (ListViewKitch.Items.Count > 0)
            {
                OrderItem order = ListViewKitch.SelectedItems[0].Tag as OrderItem;
                var confirmResult = MessageBox.Show("Do you want to mark the order ready??",
                                     "Confirm Order Status",
                                     MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    orderService.UpdateOrderReady(order);

                    ListViewKitch.Items.Clear();
                    ListViewKitchenBar();
                }
                else
                {
                    MessageBox.Show($"Order is not marked");
                }
            }
        }

        private void btnPreparing_Click_1(object sender, EventArgs e)
        {
            if (ListViewKitch.SelectedItems.Count <= 0)
            {
                MessageBox.Show($"Order is not marked");
            }
            else if (ListViewKitch.Items.Count > 0)
            {
                OrderItem order = ListViewKitch.SelectedItems[0].Tag as OrderItem;
                var confirmResult = MessageBox.Show("Do you want to mark the order Preparing??",
                                     "Confirm Order Status",
                                     MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    orderService.UpdateOrderPreparing(order);

                    ListViewKitch.Items.Clear();
                    ListViewKitchenBar();
                }
                else
                {
                    MessageBox.Show($"Order is not marked");
                }
            }
        }
    }
}