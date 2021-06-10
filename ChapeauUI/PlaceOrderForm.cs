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
            pnlFoodMenu.Visible = false; 
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
            if (order.OrderItems.Count <= 0)
            {
                MessageBox.Show("Add item to the cart to view the order cart!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLunchMenu_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            FillFoodMenu(MenuCategory.Lunch, MenuSubCategory.lunchMain, MenuSubCategory.specials, MenuSubCategory.bites);
        }

        private void btnDinnerMenu_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            FillFoodMenu(MenuCategory.Dinner, MenuSubCategory.starters, MenuSubCategory.mains, MenuSubCategory.desserts);
        }

        private void btnDrinksNonAlcMenu_Click(object sender, EventArgs e)
        {
            // to do...
        }

        private void btnDrinksAlcMenu_Click(object sender, EventArgs e)
        {
            // to do...
        }
        
        public void SetListBoxSize(int size1, int size2, int size3, int size4)
        {
            listBoxFirstList.Size = new Size(482, size1);
            listBoxSecondList.Size = new Size(482, size2);
            listBoxThirdList.Size = new Size(482, 124);// stays the same always
            listBoxFirstListPrice.Size = new Size(70, size3);
            listBoxSecondListPrice.Size = new Size(70, size4);
            listBoxThirdListPrice.Size = new Size(70, 124);// stays the same always
        }

        public void ClearFoodMenu() // clear all lists etc.
        {
            listBoxFirstList.Items.Clear();
            listBoxSecondList.Items.Clear();
            listBoxThirdList.Items.Clear();
            listBoxFirstListPrice.Items.Clear();
            listBoxSecondListPrice.Items.Clear();
            listBoxThirdListPrice.Items.Clear();
            listBoxSelectedFoodItem.Items.Clear();
            numericUpDownFoodMenu.Value = 0;
        }

        private void FillFoodMenu(MenuCategory category, MenuSubCategory firstCategory, MenuSubCategory secondCategory, MenuSubCategory ThirdCategory)
        {
            ClearFoodMenu();
            pnlFoodMenu.Visible = true; // make menu panel visible
            
            // List box sizes depending on menu type.
            if (category == MenuCategory.Lunch)
                SetListBoxSize(124, 124, 124, 124);
            else
                SetListBoxSize(154, 184, 154, 184);

            menuItems.Clear();
            menuItems = menuItemService.GetAllMenuItems(); // Gets list of menuItems form database
            btnAddFoodItem.Enabled = false;

            foreach (MenuItem item in menuItems) // Adding items tot the listboxes
            {
                if (item.item_type == firstCategory)
                {
                    listBoxFirstList.Items.Add(item);
                    listBoxFirstListPrice.Items.Add(item.item_price.ToString("C", new CultureInfo("nl-NL")));
                }
                else if (item.item_type == secondCategory)
                {
                    listBoxSecondList.Items.Add(item);
                    listBoxSecondListPrice.Items.Add(item.item_price.ToString("C", new CultureInfo("nl-NL")));
                }
                else if (item.item_type == ThirdCategory)
                {
                    listBoxThirdList.Items.Add(item);
                    listBoxThirdListPrice.Items.Add(item.item_price.ToString("C", new CultureInfo("nl-NL")));
                }
            }
        }

        private void FillOrderItem()
        {
            orderItem.OrderTime = DateTime.Now;
            orderItem.Status = ItemStatus.Preparing;
        }

        private void listBoxSelectedFoodItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDownFoodMenu.Value = 1; // set quantity to 1 when the an item is selected.
        }

        private void numericUpDownFoodMenu_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownFoodMenu.Value >= 1)
            {
                btnAddFoodItem.Enabled = true; // enable add button when quantity is selected.
            }
            else
            {
                btnAddFoodItem.Enabled = false; // disable add button
                listBoxSelectedFoodItem.Items.Clear(); // clear selected item list
            }
        }

        private void listBoxFirstList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillOrderItem();
            item = (MenuItem)listBoxFirstList.SelectedItem;
            AddOrderItemToOrder();
        }

        private void listBoxSecondList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillOrderItem();
            item = (MenuItem)listBoxSecondList.SelectedItem;
            AddOrderItemToOrder();
            listBoxSelectedFoodItem.SelectedIndex = 0;
        }

        private void listBoxThirdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillOrderItem();
            item = (MenuItem)listBoxThirdList.SelectedItem;
            AddOrderItemToOrder();
            listBoxSelectedFoodItem.SelectedIndex = 0;
        }

        public void AddOrderItemToOrder()
        {
            orderItem.menuItem = item;
            listBoxSelectedFoodItem.Items.Clear();
            listBoxSelectedFoodItem.Items.Add(orderItem);
            listBoxSelectedFoodItem.SelectedIndex = 0;
        }

        private void btnAddFoodItem_Click(object sender, EventArgs e) // add item to cart
        {
            bool grouped = false;
            // orderItem = (OrderItem)listBoxSelectedLunchItem.SelectedItem;
            this.listBoxSelectedFoodItem.SelectedIndex = 0;
            orderItem = (OrderItem)listBoxSelectedFoodItem.SelectedItem;
            int temp = Convert.ToInt32(numericUpDownFoodMenu.Value);
            orderItem.Comment = "no comment";
            orderItem.Quantity = temp;

            order.OrderItems = menuItemService.GroupOrderItem();

            foreach (OrderItem orderorderItem in order.OrderItems)
            {
                // if the selected item and the comment is the same the item will be grouped in the excisting list of orders.
                if (orderorderItem.menuItem.item_id == orderItem.menuItem.item_id && orderorderItem.Comment == orderItem.Comment)
                {
                    orderorderItem.Quantity += orderItem.Quantity;
                    grouped = true;
                }
            }
            if (!grouped) // add order item to the list if they are not grouped already in the excisting list
            {
                order.OrderItems.Add(orderItem);
            }
            if (order.OrderItems.Count >= 1)
            {
                MessageBox.Show("Item has been added to cart");             
            }

            numericUpDownFoodMenu.Value = 0;
            listBoxSelectedFoodItem.Items.Clear();
            listBoxSelectedFoodItem.Text = "";
        }
    }
}