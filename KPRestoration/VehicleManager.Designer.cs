namespace KPRestoration
{
    partial class VehicleManager
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
            this.tabVehicleManager = new System.Windows.Forms.TabControl();
            this.tabOverveiw = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblVehicles = new System.Windows.Forms.Label();
            this.tabAddVehicle = new System.Windows.Forms.TabPage();
            this.gbSellerInformation = new System.Windows.Forms.GroupBox();
            this.txtPotentialSeller = new System.Windows.Forms.TextBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPotentialSeller = new System.Windows.Forms.Label();
            this.txtAskingPrice = new System.Windows.Forms.TextBox();
            this.lblAskingPrice = new System.Windows.Forms.Label();
            this.gbNotes = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.btnAddVehicle = new System.Windows.Forms.Button();
            this.gbPurchaseInfo = new System.Windows.Forms.GroupBox();
            this.cbTitleHolder = new System.Windows.Forms.ComboBox();
            this.cbSeller = new System.Windows.Forms.ComboBox();
            this.lblTitleHolder = new System.Windows.Forms.Label();
            this.lblSeller = new System.Windows.Forms.Label();
            this.datePurchased = new System.Windows.Forms.DateTimePicker();
            this.lblPurchaseDate = new System.Windows.Forms.Label();
            this.txtPurhcasePrice = new System.Windows.Forms.TextBox();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.gbValueInfo = new System.Windows.Forms.GroupBox();
            this.txtEdmundsValue = new System.Windows.Forms.TextBox();
            this.lblEdmundsValue = new System.Windows.Forms.Label();
            this.txtKBBValue = new System.Windows.Forms.TextBox();
            this.lblKBB = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPurchaseStatus = new System.Windows.Forms.Label();
            this.cbPurchaseStatus = new System.Windows.Forms.ComboBox();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.cbVehicleType = new System.Windows.Forms.ComboBox();
            this.txtVIN = new System.Windows.Forms.TextBox();
            this.lblVIN = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.cbMake = new System.Windows.Forms.ComboBox();
            this.lblCondition = new System.Windows.Forms.Label();
            this.lblMakes = new System.Windows.Forms.Label();
            this.cbCondition = new System.Windows.Forms.ComboBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.cbColors = new System.Windows.Forms.ComboBox();
            this.txtMileage = new System.Windows.Forms.TextBox();
            this.lblTransmission = new System.Windows.Forms.Label();
            this.lblMileage = new System.Windows.Forms.Label();
            this.cbTransmission = new System.Windows.Forms.ComboBox();
            this.txtEngine = new System.Windows.Forms.TextBox();
            this.lblEngine = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabVehicleManager.SuspendLayout();
            this.tabOverveiw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabAddVehicle.SuspendLayout();
            this.gbSellerInformation.SuspendLayout();
            this.gbNotes.SuspendLayout();
            this.gbPurchaseInfo.SuspendLayout();
            this.gbValueInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabVehicleManager
            // 
            this.tabVehicleManager.Controls.Add(this.tabOverveiw);
            this.tabVehicleManager.Controls.Add(this.tabAddVehicle);
            this.tabVehicleManager.Controls.Add(this.tabPage1);
            this.tabVehicleManager.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabVehicleManager.Location = new System.Drawing.Point(0, 0);
            this.tabVehicleManager.Name = "tabVehicleManager";
            this.tabVehicleManager.SelectedIndex = 0;
            this.tabVehicleManager.Size = new System.Drawing.Size(1032, 533);
            this.tabVehicleManager.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabVehicleManager.TabIndex = 0;
            this.tabVehicleManager.SelectedIndexChanged += new System.EventHandler(this.tabVehicleManager_SelectedIndexChanged);
            // 
            // tabOverveiw
            // 
            this.tabOverveiw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.tabOverveiw.Controls.Add(this.dataGridView1);
            this.tabOverveiw.Controls.Add(this.lblVehicles);
            this.tabOverveiw.Location = new System.Drawing.Point(4, 22);
            this.tabOverveiw.Name = "tabOverveiw";
            this.tabOverveiw.Padding = new System.Windows.Forms.Padding(3);
            this.tabOverveiw.Size = new System.Drawing.Size(1024, 507);
            this.tabOverveiw.TabIndex = 0;
            this.tabOverveiw.Text = "Overview";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(697, 388);
            this.dataGridView1.TabIndex = 4;
            // 
            // lblVehicles
            // 
            this.lblVehicles.AutoSize = true;
            this.lblVehicles.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicles.Location = new System.Drawing.Point(8, 13);
            this.lblVehicles.Name = "lblVehicles";
            this.lblVehicles.Size = new System.Drawing.Size(76, 19);
            this.lblVehicles.TabIndex = 3;
            this.lblVehicles.Text = "Vehicles";
            // 
            // tabAddVehicle
            // 
            this.tabAddVehicle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.tabAddVehicle.Controls.Add(this.gbSellerInformation);
            this.tabAddVehicle.Controls.Add(this.gbNotes);
            this.tabAddVehicle.Controls.Add(this.btnAddVehicle);
            this.tabAddVehicle.Controls.Add(this.gbPurchaseInfo);
            this.tabAddVehicle.Controls.Add(this.gbValueInfo);
            this.tabAddVehicle.Controls.Add(this.groupBox1);
            this.tabAddVehicle.Location = new System.Drawing.Point(4, 22);
            this.tabAddVehicle.Name = "tabAddVehicle";
            this.tabAddVehicle.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddVehicle.Size = new System.Drawing.Size(1024, 507);
            this.tabAddVehicle.TabIndex = 1;
            this.tabAddVehicle.Text = "Add Vehicle";
            // 
            // gbSellerInformation
            // 
            this.gbSellerInformation.Controls.Add(this.txtPotentialSeller);
            this.gbSellerInformation.Controls.Add(this.cbStatus);
            this.gbSellerInformation.Controls.Add(this.lblStatus);
            this.gbSellerInformation.Controls.Add(this.lblPotentialSeller);
            this.gbSellerInformation.Controls.Add(this.txtAskingPrice);
            this.gbSellerInformation.Controls.Add(this.lblAskingPrice);
            this.gbSellerInformation.Location = new System.Drawing.Point(322, 23);
            this.gbSellerInformation.Name = "gbSellerInformation";
            this.gbSellerInformation.Size = new System.Drawing.Size(269, 137);
            this.gbSellerInformation.TabIndex = 30;
            this.gbSellerInformation.TabStop = false;
            this.gbSellerInformation.Text = "Seller Information";
            this.gbSellerInformation.Visible = false;
            // 
            // txtPotentialSeller
            // 
            this.txtPotentialSeller.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPotentialSeller.Location = new System.Drawing.Point(101, 63);
            this.txtPotentialSeller.Name = "txtPotentialSeller";
            this.txtPotentialSeller.Size = new System.Drawing.Size(150, 21);
            this.txtPotentialSeller.TabIndex = 30;
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Researching",
            "Contacted Seller",
            "Appointment Set"});
            this.cbStatus.Location = new System.Drawing.Point(101, 98);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(150, 21);
            this.cbStatus.TabIndex = 29;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(17, 101);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 13);
            this.lblStatus.TabIndex = 27;
            this.lblStatus.Text = "Status:";
            // 
            // lblPotentialSeller
            // 
            this.lblPotentialSeller.AutoSize = true;
            this.lblPotentialSeller.Location = new System.Drawing.Point(17, 67);
            this.lblPotentialSeller.Name = "lblPotentialSeller";
            this.lblPotentialSeller.Size = new System.Drawing.Size(37, 13);
            this.lblPotentialSeller.TabIndex = 25;
            this.lblPotentialSeller.Text = "Seller:";
            // 
            // txtAskingPrice
            // 
            this.txtAskingPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAskingPrice.Location = new System.Drawing.Point(101, 28);
            this.txtAskingPrice.Name = "txtAskingPrice";
            this.txtAskingPrice.Size = new System.Drawing.Size(150, 21);
            this.txtAskingPrice.TabIndex = 11;
            // 
            // lblAskingPrice
            // 
            this.lblAskingPrice.AutoSize = true;
            this.lblAskingPrice.Location = new System.Drawing.Point(17, 31);
            this.lblAskingPrice.Name = "lblAskingPrice";
            this.lblAskingPrice.Size = new System.Drawing.Size(68, 13);
            this.lblAskingPrice.TabIndex = 23;
            this.lblAskingPrice.Text = "Asking Price:";
            // 
            // gbNotes
            // 
            this.gbNotes.Controls.Add(this.txtNotes);
            this.gbNotes.Location = new System.Drawing.Point(631, 26);
            this.gbNotes.Name = "gbNotes";
            this.gbNotes.Size = new System.Drawing.Size(373, 355);
            this.gbNotes.TabIndex = 28;
            this.gbNotes.TabStop = false;
            this.gbNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotes.Location = new System.Drawing.Point(20, 23);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(336, 312);
            this.txtNotes.TabIndex = 0;
            this.txtNotes.Text = "";
            // 
            // btnAddVehicle
            // 
            this.btnAddVehicle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnAddVehicle.FlatAppearance.BorderSize = 0;
            this.btnAddVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVehicle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.btnAddVehicle.Location = new System.Drawing.Point(117, 459);
            this.btnAddVehicle.Name = "btnAddVehicle";
            this.btnAddVehicle.Size = new System.Drawing.Size(75, 23);
            this.btnAddVehicle.TabIndex = 27;
            this.btnAddVehicle.Text = "Add Vehicle";
            this.btnAddVehicle.UseVisualStyleBackColor = false;
            this.btnAddVehicle.Click += new System.EventHandler(this.btnAddVehicle_Click);
            // 
            // gbPurchaseInfo
            // 
            this.gbPurchaseInfo.Controls.Add(this.cbTitleHolder);
            this.gbPurchaseInfo.Controls.Add(this.cbSeller);
            this.gbPurchaseInfo.Controls.Add(this.lblTitleHolder);
            this.gbPurchaseInfo.Controls.Add(this.lblSeller);
            this.gbPurchaseInfo.Controls.Add(this.datePurchased);
            this.gbPurchaseInfo.Controls.Add(this.lblPurchaseDate);
            this.gbPurchaseInfo.Controls.Add(this.txtPurhcasePrice);
            this.gbPurchaseInfo.Controls.Add(this.lblPurchasePrice);
            this.gbPurchaseInfo.Location = new System.Drawing.Point(322, 26);
            this.gbPurchaseInfo.Name = "gbPurchaseInfo";
            this.gbPurchaseInfo.Size = new System.Drawing.Size(269, 174);
            this.gbPurchaseInfo.TabIndex = 26;
            this.gbPurchaseInfo.TabStop = false;
            this.gbPurchaseInfo.Text = "Purchase Information";
            // 
            // cbTitleHolder
            // 
            this.cbTitleHolder.FormattingEnabled = true;
            this.cbTitleHolder.Items.AddRange(new object[] {
            "Add Later"});
            this.cbTitleHolder.Location = new System.Drawing.Point(101, 134);
            this.cbTitleHolder.Name = "cbTitleHolder";
            this.cbTitleHolder.Size = new System.Drawing.Size(150, 21);
            this.cbTitleHolder.TabIndex = 29;
            // 
            // cbSeller
            // 
            this.cbSeller.FormattingEnabled = true;
            this.cbSeller.Items.AddRange(new object[] {
            "Add Later"});
            this.cbSeller.Location = new System.Drawing.Point(101, 99);
            this.cbSeller.Name = "cbSeller";
            this.cbSeller.Size = new System.Drawing.Size(150, 21);
            this.cbSeller.TabIndex = 28;
            // 
            // lblTitleHolder
            // 
            this.lblTitleHolder.AutoSize = true;
            this.lblTitleHolder.Location = new System.Drawing.Point(17, 137);
            this.lblTitleHolder.Name = "lblTitleHolder";
            this.lblTitleHolder.Size = new System.Drawing.Size(65, 13);
            this.lblTitleHolder.TabIndex = 27;
            this.lblTitleHolder.Text = "Title Holder:";
            // 
            // lblSeller
            // 
            this.lblSeller.AutoSize = true;
            this.lblSeller.Location = new System.Drawing.Point(17, 103);
            this.lblSeller.Name = "lblSeller";
            this.lblSeller.Size = new System.Drawing.Size(37, 13);
            this.lblSeller.TabIndex = 25;
            this.lblSeller.Text = "Seller:";
            // 
            // datePurchased
            // 
            this.datePurchased.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePurchased.Location = new System.Drawing.Point(101, 29);
            this.datePurchased.Name = "datePurchased";
            this.datePurchased.Size = new System.Drawing.Size(150, 21);
            this.datePurchased.TabIndex = 10;
            // 
            // lblPurchaseDate
            // 
            this.lblPurchaseDate.AutoSize = true;
            this.lblPurchaseDate.Location = new System.Drawing.Point(17, 32);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(61, 13);
            this.lblPurchaseDate.TabIndex = 22;
            this.lblPurchaseDate.Text = "Purchased:";
            // 
            // txtPurhcasePrice
            // 
            this.txtPurhcasePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurhcasePrice.Location = new System.Drawing.Point(101, 64);
            this.txtPurhcasePrice.Name = "txtPurhcasePrice";
            this.txtPurhcasePrice.Size = new System.Drawing.Size(150, 21);
            this.txtPurhcasePrice.TabIndex = 11;
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Location = new System.Drawing.Point(17, 67);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(81, 13);
            this.lblPurchasePrice.TabIndex = 23;
            this.lblPurchasePrice.Text = "Purchase Price:";
            // 
            // gbValueInfo
            // 
            this.gbValueInfo.Controls.Add(this.txtEdmundsValue);
            this.gbValueInfo.Controls.Add(this.lblEdmundsValue);
            this.gbValueInfo.Controls.Add(this.txtKBBValue);
            this.gbValueInfo.Controls.Add(this.lblKBB);
            this.gbValueInfo.Location = new System.Drawing.Point(322, 235);
            this.gbValueInfo.Name = "gbValueInfo";
            this.gbValueInfo.Size = new System.Drawing.Size(269, 113);
            this.gbValueInfo.TabIndex = 25;
            this.gbValueInfo.TabStop = false;
            this.gbValueInfo.Text = "Value Information";
            // 
            // txtEdmundsValue
            // 
            this.txtEdmundsValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEdmundsValue.Location = new System.Drawing.Point(98, 34);
            this.txtEdmundsValue.Name = "txtEdmundsValue";
            this.txtEdmundsValue.Size = new System.Drawing.Size(150, 21);
            this.txtEdmundsValue.TabIndex = 16;
            // 
            // lblEdmundsValue
            // 
            this.lblEdmundsValue.AutoSize = true;
            this.lblEdmundsValue.Location = new System.Drawing.Point(21, 38);
            this.lblEdmundsValue.Name = "lblEdmundsValue";
            this.lblEdmundsValue.Size = new System.Drawing.Size(54, 13);
            this.lblEdmundsValue.TabIndex = 15;
            this.lblEdmundsValue.Text = "Edmunds:";
            // 
            // txtKBBValue
            // 
            this.txtKBBValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKBBValue.Location = new System.Drawing.Point(98, 70);
            this.txtKBBValue.Name = "txtKBBValue";
            this.txtKBBValue.Size = new System.Drawing.Size(150, 21);
            this.txtKBBValue.TabIndex = 17;
            // 
            // lblKBB
            // 
            this.lblKBB.AutoSize = true;
            this.lblKBB.Location = new System.Drawing.Point(21, 72);
            this.lblKBB.Name = "lblKBB";
            this.lblKBB.Size = new System.Drawing.Size(29, 13);
            this.lblKBB.TabIndex = 14;
            this.lblKBB.Text = "KBB:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPurchaseStatus);
            this.groupBox1.Controls.Add(this.cbPurchaseStatus);
            this.groupBox1.Controls.Add(this.lblVehicleType);
            this.groupBox1.Controls.Add(this.cbVehicleType);
            this.groupBox1.Controls.Add(this.txtVIN);
            this.groupBox1.Controls.Add(this.lblVIN);
            this.groupBox1.Controls.Add(this.cbYear);
            this.groupBox1.Controls.Add(this.lblYear);
            this.groupBox1.Controls.Add(this.cbMake);
            this.groupBox1.Controls.Add(this.lblCondition);
            this.groupBox1.Controls.Add(this.lblMakes);
            this.groupBox1.Controls.Add(this.cbCondition);
            this.groupBox1.Controls.Add(this.txtModel);
            this.groupBox1.Controls.Add(this.lblColor);
            this.groupBox1.Controls.Add(this.lblModel);
            this.groupBox1.Controls.Add(this.cbColors);
            this.groupBox1.Controls.Add(this.txtMileage);
            this.groupBox1.Controls.Add(this.lblTransmission);
            this.groupBox1.Controls.Add(this.lblMileage);
            this.groupBox1.Controls.Add(this.cbTransmission);
            this.groupBox1.Controls.Add(this.txtEngine);
            this.groupBox1.Controls.Add(this.lblEngine);
            this.groupBox1.Location = new System.Drawing.Point(19, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 427);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicle Information";
            // 
            // lblPurchaseStatus
            // 
            this.lblPurchaseStatus.AutoSize = true;
            this.lblPurchaseStatus.Location = new System.Drawing.Point(21, 394);
            this.lblPurchaseStatus.Name = "lblPurchaseStatus";
            this.lblPurchaseStatus.Size = new System.Drawing.Size(42, 13);
            this.lblPurchaseStatus.TabIndex = 25;
            this.lblPurchaseStatus.Text = "Status:";
            // 
            // cbPurchaseStatus
            // 
            this.cbPurchaseStatus.FormattingEnabled = true;
            this.cbPurchaseStatus.Items.AddRange(new object[] {
            "Initial Inspection",
            "Initial Cleaning",
            "Mechanical Repairs",
            "Final Cleaning",
            "Listed",
            "Pending",
            "Sold"});
            this.cbPurchaseStatus.Location = new System.Drawing.Point(98, 390);
            this.cbPurchaseStatus.Name = "cbPurchaseStatus";
            this.cbPurchaseStatus.Size = new System.Drawing.Size(150, 21);
            this.cbPurchaseStatus.TabIndex = 24;
            // 
            // lblVehicleType
            // 
            this.lblVehicleType.AutoSize = true;
            this.lblVehicleType.Location = new System.Drawing.Point(21, 35);
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Size = new System.Drawing.Size(35, 13);
            this.lblVehicleType.TabIndex = 23;
            this.lblVehicleType.Text = "Type:";
            // 
            // cbVehicleType
            // 
            this.cbVehicleType.FormattingEnabled = true;
            this.cbVehicleType.Items.AddRange(new object[] {
            "Purchased",
            "Potential Purchase"});
            this.cbVehicleType.Location = new System.Drawing.Point(98, 30);
            this.cbVehicleType.Name = "cbVehicleType";
            this.cbVehicleType.Size = new System.Drawing.Size(150, 21);
            this.cbVehicleType.TabIndex = 22;
            this.cbVehicleType.SelectedValueChanged += new System.EventHandler(this.cbVehicleType_SelectedValueChanged);
            // 
            // txtVIN
            // 
            this.txtVIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVIN.Location = new System.Drawing.Point(98, 65);
            this.txtVIN.Name = "txtVIN";
            this.txtVIN.Size = new System.Drawing.Size(150, 21);
            this.txtVIN.TabIndex = 1;
            // 
            // lblVIN
            // 
            this.lblVIN.AutoSize = true;
            this.lblVIN.Location = new System.Drawing.Point(21, 69);
            this.lblVIN.Name = "lblVIN";
            this.lblVIN.Size = new System.Drawing.Size(28, 13);
            this.lblVIN.TabIndex = 0;
            this.lblVIN.Text = "VIN:";
            // 
            // cbYear
            // 
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(98, 101);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(150, 21);
            this.cbYear.TabIndex = 2;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(21, 105);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(33, 13);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "Year:";
            // 
            // cbMake
            // 
            this.cbMake.FormattingEnabled = true;
            this.cbMake.Location = new System.Drawing.Point(98, 137);
            this.cbMake.Name = "cbMake";
            this.cbMake.Size = new System.Drawing.Size(150, 21);
            this.cbMake.TabIndex = 3;
            // 
            // lblCondition
            // 
            this.lblCondition.AutoSize = true;
            this.lblCondition.Location = new System.Drawing.Point(21, 357);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(56, 13);
            this.lblCondition.TabIndex = 21;
            this.lblCondition.Text = "Condition:";
            // 
            // lblMakes
            // 
            this.lblMakes.AutoSize = true;
            this.lblMakes.Location = new System.Drawing.Point(21, 141);
            this.lblMakes.Name = "lblMakes";
            this.lblMakes.Size = new System.Drawing.Size(36, 13);
            this.lblMakes.TabIndex = 1;
            this.lblMakes.Text = "Make:";
            // 
            // cbCondition
            // 
            this.cbCondition.FormattingEnabled = true;
            this.cbCondition.Items.AddRange(new object[] {
            "Excellent",
            "Good",
            "Average",
            "Poor"});
            this.cbCondition.Location = new System.Drawing.Point(98, 353);
            this.cbCondition.Name = "cbCondition";
            this.cbCondition.Size = new System.Drawing.Size(150, 21);
            this.cbCondition.TabIndex = 9;
            // 
            // txtModel
            // 
            this.txtModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModel.Location = new System.Drawing.Point(98, 173);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(150, 21);
            this.txtModel.TabIndex = 4;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(21, 321);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(36, 13);
            this.lblColor.TabIndex = 17;
            this.lblColor.Text = "Color:";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(21, 177);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(39, 13);
            this.lblModel.TabIndex = 3;
            this.lblModel.Text = "Model:";
            // 
            // cbColors
            // 
            this.cbColors.FormattingEnabled = true;
            this.cbColors.Location = new System.Drawing.Point(98, 317);
            this.cbColors.Name = "cbColors";
            this.cbColors.Size = new System.Drawing.Size(150, 21);
            this.cbColors.TabIndex = 8;
            // 
            // txtMileage
            // 
            this.txtMileage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMileage.Location = new System.Drawing.Point(98, 209);
            this.txtMileage.Name = "txtMileage";
            this.txtMileage.Size = new System.Drawing.Size(150, 21);
            this.txtMileage.TabIndex = 5;
            // 
            // lblTransmission
            // 
            this.lblTransmission.AutoSize = true;
            this.lblTransmission.Location = new System.Drawing.Point(21, 285);
            this.lblTransmission.Name = "lblTransmission";
            this.lblTransmission.Size = new System.Drawing.Size(72, 13);
            this.lblTransmission.TabIndex = 15;
            this.lblTransmission.Text = "Transmission:";
            // 
            // lblMileage
            // 
            this.lblMileage.AutoSize = true;
            this.lblMileage.Location = new System.Drawing.Point(21, 213);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new System.Drawing.Size(47, 13);
            this.lblMileage.TabIndex = 2;
            this.lblMileage.Text = "Mileage:";
            // 
            // cbTransmission
            // 
            this.cbTransmission.FormattingEnabled = true;
            this.cbTransmission.Items.AddRange(new object[] {
            "Automatic",
            "Manual"});
            this.cbTransmission.Location = new System.Drawing.Point(98, 281);
            this.cbTransmission.Name = "cbTransmission";
            this.cbTransmission.Size = new System.Drawing.Size(150, 21);
            this.cbTransmission.TabIndex = 7;
            // 
            // txtEngine
            // 
            this.txtEngine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEngine.Location = new System.Drawing.Point(98, 245);
            this.txtEngine.Name = "txtEngine";
            this.txtEngine.Size = new System.Drawing.Size(150, 21);
            this.txtEngine.TabIndex = 6;
            // 
            // lblEngine
            // 
            this.lblEngine.AutoSize = true;
            this.lblEngine.Location = new System.Drawing.Point(21, 249);
            this.lblEngine.Name = "lblEngine";
            this.lblEngine.Size = new System.Drawing.Size(43, 13);
            this.lblEngine.TabIndex = 13;
            this.lblEngine.Text = "Engine:";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1024, 507);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Manage Vehicles";
            // 
            // VehicleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1032, 533);
            this.Controls.Add(this.tabVehicleManager);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VehicleManager";
            this.Text = "Vehcile Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabVehicleManager.ResumeLayout(false);
            this.tabOverveiw.ResumeLayout(false);
            this.tabOverveiw.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabAddVehicle.ResumeLayout(false);
            this.gbSellerInformation.ResumeLayout(false);
            this.gbSellerInformation.PerformLayout();
            this.gbNotes.ResumeLayout(false);
            this.gbPurchaseInfo.ResumeLayout(false);
            this.gbPurchaseInfo.PerformLayout();
            this.gbValueInfo.ResumeLayout(false);
            this.gbValueInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabVehicleManager;
        private System.Windows.Forms.TabPage tabOverveiw;
        private System.Windows.Forms.TabPage tabAddVehicle;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblVehicles;
        private System.Windows.Forms.Label lblVIN;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblMileage;
        private System.Windows.Forms.Label lblMakes;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.TextBox txtVIN;
        private System.Windows.Forms.ComboBox cbMake;
        private System.Windows.Forms.TextBox txtEngine;
        private System.Windows.Forms.TextBox txtMileage;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label lblTransmission;
        private System.Windows.Forms.ComboBox cbTransmission;
        private System.Windows.Forms.Label lblEngine;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ComboBox cbColors;
        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.ComboBox cbCondition;
        private System.Windows.Forms.DateTimePicker datePurchased;
        private System.Windows.Forms.GroupBox gbPurchaseInfo;
        private System.Windows.Forms.ComboBox cbTitleHolder;
        private System.Windows.Forms.ComboBox cbSeller;
        private System.Windows.Forms.Label lblTitleHolder;
        private System.Windows.Forms.Label lblSeller;
        private System.Windows.Forms.Label lblPurchaseDate;
        private System.Windows.Forms.TextBox txtPurhcasePrice;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.GroupBox gbValueInfo;
        private System.Windows.Forms.TextBox txtEdmundsValue;
        private System.Windows.Forms.Label lblEdmundsValue;
        private System.Windows.Forms.TextBox txtKBBValue;
        private System.Windows.Forms.Label lblKBB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddVehicle;
        private System.Windows.Forms.GroupBox gbNotes;
        private System.Windows.Forms.RichTextBox txtNotes;
        private System.Windows.Forms.Label lblVehicleType;
        private System.Windows.Forms.ComboBox cbVehicleType;
        private System.Windows.Forms.GroupBox gbSellerInformation;
        private System.Windows.Forms.TextBox txtPotentialSeller;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPotentialSeller;
        private System.Windows.Forms.TextBox txtAskingPrice;
        private System.Windows.Forms.Label lblAskingPrice;
        private System.Windows.Forms.Label lblPurchaseStatus;
        private System.Windows.Forms.ComboBox cbPurchaseStatus;
    }
}