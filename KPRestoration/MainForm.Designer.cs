namespace KPRestoration
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLogout = new System.Windows.Forms.LinkLabel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnPotentialPurchases = new System.Windows.Forms.Button();
            this.btnVehicleManager = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.logoContainer = new System.Windows.Forms.PictureBox();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.panelMenu.Controls.Add(this.panel2);
            this.panelMenu.Controls.Add(this.btnUsers);
            this.panelMenu.Controls.Add(this.btnReports);
            this.panelMenu.Controls.Add(this.btnSchedule);
            this.panelMenu.Controls.Add(this.btnPotentialPurchases);
            this.panelMenu.Controls.Add(this.btnVehicleManager);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Controls.Add(this.logoContainer);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 691);
            this.panelMenu.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblLogout);
            this.panel2.Controls.Add(this.lblUsername);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 621);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.panel2.Size = new System.Drawing.Size(220, 70);
            this.panel2.TabIndex = 8;
            // 
            // lblLogout
            // 
            this.lblLogout.AutoSize = true;
            this.lblLogout.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(97)))), ((int)(((byte)(204)))));
            this.lblLogout.Location = new System.Drawing.Point(77, 40);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(40, 13);
            this.lblLogout.TabIndex = 2;
            this.lblLogout.TabStop = true;
            this.lblLogout.Text = "Logout";
            this.lblLogout.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(97)))), ((int)(((byte)(204)))));
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.lblUsername.Location = new System.Drawing.Point(77, 18);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(57, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Kylep5587";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 60);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(97)))), ((int)(((byte)(204)))));
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnUsers.Image")));
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(0, 240);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnUsers.Size = new System.Drawing.Size(220, 30);
            this.btnUsers.TabIndex = 7;
            this.btnUsers.Text = "          Manage Users";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(97)))), ((int)(((byte)(204)))));
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnReports.Image = ((System.Drawing.Image)(resources.GetObject("btnReports.Image")));
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(0, 207);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(220, 30);
            this.btnReports.TabIndex = 6;
            this.btnReports.Text = "          Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = false;
            // 
            // btnSchedule
            // 
            this.btnSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnSchedule.FlatAppearance.BorderSize = 0;
            this.btnSchedule.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(97)))), ((int)(((byte)(204)))));
            this.btnSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedule.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnSchedule.Image = ((System.Drawing.Image)(resources.GetObject("btnSchedule.Image")));
            this.btnSchedule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSchedule.Location = new System.Drawing.Point(0, 174);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSchedule.Size = new System.Drawing.Size(220, 30);
            this.btnSchedule.TabIndex = 5;
            this.btnSchedule.Text = "          Schedule";
            this.btnSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSchedule.UseVisualStyleBackColor = false;
            // 
            // btnPotentialPurchases
            // 
            this.btnPotentialPurchases.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnPotentialPurchases.FlatAppearance.BorderSize = 0;
            this.btnPotentialPurchases.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(97)))), ((int)(((byte)(204)))));
            this.btnPotentialPurchases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPotentialPurchases.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPotentialPurchases.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnPotentialPurchases.Image = ((System.Drawing.Image)(resources.GetObject("btnPotentialPurchases.Image")));
            this.btnPotentialPurchases.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPotentialPurchases.Location = new System.Drawing.Point(0, 141);
            this.btnPotentialPurchases.Name = "btnPotentialPurchases";
            this.btnPotentialPurchases.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnPotentialPurchases.Size = new System.Drawing.Size(220, 30);
            this.btnPotentialPurchases.TabIndex = 3;
            this.btnPotentialPurchases.Text = "          Potential Purchases";
            this.btnPotentialPurchases.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPotentialPurchases.UseVisualStyleBackColor = false;
            // 
            // btnVehicleManager
            // 
            this.btnVehicleManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnVehicleManager.FlatAppearance.BorderSize = 0;
            this.btnVehicleManager.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(97)))), ((int)(((byte)(204)))));
            this.btnVehicleManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVehicleManager.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehicleManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnVehicleManager.Image = ((System.Drawing.Image)(resources.GetObject("btnVehicleManager.Image")));
            this.btnVehicleManager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVehicleManager.Location = new System.Drawing.Point(0, 107);
            this.btnVehicleManager.Name = "btnVehicleManager";
            this.btnVehicleManager.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnVehicleManager.Size = new System.Drawing.Size(220, 30);
            this.btnVehicleManager.TabIndex = 2;
            this.btnVehicleManager.Text = "          Vehicle Manager";
            this.btnVehicleManager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVehicleManager.UseVisualStyleBackColor = false;
            this.btnVehicleManager.Click += new System.EventHandler(this.btnVehicleManager_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(97)))), ((int)(((byte)(204)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 73);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(220, 30);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "          Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.UseVisualStyleBackColor = false;
            // 
            // logoContainer
            // 
            this.logoContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoContainer.Image = ((System.Drawing.Image)(resources.GetObject("logoContainer.Image")));
            this.logoContainer.Location = new System.Drawing.Point(0, 0);
            this.logoContainer.Name = "logoContainer";
            this.logoContainer.Size = new System.Drawing.Size(220, 50);
            this.logoContainer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.logoContainer.TabIndex = 0;
            this.logoContainer.TabStop = false;
            // 
            // panelContent
            // 
            this.panelContent.AutoSize = true;
            this.panelContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(220, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1214, 691);
            this.panelContent.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 691);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1300, 650);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.panelMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoContainer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.PictureBox logoContainer;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnPotentialPurchases;
        private System.Windows.Forms.Button btnVehicleManager;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lblLogout;
        private System.Windows.Forms.Label lblUsername;
    }
}

