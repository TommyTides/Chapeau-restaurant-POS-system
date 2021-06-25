using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MenuItem = ChapeauModel.MenuItem;
using ChapeauModel;
using ChapeauLogic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace ChapeauUI
{
    public partial class Stockview : Form
    {
        MenuItemService menuItemService;
        List<MenuItem> Items;
        public Stockview()
        {
            InitializeComponent();
            pnlAddNew.Enabled = false;
            menuItemService = new MenuItemService();
            Items = menuItemService.GetAllMenuItems();
            FillStockView();
        }

        private void Stockview_Load(object sender, EventArgs e)
        {

        }

        private void FillStockView()
        {
            lstMenu.Items.Clear();
            Items = menuItemService.GetAllMenuItems();
            pnlAddNew.Enabled = false;
            foreach (MenuItem item in Items)
            {
                ListViewItem li = new ListViewItem(item.item_id.ToString());
                li.SubItems.Add(item.item_name);
                li.SubItems.Add(item.menu_type.ToString());
                li.SubItems.Add(item.item_type.ToString());
                li.SubItems.Add(item.item_price.ToString());
                li.SubItems.Add(item.place.ToString());
                li.SubItems.Add(item.stock.ToString());
                li.Tag = item;
                //fill the items in the listview
                lstMenu.Items.Add(li);
            }
        }

        private void lstMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMenu.SelectedItems.Count <= 0)
            {
                return;
            }
            //MenuItem selectedItem = lstMenu.SelectedItems[0].Tag as MenuItem;
            MenuItem item = (MenuItem)lstMenu.SelectedItems[0].Tag;
            txtStock.Text = item.stock.ToString();
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
            txtStock.Text = selectedItem.stock.ToString();

            cmbCategory.Items.Add(MenuCategory.Lunch);
            cmbCategory.Items.Add(MenuCategory.Dinner);
            cmbCategory.Items.Add(MenuCategory.Drinks);
            cmbCategory.SelectedItem = selectedItem.menu_type;

            cmbSubCategory.Items.Add(MenuSubCategory.alcohol);
            cmbSubCategory.Items.Add(MenuSubCategory.bites);
            cmbSubCategory.Items.Add(MenuSubCategory.desserts);
            cmbSubCategory.Items.Add(MenuSubCategory.hot);
            cmbSubCategory.Items.Add(MenuSubCategory.lunchMain);
            cmbSubCategory.Items.Add(MenuSubCategory.mains);
            cmbSubCategory.Items.Add(MenuSubCategory.soft);
            cmbSubCategory.Items.Add(MenuSubCategory.specials);
            cmbSubCategory.Items.Add(MenuSubCategory.starters);
            cmbSubCategory.Items.Add(MenuSubCategory.wines);
            cmbSubCategory.SelectedItem = selectedItem.item_type;

            cmbPlace.Items.Add(Place.Kitchen);
            cmbPlace.Items.Add(Place.Bar);
            cmbPlace.SelectedItem = selectedItem.place;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MenuItem selectedItem = lstMenu.SelectedItems[0].Tag as MenuItem;
            MenuItem newItem = new MenuItem();

            newItem.item_id = selectedItem.item_id;
            newItem.item_name = txtName.Text;
            newItem.item_price = double.Parse(txtPrice.Text);
            newItem.item_type = (MenuSubCategory)cmbSubCategory.SelectedItem;
            newItem.menu_type = (MenuCategory)cmbCategory.SelectedItem;
            newItem.stock = int.Parse(txtStock.Text);
            newItem.place = (Place)cmbPlace.SelectedItem;

            // send item to database
            menuItemService.EditMenuItem(newItem);
            FillStockView();
        }

        private void buttonDeleteItem_Click(object sender, EventArgs e)
        {
            MenuItem selectedItem = lstMenu.SelectedItems[0].Tag as MenuItem;
            menuItemService.RemoveMenuItem(selectedItem);
        }
    }
}
