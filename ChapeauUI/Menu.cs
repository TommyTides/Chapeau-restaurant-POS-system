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
        Order order;
        OrderItem orderItem;
        List<MenuItem> menuItems; // list of menu items to fill the menu

        public Menu(Employee employee)
        {
            InitializeComponent();
            menuItemService = new MenuItemService();
            order = new Order();
            orderItem = new OrderItem();
            menuItems = new List<MenuItem>();

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

        public void EmptyOrder() // remove entire order.
        {
            //this.order = new Order();
            //this.order.OrderItem = new List<OrderItem>();
        }

        private void LunchMenuPanel()
        {
            menuItems = menuItemService.GetAllMenuItems(); // Gets list of menuItems form database

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

        private void btnExitGunaUI_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (order.OrderItem.Count <= 0)
            {
                MessageBox.Show("Select an item to send an order!");
                return;
            }
            order.Table.TableID = 1; // temporaty table;
            order.PaymentStatus = false;
            menuItemService.SendOrder(order);// send order to database
        }

        private void cmbLunchMain1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(cmbLunchMain1.SelectedItem) == 0)
            //{

            //}
            //else
            //{
            //    MenuItem item = menuItems[0];
            //    OrderItem testOrder = new OrderItem();
            //    testOrder.menuItem = item;
            //    testOrder.Quantity = Convert.ToInt32(cmbLunchMain1.SelectedItem);
            //    lstbTest.Items.Add(testOrder);
            //}
            
        }
    }
}
