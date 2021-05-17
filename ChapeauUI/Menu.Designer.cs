
namespace ChapeauUI
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlHamburger = new System.Windows.Forms.Panel();
            this.lblOrderCart = new System.Windows.Forms.Label();
            this.lblMenuOptions = new System.Windows.Forms.Label();
            this.lblTableView = new System.Windows.Forms.Label();
            this.lblHome = new System.Windows.Forms.Label();
            this.lblApplicationState = new System.Windows.Forms.Label();
            this.lblApplicationSubState = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlHamburger.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ChapeauUI.Properties.Resources.logo_chapeau;
            this.pictureBox3.Location = new System.Drawing.Point(12, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(156, 94);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ChapeauUI.Properties.Resources.hamburger_menu;
            this.pictureBox1.Location = new System.Drawing.Point(683, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ChapeauUI.Properties.Resources.Rectangle_1;
            this.pictureBox2.Location = new System.Drawing.Point(-5, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(759, 94);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pnlHamburger
            // 
            this.pnlHamburger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(150)))), ((int)(((byte)(44)))));
            this.pnlHamburger.Controls.Add(this.button1);
            this.pnlHamburger.Controls.Add(this.lblOrderCart);
            this.pnlHamburger.Controls.Add(this.lblMenuOptions);
            this.pnlHamburger.Controls.Add(this.lblTableView);
            this.pnlHamburger.Controls.Add(this.lblHome);
            this.pnlHamburger.Location = new System.Drawing.Point(537, 91);
            this.pnlHamburger.Name = "pnlHamburger";
            this.pnlHamburger.Size = new System.Drawing.Size(217, 894);
            this.pnlHamburger.TabIndex = 5;
            // 
            // lblOrderCart
            // 
            this.lblOrderCart.AutoSize = true;
            this.lblOrderCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderCart.ForeColor = System.Drawing.Color.White;
            this.lblOrderCart.Location = new System.Drawing.Point(30, 189);
            this.lblOrderCart.Name = "lblOrderCart";
            this.lblOrderCart.Size = new System.Drawing.Size(142, 31);
            this.lblOrderCart.TabIndex = 3;
            this.lblOrderCart.Text = "Order Cart";
            this.lblOrderCart.Click += new System.EventHandler(this.lblOrderCart_Click);
            // 
            // lblMenuOptions
            // 
            this.lblMenuOptions.AutoSize = true;
            this.lblMenuOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuOptions.ForeColor = System.Drawing.Color.White;
            this.lblMenuOptions.Location = new System.Drawing.Point(30, 135);
            this.lblMenuOptions.Name = "lblMenuOptions";
            this.lblMenuOptions.Size = new System.Drawing.Size(182, 31);
            this.lblMenuOptions.TabIndex = 2;
            this.lblMenuOptions.Text = "Menu Options";
            this.lblMenuOptions.Click += new System.EventHandler(this.lblMenuOptions_Click);
            // 
            // lblTableView
            // 
            this.lblTableView.AutoSize = true;
            this.lblTableView.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableView.ForeColor = System.Drawing.Color.White;
            this.lblTableView.Location = new System.Drawing.Point(30, 78);
            this.lblTableView.Name = "lblTableView";
            this.lblTableView.Size = new System.Drawing.Size(148, 31);
            this.lblTableView.TabIndex = 1;
            this.lblTableView.Text = "Table View";
            this.lblTableView.Click += new System.EventHandler(this.lblTableView_Click);
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHome.ForeColor = System.Drawing.Color.White;
            this.lblHome.Location = new System.Drawing.Point(30, 23);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(86, 31);
            this.lblHome.TabIndex = 0;
            this.lblHome.Text = "Home";
            this.lblHome.Click += new System.EventHandler(this.lblHome_Click);
            // 
            // lblApplicationState
            // 
            this.lblApplicationState.AutoSize = true;
            this.lblApplicationState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(150)))), ((int)(((byte)(44)))));
            this.lblApplicationState.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationState.ForeColor = System.Drawing.Color.White;
            this.lblApplicationState.Location = new System.Drawing.Point(294, 9);
            this.lblApplicationState.Name = "lblApplicationState";
            this.lblApplicationState.Size = new System.Drawing.Size(117, 42);
            this.lblApplicationState.TabIndex = 6;
            this.lblApplicationState.Text = "Home";
            this.lblApplicationState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblApplicationSubState
            // 
            this.lblApplicationSubState.AutoSize = true;
            this.lblApplicationSubState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(150)))), ((int)(((byte)(44)))));
            this.lblApplicationSubState.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationSubState.ForeColor = System.Drawing.Color.White;
            this.lblApplicationSubState.Location = new System.Drawing.Point(297, 51);
            this.lblApplicationSubState.Name = "lblApplicationSubState";
            this.lblApplicationSubState.Size = new System.Drawing.Size(62, 24);
            this.lblApplicationSubState.TabIndex = 7;
            this.lblApplicationSubState.Text = "Home";
            this.lblApplicationSubState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 855);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 39);
            this.button1.TabIndex = 8;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Menu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(752, 985);
            this.Controls.Add(this.lblApplicationSubState);
            this.Controls.Add(this.lblApplicationState);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pnlHamburger);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UI";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlHamburger.ResumeLayout(false);
            this.pnlHamburger.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel pnlHamburger;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Label lblOrderCart;
        private System.Windows.Forms.Label lblMenuOptions;
        private System.Windows.Forms.Label lblTableView;
        private System.Windows.Forms.Label lblApplicationState;
        private System.Windows.Forms.Label lblApplicationSubState;
        private System.Windows.Forms.Button button1;
    }
}

