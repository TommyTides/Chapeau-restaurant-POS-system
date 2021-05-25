
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TakingOrderForm));
            this.xuiSplashScreen1 = new XanderUI.XUISplashScreen();
            this.WorkingArea = new System.Windows.Forms.Panel();
            this.xuiSlidingPanel1 = new XanderUI.XUISlidingPanel();
            this.xuiSwitch1 = new XanderUI.XUISwitch();
            this.xuiButton1 = new XanderUI.XUIButton();
            this.xuiFormDesign1 = new XanderUI.XUIFormDesign();
            this.xuiFormDesign1.WorkingArea.SuspendLayout();
            this.xuiFormDesign1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xuiSplashScreen1
            // 
            this.xuiSplashScreen1.AllowDragging = true;
            this.xuiSplashScreen1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.xuiSplashScreen1.BottomText = "Ordering System";
            this.xuiSplashScreen1.BottomTextColor = System.Drawing.Color.White;
            this.xuiSplashScreen1.BottomTextSize = 16;
            this.xuiSplashScreen1.EllipseCornerRadius = 10;
            this.xuiSplashScreen1.IsEllipse = false;
            this.xuiSplashScreen1.LoadedColor = System.Drawing.Color.DodgerBlue;
            this.xuiSplashScreen1.ProgressBarStyle = XanderUI.XUIFlatProgressBar.Style.Material;
            this.xuiSplashScreen1.SecondsDisplayed = 3000;
            this.xuiSplashScreen1.ShowProgressBar = true;
            this.xuiSplashScreen1.SplashSize = new System.Drawing.Size(450, 280);
            this.xuiSplashScreen1.TopText = "Chapeau";
            this.xuiSplashScreen1.TopTextColor = System.Drawing.Color.Coral;
            this.xuiSplashScreen1.TopTextSize = 36;
            this.xuiSplashScreen1.UnloadedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            // 
            // WorkingArea
            // 
            this.WorkingArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.WorkingArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkingArea.Location = new System.Drawing.Point(0, 39);
            this.WorkingArea.Name = "WorkingArea";
            this.WorkingArea.Size = new System.Drawing.Size(768, 985);
            this.WorkingArea.TabIndex = 0;
            // 
            // xuiSlidingPanel1
            // 
            this.xuiSlidingPanel1.BottomLeft = System.Drawing.Color.Black;
            this.xuiSlidingPanel1.BottomRight = System.Drawing.Color.DodgerBlue;
            this.xuiSlidingPanel1.CollapseControl = this.xuiSwitch1;
            this.xuiSlidingPanel1.Collapsed = true;
            this.xuiSlidingPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.xuiSlidingPanel1.HideControls = false;
            this.xuiSlidingPanel1.Location = new System.Drawing.Point(0, 0);
            this.xuiSlidingPanel1.Name = "xuiSlidingPanel1";
            this.xuiSlidingPanel1.PanelWidthCollapsed = 50;
            this.xuiSlidingPanel1.PanelWidthExpanded = 200;
            this.xuiSlidingPanel1.PrimerColor = System.Drawing.Color.White;
            this.xuiSlidingPanel1.Size = new System.Drawing.Size(50, 985);
            this.xuiSlidingPanel1.Style = XanderUI.XUIGradientPanel.GradientStyle.Corners;
            this.xuiSlidingPanel1.TabIndex = 0;
            this.xuiSlidingPanel1.TopLeft = System.Drawing.Color.Black;
            this.xuiSlidingPanel1.TopRight = System.Drawing.Color.Black;
            // 
            // xuiSwitch1
            // 
            this.xuiSwitch1.BackColor = System.Drawing.Color.Transparent;
            this.xuiSwitch1.HandleOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(71)))), ((int)(((byte)(89)))));
            this.xuiSwitch1.HandleOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(180)))), ((int)(((byte)(120)))));
            this.xuiSwitch1.Location = new System.Drawing.Point(696, 13);
            this.xuiSwitch1.Name = "xuiSwitch1";
            this.xuiSwitch1.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(129)))), ((int)(((byte)(136)))));
            this.xuiSwitch1.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(217)))), ((int)(((byte)(174)))));
            this.xuiSwitch1.Size = new System.Drawing.Size(60, 30);
            this.xuiSwitch1.SwitchState = XanderUI.XUISwitch.State.On;
            this.xuiSwitch1.SwitchStyle = XanderUI.XUISwitch.Style.Horizontal;
            this.xuiSwitch1.TabIndex = 2;
            this.xuiSwitch1.Text = "xuiSwitch1";
            // 
            // xuiButton1
            // 
            this.xuiButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xuiButton1.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xuiButton1.ButtonImage")));
            this.xuiButton1.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuiButton1.ButtonText = "Exit";
            this.xuiButton1.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.xuiButton1.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.xuiButton1.CornerRadius = 5;
            this.xuiButton1.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton1.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.xuiButton1.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.xuiButton1.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuiButton1.Location = new System.Drawing.Point(556, 519);
            this.xuiButton1.Name = "xuiButton1";
            this.xuiButton1.Size = new System.Drawing.Size(200, 50);
            this.xuiButton1.TabIndex = 3;
            this.xuiButton1.TextColor = System.Drawing.Color.DodgerBlue;
            this.xuiButton1.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton1.Click += new System.EventHandler(this.xuiButton1_Click);
            // 
            // xuiFormDesign1
            // 
            this.xuiFormDesign1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.xuiFormDesign1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xuiFormDesign1.ExitApplication = true;
            this.xuiFormDesign1.FormStyle = XanderUI.XUIFormDesign.Style.MacOS;
            this.xuiFormDesign1.Location = new System.Drawing.Point(0, 0);
            this.xuiFormDesign1.MaterialBackColor = System.Drawing.Color.DodgerBlue;
            this.xuiFormDesign1.MaterialForeColor = System.Drawing.Color.White;
            this.xuiFormDesign1.Name = "xuiFormDesign1";
            this.xuiFormDesign1.ShowMaximize = true;
            this.xuiFormDesign1.ShowMinimize = true;
            this.xuiFormDesign1.Size = new System.Drawing.Size(768, 1024);
            this.xuiFormDesign1.TabIndex = 3;
            this.xuiFormDesign1.TitleText = "Form Name";
            // 
            // xuiFormDesign1.WorkingArea
            // 
            this.xuiFormDesign1.WorkingArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.xuiFormDesign1.WorkingArea.Controls.Add(this.xuiButton1);
            this.xuiFormDesign1.WorkingArea.Controls.Add(this.xuiSwitch1);
            this.xuiFormDesign1.WorkingArea.Controls.Add(this.xuiSlidingPanel1);
            this.xuiFormDesign1.WorkingArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xuiFormDesign1.WorkingArea.Location = new System.Drawing.Point(0, 39);
            this.xuiFormDesign1.WorkingArea.Name = "WorkingArea";
            this.xuiFormDesign1.WorkingArea.Size = new System.Drawing.Size(768, 985);
            this.xuiFormDesign1.WorkingArea.TabIndex = 0;
            // 
            // TakingOrderForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(768, 1024);
            this.Controls.Add(this.xuiFormDesign1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TakingOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TakingOrderForm";
            this.Load += new System.EventHandler(this.TakingOrderForm_Load);
            this.xuiFormDesign1.WorkingArea.ResumeLayout(false);
            this.xuiFormDesign1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private XanderUI.XUISplashScreen xuiSplashScreen1;
        private System.Windows.Forms.Panel WorkingArea;
        private XanderUI.XUISlidingPanel xuiSlidingPanel1;
        private XanderUI.XUISwitch xuiSwitch1;
        private XanderUI.XUIButton xuiButton1;
        private XanderUI.XUIFormDesign xuiFormDesign1;
    }
}