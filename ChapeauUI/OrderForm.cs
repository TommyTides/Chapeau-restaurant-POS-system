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
        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 2000, WinAPI.BLEND);
          

            //ListViewOrder();
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

        //private void ListViewOrder()
        //{
        //    OrderService orderService = new OrderService();
        //    List<Order> orders = orderService.GetAllOrders();

        //    foreach (Order I in orders)
        //    {
        //        ListViewItem li = new ListViewItem(I.order_id.ToString());
        //        li.SubItems.Add(I.item_code.ToString());
        //        li.SubItems.Add(I.table_code.ToString());
        //        li.SubItems.Add(I.quantity.ToString());
        //        li.SubItems.Add(I.order_time.ToString());
        //        li.SubItems.Add(I.order_price.ToString());
        //        li.SubItems.Add(I.order_price.ToString());
        //        li.SubItems.Add(I.order_price.ToString());
        //        li.SubItems.Add(I.order_status.ToString());
        //        li.SubItems.Add(I.employee_code.ToString());
        //        listViewOrder.Items.Add(li);

        //    }
        //}

        private void ListViewKitchen()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderKitchen = orderService.GetAllKitchen();
            //List<Order> orderBar = orderService.GetAllBar();
            foreach (OrderItem I in orderKitchen)
            {
                ListViewItem li = new ListViewItem(I.menuItem.menu_type.ToString());
                li.SubItems.Add(I.menuItem.item_name);
                li.SubItems.Add(I.Quantity.ToString());
                li.SubItems.Add(I.OrderTime.ToString());
                li.SubItems.Add(I.Status.ToString());
                listViewKitch.Items.Add(li);

            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //listViewOrder.Clear();
        }

        private void listViewKitch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
