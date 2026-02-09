namespace project_datahave_
{
    partial class mainform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainform));
            this.Sidebar2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.admin_acces = new System.Windows.Forms.Button();
            this.ManageFlow_pnl = new System.Windows.Forms.FlowLayoutPanel();
            this.Manage_Money_but = new System.Windows.Forms.Button();
            this.Deposit_butt = new System.Windows.Forms.Button();
            this.Withdraw_butt = new System.Windows.Forms.Button();
            this.Transfer_butt = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.logout_button = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Manage_Account_butt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sidetimer = new System.Windows.Forms.Timer(this.components);
            this.Manage_money_timer = new System.Windows.Forms.Timer(this.components);
            this.welcomeTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.Sidebar2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.ManageFlow_pnl.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Menu)).BeginInit();
            this.SuspendLayout();
            // 
            // Sidebar2
            // 
            this.Sidebar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Sidebar2.Controls.Add(this.panel6);
            this.Sidebar2.Controls.Add(this.ManageFlow_pnl);
            this.Sidebar2.Controls.Add(this.panel5);
            this.Sidebar2.Controls.Add(this.panel4);
            this.Sidebar2.Controls.Add(this.panel1);
            this.Sidebar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Sidebar2.Location = new System.Drawing.Point(0, 0);
            this.Sidebar2.MaximumSize = new System.Drawing.Size(265, 658);
            this.Sidebar2.MinimumSize = new System.Drawing.Size(59, 658);
            this.Sidebar2.Name = "Sidebar2";
            this.Sidebar2.Size = new System.Drawing.Size(265, 658);
            this.Sidebar2.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.admin_acces);
            this.panel6.Location = new System.Drawing.Point(5, 526);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panel6.Size = new System.Drawing.Size(341, 71);
            this.panel6.TabIndex = 8;
            // 
            // admin_acces
            // 
            this.admin_acces.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.admin_acces.FlatAppearance.BorderSize = 0;
            this.admin_acces.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.admin_acces.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(215)))), ((int)(((byte)(110)))));
            this.admin_acces.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.admin_acces.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_acces.ForeColor = System.Drawing.Color.White;
            this.admin_acces.Image = ((System.Drawing.Image)(resources.GetObject("admin_acces.Image")));
            this.admin_acces.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.admin_acces.Location = new System.Drawing.Point(0, -17);
            this.admin_acces.Name = "admin_acces";
            this.admin_acces.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.admin_acces.Size = new System.Drawing.Size(259, 97);
            this.admin_acces.TabIndex = 0;
            this.admin_acces.Text = "Admin Access";
            this.admin_acces.UseVisualStyleBackColor = false;
            this.admin_acces.Click += new System.EventHandler(this.admin_acces_Click);
            // 
            // ManageFlow_pnl
            // 
            this.ManageFlow_pnl.Controls.Add(this.Manage_Money_but);
            this.ManageFlow_pnl.Controls.Add(this.Deposit_butt);
            this.ManageFlow_pnl.Controls.Add(this.Withdraw_butt);
            this.ManageFlow_pnl.Controls.Add(this.Transfer_butt);
            this.ManageFlow_pnl.Location = new System.Drawing.Point(5, 250);
            this.ManageFlow_pnl.MaximumSize = new System.Drawing.Size(260, 273);
            this.ManageFlow_pnl.MinimumSize = new System.Drawing.Size(260, 78);
            this.ManageFlow_pnl.Name = "ManageFlow_pnl";
            this.ManageFlow_pnl.Size = new System.Drawing.Size(260, 273);
            this.ManageFlow_pnl.TabIndex = 1;
            // 
            // Manage_Money_but
            // 
            this.Manage_Money_but.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.Manage_Money_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Manage_Money_but.FlatAppearance.BorderSize = 0;
            this.Manage_Money_but.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.Manage_Money_but.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(173)))), ((int)(((byte)(226)))));
            this.Manage_Money_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Manage_Money_but.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Manage_Money_but.ForeColor = System.Drawing.Color.White;
            this.Manage_Money_but.Image = ((System.Drawing.Image)(resources.GetObject("Manage_Money_but.Image")));
            this.Manage_Money_but.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Manage_Money_but.Location = new System.Drawing.Point(3, 3);
            this.Manage_Money_but.Name = "Manage_Money_but";
            this.Manage_Money_but.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Manage_Money_but.Size = new System.Drawing.Size(286, 71);
            this.Manage_Money_but.TabIndex = 3;
            this.Manage_Money_but.Text = "Manage Money";
            this.Manage_Money_but.UseVisualStyleBackColor = false;
            this.Manage_Money_but.Click += new System.EventHandler(this.Manage_Money_but_Click);
            // 
            // Deposit_butt
            // 
            this.Deposit_butt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Deposit_butt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Deposit_butt.FlatAppearance.BorderSize = 0;
            this.Deposit_butt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.Deposit_butt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Deposit_butt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Deposit_butt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deposit_butt.ForeColor = System.Drawing.Color.White;
            this.Deposit_butt.Image = ((System.Drawing.Image)(resources.GetObject("Deposit_butt.Image")));
            this.Deposit_butt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Deposit_butt.Location = new System.Drawing.Point(3, 80);
            this.Deposit_butt.Name = "Deposit_butt";
            this.Deposit_butt.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.Deposit_butt.Size = new System.Drawing.Size(254, 58);
            this.Deposit_butt.TabIndex = 4;
            this.Deposit_butt.Text = "Deposit";
            this.Deposit_butt.UseVisualStyleBackColor = false;
            this.Deposit_butt.Click += new System.EventHandler(this.Deposit_butt_Click);
            // 
            // Withdraw_butt
            // 
            this.Withdraw_butt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Withdraw_butt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Withdraw_butt.FlatAppearance.BorderSize = 0;
            this.Withdraw_butt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.Withdraw_butt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Withdraw_butt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Withdraw_butt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Withdraw_butt.ForeColor = System.Drawing.Color.White;
            this.Withdraw_butt.Image = ((System.Drawing.Image)(resources.GetObject("Withdraw_butt.Image")));
            this.Withdraw_butt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Withdraw_butt.Location = new System.Drawing.Point(3, 144);
            this.Withdraw_butt.Name = "Withdraw_butt";
            this.Withdraw_butt.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.Withdraw_butt.Size = new System.Drawing.Size(254, 56);
            this.Withdraw_butt.TabIndex = 5;
            this.Withdraw_butt.Text = "Withdraw";
            this.Withdraw_butt.UseVisualStyleBackColor = false;
            this.Withdraw_butt.Click += new System.EventHandler(this.Withdraw_butt_Click);
            // 
            // Transfer_butt
            // 
            this.Transfer_butt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Transfer_butt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Transfer_butt.FlatAppearance.BorderSize = 0;
            this.Transfer_butt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.Transfer_butt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Transfer_butt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Transfer_butt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Transfer_butt.ForeColor = System.Drawing.Color.White;
            this.Transfer_butt.Image = ((System.Drawing.Image)(resources.GetObject("Transfer_butt.Image")));
            this.Transfer_butt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Transfer_butt.Location = new System.Drawing.Point(3, 206);
            this.Transfer_butt.Name = "Transfer_butt";
            this.Transfer_butt.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.Transfer_butt.Size = new System.Drawing.Size(256, 64);
            this.Transfer_butt.TabIndex = 6;
            this.Transfer_butt.Text = "Transfer Money";
            this.Transfer_butt.UseVisualStyleBackColor = false;
            this.Transfer_butt.Click += new System.EventHandler(this.Transfer_butt_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.logout_button);
            this.panel5.Location = new System.Drawing.Point(5, 600);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(260, 58);
            this.panel5.TabIndex = 10;
            // 
            // logout_button
            // 
            this.logout_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.logout_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.logout_button.FlatAppearance.BorderSize = 0;
            this.logout_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.logout_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(112)))), ((int)(((byte)(99)))));
            this.logout_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout_button.ForeColor = System.Drawing.Color.White;
            this.logout_button.Image = ((System.Drawing.Image)(resources.GetObject("logout_button.Image")));
            this.logout_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logout_button.Location = new System.Drawing.Point(0, 0);
            this.logout_button.Name = "logout_button";
            this.logout_button.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.logout_button.Size = new System.Drawing.Size(256, 58);
            this.logout_button.TabIndex = 7;
            this.logout_button.Text = "Logout";
            this.logout_button.UseVisualStyleBackColor = false;
            this.logout_button.Click += new System.EventHandler(this.logout_button_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Manage_Account_butt);
            this.panel4.Font = new System.Drawing.Font("Italic Outline Art", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.panel4.Location = new System.Drawing.Point(5, 175);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(260, 69);
            this.panel4.TabIndex = 9;
            // 
            // Manage_Account_butt
            // 
            this.Manage_Account_butt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.Manage_Account_butt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Manage_Account_butt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Manage_Account_butt.FlatAppearance.BorderSize = 0;
            this.Manage_Account_butt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.Manage_Account_butt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.Manage_Account_butt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Manage_Account_butt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Manage_Account_butt.ForeColor = System.Drawing.Color.White;
            this.Manage_Account_butt.Image = ((System.Drawing.Image)(resources.GetObject("Manage_Account_butt.Image")));
            this.Manage_Account_butt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Manage_Account_butt.Location = new System.Drawing.Point(0, 0);
            this.Manage_Account_butt.Name = "Manage_Account_butt";
            this.Manage_Account_butt.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Manage_Account_butt.Size = new System.Drawing.Size(260, 69);
            this.Manage_Account_butt.TabIndex = 2;
            this.Manage_Account_butt.Text = "Manage Account";
            this.Manage_Account_butt.UseVisualStyleBackColor = false;
            this.Manage_Account_butt.Click += new System.EventHandler(this.Manage_Account_butt_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Controls.Add(this.Menu);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 169);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(94, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 45);
            this.label2.TabIndex = 3;
            this.label2.Text = "FCB";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblWelcome.Location = new System.Drawing.Point(87, 111);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(89, 20);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "Login_name";
            // 
            // Menu
            // 
            this.Menu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Menu.Image = ((System.Drawing.Image)(resources.GetObject("Menu.Image")));
            this.Menu.Location = new System.Drawing.Point(-3, -3);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(59, 53);
            this.Menu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Menu.TabIndex = 2;
            this.Menu.TabStop = false;
            this.Menu.Click += new System.EventHandler(this.Menu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(86, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome";
            // 
            // sidetimer
            // 
            this.sidetimer.Interval = 1;
            this.sidetimer.Tick += new System.EventHandler(this.sidetimer_Tick);
            // 
            // Manage_money_timer
            // 
            this.Manage_money_timer.Interval = 5;
            this.Manage_money_timer.Tick += new System.EventHandler(this.Manage_money_timer_Tick);
            // 
            // welcomeTimer
            // 
            this.welcomeTimer.Interval = 100;
            this.welcomeTimer.Enabled = false;
            this.welcomeTimer.Tick += new System.EventHandler(this.welcomeTimer_Tick);
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(265, 0);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(870, 658);
            this.pnlMainContainer.TabIndex = 1;
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 658);
            this.Controls.Add(this.pnlMainContainer);
            this.Controls.Add(this.Sidebar2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mainformEx2";
            this.Sidebar2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ManageFlow_pnl.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Menu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Sidebar2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.PictureBox Menu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button Manage_Account_butt;
        private System.Windows.Forms.FlowLayoutPanel ManageFlow_pnl;
        private System.Windows.Forms.Button Manage_Money_but;
        private System.Windows.Forms.Button Deposit_butt;
        private System.Windows.Forms.Button Withdraw_butt;
        private System.Windows.Forms.Button Transfer_butt;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button logout_button;
        private System.Windows.Forms.Timer sidetimer;
        private System.Windows.Forms.Timer Manage_money_timer;
        private System.Windows.Forms.Timer welcomeTimer;
        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button admin_acces;
    }
}