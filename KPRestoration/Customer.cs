/*********************************************************
 * KP Restoration VMS                                    *
 * Created 4/12/19 by Kyle Price                         *
 * Customer.cs - stores data related to buyers, sellers, *
 *  and title holders.                                   *
 *  Parent class of Buyer, Seller, & TitleHolder         *
 * ******************************************************/

using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KPRestoration
{
    public abstract class Customer
    {
        DatabaseHelper db = new DatabaseHelper();

        // Members
        private int id;
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string state;
        private int? zip;   // nullable
        private string phone;
        private string email;

        // Getters and setters
        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string State { get => state; set => state = value; }
        public int? Zip { get => zip; set => zip = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string City { get => city; set => city = value; }

        /* Adds a new entry of the customer type
         * *******************************/
        public bool Add(string customerType, Dictionary<string, string> customerParams)
        {
            string query = null;
            switch (customerType.ToLower())
            {
                case "user":
                    query = "INSERT INTO Users (username, pass, firstName, lastName, email, phone, registrationDate, rank, userStatus) VALUES " +
                            "(@username, @password, @fName, @lName, @email, @phone, @dateAdded, @rank, @status)";
                    break;
                case "buyer":
                    query = "INSERT INTO Buyers (firstName, lastName, address, city, state, zip, phone, email, buyerStatus) VALUES " +
                            "(@fName, @lName, @address, @city, @state, @zip, @phone, @email, @status)";
                    break;
                case "seller":
                    query = "INSERT INTO Sellers (firstName, lastName, address, city, state, zip, phone, email, sellerStatus) VALUES " +
                            "(@fName, @lName, @address, @city, @state, @zip, @phone, @email, @status)";
                    break;
                case "holder":
                    query = "INSERT INTO TitleHolders (firstName, lastName, address, city, state, zip, phone, email, holderStatus, fee, feeType) VALUES " +
                            "(@fName, @lName, @address, @city, @state, @zip, @phone, @email, @status, @fee, @feeType)";
                    break;
            }
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            foreach (KeyValuePair<string, string> p in customerParams)
                cmd.Parameters.AddWithValue(p.Key, p.Value);

            return db.ExecuteCommand(cmd);
        }


        /* Determines if email is present in the database
         * *********************************************/
        public bool EmailExists(string customerType, string email)
        {
            string retrievedEmail = "";
            string query = null;

            switch (customerType.ToLower()) // Determine which queries to use based on customer type = Buyer, Seller, or TitleHolder
            {
                case "user":
                    query = "SELECT email FROM Users WHERE email = @email LIMIT 1";
                    break;
                case "buyer":
                    query = "SELECT email FROM Buyers WHERE email = @email LIMIT 1";
                    break;
                case "seller":
                    query = "SELECT email FROM Sellers WHERE email = @email LIMIT 1";
                    break;
                case "holder":
                    query = "SELECT email FROM TitleHolders WHERE email = @email LIMIT 1";
                    break;
            }

            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@email", email);

            if (db.ExecuteCommand(cmd))
            {
                db.OpenConnection();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    retrievedEmail = dr["email"].ToString();

                db.CloseConnection();
                if (retrievedEmail == email)
                    return true;
                else
                    return false;
            }
            return false;
        }


        /* Checks if name present in database
         * *******************************/
        public bool NameExists(string customerType, string firstName, string lastName)
        {
            string name = firstName + " " + lastName;
            string retrievedName = null;
            string query = null;

            switch (customerType.ToLower()) // Determine which queries to use based on customer type = Buyer, Seller, or TitleHolder
            {
                case "user":
                    query = "SELECT CONCAT(firstName, ' ', lastName) AS RetrievedName FROM Users WHERE CONCAT(firstName, ' ', lastName) = @name LIMIT 1";
                    break;
                case "buyer":
                    query = "SELECT CONCAT(firstName, ' ', lastName) AS RetrievedName FROM Buyers WHERE CONCAT(firstName, ' ', lastName) = @name LIMIT 1";
                    break;
                case "seller":
                    query = "SELECT CONCAT(firstName, ' ', lastName) AS RetrievedName FROM Sellers WHERE CONCAT(firstName, ' ', lastName) = @name LIMIT 1";
                    break;
                case "holder":
                    query = "SELECT CONCAT(firstName, ' ', lastName) AS RetrievedName FROM TitleHolders WHERE CONCAT(firstName, ' ', lastName) = @name LIMIT 1";
                    break;
            }
            
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@name", name);

            if (db.ExecuteCommand(cmd))
            {
                db.OpenConnection();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    retrievedName = dr["RetrievedName"].ToString();

                db.CloseConnection();
                if (name == retrievedName)
                    return true;
                else
                    return false;
            }
            return false;
        }


        /* Vefifies data before creating new customer or updating existing customer
         * *****************************/
        public string CheckData(string customerType, string checkType, string phone, string email, string firstName, string lastName, string zip, string fee)
        {
            bool inputError = false;
            bool dataConflict = false;
            string errors = "";

            // Phone validation and formatting
            if ((phone != "" && phone.Length >= 10) && Globals.IsPhoneNumber(phone))
                phone = Globals.FormatPhoneNumber(phone);
            else if (phone != "" && !Globals.IsPhoneNumber(phone))
            {
                errors += "\u2022 Invalid phone number\n";
                inputError = true;
            }
            else if (phone == "")
            {
                errors += "\u2022 Phone number required\n";
                inputError = true;
            }

            // Email validation
            if (email == "" || !Globals.IsEmail(email))
            {
                errors += "\u2022 Valid email address required\n";
                inputError = true;
            }

            // Check for first name
            if (firstName.Length < 2)
            {
                errors += "\u2022 First name required\n";
                inputError = true;
            }

            // Check if zip code is numeric and equal to 5 numbers if entered
            if (zip != "" && (!Globals.IsNumeric(zip) || zip.Length != 5))
            {
                errors += "\u2022 Invalid zip code\n";
                inputError = true;
            }

            if (!inputError && checkType.ToLower() == "new") // Check if email address and name are already in use if not updating existing user
            {
                if (this.EmailExists(customerType, email))
                {
                    dataConflict = true;
                    errors += "\u2022 Email address already registered\n";
                }

                // Check if name is already used
                if (this.NameExists(customerType, lastName, firstName))
                {
                    dataConflict = true;
                    errors += "\u2022 Name already in use\n";
                }
            }

            if (customerType.ToLower() == "holder" && fee != "")
            {
                if (!Globals.IsNumeric(fee))
                {
                    errors += "\u2022 Invalid fee amount\n";
                    inputError = true;
                }
            }


            if (inputError || dataConflict)
                return errors;
            else
                return null;
        }


        /* Performs search of correct table and populates
         *  the correct DGV with results
         * *****************************/
        public void Search(DataGridView DGV, string searchQuery, string table)
        {
            string procedureName = "";
            switch (table.ToLower())
            {
                case "users":
                    procedureName = "SEARCH_USERS";
                    break;
                case "buyers":
                    procedureName = "SEARCH_BUYERS";
                    break;
                case "holders":
                    procedureName = "SEARCH_HOLDERS";
                    break;
            }

            searchQuery = "%" + searchQuery + "%";                              // Add wildcards to the search query
            MySqlCommand cmd = new MySqlCommand(procedureName, db.conn);
            cmd.CommandType = CommandType.StoredProcedure;                      // Name of the stored procedure
            cmd.Parameters.AddWithValue("@searchQuery", searchQuery.Trim());
            db.ExecuteCommand(cmd);
            db.PopulateDGV(DGV, cmd);
        }


        /* Disables all fields
         *  "null" may be passed if there is no values for one of the arrays
         * *****************************/
        public void DisableFields(TextBox[] fields, ComboBox[] comboBoxes, Button[] buttons, Label[] labels)
        {
            if (fields != null)
            {
                foreach (TextBox field in fields)
                    field.Enabled = false;
            }

            if (comboBoxes != null)
            {
                foreach (ComboBox cb in comboBoxes)
                  cb.Enabled = false;
            }

            if (buttons != null)
            {
                foreach (Button btn in buttons)
                    btn.Enabled = false;
            }

            if (labels != null)
            {
                foreach (Label lbl in labels)
                    lbl.Visible = false;
            }
        }


        /* Enable all fields
         * *****************************/
        public void EnableFields(TextBox[] fields, ComboBox[] comboBoxes, Button[] buttons, Label[] labels)
        {
            foreach (TextBox field in fields)
                field.Enabled = true;

            foreach (ComboBox cb in comboBoxes)
                cb.Enabled = true;

            foreach (Button btn in buttons)
                btn.Enabled = true;

            foreach (Label lbl in labels)
                lbl.Visible = true;
        }


        /* Delete buyer information
         * *****************************************/
        public void Delete(string customerType, string name, DataGridView DGV)
        {
            string query = null;
            string sqlErrorMSG = null;
            string errorMSG = null;
            switch (customerType.ToLower())
            {
                case "user":
                    query = "DELETE FROM Users WHERE userID = @id";
                    sqlErrorMSG = errorMSG = "An error occured while attempting to delete the user!";
                    break;
                case "buyer":
                    query = "DELETE FROM Buyers WHERE buyerID = @id";
                    sqlErrorMSG = "The buyer is associated with a vehicle(s) currently in the database. The vehicle entry must be deleted or buyer changed before deleting this buyer.";
                    errorMSG = "An error occured while attempting to delete the buyer!";
                    break;
                case "seller":
                    query = "DELETE FROM Sellers WHERE sellerID = @id";
                    sqlErrorMSG = "The seller is associated with a vehicle(s) currently in the database. The vehicle entry must be deleted or seller changed before deleting this seller.";
                    errorMSG = "An error occured while attempting to delete the seller!";
                    break;
                case "holder":
                    query = "DELETE FROM TitleHolders WHERE titleHolderID = @id";
                    sqlErrorMSG = "The titel holder is associated with a vehicle(s) currently in the database. The vehicle entry must be deleted or title holder changed before deleting this title holder.";
                    errorMSG = "An error occured while attempting to delete the title holder!";
                    break;
                default:
                    query = null;
                    break;
            }

            if (query == null) // Invalid customerType passed to the method
                MessageBox.Show("Invalid user type!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                System.Windows.Forms.DialogResult DialogResult = MessageBox.Show("Are you sure you want to delete the entry: " + name + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (DialogResult == DialogResult.Yes) 
                {
                    MySqlCommand cmd = new MySqlCommand(query, db.conn);
                    cmd.Parameters.AddWithValue("@id", this.Id);

                    try
                    {
                        db.ExecuteCommand(cmd);
                        this.PopulateDGV(DGV);
                    }
                    catch (MySqlException)
                    {
                        MessageBox.Show(sqlErrorMSG, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch
                    {
                        MessageBox.Show(errorMSG, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
        }


        /* Abstract Methods
         * *********************************************/
        public abstract bool Update();
        public abstract void PopulateDGV(DataGridView DGV);

    }
}
