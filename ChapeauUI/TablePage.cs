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
    public partial class TablePage : Form
    {
        private Employee employee;
        private TableServices tableServices;
        //private List<Button> tableButtons = new List<Button>();
        Dictionary<int, Table> tables;
        public TablePage(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            tableServices = new TableServices();
        }
        
        private void TablePage_Load(object sender, EventArgs e)
        {
            lblemployee.Text = $"{employee.Role}: {employee.FullName}";

            LoadTableData();

            //tableButtons.Add(btntable1);
            //tableButtons.Add(btntable2);
            //tableButtons.Add(btntable3);
            //tableButtons.Add(btntable4);
            //tableButtons.Add(btntable5);
            //tableButtons.Add(btntable6);
            //tableButtons.Add(btntable7);
            //tableButtons.Add(btntable8);
            //tableButtons.Add(btntable9);
            //tableButtons.Add(btntable10);

        }

        private void LoadTableData()
        {
            tables = tableServices.GetAllTables();

            // set the table to free by default
            //for (int i = 0; i <= 10; i++)
            //{
            //    ChangeColorByTableStatus(tableButtons[0], TableStatus.Free);
            //}


            foreach (KeyValuePair<int, Table> keyValuePair in tables)
            {
                Table table = keyValuePair.Value;

                switch (table.TableID)
                {
                    case 1:
                        ChangeColorByTableStatus(rndbutton1, table.TableStatus);
                        lbltable1status.Text = table.OrderStatus;
                        break;
                    case 2:
                        ChangeColorByTableStatus(rndbutton2, table.TableStatus);
                        lbltable2status.Text = table.OrderStatus;
                        break;
                    case 3:
                        ChangeColorByTableStatus(rndbutton3, table.TableStatus);
                        lbltable3status.Text = table.OrderStatus;
                        break;
                    case 4:
                        ChangeColorByTableStatus(rndbutton4, table.TableStatus);
                        lbltable4status.Text = table.OrderStatus;
                        break;
                    case 5:
                        ChangeColorByTableStatus(rndbutton5, table.TableStatus);
                        lbltable5status.Text = table.OrderStatus;
                        break;
                    case 6:
                        ChangeColorByTableStatus(rndbutton6, table.TableStatus);
                        lbltable6status.Text = table.OrderStatus;
                        break;
                    case 7:
                        ChangeColorByTableStatus(rndbutton7, table.TableStatus);
                        lbltable7status.Text = table.OrderStatus;
                        break;
                    case 8:
                        ChangeColorByTableStatus(rndbutton8, table.TableStatus);
                        lbltable8status.Text = table.OrderStatus;
                        break;
                    case 9:
                        ChangeColorByTableStatus(rndbuttons9, table.TableStatus);
                        lbltable9status.Text = table.OrderStatus;
                        break;
                    case 10:
                        ChangeColorByTableStatus(rndbutton10, table.TableStatus);
                        lbltable10status.Text = table.OrderStatus;
                        break;
                }
            }
        }

        private void ChangeColorByTableStatus(Button buttonTable, TableStatus? tableStatus)
        {
            switch (tableStatus)
            {
                case TableStatus.Free:
                    buttonTable.BackColor = Color.Green;
                    break;
                case TableStatus.Occupied:
                    buttonTable.BackColor = Color.Red;
                    break;
                case TableStatus.Reserved:
                    buttonTable.BackColor = Color.Cyan;
                    break;
                default:
                    buttonTable.BackColor = Color.Green;
                    break;
            }
        }

        private void TableStatusChangeOnClick(int tableid)
        {
            Table table = tables[tableid];

            if (table.TableStatus == TableStatus.Free)
            {
                string message = "Do you want to reserve this table?, select No to occupy the table";
                string caption = "Table reservation";
                MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, caption, messageBoxButtons);

                if (result == DialogResult.Yes)
                {
                    tableServices.ChangeTableStatus(tableid, (int)TableStatus.Reserved);
                }

                else if (result == DialogResult.No)
                {
                    TakeOrder(tableid);
                    tableServices.ChangeTableStatus(tableid, (int)TableStatus.Occupied);
                }
            }


            else if (table.TableStatus == TableStatus.Occupied)
            {
                string message = "Finish ordering?";
                string caption = "Check customer order";

                MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;

                DialogResult result = MessageBox.Show(message, caption, messageBoxButtons);

                if (result == DialogResult.Yes)
                {
                    PaymentForm paymentForm = new PaymentForm();
                    paymentForm.ShowDialog();
                }
            }

            else if (table.TableStatus == TableStatus.Reserved)
            {
                TakeOrder(tableid);
            }
        }

        private void TakeOrder(int tableid)
        {
            string message = "Would you like to place order for this table";
            string caption = "Start ordering";

            MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
            DialogResult result1 = MessageBox.Show(message, caption, messageBoxButtons);

            if (result1 == DialogResult.Yes)
            {
                PlaceOrderForm placeOrderForm = new PlaceOrderForm();
                placeOrderForm.ShowDialog();
            }
        }



        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.ShowDialog();
        }

        private void btntable1_Click(object sender, EventArgs e)
        {
            TableStatusChangeOnClick(1);
        }

        private void btntable2_Click(object sender, EventArgs e)
        {
            TableStatusChangeOnClick(2);
        }

        private void btntable3_Click(object sender, EventArgs e)
        {
            TableStatusChangeOnClick(3);
        }

        private void btntable4_Click(object sender, EventArgs e)
        {
            TableStatusChangeOnClick(4);
        }

        private void btntable5_Click(object sender, EventArgs e)
        {
            TableStatusChangeOnClick(5);
        }

        private void btntable6_Click(object sender, EventArgs e)
        {
            TableStatusChangeOnClick(6);
        }

        private void btntable7_Click(object sender, EventArgs e)
        {
            TableStatusChangeOnClick(7);
        }

        private void btntable8_Click(object sender, EventArgs e)
        {
            TableStatusChangeOnClick(8);
        }

        private void btntable9_Click(object sender, EventArgs e)
        {
            TableStatusChangeOnClick(9);
        }

        private void btntable10_Click(object sender, EventArgs e)
        {
            TableStatusChangeOnClick(10);
        }
    }
}
