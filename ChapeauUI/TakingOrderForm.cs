using ChapeauLogic;
using ChapeauModel;
using MenuItem = ChapeauModel.MenuItem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class TakingOrderForm : Form
    {
        MenuItemService menuItemService;
        public TakingOrderForm()
        {
            InitializeComponent();
            menuItemService = new MenuItemService();


            // or
            xuiSplashScreen1.initializeLoader(this);
        }

        private void TakingOrderForm_Load(object sender, EventArgs e)
        {

        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}