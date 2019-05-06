/*********************************************************
 * KP Restoration VMS                                    *
 * Created 4/12/19 by Kyle Price                         *
 * PCustomer.cs - stores data related to buyers and      *
 *  sellers.                                             *
 *  Parent class of Buyer, Seller, & TitleHolder         *
 * ******************************************************/

using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace KPRestoration
{
    class Buyer : Customer
    {
        DatabaseHelper db = new DatabaseHelper();
        private string buyerStatus;
        private string defaultDGVQuery = "SELECT buyerID as ID, CONCAT(firstName, ' ', lastName) AS Name, email, phone, address, city, state, zip, buyerStatus, dateAdded FROM Buyers ORDER BY Name";

        public string BuyerStatus { get => buyerStatus; set => buyerStatus = value; }

        /* Enters current User object data into database
         * *****************************************/
        public override bool Add()
        {
            bool buyerCreated = false;
            string query = "INSERT INTO Buyers (firstName, lastName, address, city, state, zip, phone, email, buyerStatus) VALUES " +
                "(@fName, @lName, @address, @city, @state, @zip, @phone, @email, @status)";
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

            if (db.ExecuteCommand(cmd))
            {
                MessageBox.Show("Buyer information updated successfully!", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Error updating buyer information!", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /* Delete buyer information
         * *****************************************/
        public override void Delete()
        {
            string query = "DELETE FROM Buyers WHERE buyerID = @buyerID";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@buyerID", Id);

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


        /* Delete buyer information - takes string and DGV parameters
         * *****************************************/
        public override void Delete(string name, DataGridView DGV)
        {
            System.Windows.Forms.DialogResult DialogResult = MessageBox.Show("Are you sure you want to delete the buyer: \"" + name + "\"?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes) // User confirmed delete
            {
                if (name == " ") // No user selected
                    MessageBox.Show("Please select a buyer to delete.", "No buyer Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    string query = "DELETE FROM Buyers WHERE buyerID = @buyerID";
                    MySqlCommand cmd = new MySqlCommand(query, db.conn);
                    cmd.Parameters.AddWithValue("@buyerID", Id);

                    try
                    {
                        db.ExecuteCommand(cmd);
                        MessageBox.Show("Buyer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PopulateDGV(DGV);
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
            }
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
                DGV.Columns[5].HeaderText = "City";
                DGV.Columns[6].HeaderText = "State";
                DGV.Columns[7].HeaderText = "Zip";
                DGV.Columns[8].HeaderText = "Status";
                DGV.Columns[9].HeaderText = "Date Added";
                DGV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;    // Fixed issue with email not being fully displayed
                DGV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;    // Fixed issue with address not being fully displayed
                DGV.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;    // Fixed issue with date added not being fully displayed
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
