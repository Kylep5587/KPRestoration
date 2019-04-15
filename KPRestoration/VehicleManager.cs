using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace KPRestoration
{
    public partial class VehicleManager : Form
    {
        User currentUser = new User();
        bool addVehicleLoaded = false; // Used to indicate whether page has been previously loaded
        DatabaseHelper db = new DatabaseHelper();

        public VehicleManager(User userInfo)
        {
            InitializeComponent();
            cbVehicleType.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
            cbSeller.SelectedValue = "Add Later";
            cbTitleHolder.SelectedValue = "Add Later";
            cbPurchaseStatus.SelectedIndex = 0;
        }


        /* Adds years from min to max to combobox
         * ****************************/
        private void populateYears()
        {
            DateTime current = DateTime.Now;
            int max = current.Year;
            int min = 1980;

            for (int i = max; i >= min; i--)
                cbYear.Items.Add(i);
        }


        /* Populates makes combobox
         * Uses resource file "VehcileMakes.txt"
         * ****************************/
        private void populateMakes()
        {
            int counter = 0;
            string line;
            string fileSource = Properties.Resources.VehicleMakes;

            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream("KPRestoration.VehicleMakes.txt");

            StreamReader file = new StreamReader(stream);
            while ((line = file.ReadLine()) != null)
            {
                cbMake.Items.Add(line);
                counter++;
            }

            file.Close();
        }


        /* Populates colors combobox
         * ****************************/
        private void populateColors()
        {
            string[] colors = { "Black", "Blue", "Gold", "Green", "Red", "White", "Silver", "Yellow", "Orange", "Grey", "Purple" };
            Array.Sort(colors);

            foreach (string color in colors)
                cbColors.Items.Add(color);
        }


        /* Performs tasks when selected tab changes
         * ****************************/
        private void tabVehicleManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabVehicleManager.SelectedIndex)
            {
                case 0: // Overview Page

                    break;
                case 1: // Add Vehicle Page
                    if (!addVehicleLoaded)
                    {
                        populateYears();
                        populateMakes();
                        populateColors();
                        addVehicleLoaded = true;

                        // Set default selections
                        cbCondition.SelectedIndex = cbCondition.FindStringExact("Good");
                        cbTransmission.SelectedIndex = cbTransmission.FindStringExact("Automatic");
                        cbSeller.SelectedIndex = cbSeller.FindStringExact("Add Later");
                        cbTitleHolder.SelectedIndex = cbTitleHolder.FindStringExact("Add Later");
                    }
                        
                    break;
                case 2: // Manage Vehicle Page

                    break;
            }
        }


        /* Performs tasks when "Add Vehicle" button clicked
         * ****************************/
        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            bool vehicleAdded = false;
            string missingFieldMessage = "";
            string missingItems = "";
            string mySQLDateFormat = "yyyy-MM-dd";
            CultureInfo provider = CultureInfo.InvariantCulture; // Needed for MySQL date conversion

            // Arrays containing fields which are required for potential purchases or purchased vehicles
            string[] alwaysRequired = { "VIN", "Year", "Make", "Model", "Mileage", "Engine", "Transmission", "Color", "Condition", "edmundsValue", "kbbValue", "vehicleStatus" };
            string[] purchasedRequired = { "Purchase Date", "Purchase Price", "Seller ID", "Title Holder ID" };
            string[] potentialRequired = { "Asking Price", "Seller" };
            List<string> missingFields = new List<string>();

            // Get input values
            int year = Convert.ToInt32(cbYear.SelectedItem);
            string make;
                if (cbMake.SelectedItem == null) { make = ""; } else { make = cbMake.SelectedItem.ToString(); } // Prevent null object error
            string color;
                if (cbColors.SelectedItem == null) { color = ""; } else { color = cbColors.SelectedItem.ToString(); }
            string VIN = txtVIN.Text.ToString();
            string model = txtModel.Text.ToString();
            int mileage;
                if (txtMileage.Text == "") { mileage = 0; } else { mileage = Convert.ToInt32(txtMileage.Text.Replace(",", "")); } // Prevent format error on empty string
            string engine = txtEngine.Text.ToString();
            string transmission = cbTransmission.SelectedItem.ToString();
            string condition = cbCondition.SelectedItem.ToString();
            DateTime purchaseDate = Convert.ToDateTime(datePurchased.Value.ToString(mySQLDateFormat));
            decimal edmundsValue;
                if (txtEdmundsValue.Text == "") { edmundsValue = 0; } else { edmundsValue = Convert.ToDecimal(txtEdmundsValue.Text.Replace(",", "")); }
            decimal kbbValue;
                if (txtKBBValue.Text == "") { kbbValue = 0; } else { kbbValue = Convert.ToDecimal(txtKBBValue.Text.Replace(",", "")); }
            decimal purchasePrice;
                if (txtPurhcasePrice.Text == "") { purchasePrice = 0; } else { purchasePrice = Convert.ToDecimal(txtPurhcasePrice.Text.Replace(",", "")); }
            decimal askingPrice = 0;
                if (txtAskingPrice.Text == "") { askingPrice = 0; } else { askingPrice = Convert.ToDecimal(txtAskingPrice.Text.Replace(",", "")); }
            string titleHolder;
                if (cbTitleHolder.SelectedItem == null) { titleHolder = ""; } else { titleHolder = cbTitleHolder.SelectedItem.ToString(); }
            string notes = txtNotes.Text;

            // Set buyer ID to current user
            int buyerID = currentUser.Id;
            // Get seller ID
            int sellerID;
            if (cbSeller.SelectedItem.ToString() == "Add Later" || cbSeller.SelectedItem.ToString() == "" || cbSeller.SelectedItem.ToString() == null)
                sellerID = 1; // Default seller
            else
                sellerID = db.GetInt("SELECT sellerID FROM Sellers WHERE CONCAT(firstName, ' ', lastName) = '" + cbSeller.SelectedItem.ToString() + "' LIMIT 1;");

            // Get title holder ID
            int titleHolderID;
            if (cbTitleHolder.SelectedItem.ToString() == "Add Later" || cbTitleHolder.SelectedItem.ToString() == "" || cbTitleHolder.SelectedItem.ToString() == null)
                titleHolderID = 1;
            else
                titleHolderID = db.GetInt("SELECT titleHolderID FROM TitleHolders WHERE CONCAT(firstName, ' ', lastName) = '" + cbTitleHolder.SelectedItem.ToString() + "' LIMIT 1;");

            // Add proper required fields depending on type of vehicle being added and create object
            if (cbVehicleType.SelectedItem == "Purchased")
            {
                string echeck = "Not Tested";
                string seller;
                    if (cbSeller.SelectedItem == null) { seller = ""; } else { seller = cbSeller.SelectedItem.ToString(); }
                string vehicleStatus;
                    if (cbPurchaseStatus.SelectedItem == null) { vehicleStatus = ""; } else { vehicleStatus = cbPurchaseStatus.SelectedItem.ToString(); }
                PurchasedVehicle newVehicle = new PurchasedVehicle(VIN, year, make, model, mileage, engine, transmission, color, condition, edmundsValue, kbbValue, echeck, vehicleStatus, notes, purchaseDate, purchasePrice, buyerID, sellerID, titleHolderID);
                if (newVehicle.VIN == "" || newVehicle.VIN.Length != 17 ) { missingFields.Add("VIN"); }
                if (newVehicle.Year == 0) { missingFields.Add("Year"); }
                if (newVehicle.Make == "") { missingFields.Add("Make"); }
                if (newVehicle.Model == "") { missingFields.Add("Model"); }
                if (newVehicle.Mileage == 0) { missingFields.Add("Mileage"); }
                if (newVehicle.Engine == "") { missingFields.Add("Engine"); }
                if (newVehicle.Color == "") { missingFields.Add("Color"); }
                if (newVehicle.PurchaseDate == null) { missingFields.Add("Purhase Date"); }
                if (newVehicle.PurchasePrice == 0 || !Globals.IsCurrency(newVehicle.PurchasePrice)) { missingFields.Add("Purchase Price"); } 
                // Validate numeric fields if entered
                if (newVehicle.EdmundsValue != 0) 
                    if (!Globals.IsCurrency(newVehicle.EdmundsValue)) { missingFields.Add("Edmunds Value"); }

                if (newVehicle.KbbValue != 0)
                    if (!Globals.IsCurrency(newVehicle.KbbValue)) { missingFields.Add("KBB Value"); }

                vehicleAdded = newVehicle.AddVehicle(newVehicle); // Attempt to insert into database
            }
            else
            {
                string seller = txtPotentialSeller.Text;
                string vehicleStatus = cbStatus.SelectedItem.ToString();
                    if (cbStatus.SelectedItem == null) { vehicleStatus = ""; } else { vehicleStatus = cbStatus.SelectedItem.ToString(); }
                PotentialVehicle newVehicle = new PotentialVehicle(VIN, year, make, model, mileage, engine, transmission, color, condition, edmundsValue, kbbValue, vehicleStatus, notes, seller, askingPrice);
                if (newVehicle.VIN == "" || newVehicle.VIN.Length < 17) { missingFields.Add("VIN"); }
                if (newVehicle.Year == 0) { missingFields.Add("Year"); }
                if (newVehicle.Make == "") { missingFields.Add("Make"); }
                if (newVehicle.Model == "") { missingFields.Add("Model"); }
                if (newVehicle.Mileage == 0) { missingFields.Add("Mileage"); }
                if (newVehicle.Engine == "") { missingFields.Add("Engine"); }
                if (newVehicle.Color == "") { missingFields.Add("Color"); }
                if (newVehicle.Seller == "") { missingFields.Add("Seller"); }
                if (newVehicle.AskingPrice == 0 || !Globals.IsCurrency(newVehicle.AskingPrice)) { missingFields.Add("Asking Price"); }
                // Validate numeric fields if entered
                if (newVehicle.EdmundsValue != 0)
                    if (!Globals.IsCurrency(newVehicle.EdmundsValue)) { missingFields.Add("Edmunds Value"); }

                if (newVehicle.KbbValue != 0)
                    if (!Globals.IsCurrency(newVehicle.KbbValue)) { missingFields.Add("KBB Value"); }

                vehicleAdded = newVehicle.AddVehicle(newVehicle); // Attempt to insert into database
            }

            if (missingFields.Count > 0)
            {
                resetLabels();

                // Handle missing required fields
                if (missingFields.Count > 0)
                {
                    missingFieldMessage = "Please enter valid information for the following:\n ";

                    foreach (var item in missingFields)
                    {
                        missingItems += "\n\u2022 " + item;

                        // Highlight labels
                        switch (item)
                        {
                            case "VIN":
                                lblVIN.ForeColor = Globals.errorColor;
                                break;
                            case "Year":
                                lblYear.ForeColor = Globals.errorColor;
                                break;
                            case "Make":
                                lblMakes.ForeColor = Globals.errorColor;
                                break;
                            case "Model":
                                lblModel.ForeColor = Globals.errorColor;
                                break;
                            case "Mileage":
                                lblMileage.ForeColor = Globals.errorColor;
                                break;
                            case "Color":
                                lblColor.ForeColor = Globals.errorColor;
                                break;
                            case "Purchase Price":
                                lblPurchasePrice.ForeColor = Globals.errorColor;
                                break;
                            case "Purchase Date":
                                lblPurchaseDate.ForeColor = Globals.errorColor;
                                break;
                            case "Edmunds Value":
                                lblEdmundsValue.ForeColor = Globals.errorColor;
                                break;
                            case "KBB Value":
                                lblKBB.ForeColor = Globals.errorColor;
                                break;
                            case "Seller":
                                lblSeller.ForeColor = Globals.errorColor;
                                break;
                            case "Asking Price":
                                lblAskingPrice.ForeColor = Globals.errorColor;
                                break;
                        }
                    }
                }

                MessageBox.Show(missingFieldMessage + missingItems, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                missingFields.Clear();
                missingItems = "";
                missingFieldMessage = "";
            }
            else
            {
                if (vehicleAdded)
                {
                    MessageBox.Show("Vehicle information successfully added to the database.");
                    tabVehicleManager.TabPages[2].Show();
                }
                else
                    MessageBox.Show("Error inserting vehicle information!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /* Resets label colors
         * ****************************/
        private void resetLabels()
        {
            lblVIN.ForeColor = SystemColors.ControlText;
            lblYear.ForeColor = SystemColors.ControlText;
            lblMakes.ForeColor = SystemColors.ControlText;
            lblModel.ForeColor = SystemColors.ControlText;
            lblMileage.ForeColor = SystemColors.ControlText;
            lblColor.ForeColor = SystemColors.ControlText;
            lblPurchasePrice.ForeColor = SystemColors.ControlText;
            lblEdmundsValue.ForeColor = SystemColors.ControlText;
            lblKBB.ForeColor = SystemColors.ControlText;
        }

        private void cbVehicleType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbVehicleType.SelectedItem == "Purchased")
            {
                gbPurchaseInfo.Visible = true;
                gbSellerInformation.Visible = false;
            }
            else 
            {
                gbSellerInformation.Visible = true;
                gbPurchaseInfo.Visible = false;
            }
        }
        
    }
}
