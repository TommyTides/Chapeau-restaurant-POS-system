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
        public OrderService orderService;
        public Order order;
        public OrderItem orderItem;
        public List<MenuItem> menuItems; // list of menu items to fill the menu
        public MenuItem item;
        public Employee employee;
        private Table table;

        public PlaceOrderForm(Table table, Employee employee)
        {
            InitializeComponent();
            HideAllPanels();

            menuItemService = new MenuItemService();
            orderService = new OrderService();
            order = new Order();
            orderItem = new OrderItem();
            order.OrderItems = new List<OrderItem>();
            order.Employee = employee;
            menuItems = new List<MenuItem>();
            item = new MenuItem();
            this.employee = employee;
            order.Employee.employeeID = employee.employeeID;
            this.table = table;
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
            pnlDrinks.Visible = false;
            pnlCart.Visible = false;
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
            TablePage tableView = new TablePage(this.employee);
            tableView.Show();
            Close();
        }

        private void lblMenuOptions_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            pnlMenuOptions.Visible = true;
        }

        private void lblOrderCart_Click(object sender, EventArgs e)
        {
            if (order.OrderItems.Count <= 0)
            {
                MessageBox.Show("Add item to the cart to view the order cart!");
            }
            else
            {
                HideAllPanels();
                pnlCart.Visible = true;
                FillCart();
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
            HideAllPanels();
            FillDrinksMenu(MenuSubCategory.soft, MenuSubCategory.hot);
        }

        private void btnDrinksAlcMenu_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            FillDrinksMenu(MenuSubCategory.alcohol, MenuSubCategory.wines);
        }

        public void SetListBoxSize(int size1, int size2, int size3, int size4) // Cahnges the size of the listboxes
        {
            listBoxFirstList.Size = new Size(482, size1);
            listBoxSecondList.Size = new Size(482, size2);
            listBoxThirdList.Size = new Size(482, 124);// stays the same always
            listBoxFirstListPrice.Size = new Size(70, size3);
            listBoxSecondListPrice.Size = new Size(70, size4);
            listBoxThirdListPrice.Size = new Size(70, 124);// stays the same always
        }

        public void SetListBoxSizeDrinks(int size1, int size2, int size3, int size4) // Cahnges the size of the listboxes
        {
            listBoxDrink1.Size = new Size(482, size1);
            listBoxDrink2.Size = new Size(482, size2);
            listBoxDrink1Price.Size = new Size(83, size3);
            listBoxDrink2Price.Size = new Size(83, size4);
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
                    if (item.stock <= 0)
                        listBoxFirstListPrice.Items.Add("out of stock");
                    else
                        listBoxFirstListPrice.Items.Add(item.item_price.ToString("C", new CultureInfo("nl-NL")));               
                }
                else if (item.item_type == secondCategory)
                {
                    listBoxSecondList.Items.Add(item);
                    if (item.stock <= 0)
                        listBoxSecondListPrice.Items.Add("out of stock");
                    else
                        listBoxSecondListPrice.Items.Add(item.item_price.ToString("C", new CultureInfo("nl-NL")));
                }
                else if (item.item_type == ThirdCategory)
                {
                    listBoxThirdList.Items.Add(item);
                    if (item.stock <= 0)
                        listBoxThirdListPrice.Items.Add("out of stock");
                    else
                        listBoxThirdListPrice.Items.Add(item.item_price.ToString("C", new CultureInfo("nl-NL")));
                }
            }
        }

        private void FillOrderItem()
        {
            orderItem.Status = OrderItemStatus.Preparing;
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
                btnAddFoodItem.Enabled = false; // disable add button when amount <= 0
                listBoxSelectedFoodItem.Items.Clear(); // clear selected item list
            }
        }

        private void listBoxFirstList_SelectedIndexChanged(object sender, EventArgs e)
        {
            item = (MenuItem)listBoxFirstList.SelectedItem;
            AddOrderItemToOrder();
            listBoxSelectedFoodItem.SelectedIndex = 0;
        }

        private void listBoxSecondList_SelectedIndexChanged(object sender, EventArgs e)
        {
            item = (MenuItem)listBoxSecondList.SelectedItem;
            AddOrderItemToOrder();
            listBoxSelectedFoodItem.SelectedIndex = 0;
        }

        private void listBoxThirdList_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        public void AddOrderItemToOrderDrink()
        {
            orderItem.menuItem = item;
            listBoxSelectedDrink.Items.Clear();
            listBoxSelectedDrink.Items.Add(orderItem);
            listBoxSelectedDrink.SelectedIndex = 0;
        }

        private void btnAddFoodItem_Click(object sender, EventArgs e) // add item to cart
        {
            int temp = Convert.ToInt32(numericUpDownFoodMenu.Value);
            orderItem.Comment = "no comment";
            orderItem.Quantity = temp;
            FillOrderItem();
            int checkGrouped = 0;

            foreach (OrderItem orderOrderItem in order.OrderItems) // groupinng same items together in the order cart
            {
                if (orderOrderItem.menuItem.item_name == orderItem.menuItem.item_name)
                {
                    orderOrderItem.Quantity = orderService.GroupOrderItem(orderOrderItem.Quantity, orderItem.Quantity);
                    checkGrouped = 1;
                }
            }

            if (checkGrouped == 0)
            {
                order.OrderItems.Add(orderItem);
                orderItem = new OrderItem();
            }
            if (order.OrderItems.Count >= 1)
            {
                MessageBox.Show("Item has been added to cart");
            }
            listBoxSelectedFoodItem.Items.Clear();
            numericUpDownFoodMenu.Value = 0;
            listBoxSelectedFoodItem.Items.Clear();
            listBoxSelectedFoodItem.Text = "";
        }

        public void ClearDrinkMenu()
        {
            listBoxDrink1.Items.Clear();
            listBoxDrink2.Items.Clear();
            listBoxDrink1Price.Items.Clear();
            listBoxDrink2Price.Items.Clear();
            listBoxSelectedDrink.Items.Clear();
            numericUpDownDrink.Value = 0;
        }

        private void FillDrinksMenu(MenuSubCategory firstCategory, MenuSubCategory secondCategory)
        {
            ClearDrinkMenu();
            pnlDrinks.Visible = true;

            // List box sizes depending on menu type.
            if (secondCategory == MenuSubCategory.wines)
                SetListBoxSizeDrinks(154, 184, 154, 184);
            else
                SetListBoxSizeDrinks(214, 184, 214, 184);

            menuItems.Clear();
            menuItems = menuItemService.GetAllMenuItems(); // Gets list of menuItems form database
            btnAddDrink.Enabled = false;

            if (firstCategory == MenuSubCategory.wines) // Change label names
            {
                lblDrinks1.Text = "Beers";
                lblDrinks2.Text = "Wines";
            }
            else
            {
                lblDrinks1.Text = "Soft Drinks";
                lblDrinks2.Text = "Hot Drinks";
            }

            foreach (MenuItem item in menuItems) // Adding items tot the listboxes
            {
                if (item.item_type == firstCategory)
                {
                    listBoxDrink1.Items.Add(item);    
                    if (item.stock == 0)
                        listBoxDrink1Price.Items.Add("out of stock");
                    else
                        listBoxDrink1Price.Items.Add(item.item_price.ToString("C", new CultureInfo("nl-NL")));
                }
                else if (item.item_type == secondCategory)
                {
                    listBoxDrink2.Items.Add(item);
                    if (item.stock == 0)
                        listBoxDrink2Price.Items.Add("out of stock");
                    else
                        listBoxDrink2Price.Items.Add(item.item_price.ToString("C", new CultureInfo("nl-NL")));
                }
            }
        }

        private void numericUpDownDrink_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownDrink.Value >= 1)
            {
                btnAddDrink.Enabled = true; // enable add button when quantity is selected.
            }
            else
            {
                btnAddDrink.Enabled = false; // disable add button
                listBoxSelectedDrink.Items.Clear(); // clear selected item list
            }
        }

        private void listBoxSelectedDrink_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDownDrink.Value = 1;
        }

        private void btnAddDrink_Click(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32(numericUpDownDrink.Value);
            orderItem.Comment = "no comment";
            orderItem.Quantity = temp;
            FillOrderItem();
            int checkGrouped = 0;

            foreach (OrderItem orderOrderItem in order.OrderItems) // groupinng same items together in the order cart
            {
                if (orderOrderItem.menuItem.item_name == orderItem.menuItem.item_name)
                {
                    orderOrderItem.Quantity = orderService.GroupOrderItem(orderOrderItem.Quantity, orderItem.Quantity);
                    checkGrouped = 1;
                }
            }

            if (checkGrouped == 0)
            {
                order.OrderItems.Add(orderItem);
                orderItem = new OrderItem();
            }
            if (order.OrderItems.Count >= 1)
            {
                MessageBox.Show("Item has been added to cart");
            }
            numericUpDownDrink.Value = 0;
            listBoxSelectedDrink.Items.Clear();
            listBoxSelectedDrink.Text = "";
        }

        private void listBoxDrink1_SelectedIndexChanged(object sender, EventArgs e)
        {
            item = (MenuItem)listBoxDrink1.SelectedItem;
            AddOrderItemToOrderDrink();
            listBoxSelectedDrink.SelectedIndex = 0;
        }

        private void listBoxDrink2_SelectedIndexChanged(object sender, EventArgs e)
        {
            item = (MenuItem)listBoxDrink2.SelectedItem;
            AddOrderItemToOrderDrink();
            listBoxSelectedDrink.SelectedIndex = 0;
        }

        private void listBoxCartName_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveCartItem.Visible = true;
        }

        private void FillCart()
        {
            ClearCart();
            btnRemoveCartItem.Visible = false;
            double totalPrice = 0;
            foreach (OrderItem orderItemee in order.OrderItems) // Adding items tot the listboxes
            {
                listBoxCartName.Items.Add(orderItemee);
                listBoxCartAmount.Items.Add(orderItemee.Quantity);
                listBoxCartPrice.Items.Add(orderItemee.TotalPrice.ToString("C", new CultureInfo("nl-NL")));
                totalPrice += orderItemee.TotalPrice;
            }
            lblTotalCartPrice.Text = totalPrice.ToString("C", new CultureInfo("nl-NL"));
        }

        private void ClearCart()
        {
            listBoxCartName.Items.Clear();
            listBoxCartAmount.Items.Clear();
            listBoxCartPrice.Items.Clear();
        }

        private void btnRemoveCartItem_Click(object sender, EventArgs e)
        {
            OrderItem selectedCart = (OrderItem)listBoxCartName.SelectedItem;
            order.OrderItems.Remove(selectedCart);
            FillCart();
        }

        private void btnSendOrder_Click(object sender, EventArgs e)
        {
            order.Table = table;
            orderService.SendOrder(order);

            btnRemoveCartItem.Visible = false;
            order.OrderItems.Clear();
            FillCart();
        }

        private void btnRemoveCompleteOrder_Click(object sender, EventArgs e)
        {
            order.OrderItems.Clear();
            lblTotalCartPrice.Text = 0.ToString("C", new CultureInfo("nl-NL"));
            FillCart();
        }
    }
}
