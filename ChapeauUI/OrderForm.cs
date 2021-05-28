using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauLogic;
using ChapeauModel;

namespace ChapeauUI
{
    public partial class OrderForm : Form
    {
        OrderService orderService;
        public OrderForm()
        {
            InitializeComponent();
           orderService = new OrderService();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 2000, WinAPI.BLEND);
          
            ListViewKitchen();
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

        private void ListViewKitchen()
        {
            
            //Employee employee = EmployeeService.GetEmployeeByCode(int.Parse(txtlogincode.Text));
            List<OrderItem> orderKitchen = orderService.GetAllKitchen();
          
            foreach (OrderItem I in orderKitchen)
            {
                ListViewItem li = new ListViewItem(I.menuItem.menu_type.ToString());
                li.SubItems.Add(I.menuItem.item_name);
                li.SubItems.Add(I.Quantity.ToString());
                li.SubItems.Add(I.OrderTime.ToString());
                li.SubItems.Add(I.Status.ToString());
                li.SubItems.Add(I.Comment.ToString());
           
                ListViewKitch.Items.Add(li);
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //listViewOrder.Clear();
        }

        //private void btnReady_Click(object sender, EventArgs e)
        //{
            
        //    if (ListViewKitch.Items.Count > 0) 
        //    {
        //        OrderItem order = ListViewKitch.SelectedItems[0].Tag as OrderItem;
        //        MessageBox.Show($"Order is marked 'ready' Click refresh ");
        //        orderService.UpdateOrderStatus(order);

        //    }
              
        //}


    }
}
