using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauModel;
using ChapeauLogic;

namespace ChapeauUI
{
    public partial class PaymentForm : Form
    {
        PaymentService paymentService;
        OrderService orderService;
        Order Order;
        Employee Employee;

        public PaymentForm()
        {
            InitializeComponent();

            orderService = new OrderService();
            paymentService = new PaymentService();
            Employee = new Employee();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            ShowPayments();

            // at the start of the form, the tip checkbox is disabled
            txtTip.Enabled = false;
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowPayments()
        {
            List<Order> orders = paymentService.GetOrdersToPay();

            // get table# for each order
            foreach(Order order in orders)
            {
                cmbTable.Items.Add(order.Table.TableID);
                cmbTable.Tag = order;
            }
        }

        private void lstViewItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //check whether the list is empty, if so return, if not, continue
            if (lstViewItems.SelectedItems.Count <= 0)
                return;

            OrderItem orderItem = lstViewItems.SelectedItems[0].Tag as OrderItem;
            // Set the label as the name of the menu item 
            lblComment.Text = orderItem.menuItem.item_name;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string comment;

            // if the viewlist is empty or if the comment is empty then return
            if (lstViewItems.SelectedItems.Count <= 0 || String.IsNullOrWhiteSpace(txtComment.Text))
                return;

            OrderItem orderItem = lstViewItems.SelectedItems[0].Tag as OrderItem;

            // if the comment is not empty, you're able to add a comment, otherwise a message displays that you havent added a comment
            // the comment gets stored in the object and gets sent through with the message when the button is clicked.
            orderItem.Comment = txtComment.Text;

            if (!String.IsNullOrWhiteSpace(txtComment.Text))
                comment = txtComment.Text;
            else
                comment = "There was no comment added";

            orderItem.Comment = comment;

            MessageBox.Show("Your comment has been added");
        }

        private void cmdTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            // fill the listview with the order items and make a way to distinguish alcoholic from non alcoholic drinks (VAT)
            double VAT = 0;

            // this.Order = cmbTable.Tag as Order;

            //gets the tableID based on the GetOrderForTableByTableID method and parses it
            int tableID=Int32.Parse(cmbTable.Text);
            this.Order = paymentService.GetOrderForTableByTableID(tableID);


            //Order order = paymentService.GetOrderForTable();
            //Order.OrderItem = paymentService.GetOrderItems()

            lstViewItems.Items.Clear();
            foreach(OrderItem orderItem in Order.OrderItem) // fill the listview with ordered items
            {
                ListViewItem item = new ListViewItem(Order.OrderID.ToString());
                item.SubItems.Add(orderItem.menuItem.item_name);
                item.SubItems.Add(orderItem.Quantity.ToString());
                item.SubItems.Add(orderItem.TotalPrice.ToString());
                item.Tag = orderItem;

                lstViewItems.Items.Add(item);
            }
            cmbMethod.DataSource = (Enum.GetValues(typeof(PaymentMethod)));

            lblTableNumber.Text = this.Order.Table.TableID.ToString();
            lblBill.Text = this.Order.Total.ToString();
            lblWaiter.Text = this.Order.Employee.employeeID.ToString();

            if(Order.Tip>0)
            {
                txtTip.Text = this.Order.Tip.ToString("0.00");
                chbTip.Checked = true;
            }

            foreach (OrderItem orderItem in Order.OrderItem)
            {
                if (orderItem.menuItem.item_type == MenuSubCategory.alcohol)
                {
                    VAT += orderItem.menuItem.item_price * orderItem.Quantity * 0.21;
                }

                else
                {
                    VAT += orderItem.menuItem.item_price * orderItem.Quantity * 0.06;
                }
            }
            // storing VAT (calculated) into VATTOTAL
            Order.VATTotal = VAT;
            lblTotalVAT.Text = VAT.ToString("€ 0.00");
            // calculating the total price by adding the total order price + the total vat + the tip
            lblTotalAmount.Text = (Order.Total + Order.VATTotal + Order.Tip).ToString("€ 0.00");
           // Order.Feedback = txtComment.Text;

        }

        private void chbTip_CheckedChanged(object sender, EventArgs e)
        {
            // if the checkbox is ticked, then the textbox for the tip gets enabled and you can fill out the amount, otherwise not.
            if (chbTip.Checked)
            {
                txtTip.Enabled = true;
            }

            else
            {
                txtTip.Enabled = false;
                txtTip.Text = "0";
            }
        }

        private void btnFinalizePayment_Click(object sender, EventArgs e)
        {
            double tip = 0;

            // the tip gets converted into a double
            bool validTip = double.TryParse(txtTip.Text, out tip);

            // checks if the tip is ticked and whether its not valid -> displays message that its not valid
            if (chbTip.Checked && !validTip)
            {
                MessageBox.Show("Please enter a valid amount for the tip");
            }

            Order.paymentMethod = (PaymentMethod)cmbMethod.SelectedItem;
            Order.Tip = tip;

            paymentService.OrderPayment(Order);
            paymentService.UpdateOrderStatus(Order);
            MessageBox.Show("Order was successfully paid!");
        }

        private void cmbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTip_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // if the tip if empty, it's automatically assigned the value 0
                if (txtTip.Text.Trim() == "")
                    txtTip.Text="0";
                double newTip = double.Parse(txtTip.Text);
                Order.Tip = newTip;
                lblTotalAmount.Text = (Order.Total + Order.VATTotal + Order.Tip).ToString("€ 0.00");
            }
            catch { };
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
