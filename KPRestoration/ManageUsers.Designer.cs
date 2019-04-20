﻿namespace KPRestoration
{
    partial class ManageUsers
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
            this.menuManageUsers = new System.Windows.Forms.MenuStrip();
            this.btnAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.lblUsers = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblAccess = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.firstName = new System.Windows.Forms.TextBox();
            this.lastName = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.TextBox();
            this.cbRank = new System.Windows.Forms.ComboBox();
            this.btnEnable = new System.Windows.Forms.Button();
            this.btnSaveEdit = new System.Windows.Forms.Button();
            this.btnResetPass = new System.Windows.Forms.Button();
            this.userSearch = new System.Windows.Forms.TextBox();
            this.btnSearchUsers = new System.Windows.Forms.Button();
            this.lblUserStatus = new System.Windows.Forms.Label();
            this.cbUserStatus = new System.Windows.Forms.ComboBox();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.usersTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buyerTab = new System.Windows.Forms.TabPage();
            this.sellerTab = new System.Windows.Forms.TabPage();
            this.holderTab = new System.Windows.Forms.TabPage();
            this.menuManageUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.usersTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuManageUsers
            // 
            this.menuManageUsers.AllowMerge = false;
            this.menuManageUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.menuManageUsers.Dock = System.Windows.Forms.DockStyle.None;
            this.menuManageUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddUser});
            this.menuManageUsers.Location = new System.Drawing.Point(3, 3);
            this.menuManageUsers.Name = "menuManageUsers";
            this.menuManageUsers.Size = new System.Drawing.Size(195, 24);
            this.menuManageUsers.TabIndex = 0;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(67, 20);
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click_1);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeColumns = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(329, 63);
            this.dgvUsers.MinimumSize = new System.Drawing.Size(704, 379);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(821, 379);
            this.dgvUsers.TabIndex = 1;
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInfo.Location = new System.Drawing.Point(48, 27);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(148, 19);
            this.lblUserInfo.TabIndex = 2;
            this.lblUserInfo.Text = "User Information";
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsers.Location = new System.Drawing.Point(654, 27);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(54, 19);
            this.lblUsers.TabIndex = 3;
            this.lblUsers.Text = "Users";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(7, 102);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(59, 13);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "Username:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(7, 201);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(7, 234);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(41, 13);
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Text = "Phone:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(7, 168);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 7;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(7, 135);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(62, 13);
            this.lblFirstName.TabIndex = 8;
            this.lblFirstName.Text = "First Name:";
            // 
            // lblAccess
            // 
            this.lblAccess.AutoSize = true;
            this.lblAccess.Location = new System.Drawing.Point(7, 300);
            this.lblAccess.Name = "lblAccess";
            this.lblAccess.Size = new System.Drawing.Size(72, 13);
            this.lblAccess.TabIndex = 9;
            this.lblAccess.Text = "Access Level:";
            // 
            // username
            // 
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username.Enabled = false;
            this.username.Location = new System.Drawing.Point(88, 98);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(150, 21);
            this.username.TabIndex = 3;
            // 
            // firstName
            // 
            this.firstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.firstName.Enabled = false;
            this.firstName.Location = new System.Drawing.Point(88, 131);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(150, 21);
            this.firstName.TabIndex = 4;
            // 
            // lastName
            // 
            this.lastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lastName.Enabled = false;
            this.lastName.Location = new System.Drawing.Point(88, 164);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(150, 21);
            this.lastName.TabIndex = 5;
            // 
            // email
            // 
            this.email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.email.Enabled = false;
            this.email.Location = new System.Drawing.Point(88, 197);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(150, 21);
            this.email.TabIndex = 6;
            // 
            // phone
            // 
            this.phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phone.Enabled = false;
            this.phone.Location = new System.Drawing.Point(88, 230);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(150, 21);
            this.phone.TabIndex = 7;
            // 
            // cbRank
            // 
            this.cbRank.Enabled = false;
            this.cbRank.Location = new System.Drawing.Point(88, 296);
            this.cbRank.Name = "cbRank";
            this.cbRank.Size = new System.Drawing.Size(121, 21);
            this.cbRank.TabIndex = 8;
            // 
            // btnEnable
            // 
            this.btnEnable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnEnable.FlatAppearance.BorderSize = 0;
            this.btnEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnEnable.Location = new System.Drawing.Point(152, 63);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(86, 23);
            this.btnEnable.TabIndex = 2;
            this.btnEnable.Text = "Enable Editing";
            this.btnEnable.UseVisualStyleBackColor = false;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnSaveEdit.Enabled = false;
            this.btnSaveEdit.FlatAppearance.BorderSize = 0;
            this.btnSaveEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnSaveEdit.Location = new System.Drawing.Point(10, 334);
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.Size = new System.Drawing.Size(75, 23);
            this.btnSaveEdit.TabIndex = 9;
            this.btnSaveEdit.Text = "Save";
            this.btnSaveEdit.UseVisualStyleBackColor = false;
            this.btnSaveEdit.Click += new System.EventHandler(this.btnSaveEdit_Click);
            // 
            // btnResetPass
            // 
            this.btnResetPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnResetPass.FlatAppearance.BorderSize = 0;
            this.btnResetPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnResetPass.Location = new System.Drawing.Point(144, 334);
            this.btnResetPass.Name = "btnResetPass";
            this.btnResetPass.Size = new System.Drawing.Size(94, 23);
            this.btnResetPass.TabIndex = 18;
            this.btnResetPass.TabStop = false;
            this.btnResetPass.Text = "Reset Password";
            this.btnResetPass.UseVisualStyleBackColor = false;
            // 
            // userSearch
            // 
            this.userSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userSearch.Location = new System.Drawing.Point(329, 453);
            this.userSearch.Name = "userSearch";
            this.userSearch.Size = new System.Drawing.Size(200, 21);
            this.userSearch.TabIndex = 10;
            this.userSearch.TextChanged += new System.EventHandler(this.userSearch_TextChanged);
            // 
            // btnSearchUsers
            // 
            this.btnSearchUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnSearchUsers.FlatAppearance.BorderSize = 0;
            this.btnSearchUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnSearchUsers.Location = new System.Drawing.Point(546, 452);
            this.btnSearchUsers.Name = "btnSearchUsers";
            this.btnSearchUsers.Size = new System.Drawing.Size(75, 23);
            this.btnSearchUsers.TabIndex = 11;
            this.btnSearchUsers.Text = "Search";
            this.btnSearchUsers.UseVisualStyleBackColor = false;
            this.btnSearchUsers.Click += new System.EventHandler(this.btnSearchUsers_Click);
            // 
            // lblUserStatus
            // 
            this.lblUserStatus.AutoSize = true;
            this.lblUserStatus.Location = new System.Drawing.Point(7, 267);
            this.lblUserStatus.Name = "lblUserStatus";
            this.lblUserStatus.Size = new System.Drawing.Size(42, 13);
            this.lblUserStatus.TabIndex = 19;
            this.lblUserStatus.Text = "Status:";
            // 
            // cbUserStatus
            // 
            this.cbUserStatus.Enabled = false;
            this.cbUserStatus.Items.AddRange(new object[] {
            "Active",
            "Suspended",
            "Terminated"});
            this.cbUserStatus.Location = new System.Drawing.Point(88, 264);
            this.cbUserStatus.Name = "cbUserStatus";
            this.cbUserStatus.Size = new System.Drawing.Size(121, 21);
            this.cbUserStatus.TabIndex = 20;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnDeleteUser.Enabled = false;
            this.btnDeleteUser.FlatAppearance.BorderSize = 0;
            this.btnDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnDeleteUser.Location = new System.Drawing.Point(914, 453);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(119, 23);
            this.btnDeleteUser.TabIndex = 21;
            this.btnDeleteUser.TabStop = false;
            this.btnDeleteUser.Text = "Delete Selected User";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCurrentUser.Location = new System.Drawing.Point(8, 72);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(68, 13);
            this.lblCurrentUser.TabIndex = 23;
            this.lblCurrentUser.Text = "Current user";
            this.lblCurrentUser.Visible = false;
            // 
            // usersTabControl
            // 
            this.usersTabControl.Controls.Add(this.tabPage1);
            this.usersTabControl.Controls.Add(this.buyerTab);
            this.usersTabControl.Controls.Add(this.sellerTab);
            this.usersTabControl.Controls.Add(this.holderTab);
            this.usersTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.usersTabControl.Location = new System.Drawing.Point(0, 0);
            this.usersTabControl.Name = "usersTabControl";
            this.usersTabControl.SelectedIndex = 0;
            this.usersTabControl.Size = new System.Drawing.Size(1048, 560);
            this.usersTabControl.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.tabPage1.Controls.Add(this.menuManageUsers);
            this.tabPage1.Controls.Add(this.lblCurrentUser);
            this.tabPage1.Controls.Add(this.lblUserInfo);
            this.tabPage1.Controls.Add(this.btnDeleteUser);
            this.tabPage1.Controls.Add(this.dgvUsers);
            this.tabPage1.Controls.Add(this.cbUserStatus);
            this.tabPage1.Controls.Add(this.lblUsers);
            this.tabPage1.Controls.Add(this.lblUserStatus);
            this.tabPage1.Controls.Add(this.lblUserName);
            this.tabPage1.Controls.Add(this.btnSearchUsers);
            this.tabPage1.Controls.Add(this.lblEmail);
            this.tabPage1.Controls.Add(this.userSearch);
            this.tabPage1.Controls.Add(this.lblPhone);
            this.tabPage1.Controls.Add(this.btnResetPass);
            this.tabPage1.Controls.Add(this.lblLastName);
            this.tabPage1.Controls.Add(this.btnSaveEdit);
            this.tabPage1.Controls.Add(this.lblFirstName);
            this.tabPage1.Controls.Add(this.btnEnable);
            this.tabPage1.Controls.Add(this.lblAccess);
            this.tabPage1.Controls.Add(this.cbRank);
            this.tabPage1.Controls.Add(this.username);
            this.tabPage1.Controls.Add(this.phone);
            this.tabPage1.Controls.Add(this.firstName);
            this.tabPage1.Controls.Add(this.email);
            this.tabPage1.Controls.Add(this.lastName);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1040, 534);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Users";
            // 
            // buyerTab
            // 
            this.buyerTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.buyerTab.Location = new System.Drawing.Point(4, 22);
            this.buyerTab.Name = "buyerTab";
            this.buyerTab.Padding = new System.Windows.Forms.Padding(3);
            this.buyerTab.Size = new System.Drawing.Size(1040, 534);
            this.buyerTab.TabIndex = 1;
            this.buyerTab.Text = "Buyers";
            // 
            // sellerTab
            // 
            this.sellerTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.sellerTab.Location = new System.Drawing.Point(4, 22);
            this.sellerTab.Name = "sellerTab";
            this.sellerTab.Padding = new System.Windows.Forms.Padding(3);
            this.sellerTab.Size = new System.Drawing.Size(1040, 534);
            this.sellerTab.TabIndex = 2;
            this.sellerTab.Text = "Sellers";
            // 
            // holderTab
            // 
            this.holderTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.holderTab.Location = new System.Drawing.Point(4, 22);
            this.holderTab.Name = "holderTab";
            this.holderTab.Padding = new System.Windows.Forms.Padding(3);
            this.holderTab.Size = new System.Drawing.Size(1040, 534);
            this.holderTab.TabIndex = 3;
            this.holderTab.Text = "Title Holders";
            // 
            // ManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1048, 572);
            this.Controls.Add(this.usersTabControl);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuManageUsers;
            this.MinimumSize = new System.Drawing.Size(1048, 572);
            this.Name = "ManageUsers";
            this.Text = "Manage Users";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuManageUsers.ResumeLayout(false);
            this.menuManageUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.usersTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuManageUsers;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblAccess;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.ComboBox cbRank;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Button btnSaveEdit;
        private System.Windows.Forms.Button btnResetPass;
        private System.Windows.Forms.TextBox userSearch;
        private System.Windows.Forms.Button btnSearchUsers;
        private System.Windows.Forms.Label lblUserStatus;
        private System.Windows.Forms.ComboBox cbUserStatus;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.ToolStripMenuItem btnAddUser;
        private System.Windows.Forms.TabControl usersTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage buyerTab;
        private System.Windows.Forms.TabPage sellerTab;
        private System.Windows.Forms.TabPage holderTab;
    }
}