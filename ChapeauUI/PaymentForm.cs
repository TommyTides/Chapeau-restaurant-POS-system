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
        OrderService orderService;
        Order Order;
        Employee Employee;

        public PaymentForm()
        {
            InitializeComponent();

            orderService = new OrderService();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            txtTip.Enabled = false;
        }





        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowPayments()
        {
            
        }

        private void lstViewItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstViewItems.SelectedItems.Count <= 0)
                return;

            OrderItem orderItem = lstViewItems.SelectedItems[0].Tag as OrderItem;
            lblComment.Text = orderItem.menuItem.item_name;
        }

        private void lstViewPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChapeauLogic.PaymentService paymentService = new PaymentService();
            //List<Payment> paymentList = paymentService.GetAllPayments();

            //foreach (Payment p in paymentList)
            //{
            //    ListViewItem li = new ListViewItem(p.PaymentID.ToString());
            //    li.SubItems.Add(p.OrderitemCode.ToString());
            //    li.SubItems.Add(p.paymentStatus.ToString());
            //    li.SubItems.Add(p.paymentMethod.ToString());
            //    li.SubItems.Add(p.PaymentDate.ToShortDateString());
            //    lstViewPayment.Items.Add(li);
            //}    
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

            this.Order = cmbTable.Tag as Order;
            this.Order.Employee = Employee;

            lblTableNumber.Text = Order.Table.TableID.ToString();
            lblPayment.Text = Order.Total.ToString();

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

            foreach(OrderItem item in Order.OrderItem)
            {
                if (item.menuItem.item_type == MenuSubCategory.alcohol)
                {
                    VAT += item.menuItem.item_price * item.Quantity * 0.21;
                }

                else
                {
                    VAT += item.menuItem.item_price * item.Quantity * 0.06;
                }
            }
            Order.VATTotal = VAT;
            lblTotalVAT.Text = VAT.ToString("0.00");
            lblTotalAmount.Text = (Order.Total + Order.VATTotal + Order.Tip).ToString("0.00");
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
        }
    }
}
