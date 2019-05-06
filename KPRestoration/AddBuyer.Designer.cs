namespace KPRestoration
{
    partial class AddBuyer
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
            this.btnCancelAdd = new System.Windows.Forms.Button();
            this.lblBuyerInfo = new System.Windows.Forms.Label();
            this.btnAddBuyer = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtBuyerZip = new System.Windows.Forms.TextBox();
            this.txtZip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelAdd
            // 
            this.btnCancelAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnCancelAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelAdd.FlatAppearance.BorderSize = 0;
            this.btnCancelAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnCancelAdd.Location = new System.Drawing.Point(182, 361);
            this.btnCancelAdd.Name = "btnCancelAdd";
            this.btnCancelAdd.Size = new System.Drawing.Size(75, 23);
            this.btnCancelAdd.TabIndex = 11;
            this.btnCancelAdd.Text = "Cancel";
            this.btnCancelAdd.UseVisualStyleBackColor = false;
            this.btnCancelAdd.Click += new System.EventHandler(this.btnCancelAdd_Click);
            // 
            // lblBuyerInfo
            // 
            this.lblBuyerInfo.AutoSize = true;
            this.lblBuyerInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyerInfo.Location = new System.Drawing.Point(85, 20);
            this.lblBuyerInfo.Name = "lblBuyerInfo";
            this.lblBuyerInfo.Size = new System.Drawing.Size(158, 19);
            this.lblBuyerInfo.TabIndex = 42;
            this.lblBuyerInfo.Text = "Buyer Information";
            // 
            // btnAddBuyer
            // 
            this.btnAddBuyer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnAddBuyer.FlatAppearance.BorderSize = 0;
            this.btnAddBuyer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBuyer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnAddBuyer.Location = new System.Drawing.Point(61, 361);
            this.btnAddBuyer.Name = "btnAddBuyer";
            this.btnAddBuyer.Size = new System.Drawing.Size(75, 23);
            this.btnAddBuyer.TabIndex = 10;
            this.btnAddBuyer.Text = "Add Buyer";
            this.btnAddBuyer.UseVisualStyleBackColor = false;
            this.btnAddBuyer.Click += new System.EventHandler(this.btnAddBuyer_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Location = new System.Drawing.Point(125, 150);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(150, 21);
            this.txtPhone.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(125, 117);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(150, 21);
            this.txtEmail.TabIndex = 3;
            // 
            // txtLastName
            // 
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Location = new System.Drawing.Point(125, 84);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(150, 21);
            this.txtLastName.TabIndex = 2;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Location = new System.Drawing.Point(125, 51);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(150, 21);
            this.txtFirstName.TabIndex = 1;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(44, 187);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(50, 13);
            this.lblAddress.TabIndex = 40;
            this.lblAddress.Text = "Address:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(44, 55);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(62, 13);
            this.lblFirstName.TabIndex = 39;
            this.lblFirstName.Text = "First Name:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(44, 88);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 38;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(44, 154);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(41, 13);
            this.lblPhone.TabIndex = 37;
            this.lblPhone.Text = "Phone:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(44, 121);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 36;
            this.lblEmail.Text = "Email:";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(125, 185);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(150, 21);
            this.txtAddress.TabIndex = 5;
            // 
            // txtCity
            // 
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.Location = new System.Drawing.Point(125, 219);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(150, 21);
            this.txtCity.TabIndex = 6;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(44, 221);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(30, 13);
            this.lblCity.TabIndex = 45;
            this.lblCity.Text = "City:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(44, 255);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(37, 13);
            this.lblState.TabIndex = 47;
            this.lblState.Text = "State:";
            // 
            // cbState
            // 
            this.cbState.FormattingEnabled = true;
            this.cbState.Location = new System.Drawing.Point(125, 252);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(150, 21);
            this.cbState.TabIndex = 7;
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cbStatus.Location = new System.Drawing.Point(125, 316);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(150, 21);
            this.cbStatus.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(44, 319);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 13);
            this.lblStatus.TabIndex = 49;
            this.lblStatus.Text = "Status:";
            // 
            // txtBuyerZip
            // 
            this.txtBuyerZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuyerZip.Location = new System.Drawing.Point(125, 285);
            this.txtBuyerZip.Name = "txtBuyerZip";
            this.txtBuyerZip.Size = new System.Drawing.Size(150, 21);
            this.txtBuyerZip.TabIndex = 8;
            // 
            // txtZip
            // 
            this.txtZip.AutoSize = true;
            this.txtZip.Location = new System.Drawing.Point(44, 287);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(53, 13);
            this.txtZip.TabIndex = 51;
            this.txtZip.Text = "Zip Code:";
            // 
            // AddBuyer
            // 
            this.AcceptButton = this.btnAddBuyer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelAdd;
            this.ClientSize = new System.Drawing.Size(319, 405);
            this.Controls.Add(this.txtBuyerZip);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnCancelAdd);
            this.Controls.Add(this.lblBuyerInfo);
            this.Controls.Add(this.btnAddBuyer);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblEmail);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddBuyer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Buyer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddBuyer_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelAdd;
        private System.Windows.Forms.Label lblBuyerInfo;
        private System.Windows.Forms.Button btnAddBuyer;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtBuyerZip;
        private System.Windows.Forms.Label txtZip;
    }
}