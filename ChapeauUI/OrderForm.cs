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
            ListViewOrder();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            listViewOrder.Clear();
        }

      

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ListViewOrder()
        {
            OrderService orderService = new OrderService();
            List<Order> orders = orderService.GetAllOrders();

            foreach (Order I in orders)
            {
                ListViewItem li = new ListViewItem(I.order_id.ToString());
                li.SubItems.Add(I.item_code.ToString());
                li.SubItems.Add(I.table_code.ToString());
                li.SubItems.Add(I.quantity.ToString());
                li.SubItems.Add(I.order_time.ToString());
                li.SubItems.Add(I.order_price.ToString());
                li.SubItems.Add(I.order_price.ToString());
                li.SubItems.Add(I.order_price.ToString());
                li.SubItems.Add(I.order_status.ToString());
                li.SubItems.Add(I.employee_code.ToString());
                listViewOrder.Items.Add(li);

            }
        }
    }
}
