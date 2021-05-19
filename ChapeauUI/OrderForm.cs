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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listViewOrder.Clear();
        }

        private void listViewOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderService orderService = new OrderService();
            List<Order> orders = orderService.GetAllOrders();

            foreach (var Item in orders)
            {
                 ListViewItem li = new ListViewItem(Item.order_id.ToString());
                li.SubItems.Add(Item.item_code.ToString());
                li.SubItems.Add(Item.table_code.ToString());
                li.SubItems.Add(Item.quantity.ToString());
                li.SubItems.Add(Item.order_time.ToString());
                li.SubItems.Add(Item.order_price.ToString());
                li.SubItems.Add(Item.order_price.ToString());
                li.SubItems.Add(Item.order_price.ToString());
                li.SubItems.Add(Item.order_status.ToString());
                li.SubItems.Add(Item.employee_code.ToString());
                listViewOrder.Items.Add(li);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
