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
        private int TableID;

        // constructor used when a tableID is passed from the tableoverview with the right table to pay
        public PaymentForm(int tableID)
        {
            InitializeComponent();

            TableID = tableID;
            orderService = new OrderService();
            tableService = new TableServices();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            LoadOrderDetails();

            // at the start of the form, the tip checkbox is disabled
            txtTip.Enabled = false;
            txtRoundUp.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // this method displays the tables that are yet to be paid (when the payment form loads)
        private void LoadOrderDetails()
        {
            // gets the order based on the tableID from the database and stores it into the order field
            this.Order = orderService.GetOrderForTableByTableID(TableID);

            // gets the total price for every item times the quantity and stores it into Order.Total
            // VAT logic is stores in the Order class as a method/function and called here and stored in VATTotal
            Order.Total = Order.CalculateTotalOrderPriceByItems();
            Order.VATTotal = Order.CalculateVATbyItems();

            //clear listview before filling it
            lstViewItems.Items.Clear();
            foreach (OrderItem orderItem in Order.OrderItems) // fill the listview with ordered items
            {
                ListViewItem item = new ListViewItem(Order.OrderID.ToString());
                item.SubItems.Add(orderItem.menuItem.item_name);
                item.SubItems.Add(orderItem.Quantity.ToString());
                item.SubItems.Add(orderItem.TotalPrice.ToString("€ 0.00"));
                lstViewItems.Items.Add(item);
            }
            // searching the enumeration for the types of values that are stored within and gets them 
            cmbMethod.DataSource = (Enum.GetValues(typeof(PaymentMethod)));

            // storing values from the database into the labels
            lblTableNumber.Text = this.Order.Table.TableID.ToString();
            lblBill.Text = (Order.Total + Order.VATTotal).ToString("€ 0.00");
            lblWaiter.Text = this.Order.Employee.EmployeeID.ToString();

            // if a user decides to tip beforehand the tip can be written in the database before the payment is handed out
            if (Order.Tip > 0)
            {
                txtTip.Text = this.Order.Tip.ToString("0.00");
                txtRoundUp.Text = this.Order.Tip.ToString("0.00");
                chbTip.Checked = true;
            }

            //lblTotalVAT.Text = Order.VATTotal.ToString("€ 0.00");

            // calculating the total price by adding the total order price + the total vat + the tip
            lblTotalAmount.Text = (Order.Total + Order.VATTotal + Order.Tip).ToString("€ 0.00");
        }

        private void chbTip_CheckedChanged(object sender, EventArgs e)
        {
            // if the checkbox is ticked, then the textbox for the tip gets enabled and you can fill out the amount, otherwise not.
            if (chbTip.Checked)
            {
                txtTip.Enabled = true;
                txtRoundUp.Enabled = true;
            }

            else
            {
                txtTip.Enabled = false;
                txtTip.Text = "0";

                txtRoundUp.Enabled = false;
                txtRoundUp.Text = "";
            }
        }

        private void btnFinalizePayment_Click(object sender, EventArgs e)
        {
            // if the textbox is not null or empty, add whatever is in it to the value Order.Feedback
            if (!String.IsNullOrWhiteSpace(txtFeedback.Text))
            {
                Order.Feedback = txtFeedback.Text;
            }

            double tip = 0;
            double roundUpTip = 0;
            if (chbTip.Checked)
            {
                // if the tip if empty, it's automatically assigned the value 0
                if (txtTip.Text.Trim() == "")
                    txtTip.Text = "0";

                // the tip gets converted into a double
                // only digits, no letters or weird things
                // tip is the output parameter which gets its value by assigment inside the Parse function
                bool validTip = double.TryParse(txtTip.Text, out tip);

                // checks if the tip is ticked and whether its not valid -> displays message that its not valid
                // tip only takes into account anything that is a digit eg. 1 or 1,5
                if (!validTip)
                {
                    MessageBox.Show("Please enter a valid amount for the tip");
                    return;
                }
            }
            // after inserting a tip, update the price and store it into the TotalAmount
            Order.Tip = tip;

            lblTotalAmount.Text = (Order.Total + Order.VATTotal + Order.Tip).ToString("€ 0.00");

            Order.paymentMethod = (PaymentMethod)cmbMethod.SelectedItem;

            // a boolean to check whether the payment has been paid for
            bool isPaid = orderService.ExecuteOrderPayment(Order);

            // if the payment is paid for, it shows a message that it has been successfull
            // as well as updates the order status. otherwise gives an error message.
            if (isPaid == true)
            {
                tableService.ChangeTableStatus(Order.Table.TableID,(int)TableStatus.Free);  // TableStatus.Free = 1
                MessageBox.Show("Order has been paid successfully!");
                this.Close();

                TablePage tablePage = new TablePage(Order.Employee);
                tablePage.ShowDialog();
            }
            else
            {
                MessageBox.Show("An error has occured during the payment process.");
            }
        }

        bool bDisableOnTextChanged = false;
        private void txtTip_TextChanged(object sender, EventArgs e)
        {
            if (bDisableOnTextChanged)
                return;
            try
            {
                bDisableOnTextChanged = true;
                double tip = 0;
                if (chbTip.Checked)
                {
                    // the tip gets converted into a double
                    // only digits, no letters or weird things
                    // tip is the output parameter which gets its value by assigment inside the Parse function
                    bool validTip = double.TryParse(txtTip.Text, out tip);
                    if (!validTip)
                        return;
                }
                lblTotalAmount.Text = (Order.Total + Order.VATTotal + tip).ToString("€ 0.00");
                string totalAmountToPay = (Order.Total + Order.VATTotal + tip).ToString("0.00");
                txtRoundUp.Text = totalAmountToPay;
            }
            finally
            {
                bDisableOnTextChanged = false;
            }
        }

        private void txtRoundUp_TextChanged(object sender, EventArgs e)
        {
            if (bDisableOnTextChanged)
                return;
            try
            {
                bDisableOnTextChanged = true;
                double roundUp = 0;
                if (chbTip.Checked)
                {
                    bool validRoundUp = double.TryParse(txtRoundUp.Text, out roundUp);
                    if (!validRoundUp)
                        return;
                }
                if (roundUp < Order.Total + Order.VATTotal)
                    return;
                lblTotalAmount.Text = roundUp.ToString("€ 0.00");
                string strTip = (roundUp - Order.Total - Order.VATTotal).ToString("0.00");
                txtTip.Text = strTip;
            }
            finally
            {
                bDisableOnTextChanged = false;
            }
        }
    }
}
