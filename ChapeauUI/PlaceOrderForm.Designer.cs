
namespace ChapeauUI
{
    partial class PlaceOrderForm
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
            this.pnlStaticBar = new System.Windows.Forms.Panel();
            this.lblBack = new System.Windows.Forms.Label();
            this.lblForward = new System.Windows.Forms.Label();
            this.hamburgerIcon = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblApplicationSubState = new System.Windows.Forms.Label();
            this.lblWhereWeAre = new System.Windows.Forms.Label();
            this.pnlHamburger = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblOrderCart = new System.Windows.Forms.Label();
            this.lblMenuOptions = new System.Windows.Forms.Label();
            this.lblTableView = new System.Windows.Forms.Label();
            this.lblHome = new System.Windows.Forms.Label();
            this.pnlMenuOptions = new System.Windows.Forms.Panel();
            this.btnDrinksAlcMenu = new System.Windows.Forms.Button();
            this.btnDinnerMenu = new System.Windows.Forms.Button();
            this.btnDrinksNonAlcMenu = new System.Windows.Forms.Button();
            this.btnLunchMenu = new System.Windows.Forms.Button();
            this.pnlFoodMenu = new System.Windows.Forms.Panel();
            this.pnlAllMenuInside = new System.Windows.Forms.Panel();
            this.numericUpDownFoodMenu = new System.Windows.Forms.NumericUpDown();
            this.listBoxSelectedFoodItem = new System.Windows.Forms.ListBox();
            this.btnAddFoodItem = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.listBoxThirdListPrice = new System.Windows.Forms.ListBox();
            this.listBoxSecondListPrice = new System.Windows.Forms.ListBox();
            this.listBoxFirstListPrice = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.listBoxThirdList = new System.Windows.Forms.ListBox();
            this.listBoxSecondList = new System.Windows.Forms.ListBox();
            this.listBoxFirstList = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.pnlStaticBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hamburgerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.pnlHamburger.SuspendLayout();
            this.pnlMenuOptions.SuspendLayout();
            this.pnlFoodMenu.SuspendLayout();
            this.pnlAllMenuInside.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFoodMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlStaticBar
            // 
            this.pnlStaticBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(150)))), ((int)(((byte)(44)))));
            this.pnlStaticBar.Controls.Add(this.lblBack);
            this.pnlStaticBar.Controls.Add(this.lblForward);
            this.pnlStaticBar.Controls.Add(this.hamburgerIcon);
            this.pnlStaticBar.Controls.Add(this.pictureBox3);
            this.pnlStaticBar.Controls.Add(this.lblApplicationSubState);
            this.pnlStaticBar.Controls.Add(this.lblWhereWeAre);
            this.pnlStaticBar.Location = new System.Drawing.Point(-1, -1);
            this.pnlStaticBar.Name = "pnlStaticBar";
            this.pnlStaticBar.Size = new System.Drawing.Size(756, 94);
            this.pnlStaticBar.TabIndex = 0;
            // 
            // lblBack
            // 
            this.lblBack.AutoSize = true;
            this.lblBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBack.ForeColor = System.Drawing.Color.White;
            this.lblBack.Location = new System.Drawing.Point(270, 10);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(41, 42);
            this.lblBack.TabIndex = 12;
            this.lblBack.Text = "<";
            // 
            // lblForward
            // 
            this.lblForward.AutoSize = true;
            this.lblForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForward.ForeColor = System.Drawing.Color.White;
            this.lblForward.Location = new System.Drawing.Point(440, 10);
            this.lblForward.Name = "lblForward";
            this.lblForward.Size = new System.Drawing.Size(41, 42);
            this.lblForward.TabIndex = 11;
            this.lblForward.Text = ">";
            // 
            // hamburgerIcon
            // 
            this.hamburgerIcon.BackColor = System.Drawing.Color.Transparent;
            this.hamburgerIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hamburgerIcon.Image = global::ChapeauUI.Properties.Resources.hamburger_menu;
            this.hamburgerIcon.Location = new System.Drawing.Point(670, 0);
            this.hamburgerIcon.Name = "hamburgerIcon";
            this.hamburgerIcon.Size = new System.Drawing.Size(71, 94);
            this.hamburgerIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hamburgerIcon.TabIndex = 10;
            this.hamburgerIcon.TabStop = false;
            this.hamburgerIcon.Click += new System.EventHandler(this.hamburgerIcon_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ChapeauUI.Properties.Resources.logo_chapeau;
            this.pictureBox3.Location = new System.Drawing.Point(13, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(156, 94);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // lblApplicationSubState
            // 
            this.lblApplicationSubState.AutoSize = true;
            this.lblApplicationSubState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(150)))), ((int)(((byte)(44)))));
            this.lblApplicationSubState.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationSubState.ForeColor = System.Drawing.Color.White;
            this.lblApplicationSubState.Location = new System.Drawing.Point(320, 52);
            this.lblApplicationSubState.Name = "lblApplicationSubState";
            this.lblApplicationSubState.Size = new System.Drawing.Size(136, 24);
            this.lblApplicationSubState.TabIndex = 8;
            this.lblApplicationSubState.Text = "Welcome back";
            this.lblApplicationSubState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWhereWeAre
            // 
            this.lblWhereWeAre.AutoSize = true;
            this.lblWhereWeAre.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F);
            this.lblWhereWeAre.ForeColor = System.Drawing.Color.White;
            this.lblWhereWeAre.Location = new System.Drawing.Point(317, 10);
            this.lblWhereWeAre.Name = "lblWhereWeAre";
            this.lblWhereWeAre.Size = new System.Drawing.Size(117, 42);
            this.lblWhereWeAre.TabIndex = 0;
            this.lblWhereWeAre.Text = "Home";
            // 
            // pnlHamburger
            // 
            this.pnlHamburger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(150)))), ((int)(((byte)(44)))));
            this.pnlHamburger.Controls.Add(this.button1);
            this.pnlHamburger.Controls.Add(this.lblOrderCart);
            this.pnlHamburger.Controls.Add(this.lblMenuOptions);
            this.pnlHamburger.Controls.Add(this.lblTableView);
            this.pnlHamburger.Controls.Add(this.lblHome);
            this.pnlHamburger.Location = new System.Drawing.Point(538, 92);
            this.pnlHamburger.Name = "pnlHamburger";
            this.pnlHamburger.Size = new System.Drawing.Size(217, 898);
            this.pnlHamburger.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(121, 858);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 36);
            this.button1.TabIndex = 8;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // pnlMenuOptions
            // 
            this.pnlMenuOptions.BackColor = System.Drawing.Color.White;
            this.pnlMenuOptions.Controls.Add(this.btnDrinksAlcMenu);
            this.pnlMenuOptions.Controls.Add(this.btnDinnerMenu);
            this.pnlMenuOptions.Controls.Add(this.btnDrinksNonAlcMenu);
            this.pnlMenuOptions.Controls.Add(this.btnLunchMenu);
            this.pnlMenuOptions.Location = new System.Drawing.Point(-1, 95);
            this.pnlMenuOptions.Name = "pnlMenuOptions";
            this.pnlMenuOptions.Size = new System.Drawing.Size(756, 898);
            this.pnlMenuOptions.TabIndex = 11;
            // 
            // btnDrinksAlcMenu
            // 
            this.btnDrinksAlcMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDrinksAlcMenu.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrinksAlcMenu.ForeColor = System.Drawing.Color.White;
            this.btnDrinksAlcMenu.Location = new System.Drawing.Point(197, 718);
            this.btnDrinksAlcMenu.Name = "btnDrinksAlcMenu";
            this.btnDrinksAlcMenu.Size = new System.Drawing.Size(354, 77);
            this.btnDrinksAlcMenu.TabIndex = 3;
            this.btnDrinksAlcMenu.Text = "Drinks(alc)";
            this.btnDrinksAlcMenu.UseVisualStyleBackColor = false;
            this.btnDrinksAlcMenu.Click += new System.EventHandler(this.btnDrinksAlcMenu_Click);
            // 
            // btnDinnerMenu
            // 
            this.btnDinnerMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDinnerMenu.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDinnerMenu.ForeColor = System.Drawing.Color.White;
            this.btnDinnerMenu.Location = new System.Drawing.Point(197, 333);
            this.btnDinnerMenu.Name = "btnDinnerMenu";
            this.btnDinnerMenu.Size = new System.Drawing.Size(354, 77);
            this.btnDinnerMenu.TabIndex = 2;
            this.btnDinnerMenu.Text = "Dinner";
            this.btnDinnerMenu.UseVisualStyleBackColor = false;
            this.btnDinnerMenu.Click += new System.EventHandler(this.btnDinnerMenu_Click);
            // 
            // btnDrinksNonAlcMenu
            // 
            this.btnDrinksNonAlcMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDrinksNonAlcMenu.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrinksNonAlcMenu.ForeColor = System.Drawing.Color.White;
            this.btnDrinksNonAlcMenu.Location = new System.Drawing.Point(197, 522);
            this.btnDrinksNonAlcMenu.Name = "btnDrinksNonAlcMenu";
            this.btnDrinksNonAlcMenu.Size = new System.Drawing.Size(354, 77);
            this.btnDrinksNonAlcMenu.TabIndex = 1;
            this.btnDrinksNonAlcMenu.Text = "Drinks(non-alc)";
            this.btnDrinksNonAlcMenu.UseVisualStyleBackColor = false;
            this.btnDrinksNonAlcMenu.Click += new System.EventHandler(this.btnDrinksNonAlcMenu_Click);
            // 
            // btnLunchMenu
            // 
            this.btnLunchMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLunchMenu.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLunchMenu.ForeColor = System.Drawing.Color.White;
            this.btnLunchMenu.Location = new System.Drawing.Point(197, 143);
            this.btnLunchMenu.Name = "btnLunchMenu";
            this.btnLunchMenu.Size = new System.Drawing.Size(354, 77);
            this.btnLunchMenu.TabIndex = 0;
            this.btnLunchMenu.Text = "Lunch";
            this.btnLunchMenu.UseVisualStyleBackColor = false;
            this.btnLunchMenu.Click += new System.EventHandler(this.btnLunchMenu_Click);
            // 
            // pnlFoodMenu
            // 
            this.pnlFoodMenu.BackColor = System.Drawing.Color.White;
            this.pnlFoodMenu.Controls.Add(this.pnlAllMenuInside);
            this.pnlFoodMenu.Location = new System.Drawing.Point(2, 99);
            this.pnlFoodMenu.Name = "pnlFoodMenu";
            this.pnlFoodMenu.Size = new System.Drawing.Size(686, 891);
            this.pnlFoodMenu.TabIndex = 14;
            // 
            // pnlAllMenuInside
            // 
            this.pnlAllMenuInside.BackColor = System.Drawing.Color.White;
            this.pnlAllMenuInside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAllMenuInside.Controls.Add(this.numericUpDownFoodMenu);
            this.pnlAllMenuInside.Controls.Add(this.listBoxSelectedFoodItem);
            this.pnlAllMenuInside.Controls.Add(this.btnAddFoodItem);
            this.pnlAllMenuInside.Controls.Add(this.label14);
            this.pnlAllMenuInside.Controls.Add(this.listBoxThirdListPrice);
            this.pnlAllMenuInside.Controls.Add(this.listBoxSecondListPrice);
            this.pnlAllMenuInside.Controls.Add(this.listBoxFirstListPrice);
            this.pnlAllMenuInside.Controls.Add(this.label15);
            this.pnlAllMenuInside.Controls.Add(this.label16);
            this.pnlAllMenuInside.Controls.Add(this.listBoxThirdList);
            this.pnlAllMenuInside.Controls.Add(this.listBoxSecondList);
            this.pnlAllMenuInside.Controls.Add(this.listBoxFirstList);
            this.pnlAllMenuInside.Controls.Add(this.label17);
            this.pnlAllMenuInside.Controls.Add(this.label18);
            this.pnlAllMenuInside.Controls.Add(this.label19);
            this.pnlAllMenuInside.Location = new System.Drawing.Point(61, 34);
            this.pnlAllMenuInside.Name = "pnlAllMenuInside";
            this.pnlAllMenuInside.Size = new System.Drawing.Size(622, 835);
            this.pnlAllMenuInside.TabIndex = 0;
            // 
            // numericUpDownFoodMenu
            // 
            this.numericUpDownFoodMenu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.numericUpDownFoodMenu.Location = new System.Drawing.Point(520, 697);
            this.numericUpDownFoodMenu.Name = "numericUpDownFoodMenu";
            this.numericUpDownFoodMenu.Size = new System.Drawing.Size(70, 33);
            this.numericUpDownFoodMenu.TabIndex = 93;
            this.numericUpDownFoodMenu.ValueChanged += new System.EventHandler(this.numericUpDownFoodMenu_ValueChanged);
            // 
            // listBoxSelectedFoodItem
            // 
            this.listBoxSelectedFoodItem.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.listBoxSelectedFoodItem.FormattingEnabled = true;
            this.listBoxSelectedFoodItem.ItemHeight = 30;
            this.listBoxSelectedFoodItem.Location = new System.Drawing.Point(16, 697);
            this.listBoxSelectedFoodItem.Name = "listBoxSelectedFoodItem";
            this.listBoxSelectedFoodItem.Size = new System.Drawing.Size(482, 34);
            this.listBoxSelectedFoodItem.TabIndex = 92;
            this.listBoxSelectedFoodItem.SelectedIndexChanged += new System.EventHandler(this.listBoxSelectedFoodItem_SelectedIndexChanged);
            // 
            // btnAddFoodItem
            // 
            this.btnAddFoodItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddFoodItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFoodItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddFoodItem.Location = new System.Drawing.Point(406, 754);
            this.btnAddFoodItem.Name = "btnAddFoodItem";
            this.btnAddFoodItem.Size = new System.Drawing.Size(187, 49);
            this.btnAddFoodItem.TabIndex = 91;
            this.btnAddFoodItem.Text = "Add to cart";
            this.btnAddFoodItem.UseVisualStyleBackColor = false;
            this.btnAddFoodItem.Click += new System.EventHandler(this.btnAddFoodItem_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(15, 657);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(108, 20);
            this.label14.TabIndex = 89;
            this.label14.Text = "Selected Item";
            // 
            // listBoxThirdListPrice
            // 
            this.listBoxThirdListPrice.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxThirdListPrice.FormattingEnabled = true;
            this.listBoxThirdListPrice.ItemHeight = 30;
            this.listBoxThirdListPrice.Location = new System.Drawing.Point(520, 512);
            this.listBoxThirdListPrice.Name = "listBoxThirdListPrice";
            this.listBoxThirdListPrice.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxThirdListPrice.Size = new System.Drawing.Size(83, 124);
            this.listBoxThirdListPrice.TabIndex = 43;
            // 
            // listBoxSecondListPrice
            // 
            this.listBoxSecondListPrice.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSecondListPrice.FormattingEnabled = true;
            this.listBoxSecondListPrice.ItemHeight = 30;
            this.listBoxSecondListPrice.Location = new System.Drawing.Point(520, 265);
            this.listBoxSecondListPrice.Name = "listBoxSecondListPrice";
            this.listBoxSecondListPrice.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxSecondListPrice.Size = new System.Drawing.Size(83, 184);
            this.listBoxSecondListPrice.TabIndex = 42;
            // 
            // listBoxFirstListPrice
            // 
            this.listBoxFirstListPrice.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxFirstListPrice.FormattingEnabled = true;
            this.listBoxFirstListPrice.ItemHeight = 30;
            this.listBoxFirstListPrice.Location = new System.Drawing.Point(520, 57);
            this.listBoxFirstListPrice.Name = "listBoxFirstListPrice";
            this.listBoxFirstListPrice.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxFirstListPrice.Size = new System.Drawing.Size(83, 154);
            this.listBoxFirstListPrice.TabIndex = 41;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 464);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 24);
            this.label15.TabIndex = 9;
            this.label15.Text = "Desserts";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 225);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 24);
            this.label16.TabIndex = 8;
            this.label16.Text = "Mains";
            // 
            // listBoxThirdList
            // 
            this.listBoxThirdList.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxThirdList.FormattingEnabled = true;
            this.listBoxThirdList.ItemHeight = 30;
            this.listBoxThirdList.Location = new System.Drawing.Point(16, 512);
            this.listBoxThirdList.Name = "listBoxThirdList";
            this.listBoxThirdList.Size = new System.Drawing.Size(482, 124);
            this.listBoxThirdList.TabIndex = 7;
            this.listBoxThirdList.SelectedIndexChanged += new System.EventHandler(this.listBoxThirdList_SelectedIndexChanged);
            // 
            // listBoxSecondList
            // 
            this.listBoxSecondList.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSecondList.FormattingEnabled = true;
            this.listBoxSecondList.ItemHeight = 30;
            this.listBoxSecondList.Location = new System.Drawing.Point(16, 265);
            this.listBoxSecondList.Name = "listBoxSecondList";
            this.listBoxSecondList.Size = new System.Drawing.Size(482, 184);
            this.listBoxSecondList.TabIndex = 6;
            this.listBoxSecondList.SelectedIndexChanged += new System.EventHandler(this.listBoxSecondList_SelectedIndexChanged);
            // 
            // listBoxFirstList
            // 
            this.listBoxFirstList.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxFirstList.FormattingEnabled = true;
            this.listBoxFirstList.ItemHeight = 30;
            this.listBoxFirstList.Location = new System.Drawing.Point(16, 57);
            this.listBoxFirstList.Name = "listBoxFirstList";
            this.listBoxFirstList.Size = new System.Drawing.Size(482, 154);
            this.listBoxFirstList.TabIndex = 5;
            this.listBoxFirstList.SelectedIndexChanged += new System.EventHandler(this.listBoxFirstList_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 24);
            this.label17.TabIndex = 3;
            this.label17.Text = "Starters";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(519, 664);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 20);
            this.label18.TabIndex = 2;
            this.label18.Text = "Quantity";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(516, 15);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 20);
            this.label19.TabIndex = 1;
            this.label19.Text = "Price";
            // 
            // PlaceOrderForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(752, 985);
            this.Controls.Add(this.pnlFoodMenu);
            this.Controls.Add(this.pnlHamburger);
            this.Controls.Add(this.pnlStaticBar);
            this.Controls.Add(this.pnlMenuOptions);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlaceOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlaceOrderForm";
            this.Load += new System.EventHandler(this.PlaceOrderForm_Load);
            this.pnlStaticBar.ResumeLayout(false);
            this.pnlStaticBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hamburgerIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.pnlHamburger.ResumeLayout(false);
            this.pnlHamburger.PerformLayout();
            this.pnlMenuOptions.ResumeLayout(false);
            this.pnlFoodMenu.ResumeLayout(false);
            this.pnlAllMenuInside.ResumeLayout(false);
            this.pnlAllMenuInside.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFoodMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlStaticBar;
        private System.Windows.Forms.Label lblWhereWeAre;
        private System.Windows.Forms.Label lblApplicationSubState;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox hamburgerIcon;
        private System.Windows.Forms.Panel pnlHamburger;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblOrderCart;
        private System.Windows.Forms.Label lblMenuOptions;
        private System.Windows.Forms.Label lblTableView;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Panel pnlMenuOptions;
        private System.Windows.Forms.Button btnDrinksAlcMenu;
        private System.Windows.Forms.Button btnDinnerMenu;
        private System.Windows.Forms.Button btnDrinksNonAlcMenu;
        private System.Windows.Forms.Button btnLunchMenu;
        private System.Windows.Forms.Label lblBack;
        private System.Windows.Forms.Label lblForward;
        private System.Windows.Forms.Panel pnlFoodMenu;
        private System.Windows.Forms.Panel pnlAllMenuInside;
        private System.Windows.Forms.NumericUpDown numericUpDownFoodMenu;
        private System.Windows.Forms.ListBox listBoxSelectedFoodItem;
        private System.Windows.Forms.Button btnAddFoodItem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox listBoxThirdListPrice;
        private System.Windows.Forms.ListBox listBoxSecondListPrice;
        private System.Windows.Forms.ListBox listBoxFirstListPrice;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListBox listBoxThirdList;
        private System.Windows.Forms.ListBox listBoxSecondList;
        private System.Windows.Forms.ListBox listBoxFirstList;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
    }
}