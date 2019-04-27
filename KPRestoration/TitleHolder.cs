﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPRestoration
{
    class TitleHolder : Customer
    {
        DatabaseHelper db = new DatabaseHelper();
        string defaultDGVQuery = "SELECT CONCAT(firstName, ' ', lastName) AS Name, email, CONCAT(address, ' ', city, ', ', state, ' ', zip) AS Address, phone, holderStatus, dateAdded FROM TitleHolders ORDER BY Name";

        // Members
        private int fee;
        private string feeType;
        private string status;

        // Getters and setters
        public int Fee { get => fee; set => fee = value; }
        public string FeeType { get => feeType; set => feeType = value; }
        public string Status { get => status; set => status = value; }


        /* Enters current User object data into database
         * *****************************************/
        public override bool Add()
        {
            bool holderCreated = false;
            string query = "INSERT INTO TitleHolders (firstName, lastName, phone, email, holderStatus) VALUES " +
                "(@fName, @lName, @phone, @email, @status)";
            MySqlCommand addHolderCMD = new MySqlCommand(query, db.conn);
            addHolderCMD.Parameters.AddWithValue("@fName", this.FirstName);
            addHolderCMD.Parameters.AddWithValue("@lName", this.LastName);
            addHolderCMD.Parameters.AddWithValue("@email", this.Email);
            addHolderCMD.Parameters.AddWithValue("@phone", this.Phone);
            addHolderCMD.Parameters.AddWithValue("@status", this.Status);
            return holderCreated = db.ExecuteCommand(addHolderCMD);
        }


        /* Overloaded version of AddTitleHolder() that takes values 
         * *****************************************/
        public bool Add(string fName, string lName, string phone, string email, string holderStatus)
        {
            bool holderCreated = false;
            string query = "INSERT INTO TitleHolders (firstName, lastName, phone, email, holderStatus) VALUES " +
                "(@fName, @lName, @phone, @email, @status)";
            MySqlCommand addHolderCMD = new MySqlCommand(query, db.conn);
            addHolderCMD.Parameters.AddWithValue("@fName", fName);
            addHolderCMD.Parameters.AddWithValue("@lName", lName);
            addHolderCMD.Parameters.AddWithValue("@email", email);
            addHolderCMD.Parameters.AddWithValue("@phone", phone);
            addHolderCMD.Parameters.AddWithValue("@status", holderStatus);
            return holderCreated = db.ExecuteCommand(addHolderCMD);
        }


        /* Updates title holder information
         * *****************************************/
        public override bool Update()
        {
            bool buyerUpdated = false;
            string query = "Update TitleHolder SET firstName = @fName, lastName = @lName, address = @address, city = @city, state = @state, zip = @zip, phone = @phone, email = @email, holderStatus = @status WHERE titleHolderID = @titleHolderID";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@fName", this.FirstName);
            cmd.Parameters.AddWithValue("@lName", this.LastName);
            cmd.Parameters.AddWithValue("@address", this.Address);
            cmd.Parameters.AddWithValue("@city", this.City);
            cmd.Parameters.AddWithValue("@state", this.State);
            cmd.Parameters.AddWithValue("@zip", this.Zip);
            cmd.Parameters.AddWithValue("@phone", this.Phone);
            cmd.Parameters.AddWithValue("@email", this.Email);
            cmd.Parameters.AddWithValue("@status", this.Status);
            cmd.Parameters.AddWithValue("@titleHolderID", this.Id);
            return buyerUpdated = db.ExecuteCommand(cmd);
        }


        /* Delete buyer information
         * *****************************************/
        public override void Delete()
        {
            string query = "DELETE * FROM TitleHolders WHERE buyerID = @titleHolderID";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@titleHolderID", this.Id);
            try
            {
                db.ExecuteCommand(cmd);
                MessageBox.Show("Title holder deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException)
            {
                MessageBox.Show("The title holder is associated with a vehicle currently in the database. The vehicle entry must be deleted or title holder changed before deleting this buyer.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Error while attempting to delete the title holder!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /* Checks if email present in database
         * *******************************/
        public override bool EmailExists(string email)
        {
            string query = "SELECT email FROM TitleHolders WHERE email = @email LIMIT 1";
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
            string query = "SELECT titleHolderID FROM TitleHolders WHERE CONCAT(firstName, ' ', lastName) = @name LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@name", name);
            bool nameExists = db.ExecuteCommand(cmd);
            return nameExists;
        }


        /* Populate title holder DGV headers and rows
         * *****************************/
        public override void PopulateDGV(DataGridView DGV)
        {
            if (db.PopulateDGV(DGV, defaultDGVQuery))
            {
                DGV.Columns[0].HeaderText = "Name";
                DGV.Columns[1].HeaderText = "Phone";
                DGV.Columns[2].HeaderText = "Email";
                DGV.Columns[3].HeaderText = "Address";
                DGV.Columns[4].HeaderText = "Status";
                DGV.Columns[5].HeaderText = "Date Added";
                DGV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;    // Fixed issue with address not being fully displayed
            }
            else
                MessageBox.Show("There are currently no buyers in the database.", "No Users Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }


        /* Populates dgvBuyers with search results
         *      Called when user types in search box or clicks search
         * *****************************/
        public override void Search(DataGridView DGV, string searchQuery)
        {
            string query = "SELECT CONCAT(firstName, ' ', lastName) AS Name, email, CONCAT(address, ' ', city, ', ', state, ' ', zip) AS Address, phone, holderStatus, dateAdded FROM TitleHolders WHERE (buyerStatus LIKE '% @searchQuery %') OR (email LIKE '% + @searchQuery %') OR (CONCAT(firstName, ' ', lastName) LIKE '% @searchQuery %') ORDER BY Name";
            db.PopulateDGV(DGV, query);
            DGV.Columns[0].HeaderText = "Name";
            DGV.Columns[1].HeaderText = "Phone";
            DGV.Columns[2].HeaderText = "Email";
            DGV.Columns[3].HeaderText = "Address";
            DGV.Columns[4].HeaderText = "Status";
            DGV.Columns[5].HeaderText = "Date Added";
            DGV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;    // Fixed issue with address not being fully displayed


        }
    }
}
