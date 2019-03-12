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
            // Populate buyer and seller tables if empty

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
            string cleanYear, cleanMake, cleanColor;
            string missingFieldMessage = "";
            string formattingErrorMessage = "";
            string formattedItems = "";
            string missingItems = "";
            string mySQLDateFormat = "yyyy-MM-dd";
            DateTime result;
            CultureInfo provider = CultureInfo.InvariantCulture; // Needed for MySQL date conversion

            // Handle null cbYear value
            if (cbYear.SelectedItem == null)
                cleanYear = "";
            else
                cleanYear = cbYear.SelectedItem.ToString();

            // Handle null cbMake value
            if (cbMake.SelectedItem == null)
                cleanMake = "";
            else
                cleanMake = cbMake.SelectedItem.ToString();

            // Handle null cbColor value
            if (cbColors.SelectedItem == null)
                cleanColor = "";
            else
                cleanColor = cbColors.SelectedItem.ToString();

            string cleanVIN = txtVIN.Text.ToString();
            string cleanModel = txtModel.Text.ToString();
            string cleanMileage = txtMileage.Text.ToString();
            string cleanEngine = txtEngine.Text.ToString();
            string cleanTransmission = cbTransmission.SelectedItem.ToString();
            string cleanCondition = cbCondition.SelectedItem.ToString();
            string cleanPurchaseDate = datePurchased.Value.ToShortDateString(); // Need to convert to mysql date
                result = DateTime.ParseExact(cleanPurchaseDate,"m/dd/yyyy", new System.Globalization.CultureInfo("en-US"));
                cleanPurchaseDate = result.ToString(mySQLDateFormat);
            string cleanPurchasePrice = txtPurhcasePrice.Text.ToString();
            string cleanSeller = cbSeller.SelectedItem.ToString();
            string cleanTitleHolder = cbTitleHolder.SelectedItem.ToString();
            string cleanEdmundsValue = txtEdmundsValue.Text.ToString();
            string cleanKBBValue = txtKBBValue.Text.ToString();

            // Format values to currency if provided
            if (cleanEdmundsValue == "")
                cleanEdmundsValue = null;
            if (cleanKBBValue == "")
                cleanKBBValue = null;

            if (cleanPurchasePrice != null)
                cleanPurchasePrice = Globals.formatCurrency(cleanPurchasePrice);

            if (cleanEdmundsValue != null)
                cleanEdmundsValue = Globals.formatCurrency(cleanEdmundsValue);

            if (cleanKBBValue != null)
                cleanKBBValue = Globals.formatCurrency(cleanKBBValue);


            // Stores missing vehicle info fields
            IDictionary<string, string> vehicleInfo = new Dictionary<string, string>();
            vehicleInfo["VIN"] = cleanVIN;
            vehicleInfo["Year"] = cleanYear;
            vehicleInfo["Make"] = cleanMake;
            vehicleInfo["Model"] = cleanModel;
            vehicleInfo["Mileage"] = cleanMileage;
            vehicleInfo["Color"] = cleanColor;

            // Add item to missingFields list if value not given by user.
            IList<string> missingFields = new List<string>();
            foreach (KeyValuePair<string, string> entry in vehicleInfo)
            {
                if (entry.Value == "" || entry.Value == " " || entry.Value == null)
                    missingFields.Add(entry.Key);
            }

            // Stores vehicle price related input fields 
            IDictionary<string, string> priceInfo = new Dictionary<string, string>();
            priceInfo["Purchase Price"] = cleanPurchasePrice;
            priceInfo["Edmunds Value"] = cleanEdmundsValue;
            priceInfo["KBB Value"] = cleanKBBValue;

            IList<string> missingMonetaryFields = new List<string>();

            // 
            foreach (KeyValuePair<string, string> entry in priceInfo)
            {
                if (entry.Value != "" && entry.Value != null)
                {
                    if (!Globals.isCurrency(entry.Value))
                        missingMonetaryFields.Add(entry.Key); // Add field to missing monetary value list
                }
            }

            if (missingFields.Count > 0 || missingMonetaryFields.Count > 0)
            {
                resetLabels();

                // Handle missing required fields
                if (missingFields.Count > 0)
                {
                    missingFieldMessage = "The following items are required:\n ";

                    foreach (var item in missingFields)
                    {
                        missingItems += "\n" + item;

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
                        }
                    }
                }

                // Handle imporoperly formatted items
                if (missingMonetaryFields.Count > 0)
                {
                    formattingErrorMessage = "\n\nThe following fields must contain only numeric data: ";  // Only appears in error message if formatting errors are present
                    // Highlight labels of improperly formatted numeric fields
                    foreach (var item in missingMonetaryFields)
                    {
                        formattedItems += "\n" + item;
                        switch (item)
                        {
                            case "Purchase Price":
                                lblPurchasePrice.ForeColor = Globals.errorColor;
                                break;
                            case "Edmunds Value":
                                lblEdmundsValue.ForeColor = Globals.errorColor;
                                break;
                            case "KBB Value":
                                lblKBB.ForeColor = Globals.errorColor;
                                break;
                        }
                    }
                }

                MessageBox.Show(missingFieldMessage + missingItems + formattingErrorMessage + formattedItems, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                missingFields.Clear();
                vehicleInfo.Clear();
                missingMonetaryFields.Clear();
                priceInfo.Clear();
                missingItems = "";
                formattedItems = "";
                formattingErrorMessage = "";
                missingFieldMessage = "";
            }

            else
            {
                // Set buyer ID to current user
                int buyerID = currentUser.getID();

                // Get seller ID
                int sellerID;  
                if (cbSeller.SelectedItem.ToString() != "Add Later")
                    sellerID = 1; // Default seller
                else
                {
                    sellerID = db.getInt("SELECT sellerID FROM Sellers WHERE CONCAT(firstName, ' ', lastName) = '" + cbSeller.SelectedItem.ToString() + "' LIMIT 1;");
                }

                // Get title holder ID
                int titleHolderID; 
                if (cbTitleHolder.SelectedItem.ToString() != "Add Later")
                    titleHolderID = 1;
                else
                {
                    titleHolderID = db.getInt("SELECT titleHolderID FROM TitleHolders WHERE CONCAT(firstName, ' ', lastName) = '" + cbTitleHolder.SelectedItem.ToString() + "' LIMIT 1;");
                }

                // Get title holder id
                // Insert data
                string query = "INSERT INTO Vehicles (VIN, modelYear, make, model, mileage, engineSize, transmission, color, vehicleCondition, edmundsValue, kbbValue, echeckStatus, purchaseDate, listedDate, saleDate, purchasePrice, salePrice, vehicleStatus, sellerID, buyerID, titleHolderID, notes) " +
                               "VALUES (@VIN, @ModelYear, @Make, @Model, @Mileage, @Engine, @Transmission, @Color, @Condition, @EdmundsValue, @KBBValue," +
                               " @EcheckStatus, @PurchaseDate, @ListedDate, @SaleDate, @PurchasePrice, @SalePrice, @Status, @SellerID, @BuyerID, @TitleHolderID, @Notes);";
                MySqlConnection connection = new MySqlConnection(DatabaseHelper.connectionString);
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlParameter param = new MySqlParameter();

                cmd.Parameters.AddWithValue("@VIN", cleanVIN);
                cmd.Parameters.AddWithValue("@ModelYear", cleanYear);
                cmd.Parameters.AddWithValue("@Make", cleanMake);
                cmd.Parameters.AddWithValue("@Model", cleanModel);
                cmd.Parameters.AddWithValue("@Mileage", cleanMileage);
                cmd.Parameters.AddWithValue("@Engine", cleanEngine);
                cmd.Parameters.AddWithValue("@Transmission", cleanTransmission);
                cmd.Parameters.AddWithValue("@Color", cleanColor);
                cmd.Parameters.AddWithValue("@Condition", cleanYear);
                cmd.Parameters.AddWithValue("@EdmundsValue", cleanEdmundsValue);
                cmd.Parameters.AddWithValue("@KBBValue", cleanKBBValue);
                cmd.Parameters.AddWithValue("@EcheckStatus", "Not Tested");
                cmd.Parameters.AddWithValue("@PurchaseDate", cleanPurchaseDate); // Change to proper data format
                cmd.Parameters.AddWithValue("@ListedDate", null);
                cmd.Parameters.AddWithValue("@SaleDate", null);
                cmd.Parameters.AddWithValue("@PurchasePrice", cleanPurchasePrice);
                cmd.Parameters.AddWithValue("@SalePrice", null);
                cmd.Parameters.AddWithValue("@Status", "Initial Inspection");
                cmd.Parameters.AddWithValue("@SellerID", sellerID);
                cmd.Parameters.AddWithValue("@BuyerID", buyerID);
                cmd.Parameters.AddWithValue("@TitleHolderID", titleHolderID);
                cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.ToString());

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected == 0)
                    MessageBox.Show("Error inserting vehicle information!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Vehicle information successfully added to the database.");
                    tabVehicleManager.TabPages[2].Show();
                }
                    
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
    }
}
