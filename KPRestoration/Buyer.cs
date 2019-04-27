using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPRestoration
{
    class Buyer : Customer
    {
        DatabaseHelper db = new DatabaseHelper();
        private string buyerStatus;
        private string defaultDGVQuery = "SELECT buyerID as ID, CONCAT(firstName, ' ', lastName) AS Name, email, phone, CONCAT(address, ' ', city, ', ', state, ' ', zip) AS Address, buyerStatus, dateAdded FROM Buyers ORDER BY Name";

        public string BuyerStatus { get => buyerStatus; set => buyerStatus = value; }

        /* Enters current User object data into database
         * *****************************************/
        public override bool Add()
        {
            bool buyerCreated = false;
            string query = "INSERT INTO Buyers (firstName, lastName, phone, email, buyerStatus) VALUES " +
                "(@fName, @lName, @phone, @email, @status)";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@fName", this.FirstName);
            cmd.Parameters.AddWithValue("@lName", this.LastName);
            cmd.Parameters.AddWithValue("@phone", this.Phone);
            cmd.Parameters.AddWithValue("@email", this.Email);
            cmd.Parameters.AddWithValue("@status", this.BuyerStatus);
            return buyerCreated = db.ExecuteCommand(cmd);
        }


        /* Overloaded version of AddBuyer() that takes values 
         * *****************************************/
        public bool Add(string fName, string lName, string phone, string email, string buyerStatus)
        {
            bool buyerCreated = false;
            string query = "INSERT INTO Buyers (firstName, lastName, phone, email, buyerStatus) VALUES " +
                "(@fName, @lName, @phone, @email, @status)";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@fName", fName);
            cmd.Parameters.AddWithValue("@lName", lName);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@status", buyerStatus);
            return buyerCreated = db.ExecuteCommand(cmd);
        }


        /* Updates buyer information
         * *****************************************/
        public override bool Update()
        {
            bool buyerUpdated = false;
            string query = "Update Buyers SET firstName = @fName, lastName = @lName, address = @address, city = @city, state = @state, zip = @zip, phone = @phone, email = @email, buyerStatus = @status WHERE buyerID = @buyerID";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@fName", this.FirstName);
            cmd.Parameters.AddWithValue("@lName", this.LastName);
            cmd.Parameters.AddWithValue("@address", this.Address);
            cmd.Parameters.AddWithValue("@city", this.City);
            cmd.Parameters.AddWithValue("@state", this.State);
            cmd.Parameters.AddWithValue("@zip", this.Zip);
            cmd.Parameters.AddWithValue("@phone", this.Phone);
            cmd.Parameters.AddWithValue("@email", this.Email);
            cmd.Parameters.AddWithValue("@status", this.BuyerStatus);
            cmd.Parameters.AddWithValue("@buyerID", this.Id);
            return buyerUpdated = db.ExecuteCommand(cmd);
        }


        /* Delete buyer information
         * *****************************************/
        public override void Delete()
        {
            string query = "DELETE * FROM Buyers WHERE buyerID = @buyerID";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@buyerID", this.Id);

            try
            {
                db.ExecuteCommand(cmd);
                MessageBox.Show("Buyer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException)
            {
                MessageBox.Show("The buyer is associated with a vehicle currently in the database. The vehicle entry must be deleted or buyer changed before deleting this buyer.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Error while attempting to delete the buyer!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /* Checks if email present in database
         * *******************************/
        public override bool EmailExists(string email)
        {
            string query = "SELECT email FROM Buyers WHERE email = @email LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@email", email);
            bool emailExists = db.ExecuteCommand(cmd);
            return emailExists;
        }


        /* Checks if name present in database
         * *******************************/
        public override bool NameExists()
        {
            string name = this.FirstName + " " + this.LastName;
            string query = "SELECT buyerID FROM Buyers WHERE CONCAT(firstName, ' ', lastName) = @name LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@name", name);
            bool nameExists = db.ExecuteCommand(cmd);
            return nameExists;
        }


        /* Populate buyer DGV headers and rows
         * *****************************/
        public override void PopulateDGV(DataGridView DGV)
        {
            if (db.PopulateDGV(DGV, defaultDGVQuery))
            {
                DGV.Columns[0].HeaderText = "ID";
                DGV.Columns[1].HeaderText = "Name";
                DGV.Columns[2].HeaderText = "Email";
                DGV.Columns[3].HeaderText = "Phone";
                DGV.Columns[4].HeaderText = "Address";
                DGV.Columns[5].HeaderText = "Status";
                DGV.Columns[6].HeaderText = "Date Added";
                DGV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;    // Fixed issue with address not being fully displayed
            }
            else
                MessageBox.Show("There are currently no buyers in the database.", "No Users Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }


        /* Populates dgvBuyers with search results
         *      Called when user types in search box or clicks search
         * *****************************/
        public override void Search(DataGridView DGV, string searchQuery)
        {
            searchQuery = "%" + searchQuery + "%";                              // Add wildcards to the search query
            MySqlCommand cmd = new MySqlCommand("SEARCH_BUYERS", db.conn);
            cmd.CommandType = CommandType.StoredProcedure;                        // Name of the stored procedure
            cmd.Parameters.AddWithValue("@searchQuery", searchQuery.Trim());
            db.PopulateDGV(DGV, cmd);
        }
    }
}
