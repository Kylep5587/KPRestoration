namespace KPRestoration
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
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.usersTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.cbUserStatus = new System.Windows.Forms.ComboBox();
            this.lblUsers = new System.Windows.Forms.Label();
            this.lblUserStatus = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnSearchUsers = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtUserSearch = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.btnResetPass = new System.Windows.Forms.Button();
            this.lblLastName = new System.Windows.Forms.Label();
            this.btnSaveEdit = new System.Windows.Forms.Button();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.btnEnable = new System.Windows.Forms.Button();
            this.lblAccess = new System.Windows.Forms.Label();
            this.cbRank = new System.Windows.Forms.ComboBox();
            this.username = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.TextBox();
            this.firstName = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.lastName = new System.Windows.Forms.TextBox();
            this.buyerTab = new System.Windows.Forms.TabPage();
            this.txtBuyerZip = new System.Windows.Forms.TextBox();
            this.txtZip = new System.Windows.Forms.Label();
            this.cbBuyerStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbBuyerState = new System.Windows.Forms.ComboBox();
            this.lblState = new System.Windows.Forms.Label();
            this.txtBuyerCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtBuyerAddress = new System.Windows.Forms.TextBox();
            this.txtBuyerPhone = new System.Windows.Forms.TextBox();
            this.txtBuyerEmail = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDeleteBuyer = new System.Windows.Forms.Button();
            this.dgvBuyers = new System.Windows.Forms.DataGridView();
            this.lblBuyers = new System.Windows.Forms.Label();
            this.btnSearchBuyer = new System.Windows.Forms.Button();
            this.txtBuyerSearch = new System.Windows.Forms.TextBox();
            this.lblBuyerInfo = new System.Windows.Forms.Label();
            this.btnSaveBuyerEdit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addBuyerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sellerTab = new System.Windows.Forms.TabPage();
            this.holderTab = new System.Windows.Forms.TabPage();
            this.menuManageUsers.SuspendLayout();
            this.usersTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.buyerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyers)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            this.menuManageUsers.Size = new System.Drawing.Size(75, 24);
            this.menuManageUsers.TabIndex = 0;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(67, 20);
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click_1);
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
            // usersTabControl
            // 
            this.usersTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersTabControl.Controls.Add(this.tabPage1);
            this.usersTabControl.Controls.Add(this.buyerTab);
            this.usersTabControl.Controls.Add(this.sellerTab);
            this.usersTabControl.Controls.Add(this.holderTab);
            this.usersTabControl.Location = new System.Drawing.Point(0, 0);
            this.usersTabControl.Name = "usersTabControl";
            this.usersTabControl.SelectedIndex = 0;
            this.usersTabControl.Size = new System.Drawing.Size(1200, 560);
            this.usersTabControl.TabIndex = 24;
            this.usersTabControl.Click += new System.EventHandler(this.usersTabControl_Click);
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
            this.tabPage1.Controls.Add(this.txtUserSearch);
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
            this.tabPage1.Size = new System.Drawing.Size(1192, 534);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Users";
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
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnDeleteUser.Enabled = false;
            this.btnDeleteUser.FlatAppearance.BorderSize = 0;
            this.btnDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnDeleteUser.Location = new System.Drawing.Point(1065, 453);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(119, 23);
            this.btnDeleteUser.TabIndex = 21;
            this.btnDeleteUser.TabStop = false;
            this.btnDeleteUser.Text = "Delete Selected User";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
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
            this.dgvUsers.Location = new System.Drawing.Point(299, 63);
            this.dgvUsers.MinimumSize = new System.Drawing.Size(704, 379);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(885, 379);
            this.dgvUsers.TabIndex = 1;
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);
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
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsers.Location = new System.Drawing.Point(702, 27);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(54, 19);
            this.lblUsers.TabIndex = 3;
            this.lblUsers.Text = "Users";
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
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(7, 102);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(59, 13);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "Username:";
            // 
            // btnSearchUsers
            // 
            this.btnSearchUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnSearchUsers.FlatAppearance.BorderSize = 0;
            this.btnSearchUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnSearchUsers.Location = new System.Drawing.Point(516, 452);
            this.btnSearchUsers.Name = "btnSearchUsers";
            this.btnSearchUsers.Size = new System.Drawing.Size(75, 23);
            this.btnSearchUsers.TabIndex = 11;
            this.btnSearchUsers.Text = "Search";
            this.btnSearchUsers.UseVisualStyleBackColor = false;
            this.btnSearchUsers.Click += new System.EventHandler(this.btnSearchUsers_Click);
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
            // txtUserSearch
            // 
            this.txtUserSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserSearch.Location = new System.Drawing.Point(299, 453);
            this.txtUserSearch.Name = "txtUserSearch";
            this.txtUserSearch.Size = new System.Drawing.Size(200, 21);
            this.txtUserSearch.TabIndex = 10;
            this.txtUserSearch.TextChanged += new System.EventHandler(this.txtUserSearch_TextChanged);
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
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(7, 168);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 7;
            this.lblLastName.Text = "Last Name:";
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
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(7, 135);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(62, 13);
            this.lblFirstName.TabIndex = 8;
            this.lblFirstName.Text = "First Name:";
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
            // lblAccess
            // 
            this.lblAccess.AutoSize = true;
            this.lblAccess.Location = new System.Drawing.Point(7, 300);
            this.lblAccess.Name = "lblAccess";
            this.lblAccess.Size = new System.Drawing.Size(72, 13);
            this.lblAccess.TabIndex = 9;
            this.lblAccess.Text = "Access Level:";
            // 
            // cbRank
            // 
            this.cbRank.Enabled = false;
            this.cbRank.Location = new System.Drawing.Point(88, 296);
            this.cbRank.Name = "cbRank";
            this.cbRank.Size = new System.Drawing.Size(121, 21);
            this.cbRank.TabIndex = 8;
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
            // phone
            // 
            this.phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phone.Enabled = false;
            this.phone.Location = new System.Drawing.Point(88, 230);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(150, 21);
            this.phone.TabIndex = 7;
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
            // email
            // 
            this.email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.email.Enabled = false;
            this.email.Location = new System.Drawing.Point(88, 197);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(150, 21);
            this.email.TabIndex = 6;
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
            // buyerTab
            // 
            this.buyerTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.buyerTab.Controls.Add(this.txtBuyerZip);
            this.buyerTab.Controls.Add(this.txtZip);
            this.buyerTab.Controls.Add(this.cbBuyerStatus);
            this.buyerTab.Controls.Add(this.lblStatus);
            this.buyerTab.Controls.Add(this.cbBuyerState);
            this.buyerTab.Controls.Add(this.lblState);
            this.buyerTab.Controls.Add(this.txtBuyerCity);
            this.buyerTab.Controls.Add(this.lblCity);
            this.buyerTab.Controls.Add(this.txtBuyerAddress);
            this.buyerTab.Controls.Add(this.txtBuyerPhone);
            this.buyerTab.Controls.Add(this.txtBuyerEmail);
            this.buyerTab.Controls.Add(this.txtLastName);
            this.buyerTab.Controls.Add(this.txtFirstName);
            this.buyerTab.Controls.Add(this.lblAddress);
            this.buyerTab.Controls.Add(this.label1);
            this.buyerTab.Controls.Add(this.label2);
            this.buyerTab.Controls.Add(this.label3);
            this.buyerTab.Controls.Add(this.label4);
            this.buyerTab.Controls.Add(this.btnDeleteBuyer);
            this.buyerTab.Controls.Add(this.dgvBuyers);
            this.buyerTab.Controls.Add(this.lblBuyers);
            this.buyerTab.Controls.Add(this.btnSearchBuyer);
            this.buyerTab.Controls.Add(this.txtBuyerSearch);
            this.buyerTab.Controls.Add(this.lblBuyerInfo);
            this.buyerTab.Controls.Add(this.btnSaveBuyerEdit);
            this.buyerTab.Controls.Add(this.menuStrip1);
            this.buyerTab.Location = new System.Drawing.Point(4, 22);
            this.buyerTab.Name = "buyerTab";
            this.buyerTab.Padding = new System.Windows.Forms.Padding(3);
            this.buyerTab.Size = new System.Drawing.Size(1192, 534);
            this.buyerTab.TabIndex = 1;
            this.buyerTab.Text = "Buyers";
            // 
            // txtBuyerZip
            // 
            this.txtBuyerZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuyerZip.Location = new System.Drawing.Point(89, 293);
            this.txtBuyerZip.Name = "txtBuyerZip";
            this.txtBuyerZip.Size = new System.Drawing.Size(150, 21);
            this.txtBuyerZip.TabIndex = 70;
            // 
            // txtZip
            // 
            this.txtZip.AutoSize = true;
            this.txtZip.Location = new System.Drawing.Point(8, 295);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(53, 13);
            this.txtZip.TabIndex = 69;
            this.txtZip.Text = "Zip Code:";
            // 
            // cbBuyerStatus
            // 
            this.cbBuyerStatus.FormattingEnabled = true;
            this.cbBuyerStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cbBuyerStatus.Location = new System.Drawing.Point(89, 324);
            this.cbBuyerStatus.Name = "cbBuyerStatus";
            this.cbBuyerStatus.Size = new System.Drawing.Size(150, 21);
            this.cbBuyerStatus.TabIndex = 68;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(8, 327);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 13);
            this.lblStatus.TabIndex = 67;
            this.lblStatus.Text = "Status:";
            // 
            // cbBuyerState
            // 
            this.cbBuyerState.FormattingEnabled = true;
            this.cbBuyerState.Location = new System.Drawing.Point(89, 260);
            this.cbBuyerState.Name = "cbBuyerState";
            this.cbBuyerState.Size = new System.Drawing.Size(150, 21);
            this.cbBuyerState.TabIndex = 66;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(8, 263);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(37, 13);
            this.lblState.TabIndex = 65;
            this.lblState.Text = "State:";
            // 
            // txtBuyerCity
            // 
            this.txtBuyerCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuyerCity.Location = new System.Drawing.Point(89, 227);
            this.txtBuyerCity.Name = "txtBuyerCity";
            this.txtBuyerCity.Size = new System.Drawing.Size(150, 21);
            this.txtBuyerCity.TabIndex = 64;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(8, 229);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(30, 13);
            this.lblCity.TabIndex = 63;
            this.lblCity.Text = "City:";
            // 
            // txtBuyerAddress
            // 
            this.txtBuyerAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuyerAddress.Location = new System.Drawing.Point(89, 193);
            this.txtBuyerAddress.Name = "txtBuyerAddress";
            this.txtBuyerAddress.Size = new System.Drawing.Size(150, 21);
            this.txtBuyerAddress.TabIndex = 62;
            // 
            // txtBuyerPhone
            // 
            this.txtBuyerPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuyerPhone.Location = new System.Drawing.Point(89, 158);
            this.txtBuyerPhone.Name = "txtBuyerPhone";
            this.txtBuyerPhone.Size = new System.Drawing.Size(150, 21);
            this.txtBuyerPhone.TabIndex = 56;
            // 
            // txtBuyerEmail
            // 
            this.txtBuyerEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuyerEmail.Location = new System.Drawing.Point(89, 125);
            this.txtBuyerEmail.Name = "txtBuyerEmail";
            this.txtBuyerEmail.Size = new System.Drawing.Size(150, 21);
            this.txtBuyerEmail.TabIndex = 55;
            // 
            // txtLastName
            // 
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Location = new System.Drawing.Point(89, 92);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(150, 21);
            this.txtLastName.TabIndex = 54;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Location = new System.Drawing.Point(89, 59);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(150, 21);
            this.txtFirstName.TabIndex = 53;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(8, 195);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(50, 13);
            this.lblAddress.TabIndex = 61;
            this.lblAddress.Text = "Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Last Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Phone:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Email:";
            // 
            // btnDeleteBuyer
            // 
            this.btnDeleteBuyer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnDeleteBuyer.Enabled = false;
            this.btnDeleteBuyer.FlatAppearance.BorderSize = 0;
            this.btnDeleteBuyer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteBuyer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnDeleteBuyer.Location = new System.Drawing.Point(1050, 453);
            this.btnDeleteBuyer.Name = "btnDeleteBuyer";
            this.btnDeleteBuyer.Size = new System.Drawing.Size(136, 23);
            this.btnDeleteBuyer.TabIndex = 47;
            this.btnDeleteBuyer.TabStop = false;
            this.btnDeleteBuyer.Text = "Delete Selected Buyer";
            this.btnDeleteBuyer.UseVisualStyleBackColor = false;
            this.btnDeleteBuyer.Click += new System.EventHandler(this.btnDeleteBuyer_Click);
            // 
            // dgvBuyers
            // 
            this.dgvBuyers.AllowUserToAddRows = false;
            this.dgvBuyers.AllowUserToDeleteRows = false;
            this.dgvBuyers.AllowUserToResizeColumns = false;
            this.dgvBuyers.AllowUserToResizeRows = false;
            this.dgvBuyers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBuyers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBuyers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBuyers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuyers.Location = new System.Drawing.Point(291, 63);
            this.dgvBuyers.MinimumSize = new System.Drawing.Size(704, 379);
            this.dgvBuyers.MultiSelect = false;
            this.dgvBuyers.Name = "dgvBuyers";
            this.dgvBuyers.ReadOnly = true;
            this.dgvBuyers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvBuyers.RowHeadersVisible = false;
            this.dgvBuyers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBuyers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBuyers.Size = new System.Drawing.Size(895, 379);
            this.dgvBuyers.TabIndex = 43;
            this.dgvBuyers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBuyers_CellClick);
            // 
            // lblBuyers
            // 
            this.lblBuyers.AutoSize = true;
            this.lblBuyers.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyers.Location = new System.Drawing.Point(698, 27);
            this.lblBuyers.Name = "lblBuyers";
            this.lblBuyers.Size = new System.Drawing.Size(64, 19);
            this.lblBuyers.TabIndex = 44;
            this.lblBuyers.Text = "Buyers";
            this.lblBuyers.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSearchBuyer
            // 
            this.btnSearchBuyer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnSearchBuyer.FlatAppearance.BorderSize = 0;
            this.btnSearchBuyer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchBuyer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnSearchBuyer.Location = new System.Drawing.Point(508, 452);
            this.btnSearchBuyer.Name = "btnSearchBuyer";
            this.btnSearchBuyer.Size = new System.Drawing.Size(75, 23);
            this.btnSearchBuyer.TabIndex = 46;
            this.btnSearchBuyer.Text = "Search";
            this.btnSearchBuyer.UseVisualStyleBackColor = false;
            this.btnSearchBuyer.Click += new System.EventHandler(this.btnSearchBuyer_Click);
            // 
            // txtBuyerSearch
            // 
            this.txtBuyerSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuyerSearch.Location = new System.Drawing.Point(291, 453);
            this.txtBuyerSearch.Name = "txtBuyerSearch";
            this.txtBuyerSearch.Size = new System.Drawing.Size(200, 21);
            this.txtBuyerSearch.TabIndex = 45;
            this.txtBuyerSearch.TextChanged += new System.EventHandler(this.txtBuyerSearch_TextChanged);
            // 
            // lblBuyerInfo
            // 
            this.lblBuyerInfo.AutoSize = true;
            this.lblBuyerInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyerInfo.Location = new System.Drawing.Point(48, 27);
            this.lblBuyerInfo.Name = "lblBuyerInfo";
            this.lblBuyerInfo.Size = new System.Drawing.Size(158, 19);
            this.lblBuyerInfo.TabIndex = 24;
            this.lblBuyerInfo.Text = "Buyer Information";
            // 
            // btnSaveBuyerEdit
            // 
            this.btnSaveBuyerEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnSaveBuyerEdit.Enabled = false;
            this.btnSaveBuyerEdit.FlatAppearance.BorderSize = 0;
            this.btnSaveBuyerEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveBuyerEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnSaveBuyerEdit.Location = new System.Drawing.Point(89, 363);
            this.btnSaveBuyerEdit.Name = "btnSaveBuyerEdit";
            this.btnSaveBuyerEdit.Size = new System.Drawing.Size(75, 23);
            this.btnSaveBuyerEdit.TabIndex = 37;
            this.btnSaveBuyerEdit.Text = "Save";
            this.btnSaveBuyerEdit.UseVisualStyleBackColor = false;
            this.btnSaveBuyerEdit.Click += new System.EventHandler(this.btnSaveBuyerEdit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBuyerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(82, 24);
            this.menuStrip1.TabIndex = 42;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addBuyerToolStripMenuItem
            // 
            this.addBuyerToolStripMenuItem.Name = "addBuyerToolStripMenuItem";
            this.addBuyerToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.addBuyerToolStripMenuItem.Text = "Add Buyer";
            this.addBuyerToolStripMenuItem.Click += new System.EventHandler(this.addBuyerToolStripMenuItem_Click);
            // 
            // sellerTab
            // 
            this.sellerTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.sellerTab.Location = new System.Drawing.Point(4, 22);
            this.sellerTab.Name = "sellerTab";
            this.sellerTab.Padding = new System.Windows.Forms.Padding(3);
            this.sellerTab.Size = new System.Drawing.Size(1192, 534);
            this.sellerTab.TabIndex = 2;
            this.sellerTab.Text = "Sellers";
            // 
            // holderTab
            // 
            this.holderTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.holderTab.Location = new System.Drawing.Point(4, 22);
            this.holderTab.Name = "holderTab";
            this.holderTab.Padding = new System.Windows.Forms.Padding(3);
            this.holderTab.Size = new System.Drawing.Size(1192, 534);
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
            this.ClientSize = new System.Drawing.Size(1200, 572);
            this.Controls.Add(this.usersTabControl);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuManageUsers;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 572);
            this.Name = "ManageUsers";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Users";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuManageUsers.ResumeLayout(false);
            this.menuManageUsers.PerformLayout();
            this.usersTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.buyerTab.ResumeLayout(false);
            this.buyerTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyers)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuManageUsers;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.TabControl usersTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage buyerTab;
        private System.Windows.Forms.TabPage sellerTab;
        private System.Windows.Forms.TabPage holderTab;
        private System.Windows.Forms.ToolStripMenuItem btnAddUser;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.ComboBox cbUserStatus;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Label lblUserStatus;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnSearchUsers;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtUserSearch;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Button btnResetPass;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Button btnSaveEdit;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Label lblAccess;
        private System.Windows.Forms.ComboBox cbRank;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.Label lblBuyerInfo;
        private System.Windows.Forms.Button btnSaveBuyerEdit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addBuyerToolStripMenuItem;
        private System.Windows.Forms.Button btnDeleteBuyer;
        private System.Windows.Forms.DataGridView dgvBuyers;
        private System.Windows.Forms.Label lblBuyers;
        private System.Windows.Forms.Button btnSearchBuyer;
        private System.Windows.Forms.TextBox txtBuyerSearch;
        private System.Windows.Forms.TextBox txtBuyerZip;
        private System.Windows.Forms.Label txtZip;
        private System.Windows.Forms.ComboBox cbBuyerStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbBuyerState;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtBuyerCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtBuyerAddress;
        private System.Windows.Forms.TextBox txtBuyerPhone;
        private System.Windows.Forms.TextBox txtBuyerEmail;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}