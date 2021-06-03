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
        public TablePage(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            tableServices = new TableServices();
        }
        
        private void TablePage_Load(object sender, EventArgs e)
        {
            lblemployee.Text = $"{employee.Role}: {employee.FullName}";

            while (true)
            {
                tableServices.GetAllTables();
            }
        }

        private void UpdateOrderOfTable(Order order, Label label)
        {
            List<Label> labels = Controls.OfType<Label>().ToList();

            foreach (Label item in labels)
            {
                label.Show();
                // assigns status
            }
        }

        private void AssignLabelStatus(Order order, Label label)
        {
            if (order.Status == OrderStatus.Ready)
            {
                label.Text = "Order of the table is ready to serve";
            }
            else if (order.Status == OrderStatus.Preparing)
            {
                label.Text = "Kitchen is preparing the order";
            }
        }


        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.ShowDialog();
        }
    }
}
