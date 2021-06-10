using ChapeauLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using MenuItem = ChapeauModel.MenuItem;
using ChapeauModel;

namespace ChapeauUI
{
    public partial class PlaceOrderForm : Form
    {
        public MenuItemService menuItemService; // to communicate
        public Order order;
        public OrderItem orderItem;
        public List<MenuItem> menuItems; // list of menu items to fill the menu
        public MenuItem item;
        

        public PlaceOrderForm(Employee employee)
        {
            InitializeComponent();
        }
        public PlaceOrderForm() // constructor for test runs only
        {
            InitializeComponent();
            HideAllPanels();

            menuItemService = new MenuItemService();
            order = new Order();
            orderItem = new OrderItem();
            order.OrderItems = new List<OrderItem>();
            menuItems = new List<MenuItem>();
            item = new MenuItem();
        }

        private void PlaceOrderForm_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 2000, WinAPI.BLEND); // startup animation
        }

        private void HideAllPanels() // Will hide all panels when called
        {
            pnlHamburger.Visible = false;
            pnlMenuOptions.Visible = false;
            pnlLunchMenu.Visible = false;
        }

        private void hamburgerIcon_Click(object sender, EventArgs e)
        {
            if (pnlHamburger.Visible == false)
            {
                pnlHamburger.Visible = true;
            }
            else
            {
                pnlHamburger.Visible = false;
            }
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            // to do...
        }

        private void lblTableView_Click(object sender, EventArgs e)
        {
            // to do...
        }

        private void lblMenuOptions_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            pnlMenuOptions.Visible = true;
        }

        private void lblOrderCart_Click(object sender, EventArgs e)
        {
            // to do...
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLunchMenu_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            FillLunchMenu(); // fill panel before making the panel visible
            pnlLunchMenu.Visible = true;
        }

        private void btnDinnerMenu_Click(object sender, EventArgs e)
        {
            // to do...
        }

        private void btnDrinksNonAlcMenu_Click(object sender, EventArgs e)
        {
            // to do...
        }

        private void btnDrinksAlcMenu_Click(object sender, EventArgs e)
        {
            // to do...
        }

        private void FillLunchMenu()
        {
            menuItems = menuItemService.GetAllMenuItems(); // Gets list of menuItems form database
            btnAddLunchItem.Enabled = false;

            foreach (MenuItem item in menuItems) // Adding items tot the listboxes
            {
                if (item.item_type == MenuSubCategory.lunchMain)
                {
                    listBoxLunchMain.Items.Add(item);
                    listBoxPrice1.Items.Add(item.item_price.ToString("C", new CultureInfo("nl-NL")));
                }
                else if (item.item_type == MenuSubCategory.specials)
                {
                    listBoxLunchSpecials.Items.Add(item);
                    listBoxPrice2.Items.Add(item.item_price.ToString("C", new CultureInfo("nl-NL")));
                }
                else if (item.item_type == MenuSubCategory.bites)
                {
                    listBoxLunchBites.Items.Add(item);
                    listBoxPrice3.Items.Add(item.item_price.ToString("C", new CultureInfo("nl-NL")));
                }
            }
        }

        private void btnAddLunchItem_Click(object sender, EventArgs e)
        {
            orderItem = (OrderItem)listBoxSelectedLunchItem.SelectedItem;
            int temp = Convert.ToInt32(numUpdQuantity.Value);
            orderItem.Quantity = temp;

            order.OrderItems.Add(orderItem);
        }

        private void FillOrderItem()
        {
            orderItem.OrderTime = DateTime.Now;
            orderItem.Status = ItemStatus.Preparing;
        }

        private void listBoxLunchMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            //orderItem = new OrderItem();
            FillOrderItem();
            item = (MenuItem)listBoxLunchMain.SelectedItem;
            orderItem.menuItem = item;
            listBoxSelectedLunchItem.Items.Clear();
            listBoxSelectedLunchItem.Items.Add(orderItem);
        }

        private void listBoxLunchSpecials_SelectedIndexChanged(object sender, EventArgs e)
        {
            //orderItem = new OrderItem();
            FillOrderItem();
            item = (MenuItem)listBoxLunchSpecials.SelectedItem;
            orderItem.menuItem = item;
            listBoxSelectedLunchItem.Items.Clear();
            listBoxSelectedLunchItem.Items.Add(orderItem);
        }

        private void listBoxLunchBites_SelectedIndexChanged(object sender, EventArgs e)
        {
            //orderItem = new OrderItem();
            FillOrderItem();
            item = (MenuItem)listBoxLunchBites.SelectedItem;
            orderItem.menuItem = item;
            listBoxSelectedLunchItem.Items.Clear();
            listBoxSelectedLunchItem.Items.Add(orderItem);
        }

        private void numUpdQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (numUpdQuantity.Value >= 1)
            {
                btnAddLunchItem.Enabled = true; // enable add button when quantity is selected.
            }
            else
            {
                btnAddLunchItem.Enabled = false;
            }
        }
    }
}
