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
        public TableDialog(Table table)
        {
            this.table = table;
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
            FillFormData();
        }

        private void btntakeOrder_Click(object sender, EventArgs e)
        {
            if (table.TableStatus != TableStatus.Occupied)
            {
                tableServices.ChangeTableStatus(table.TableID, (int)TableStatus.Occupied);
            }
            //TakingOrderForm form = new TakingOrderForm();
            //form.ShowDialog();
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
    }
}
