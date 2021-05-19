
namespace ChapeauUI
{
    partial class PaymentForm
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
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPayment = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lstViewItems = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstViewPayment = new System.Windows.Forms.ListView();
            this.OrderitemCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PaymentStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PaymentMethod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PaymentDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(651, 30);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 51);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(150)))), ((int)(((byte)(44)))));
            this.panel1.Controls.Add(this.lblPayment);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 118);
            this.panel1.TabIndex = 2;
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayment.ForeColor = System.Drawing.Color.White;
            this.lblPayment.Location = new System.Drawing.Point(273, 35);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(121, 31);
            this.lblPayment.TabIndex = 2;
            this.lblPayment.Text = "Payment";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ChapeauUI.Properties.Resources.logo_chapeau;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lstViewItems
            // 
            this.lstViewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstViewItems.HideSelection = false;
            this.lstViewItems.Location = new System.Drawing.Point(220, 426);
            this.lstViewItems.Name = "lstViewItems";
            this.lstViewItems.Size = new System.Drawing.Size(348, 202);
            this.lstViewItems.TabIndex = 3;
            this.lstViewItems.UseCompatibleStateImageBehavior = false;
            this.lstViewItems.View = System.Windows.Forms.View.Details;
            this.lstViewItems.SelectedIndexChanged += new System.EventHandler(this.lstViewItems_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "orderID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Item";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Qty";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Price";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lstViewPayment
            // 
            this.lstViewPayment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.OrderitemCode,
            this.PaymentStatus,
            this.PaymentMethod,
            this.PaymentDate});
            this.lstViewPayment.HideSelection = false;
            this.lstViewPayment.Location = new System.Drawing.Point(220, 180);
            this.lstViewPayment.Name = "lstViewPayment";
            this.lstViewPayment.Size = new System.Drawing.Size(348, 215);
            this.lstViewPayment.TabIndex = 4;
            this.lstViewPayment.UseCompatibleStateImageBehavior = false;
            this.lstViewPayment.View = System.Windows.Forms.View.Details;
            this.lstViewPayment.SelectedIndexChanged += new System.EventHandler(this.lstViewPayment_SelectedIndexChanged);
            // 
            // OrderitemCode
            // 
            this.OrderitemCode.Text = "OrderitemCode";
            // 
            // PaymentStatus
            // 
            this.PaymentStatus.Text = "PaymentStatus";
            // 
            // PaymentMethod
            // 
            this.PaymentMethod.Text = "PaymentMethod";
            // 
            // PaymentDate
            // 
            this.PaymentDate.Text = "PaymentDate";
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 640);
            this.Controls.Add(this.lstViewPayment);
            this.Controls.Add(this.lstViewItems);
            this.Controls.Add(this.panel1);
            this.Name = "PaymentForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView lstViewItems;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lstViewPayment;
        private System.Windows.Forms.ColumnHeader OrderitemCode;
        private System.Windows.Forms.ColumnHeader PaymentStatus;
        private System.Windows.Forms.ColumnHeader PaymentMethod;
        private System.Windows.Forms.ColumnHeader PaymentDate;
    }
}