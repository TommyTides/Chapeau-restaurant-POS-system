using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MenuItem = ChapeauModel.MenuItem;
using ChapeauModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class Stockview : Form
    {
        public Stockview()
        {
            InitializeComponent();
            pnlAddNew.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Stockview_Load(object sender, EventArgs e)
        {

        }

        private void paymnetLabel_Click(object sender, EventArgs e)
        {

        }

        private void lstMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMenu.SelectedItems.Count <= 0)
            {
                return;
            }
            MenuItem selectedItem = lstMenu.SelectedItems[0].Tag as MenuItem;
            numQchange.Value = selectedItem.stock;
        }

        private void buttonEditItem_Click(object sender, EventArgs e)
        {
            if (lstMenu.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Please select an item");
                return;

            }
            pnlAddNew.Enabled = true;
            

            MenuItem selectedItem = lstMenu.SelectedItems[0].Tag as MenuItem;

            txtName.Text = selectedItem.item_name;
            txtPrice.Text = selectedItem.item_price.ToString();

        }
    }
}
