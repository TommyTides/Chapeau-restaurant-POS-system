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
        Order orderPay;
        Employee employee;

        public PaymentForm(Employee employee_)
        {
            InitializeComponent();

            orderService = new OrderService();
            employee = employee_;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 2000, WinAPI.BLEND);
            // set the starting point for the tip at nothing
            txtTip.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowPayments()
        {
            // Load all payments for orders here
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
    }
}
