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

        public TakingOrderForm()
        {
            InitializeComponent();

            btn_guna_show.Visible = true;
            btn_guna_show.Visible = false;

            pnlGunaTakingOrder.Visible = false;
            this.Text = $"Menu options";
            lblApplicationState.Text = "";
            lblApplicationSubState.Text = "";
            // Code below makes the background tranparant on the picture behind it.
            pictureBox2.Controls.Add(btn_guna_hide);
            pictureBox2.Controls.Add(btn_guna_show);
            pictureBox2.Controls.Add(pictureBox3);
            pictureBox3.BackColor = Color.Transparent;
            btn_guna_hide.BackColor = Color.Transparent;
            btn_guna_show.BackColor = Color.Transparent;
        }

        private void btn_guna_show_Click(object sender, EventArgs e)
        {
            btn_guna_show.Visible = false;
            btn_guna_hide.Visible = true;
            pnlGunaTakingOrder.Visible = false;
            pnlGunaTakingOrder.Width = 200;
            guna2Transition1.ShowSync(pnlGunaTakingOrder);
        }

        private void btn_guna_hide_Click(object sender, EventArgs e)
        {
            //guna2PictureBox1.Visible = false;
            pnlGunaTakingOrder.Visible = false;
            btn_guna_hide.Visible = false;
            btn_guna_show.Visible = true;
            pnlGunaTakingOrder.Width = 0;
            guna2Transition1.ShowSync(pnlGunaTakingOrder);
        }

        private void btnExitGunaUI_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
