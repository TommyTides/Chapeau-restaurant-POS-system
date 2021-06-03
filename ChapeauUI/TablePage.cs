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
        private List<Button> tableButtons = new List<Button>();
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

            tableButtons.Add(btntable1);
            tableButtons.Add(btntable2);
            tableButtons.Add(btntable3);
            tableButtons.Add(btntable4);
            tableButtons.Add(btntable5);
            tableButtons.Add(btntable6);
            tableButtons.Add(btntable7);
            tableButtons.Add(btntable8);
            tableButtons.Add(btntable9);
            tableButtons.Add(btntable10);

        }

        private void LoadTableData()
        {
            List<Table> tables = tableServices.GetAllTables();

            // set the table to free by default
            for (int i = 0; i < 10; i++)
            {
                ChangeColorByTableStatus(tableButtons[0], TableStatus.Free);
            }


            foreach (Table table in tables)
            {
                switch (table.TableID)
                {
                    case 1:
                        ChangeColorByTableStatus(btntable1, table.TableStatus);
                        lbltable1status.Text = table.OrderStatus;
                        break;
                    case 2:
                        ChangeColorByTableStatus(btntable2, table.TableStatus);
                        lbltable2status.Text = table.OrderStatus;
                        break;
                    case 3:
                        ChangeColorByTableStatus(btntable3, table.TableStatus);
                        lbltable3status.Text = table.OrderStatus;
                        break;
                    case 4:
                        ChangeColorByTableStatus(btntable4, table.TableStatus);
                        lbltable4status.Text = table.OrderStatus;
                        break;
                    case 5:
                        ChangeColorByTableStatus(btntable5, table.TableStatus);
                        lbltable5status.Text = table.OrderStatus;
                        break;
                    case 6:
                        ChangeColorByTableStatus(btntable6, table.TableStatus);
                        lbltable6status.Text = table.OrderStatus;
                        break;
                    case 7:
                        ChangeColorByTableStatus(btntable7, table.TableStatus);
                        lbltable7status.Text = table.OrderStatus;
                        break;
                    case 8:
                        ChangeColorByTableStatus(btntable8, table.TableStatus);
                        lbltable8status.Text = table.OrderStatus;
                        break;
                    case 9:
                        ChangeColorByTableStatus(btntable9, table.TableStatus);
                        lbltable9status.Text = table.OrderStatus;
                        break;
                    case 10:
                        ChangeColorByTableStatus(btntable10, table.TableStatus);
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

        private void Reservation(int tableid)
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
                tableServices.ChangeTableStatus(tableid, (int)TableStatus.Occupied);
            }

        }


        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.ShowDialog();
        }

        private void btntable1_Click(object sender, EventArgs e)
        {
            Reservation(1);
        }
    }
}
