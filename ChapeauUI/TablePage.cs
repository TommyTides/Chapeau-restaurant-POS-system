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
        Dictionary<int, Table> tables;

        private Dictionary<string, string> tablestatustext; // first part recieve the status from db, second part show text.
        public TablePage(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            tableServices = new TableServices();
            tablestatustext = new Dictionary<string, string>();
            tablestatustext.Add("Pending", "Order not taken");
            tablestatustext.Add("Preparing", "Kitchen/Bar is preparing the order");
            tablestatustext.Add("Ready", "Order is ready to serve");
            tablestatustext.Add("Served", "Order is served to the table");
            tablestatustext.Add("", "");

        }
        
        private void TablePage_Load(object sender, EventArgs e)
        {
            lblemployee.Text = $"{employee.Role}: {employee.FullName}";

            Timer timer = new Timer();
            timer.Tick += new EventHandler(LoadTableData);
            timer.Interval = 1000;
            timer.Start();
        }

        private void LoadTableData(Object sender, EventArgs e)
        {
            tables = tableServices.GetAllTables();

            foreach (KeyValuePair<int, Table> keyValuePair in tables)
            {
                Table table = keyValuePair.Value;

                switch (table.TableID)
                {
                    case 1:
                        ChangeColorByTableStatus(rndbutton1, table.TableStatus);
                        //if (table.TableStatus == TableStatus.Free)
                        //{
                        //    lbltable1status.Text = "";
                        //}
                        //lbltable1status.Text = tablestatustext[table.CurrentOrderInfo];
                        lbltable1status.Text = table.CurrentOrderInfo;
                        break;
                    case 2:
                        ChangeColorByTableStatus(rndbutton2, table.TableStatus);
                        //if (table.TableStatus == TableStatus.Free)
                        //{
                        //    lbltable2status.Text = "";
                        //}
                        //lbltable2status.Text = tablestatustext[table.CurrentOrderInfo];
                        lbltable2status.Text = table.CurrentOrderInfo;
                        break;
                    case 3:
                        ChangeColorByTableStatus(rndbutton3, table.TableStatus);
                        //if (table.TableStatus == TableStatus.Free)
                        //{
                        //    lbltable3status.Text = "";
                        //}
                        //lbltable3status.Text = tablestatustext[table.CurrentOrderInfo];
                        lbltable3status.Text = table.CurrentOrderInfo;
                        break;
                    case 4:
                        ChangeColorByTableStatus(rndbutton4, table.TableStatus);
                        //if (table.TableStatus == TableStatus.Free)
                        //{
                        //    lbltable4status.Text = "";
                        //}
                        //lbltable4status.Text = tablestatustext[table.CurrentOrderInfo];
                        lbltable4status.Text = table.CurrentOrderInfo;
                        break;
                    case 5:
                        ChangeColorByTableStatus(rndbutton5, table.TableStatus);
                        //if (table.TableStatus == TableStatus.Free)
                        //{
                        //    lbltable5status.Text = "";
                        //}
                        //lbltable5status.Text = tablestatustext[table.CurrentOrderInfo];
                        lbltable5status.Text = table.CurrentOrderInfo;
                        break;
                    case 6:
                        ChangeColorByTableStatus(rndbutton6, table.TableStatus);
                        //if (table.TableStatus == TableStatus.Free)
                        //{
                        //    lbltable6status.Text = "";
                        //}
                        //lbltable6status.Text = tablestatustext[table.CurrentOrderInfo];
                        lbltable6status.Text = table.CurrentOrderInfo;
                        break;
                    case 7:
                        ChangeColorByTableStatus(rndbutton7, table.TableStatus);
                        //if (table.TableStatus == TableStatus.Free)
                        //{
                        //    lbltable7status.Text = "";
                        //}
                        //lbltable7status.Text = tablestatustext[table.CurrentOrderInfo];
                        lbltable7status.Text = table.CurrentOrderInfo;
                        break;
                    case 8:
                        ChangeColorByTableStatus(rndbutton8, table.TableStatus);
                        //if (table.TableStatus == TableStatus.Free)
                        //{
                        //    lbltable8status.Text = "";
                        //}
                        //else
                        //{
                        //    lbltable8status.Text = tablestatustext[table.CurrentOrderInfo];
                        //}
                        lbltable8status.Text = table.CurrentOrderInfo;
                        break;
                    case 9:
                        ChangeColorByTableStatus(rndbuttons9, table.TableStatus);
                        //if (table.TableStatus == TableStatus.Free)
                        //{
                        //    lbltable9status.Text = "";
                        //}
                        //else
                        //{
                        //    lbltable9status.Text = tablestatustext[table.CurrentOrderInfo];
                        //}
                        lbltable9status.Text = table.CurrentOrderInfo;
                        break;
                    case 10:
                        ChangeColorByTableStatus(rndbutton10, table.TableStatus);
                        //lbltable10status.Text = tablestatustext[table.CurrentOrderInfo];
                        lbltable10status.Text = table.CurrentOrderInfo;
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

            TableDialog tableDialog = new TableDialog(table, employee, this);
            tableDialog.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm form = new LoginForm();
            form.Show();
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

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
