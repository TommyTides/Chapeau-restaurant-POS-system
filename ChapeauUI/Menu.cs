using ChapeauLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using MenuItem = ChapeauModel.MenuItem;

namespace ChapeauUI
{
    public partial class Menu : Form
    {
        MenuItemService menuItemService;

        public Menu()
        {
            InitializeComponent();

            menuItemService = new MenuItemService();

            this.Text = $"Menu options";
            lblApplicationState.Text = "";
            lblApplicationSubState.Text = "";
            // Code below makes the background tranparant on the picture behind it.
            pictureBox2.Controls.Add(pictureBox1);
            pictureBox2.Controls.Add(pictureBox3);
            pictureBox1.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;

            HideAllPanels();
        }

        private void HideAllPanels() // Will hide all panels when called
        {
            pnlHamburger.Visible = false;
            pnlMenuOptions.Visible = false;
            pnlLunchMenu.Visible = false;
        }
        
        private void pictureBox1_Click(object sender, EventArgs e) // to open the menu strip
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
            HideAllPanels();
            lblApplicationState.Text = "Home";
            lblApplicationSubState.Text = "";
            pnlHamburger.Visible = false;
        }

        private void lblTableView_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            lblApplicationState.Text = "Table view";
            lblApplicationSubState.Text = "Select a table";
            pnlHamburger.Visible = false;
        }

        private void lblMenuOptions_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            pnlMenuOptions.Visible = true;
            lblApplicationState.Text = "Menu options";
            lblApplicationSubState.Text = "Select a menu";
            pnlHamburger.Visible = false;
        }

        private void lblOrderCart_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            lblApplicationState.Text = "Order cart";
            lblApplicationSubState.Text = "view your orders";
            pnlHamburger.Visible = false;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 2000, WinAPI.BLEND);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Will exit the application
            Application.Exit();
        }

        private void btnLunchMenu_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            pnlLunchMenu.Visible = true;
            LunchMenuPanel();
        }

        private void LunchMenuPanel()
        {
            List<MenuItem> menuItems = menuItemService.GetAllMenuItems();

            foreach (MenuItem item in menuItems)
            {
                if (item.item_type == "lunch main")
                {
                    listBoxLunchMain.Items.Add(item.item_name);
                    listBoxLunchMainPrice.Items.Add(item.item_price);
                }             
            }
        }
    }
}
