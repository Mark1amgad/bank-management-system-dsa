namespace project_datahave_
{
    partial class Manage_Account_UC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.AddBut = new System.Windows.Forms.Button();
            this.DeletBut = new System.Windows.Forms.Button();
            this.Loadbut = new System.Windows.Forms.Button();
            this.Updatebut = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panelTop.Controls.Add(this.label17);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1076, 70);
            this.panelTop.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(388, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(300, 45);
            this.label17.TabIndex = 0;
            this.label17.Text = "Manage Accounts";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelContent.Controls.Add(this.dgvAccounts);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 70);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20, 20, 20, 0);
            this.panelContent.Size = new System.Drawing.Size(1076, 488);
            this.panelContent.TabIndex = 1;
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.AllowUserToOrderColumns = true;
            this.dgvAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccounts.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.dgvAccounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccounts.EnableHeadersVisualStyles = false;
            this.dgvAccounts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dgvAccounts.Location = new System.Drawing.Point(20, 20);
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.ReadOnly = false;
            this.dgvAccounts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAccounts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.Size = new System.Drawing.Size(1036, 468);
            this.dgvAccounts.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelButtons.Controls.Add(this.AddBut);
            this.panelButtons.Controls.Add(this.DeletBut);
            this.panelButtons.Controls.Add(this.Loadbut);
            this.panelButtons.Controls.Add(this.Updatebut);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 558);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(30, 15, 30, 15);
            this.panelButtons.Size = new System.Drawing.Size(1076, 100);
            this.panelButtons.TabIndex = 2;
            // 
            // AddBut
            // 
            this.AddBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.AddBut.FlatAppearance.BorderSize = 0;
            this.AddBut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.AddBut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(173)))), ((int)(((byte)(226)))));
            this.AddBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBut.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBut.ForeColor = System.Drawing.Color.White;
            this.AddBut.Location = new System.Drawing.Point(30, 15);
            this.AddBut.Name = "AddBut";
            this.AddBut.Size = new System.Drawing.Size(220, 70);
            this.AddBut.TabIndex = 0;
            this.AddBut.Text = "ADD";
            this.AddBut.UseVisualStyleBackColor = false;
            this.AddBut.Click += new System.EventHandler(this.button1_Click);
            // 
            // DeletBut
            // 
            this.DeletBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.DeletBut.FlatAppearance.BorderSize = 0;
            this.DeletBut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.DeletBut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(112)))), ((int)(((byte)(99)))));
            this.DeletBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeletBut.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeletBut.ForeColor = System.Drawing.Color.White;
            this.DeletBut.Location = new System.Drawing.Point(280, 15);
            this.DeletBut.Name = "DeletBut";
            this.DeletBut.Size = new System.Drawing.Size(220, 70);
            this.DeletBut.TabIndex = 1;
            this.DeletBut.Text = "DELETE";
            this.DeletBut.UseVisualStyleBackColor = false;
            this.DeletBut.Click += new System.EventHandler(this.button2_Click);
            // 
            // Loadbut
            // 
            this.Loadbut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.Loadbut.FlatAppearance.BorderSize = 0;
            this.Loadbut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.Loadbut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(214)))), ((int)(((byte)(141)))));
            this.Loadbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Loadbut.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loadbut.ForeColor = System.Drawing.Color.White;
            this.Loadbut.Location = new System.Drawing.Point(530, 15);
            this.Loadbut.Name = "Loadbut";
            this.Loadbut.Size = new System.Drawing.Size(220, 70);
            this.Loadbut.TabIndex = 2;
            this.Loadbut.Text = "LOAD";
            this.Loadbut.UseVisualStyleBackColor = false;
            this.Loadbut.Click += new System.EventHandler(this.Loadbut_Click);
            // 
            // Updatebut
            // 
            this.Updatebut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.Updatebut.FlatAppearance.BorderSize = 0;
            this.Updatebut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.Updatebut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(215)))), ((int)(((byte)(110)))));
            this.Updatebut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Updatebut.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Updatebut.ForeColor = System.Drawing.Color.White;
            this.Updatebut.Location = new System.Drawing.Point(780, 15);
            this.Updatebut.Name = "Updatebut";
            this.Updatebut.Size = new System.Drawing.Size(220, 70);
            this.Updatebut.TabIndex = 3;
            this.Updatebut.Text = "UPDATE";
            this.Updatebut.UseVisualStyleBackColor = false;
            this.Updatebut.Click += new System.EventHandler(this.Updatebut_Click);
            // 
            // Manage_Account_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTop);
            this.Name = "Manage_Account_UC";
            this.Size = new System.Drawing.Size(1076, 658);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button AddBut;
        private System.Windows.Forms.Button DeletBut;
        private System.Windows.Forms.Button Loadbut;
        private System.Windows.Forms.Button Updatebut;
    }
}
