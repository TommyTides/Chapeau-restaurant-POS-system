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
    public partial class Menu : Form
    {
        MenuItemService menuItemService;

        public Menu(Employee employee)
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
            // welcome message displaying firstname, lastname and employeerole.
            
        }
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
            // welcome message displaying firstname, lastname and employeerole.

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
            List<MenuItem> menuItems = menuItemService.GetAllMenuItems(); // Gets list of menuItems form database
            int count = 0;
            foreach (MenuItem item in menuItems) // Adding items tot the listboxes
            {
                if (item.item_type == MenuSubCategory.lunchMain)
                {
                    listBoxLunchMain.Items.Add(item.item_name);
                    listBoxLunchMainPrice.Items.Add(item.item_price.ToString("c"));
                    if (count < 3)
                    {
                        listBoxLunchMain.Items.Add("");
                        listBoxLunchMain.Items.Add("");

                        listBoxLunchMainPrice.Items.Add("");
                        listBoxLunchMainPrice.Items.Add("");
                        count++;
                    }
                }
                else if (item.item_type == MenuSubCategory.specials)
                {
                    listBoxLunchSpecials.Items.Add(item.item_name);
                    listBoxLunchSpecialsPrice.Items.Add(item.item_price);
                }
                else if (item.item_type == MenuSubCategory.bites)
                {
                    listBoxLunchBites.Items.Add(item.item_name);
                    listBoxLunchBitesPrice.Items.Add(item.item_price);
                }
            }
        }

        private void btnExitGunaUI_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void pnlLunchMenuInside_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
