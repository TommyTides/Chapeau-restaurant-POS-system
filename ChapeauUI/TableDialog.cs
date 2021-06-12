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
    public partial class TableDialog : Form
    {
        Table table;
        TableServices tableServices;
        Employee employee;
        TablePage previousPage;
        public TableDialog(Table table, Employee employee, TablePage previousPage)
        {
            this.table = table;
            this.employee = employee;
            this.previousPage = previousPage;
            tableServices = new TableServices();
            InitializeComponent();

            // check table status and then display appropriate message
            if (table.TableStatus == TableStatus.Free)
            {
                btnReserveTable.Text = "Reserve Table";
            }
            else
            {
                btnReserveTable.Text = "Release Table";
            }
            btnPayment.Enabled = (table.TableStatus == TableStatus.Occupied);
            FillFormData();
        }

        private void btntakeOrder_Click(object sender, EventArgs e)
        {
            if (table.TableStatus != TableStatus.Occupied)
            {
                tableServices.ChangeTableStatus(table.TableID, (int)TableStatus.Occupied);
            }
            this.Hide();
            this.previousPage.Hide();

            PlaceOrderForm form = new PlaceOrderForm(table, employee);
            form.ShowDialog();
            this.Close();
        }

        private void FillFormData()
        {
            lbltablenumber.Text = table.TableID.ToString();
            lbltablestatus.Text = table.TableStatus.ToString();

        }

        private void btnReserveTable_Click(object sender, EventArgs e)
        {
            if (table.TableStatus == TableStatus.Free)
            {
                tableServices.ChangeTableStatus(table.TableID, (int)TableStatus.Reserved);
            }
            else
            {
                tableServices.ChangeTableStatus(table.TableID, (int)TableStatus.Free);
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.previousPage.Hide();
            PaymentForm form = new PaymentForm(table.TableID);
            form.Show();
        }
    }
}
