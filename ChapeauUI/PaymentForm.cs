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
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 2000, WinAPI.BLEND);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lstViewItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstViewItems.SelectedItems.Count <= 0)
                return;

            Order order = lstViewItems.SelectedItems[0].Tag as Order;
        }

        private void lstViewPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaymentService paymentService = new PaymentService();
            List<Payment> paymentList = paymentService.GetAllPayments();

            foreach (Payment p in paymentList)
            {
                ListViewItem li = new ListViewItem(p.PaymentID.ToString());
                li.SubItems.Add(p.OrderitemCode.ToString());
                li.SubItems.Add(p.paymentStatus.ToString());
                li.SubItems.Add(p.paymentMethod.ToString());
                li.SubItems.Add(p.PaymentDate.ToShortDateString());
                lstViewPayment.Items.Add(li);
            }    
        }
    }
}
