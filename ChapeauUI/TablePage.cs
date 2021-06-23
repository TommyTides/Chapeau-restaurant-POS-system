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
        OrderService orderService;

        private Dictionary<string, string> tablestatustext; // first part recieve the status from db, second part show text.
        public TablePage(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            tableServices = new TableServices();
            orderService = new OrderService();
            tablestatustext = new Dictionary<string, string>();
            tablestatustext.Add("Pending", "Order sent to kitchen");
            tablestatustext.Add("Preparing", "Kitchen preparing order");
            tablestatustext.Add("Ready", "Order is ready to serve");
            tablestatustext.Add("Served", "Order is served to the table");

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
                        DisplayOrderStatus(lbltable1status, table.TableStatus, table.CurrentOrderInfo);
                        break;
                    case 2:
                        ChangeColorByTableStatus(rndbutton2, table.TableStatus);
                        DisplayOrderStatus(lbltable2status, table.TableStatus, table.CurrentOrderInfo);
                        break;
                    case 3:
                        ChangeColorByTableStatus(rndbutton3, table.TableStatus);                        
                        DisplayOrderStatus(lbltable3status, table.TableStatus, table.CurrentOrderInfo);
                        break;
                    case 4:
                        ChangeColorByTableStatus(rndbutton4, table.TableStatus);
                        DisplayOrderStatus(lbltable4status, table.TableStatus, table.CurrentOrderInfo);
                        break;
                    case 5:
                        ChangeColorByTableStatus(rndbutton5, table.TableStatus);
                        DisplayOrderStatus(lbltable5status, table.TableStatus, table.CurrentOrderInfo);
                        break;
                    case 6:
                        ChangeColorByTableStatus(rndbutton6, table.TableStatus);
                        DisplayOrderStatus(lbltable6status, table.TableStatus, table.CurrentOrderInfo);
                        break;
                    case 7:
                        ChangeColorByTableStatus(rndbutton7, table.TableStatus);
                        DisplayOrderStatus(lbltable7status, table.TableStatus, table.CurrentOrderInfo);
                        break;
                    case 8:
                        ChangeColorByTableStatus(rndbutton8, table.TableStatus);
                        DisplayOrderStatus(lbltable8status, table.TableStatus, table.CurrentOrderInfo);
                        break;
                    case 9:
                        ChangeColorByTableStatus(rndbuttons9, table.TableStatus);
                        DisplayOrderStatus(lbltable9status, table.TableStatus, table.CurrentOrderInfo);
                        break;
                    case 10:
                        ChangeColorByTableStatus(rndbutton10, table.TableStatus);
                        DisplayOrderStatus(lbltable10status, table.TableStatus, table.CurrentOrderInfo);
                        lbltable10status.Text = table.CurrentOrderInfo;
                        break;
                }
            }
        }
        private void DisplayOrderStatus(Label label, TableStatus status, string orderstatus)
        {
            if (status == TableStatus.Free || status == TableStatus.Reserved)
            {
                label.Text = "";
            }
            else
            {
                label.Text = orderstatus == null || orderstatus == ""
                ? "Order not taken" : tablestatustext[orderstatus];
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
