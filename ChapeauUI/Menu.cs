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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

            this.Text = $"Menu options";
            lblApplicationState.Text = "";
            lblApplicationSubState.Text = "";
            // Code below makes the background tranparant on the picture behind it.
            pictureBox2.Controls.Add(pictureBox1);
            pictureBox2.Controls.Add(pictureBox3);
            pictureBox1.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;

            pnlHamburger.Visible = false;
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
            lblApplicationState.Text = "Home";
            lblApplicationSubState.Text = "";
        }

        private void lblTableView_Click(object sender, EventArgs e)
        {
            lblApplicationState.Text = "Table view";
            lblApplicationSubState.Text = "Select a table";
        }

        private void lblMenuOptions_Click(object sender, EventArgs e)
        {
            lblApplicationState.Text = "Menu options";
            lblApplicationSubState.Text = "Select a menu";
        }

        private void lblOrderCart_Click(object sender, EventArgs e)
        {
            lblApplicationState.Text = "Order cart";
            lblApplicationSubState.Text = "view your orders";
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
    }
}
