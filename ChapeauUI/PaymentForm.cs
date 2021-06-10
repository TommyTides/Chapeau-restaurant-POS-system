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
        TableServices tableService;
        Order Order;
        Employee Employee;

        // consturctor used for initializing every new object
        public PaymentForm()
        {
            InitializeComponent();

            orderService = new OrderService();
            tableService = new TableServices();
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

        // this method displays the tables that are yet to be paid (when the payment form loads)
        private void ShowPayments()
        {
            List<Order> orders = orderService.GetOrdersToPay();

            // get table# for each order
            foreach (Order order in orders)
            {
                cmbTable.Items.Add(order.Table.TableID);
                cmbTable.Tag = order;
            }
        }

        private void cmdTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            // fill the listview with the order items and make a way to distinguish alcoholic from non alcoholic drinks (VAT)

            // this.Order = cmbTable.Tag as Order;

            //gets the tableID based on the GetOrderForTableByTableID method and parses it
            int tableID = Int32.Parse(cmbTable.Text);
            // gets the order based on the tableID
            this.Order = orderService.GetOrderForTableByTableID(tableID);

            // gets the total price for every item times the quantity and stores it into Order.Total
            // VAT logic is stores in the Order class as a method/function and called here and stored in VATTotal
            Order.Total = Order.CalculateTotalOrderPriceByItems();
            Order.VATTotal = Order.CalculateVATbyItems();


            //Order order = paymentService.GetOrderForTable();
            //Order.OrderItem = paymentService.GetOrderItems()

            //clear listview before filling it
            lstViewItems.Items.Clear();
            foreach (OrderItem orderItem in Order.OrderItems) // fill the listview with ordered items
            {
                ListViewItem item = new ListViewItem(Order.OrderID.ToString());
                item.SubItems.Add(orderItem.menuItem.item_name);
                item.SubItems.Add(orderItem.Quantity.ToString());
                item.SubItems.Add(orderItem.TotalPrice.ToString("€ 0.00"));
                item.Tag = orderItem;

                lstViewItems.Items.Add(item);
            }
            cmbMethod.DataSource = (Enum.GetValues(typeof(PaymentMethod)));

            // storing values from the database into the labels
            lblTableNumber.Text = this.Order.Table.TableID.ToString();
            lblBill.Text = this.Order.Total.ToString("€ 0.00");
            lblWaiter.Text = this.Order.Employee.employeeID.ToString();

            // if the amount entered in the tip text box is greater than 0
            // then it adds the value to the Tip property
            if (Order.Tip > 0)
            {
                txtTip.Text = this.Order.Tip.ToString("0.00");
                chbTip.Checked = true;
            }

            lblTotalVAT.Text = Order.VATTotal.ToString("€ 0.00");
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
            // if feedback textbox is empty, then do not put feedback to order
            if (!String.IsNullOrWhiteSpace(txtFeedback.Text))
            {
                Order.Feedback = txtFeedback.Text;
            }

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

            // a boolean to check whether the payment has been paid for
            bool isPaid = orderService.OrderPayment(Order);

            // if the payment is paid for, it shows a message that it has been successfull
            // as well as updates the order status. otherwise gives an error message.
            if (isPaid == true)
            {
                orderService.UpdateOrderStatus(Order);
                Order.Table.TableStatus = TableStatus.Free;
                tableService.ChangeTableStatusAfterPayment(Order.Table);
                MessageBox.Show("Order has been paid successfully!");
                this.Close();
                new TablePage(Order.Employee).Show();
            }
            else
            {
                MessageBox.Show("An error has occured during the payment process.");
            }
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
                    txtTip.Text = "0";

                // after inserting a tip, update the price and store it into the TotalAmount
                double newTip = double.Parse(txtTip.Text);
                Order.Tip = newTip;
                lblTotalAmount.Text = (Order.Total + Order.VATTotal + Order.Tip).ToString("€ 0.00");
            }
            catch { };
        }
    }
}
