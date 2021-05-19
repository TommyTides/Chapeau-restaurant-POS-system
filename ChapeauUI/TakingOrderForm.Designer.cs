
namespace ChapeauUI
{
    partial class TakingOrderForm
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
            this.components = new System.ComponentModel.Container();
            Guna.UI2.AnimatorNS.Animation animation2 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TakingOrderForm));
            this.pnlGunaTakingOrder = new Guna.UI2.WinForms.Guna2Panel();
            this.lblApplicationSubState = new System.Windows.Forms.Label();
            this.lblApplicationState = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
            this.btn_guna_show = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_guna_hide = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnExitGunaUI = new Guna.UI2.WinForms.Guna2Button();
            this.gunBtnHome = new Guna.UI2.WinForms.Guna2GradientButton();
            this.gunBtnTableView = new Guna.UI2.WinForms.Guna2GradientButton();
            this.gunBtnMenuOptions = new Guna.UI2.WinForms.Guna2GradientButton();
            this.gunBtnOrderCart = new Guna.UI2.WinForms.Guna2GradientButton();
            this.pnlGunaTakingOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGunaTakingOrder
            // 
            this.pnlGunaTakingOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(150)))), ((int)(((byte)(44)))));
            this.pnlGunaTakingOrder.Controls.Add(this.gunBtnOrderCart);
            this.pnlGunaTakingOrder.Controls.Add(this.gunBtnMenuOptions);
            this.pnlGunaTakingOrder.Controls.Add(this.gunBtnTableView);
            this.pnlGunaTakingOrder.Controls.Add(this.gunBtnHome);
            this.pnlGunaTakingOrder.Controls.Add(this.btnExitGunaUI);
            this.guna2Transition1.SetDecoration(this.pnlGunaTakingOrder, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pnlGunaTakingOrder.Location = new System.Drawing.Point(568, 91);
            this.pnlGunaTakingOrder.Name = "pnlGunaTakingOrder";
            this.pnlGunaTakingOrder.ShadowDecoration.Parent = this.pnlGunaTakingOrder;
            this.pnlGunaTakingOrder.Size = new System.Drawing.Size(200, 934);
            this.pnlGunaTakingOrder.TabIndex = 0;
            // 
            // lblApplicationSubState
            // 
            this.lblApplicationSubState.AutoSize = true;
            this.lblApplicationSubState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(150)))), ((int)(((byte)(44)))));
            this.guna2Transition1.SetDecoration(this.lblApplicationSubState, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblApplicationSubState.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationSubState.ForeColor = System.Drawing.Color.White;
            this.lblApplicationSubState.Location = new System.Drawing.Point(299, 50);
            this.lblApplicationSubState.Name = "lblApplicationSubState";
            this.lblApplicationSubState.Size = new System.Drawing.Size(62, 24);
            this.lblApplicationSubState.TabIndex = 12;
            this.lblApplicationSubState.Text = "Home";
            this.lblApplicationSubState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblApplicationState
            // 
            this.lblApplicationState.AutoSize = true;
            this.lblApplicationState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(150)))), ((int)(((byte)(44)))));
            this.guna2Transition1.SetDecoration(this.lblApplicationState, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblApplicationState.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationState.ForeColor = System.Drawing.Color.White;
            this.lblApplicationState.Location = new System.Drawing.Point(296, 8);
            this.lblApplicationState.Name = "lblApplicationState";
            this.lblApplicationState.Size = new System.Drawing.Size(117, 42);
            this.lblApplicationState.TabIndex = 11;
            this.lblApplicationState.Text = "Home";
            this.lblApplicationState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            // 
            // guna2Transition1
            // 
            this.guna2Transition1.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Leaf;
            this.guna2Transition1.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 1F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.guna2Transition1.DefaultAnimation = animation2;
            // 
            // btn_guna_show
            // 
            this.btn_guna_show.CheckedState.Parent = this.btn_guna_show;
            this.btn_guna_show.CustomImages.Parent = this.btn_guna_show;
            this.guna2Transition1.SetDecoration(this.btn_guna_show, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btn_guna_show.FillColor = System.Drawing.Color.Transparent;
            this.btn_guna_show.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_guna_show.ForeColor = System.Drawing.Color.Transparent;
            this.btn_guna_show.HoverState.Parent = this.btn_guna_show;
            this.btn_guna_show.Image = global::ChapeauUI.Properties.Resources.kisspng_computer_icons_hamburger_button_menu_new_menu_5b34724c3cb0f7_1188475115301637882486;
            this.btn_guna_show.ImageSize = new System.Drawing.Size(60, 60);
            this.btn_guna_show.Location = new System.Drawing.Point(708, 29);
            this.btn_guna_show.Name = "btn_guna_show";
            this.btn_guna_show.ShadowDecoration.Parent = this.btn_guna_show;
            this.btn_guna_show.Size = new System.Drawing.Size(48, 45);
            this.btn_guna_show.TabIndex = 13;
            this.btn_guna_show.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btn_guna_show.Click += new System.EventHandler(this.btn_guna_show_Click);
            // 
            // pictureBox3
            // 
            this.guna2Transition1.SetDecoration(this.pictureBox3, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pictureBox3.Image = global::ChapeauUI.Properties.Resources.logo_chapeau;
            this.pictureBox3.Location = new System.Drawing.Point(14, -1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(168, 94);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.guna2Transition1.SetDecoration(this.pictureBox2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pictureBox2.Image = global::ChapeauUI.Properties.Resources.Rectangle_1;
            this.pictureBox2.Location = new System.Drawing.Point(0, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(768, 94);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // btn_guna_hide
            // 
            this.btn_guna_hide.BackColor = System.Drawing.Color.Transparent;
            this.btn_guna_hide.CheckedState.Parent = this.btn_guna_hide;
            this.btn_guna_hide.CustomImages.Parent = this.btn_guna_hide;
            this.guna2Transition1.SetDecoration(this.btn_guna_hide, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btn_guna_hide.FillColor = System.Drawing.Color.Transparent;
            this.btn_guna_hide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_guna_hide.ForeColor = System.Drawing.Color.Transparent;
            this.btn_guna_hide.HoverState.Parent = this.btn_guna_hide;
            this.btn_guna_hide.Image = global::ChapeauUI.Properties.Resources.kisspng_computer_icons_hamburger_button_menu_new_menu_5b34724c3cb0f7_1188475115301637882486;
            this.btn_guna_hide.ImageSize = new System.Drawing.Size(60, 60);
            this.btn_guna_hide.Location = new System.Drawing.Point(708, 29);
            this.btn_guna_hide.Name = "btn_guna_hide";
            this.btn_guna_hide.ShadowDecoration.Parent = this.btn_guna_hide;
            this.btn_guna_hide.Size = new System.Drawing.Size(48, 45);
            this.btn_guna_hide.TabIndex = 14;
            this.btn_guna_hide.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btn_guna_hide.Click += new System.EventHandler(this.btn_guna_hide_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this.pnlGunaTakingOrder;
            // 
            // btnExitGunaUI
            // 
            this.btnExitGunaUI.Animated = true;
            this.btnExitGunaUI.BorderColor = System.Drawing.Color.Orange;
            this.btnExitGunaUI.BorderThickness = 1;
            this.btnExitGunaUI.CheckedState.Parent = this.btnExitGunaUI;
            this.btnExitGunaUI.CustomImages.Parent = this.btnExitGunaUI;
            this.guna2Transition1.SetDecoration(this.btnExitGunaUI, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnExitGunaUI.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExitGunaUI.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnExitGunaUI.ForeColor = System.Drawing.Color.White;
            this.btnExitGunaUI.HoverState.Parent = this.btnExitGunaUI;
            this.btnExitGunaUI.IndicateFocus = true;
            this.btnExitGunaUI.Location = new System.Drawing.Point(74, 876);
            this.btnExitGunaUI.Name = "btnExitGunaUI";
            this.btnExitGunaUI.ShadowDecoration.Parent = this.btnExitGunaUI;
            this.btnExitGunaUI.Size = new System.Drawing.Size(114, 45);
            this.btnExitGunaUI.TabIndex = 27;
            this.btnExitGunaUI.Text = "Exit";
            this.btnExitGunaUI.Click += new System.EventHandler(this.btnExitGunaUI_Click);
            // 
            // gunBtnHome
            // 
            this.gunBtnHome.Animated = true;
            this.gunBtnHome.BackColor = System.Drawing.Color.Transparent;
            this.gunBtnHome.CheckedState.Parent = this.gunBtnHome;
            this.gunBtnHome.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunBtnHome.CustomImages.Parent = this.gunBtnHome;
            this.guna2Transition1.SetDecoration(this.gunBtnHome, Guna.UI2.AnimatorNS.DecorationType.None);
            this.gunBtnHome.FillColor = System.Drawing.Color.Empty;
            this.gunBtnHome.FillColor2 = System.Drawing.Color.Empty;
            this.gunBtnHome.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.gunBtnHome.ForeColor = System.Drawing.Color.White;
            this.gunBtnHome.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(150)))), ((int)(((byte)(44)))));
            this.gunBtnHome.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gunBtnHome.HoverState.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunBtnHome.HoverState.Parent = this.gunBtnHome;
            this.gunBtnHome.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunBtnHome.Location = new System.Drawing.Point(10, 24);
            this.gunBtnHome.Name = "gunBtnHome";
            this.gunBtnHome.ShadowDecoration.Parent = this.gunBtnHome;
            this.gunBtnHome.Size = new System.Drawing.Size(178, 45);
            this.gunBtnHome.TabIndex = 28;
            this.gunBtnHome.Text = "Home";
            this.gunBtnHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunBtnHome.TextOffset = new System.Drawing.Point(50, 0);
            this.gunBtnHome.UseTransparentBackground = true;
            // 
            // gunBtnTableView
            // 
            this.gunBtnTableView.Animated = true;
            this.gunBtnTableView.BackColor = System.Drawing.Color.Transparent;
            this.gunBtnTableView.CheckedState.Parent = this.gunBtnTableView;
            this.gunBtnTableView.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunBtnTableView.CustomImages.Parent = this.gunBtnTableView;
            this.guna2Transition1.SetDecoration(this.gunBtnTableView, Guna.UI2.AnimatorNS.DecorationType.None);
            this.gunBtnTableView.FillColor = System.Drawing.Color.Empty;
            this.gunBtnTableView.FillColor2 = System.Drawing.Color.Empty;
            this.gunBtnTableView.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.gunBtnTableView.ForeColor = System.Drawing.Color.White;
            this.gunBtnTableView.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(150)))), ((int)(((byte)(44)))));
            this.gunBtnTableView.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gunBtnTableView.HoverState.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunBtnTableView.HoverState.Parent = this.gunBtnTableView;
            this.gunBtnTableView.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunBtnTableView.Location = new System.Drawing.Point(10, 75);
            this.gunBtnTableView.Name = "gunBtnTableView";
            this.gunBtnTableView.ShadowDecoration.Parent = this.gunBtnTableView;
            this.gunBtnTableView.Size = new System.Drawing.Size(178, 45);
            this.gunBtnTableView.TabIndex = 29;
            this.gunBtnTableView.Text = "Table view";
            this.gunBtnTableView.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunBtnTableView.TextOffset = new System.Drawing.Point(50, 0);
            this.gunBtnTableView.UseTransparentBackground = true;
            // 
            // gunBtnMenuOptions
            // 
            this.gunBtnMenuOptions.Animated = true;
            this.gunBtnMenuOptions.BackColor = System.Drawing.Color.Transparent;
            this.gunBtnMenuOptions.CheckedState.Parent = this.gunBtnMenuOptions;
            this.gunBtnMenuOptions.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunBtnMenuOptions.CustomImages.Parent = this.gunBtnMenuOptions;
            this.guna2Transition1.SetDecoration(this.gunBtnMenuOptions, Guna.UI2.AnimatorNS.DecorationType.None);
            this.gunBtnMenuOptions.FillColor = System.Drawing.Color.Empty;
            this.gunBtnMenuOptions.FillColor2 = System.Drawing.Color.Empty;
            this.gunBtnMenuOptions.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.gunBtnMenuOptions.ForeColor = System.Drawing.Color.White;
            this.gunBtnMenuOptions.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(150)))), ((int)(((byte)(44)))));
            this.gunBtnMenuOptions.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gunBtnMenuOptions.HoverState.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunBtnMenuOptions.HoverState.Parent = this.gunBtnMenuOptions;
            this.gunBtnMenuOptions.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunBtnMenuOptions.Location = new System.Drawing.Point(10, 126);
            this.gunBtnMenuOptions.Name = "gunBtnMenuOptions";
            this.gunBtnMenuOptions.ShadowDecoration.Parent = this.gunBtnMenuOptions;
            this.gunBtnMenuOptions.Size = new System.Drawing.Size(178, 45);
            this.gunBtnMenuOptions.TabIndex = 30;
            this.gunBtnMenuOptions.Text = "Menu";
            this.gunBtnMenuOptions.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunBtnMenuOptions.TextOffset = new System.Drawing.Point(50, 0);
            this.gunBtnMenuOptions.UseTransparentBackground = true;
            // 
            // gunBtnOrderCart
            // 
            this.gunBtnOrderCart.Animated = true;
            this.gunBtnOrderCart.BackColor = System.Drawing.Color.Transparent;
            this.gunBtnOrderCart.CheckedState.Parent = this.gunBtnOrderCart;
            this.gunBtnOrderCart.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunBtnOrderCart.CustomImages.Parent = this.gunBtnOrderCart;
            this.guna2Transition1.SetDecoration(this.gunBtnOrderCart, Guna.UI2.AnimatorNS.DecorationType.None);
            this.gunBtnOrderCart.FillColor = System.Drawing.Color.Empty;
            this.gunBtnOrderCart.FillColor2 = System.Drawing.Color.Empty;
            this.gunBtnOrderCart.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.gunBtnOrderCart.ForeColor = System.Drawing.Color.White;
            this.gunBtnOrderCart.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(150)))), ((int)(((byte)(44)))));
            this.gunBtnOrderCart.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gunBtnOrderCart.HoverState.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunBtnOrderCart.HoverState.Parent = this.gunBtnOrderCart;
            this.gunBtnOrderCart.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunBtnOrderCart.Location = new System.Drawing.Point(10, 177);
            this.gunBtnOrderCart.Name = "gunBtnOrderCart";
            this.gunBtnOrderCart.ShadowDecoration.Parent = this.gunBtnOrderCart;
            this.gunBtnOrderCart.Size = new System.Drawing.Size(178, 45);
            this.gunBtnOrderCart.TabIndex = 31;
            this.gunBtnOrderCart.Text = "Order cart";
            this.gunBtnOrderCart.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gunBtnOrderCart.TextOffset = new System.Drawing.Point(50, 0);
            this.gunBtnOrderCart.UseTransparentBackground = true;
            // 
            // TakingOrderForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(768, 1024);
            this.Controls.Add(this.btn_guna_hide);
            this.Controls.Add(this.btn_guna_show);
            this.Controls.Add(this.lblApplicationSubState);
            this.Controls.Add(this.lblApplicationState);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pnlGunaTakingOrder);
            this.guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TakingOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TakingOrderForm";
            this.pnlGunaTakingOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlGunaTakingOrder;
        private System.Windows.Forms.Label lblApplicationSubState;
        private System.Windows.Forms.Label lblApplicationState;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Transition guna2Transition1;
        private Guna.UI2.WinForms.Guna2Button btn_guna_show;
        private Guna.UI2.WinForms.Guna2Button btn_guna_hide;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button btnExitGunaUI;
        private Guna.UI2.WinForms.Guna2GradientButton gunBtnHome;
        private Guna.UI2.WinForms.Guna2GradientButton gunBtnOrderCart;
        private Guna.UI2.WinForms.Guna2GradientButton gunBtnMenuOptions;
        private Guna.UI2.WinForms.Guna2GradientButton gunBtnTableView;
    }
}