
namespace ChapeauUI
{
    partial class OrderForm
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlLunchMenu = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.ListViewKitchBar = new System.Windows.Forms.ListView();
            this.OrderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Itemorder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Commentv2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quanity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeOrder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tablev2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlLunchMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ChapeauUI.Properties.Resources.Rectangle_1;
            this.pictureBox2.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(756, 94);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Silver;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExit.Location = new System.Drawing.Point(607, 26);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 53);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlLunchMenu
            // 
            this.pnlLunchMenu.BackColor = System.Drawing.Color.White;
            this.pnlLunchMenu.Controls.Add(this.btnRefresh);
            this.pnlLunchMenu.Controls.Add(this.btnStatus);
            this.pnlLunchMenu.Controls.Add(this.ListViewKitchBar);
            this.pnlLunchMenu.Location = new System.Drawing.Point(-2, 92);
            this.pnlLunchMenu.Name = "pnlLunchMenu";
            this.pnlLunchMenu.Size = new System.Drawing.Size(686, 894);
            this.pnlLunchMenu.TabIndex = 13;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefresh.Location = new System.Drawing.Point(423, 684);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(243, 96);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStatus.Location = new System.Drawing.Point(30, 684);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(243, 96);
            this.btnStatus.TabIndex = 16;
            this.btnStatus.Text = "Change Status";
            this.btnStatus.UseVisualStyleBackColor = false;
            this.btnStatus.Click += new System.EventHandler(this.btnstatus_Click);
            // 
            // ListViewKitchBar
            // 
            this.ListViewKitchBar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.OrderID,
            this.Itemorder,
            this.Commentv2,
            this.Quanity,
            this.TimeOrder,
            this.Tablev2,
            this.Status});
            this.ListViewKitchBar.FullRowSelect = true;
            this.ListViewKitchBar.GridLines = true;
            this.ListViewKitchBar.HideSelection = false;
            this.ListViewKitchBar.Location = new System.Drawing.Point(30, 64);
            this.ListViewKitchBar.Name = "ListViewKitchBar";
            this.ListViewKitchBar.Size = new System.Drawing.Size(636, 570);
            this.ListViewKitchBar.TabIndex = 15;
            this.ListViewKitchBar.UseCompatibleStateImageBehavior = false;
            this.ListViewKitchBar.View = System.Windows.Forms.View.Details;
            // 
            // OrderID
            // 
            this.OrderID.Text = "OrderID";
            // 
            // Itemorder
            // 
            this.Itemorder.Text = "Itemorder";
            this.Itemorder.Width = 138;
            // 
            // Commentv2
            // 
            this.Commentv2.Text = "Comment";
            this.Commentv2.Width = 91;
            // 
            // Quanity
            // 
            this.Quanity.Text = "Quanity";
            this.Quanity.Width = 75;
            // 
            // TimeOrder
            // 
            this.TimeOrder.Text = "Time";
            this.TimeOrder.Width = 65;
            // 
            // Tablev2
            // 
            this.Tablev2.Text = "Table";
            this.Tablev2.Width = 75;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 240;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::ChapeauUI.Properties.Resources.Rectangle_1;
            this.pictureBox4.Location = new System.Drawing.Point(-2, -2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(756, 94);
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ChapeauUI.Properties.Resources.logo_chapeau;
            this.pictureBox3.Location = new System.Drawing.Point(12, -2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(156, 94);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(150)))), ((int)(((byte)(44)))));
            this.lblEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployee.ForeColor = System.Drawing.Color.White;
            this.lblEmployee.Location = new System.Drawing.Point(190, 26);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(188, 42);
            this.lblEmployee.TabIndex = 15;
            this.lblEmployee.Text = "Orderview";
            this.lblEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OrderForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(752, 985);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.pnlLunchMenu);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlLunchMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnlLunchMenu;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ListView ListViewKitchBar;
        private System.Windows.Forms.ColumnHeader OrderID;
        private System.Windows.Forms.ColumnHeader Itemorder;
        private System.Windows.Forms.ColumnHeader Commentv2;
        private System.Windows.Forms.ColumnHeader Quanity;
        private System.Windows.Forms.ColumnHeader TimeOrder;
        private System.Windows.Forms.ColumnHeader Tablev2;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnRefresh;
    }
}