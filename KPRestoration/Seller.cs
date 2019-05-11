/*********************************************************
 * KP Restoration VMS                                    *
 * Created 4/12/19 by Kyle Price                         *
 * Seller.cs - data and operations related to sellers    *
 *  Child class of Customer                              *
 * ******************************************************/

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPRestoration
{
    class Seller : Customer
    {
        DatabaseHelper db = new DatabaseHelper();
        private string sellerStatus;
        private string defaultDGVQuery = "SELECT sellerID as ID, CONCAT(firstName, ' ', lastName) AS Name, email, phone, address, city, state, zip, buyerStatus, dateAdded FROM Sellers ORDER BY Name";

        // Getters and setters
        public string SellerStatus { get => sellerStatus; set => sellerStatus = value; }


        /* Overloaded version of Add() - adds seller with with values
         * *****************************************/
        public bool Add(string fName, string lName, string phone, string email, string sellerStatus)
        {
            string query = "INSERT INTO Sellers (firstName, lastName, phone, email, sellerStatus) VALUES " +
                "(@fName, @lName, @phone, @email, @status)";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@fName", fName);
            cmd.Parameters.AddWithValue("@lName", lName);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@status", sellerStatus);
            return db.ExecuteCommand(cmd);
        }


        /* Updates seller information
         * *****************************************/
        public override bool Update()
        {
            string query = "Update Sellers SET firstName = @fName, lastName = @lName, address = @address, city = @city, state = @state, zip = @zip, phone = @phone, email = @email, sellerStatus = @status WHERE sellerID = @sellerID";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@fName", this.FirstName);
            cmd.Parameters.AddWithValue("@lName", this.LastName);
            cmd.Parameters.AddWithValue("@address", this.Address);
            cmd.Parameters.AddWithValue("@city", this.City);
            cmd.Parameters.AddWithValue("@state", this.State);
            cmd.Parameters.AddWithValue("@zip", this.Zip);
            cmd.Parameters.AddWithValue("@phone", this.Phone);
            cmd.Parameters.AddWithValue("@email", this.Email);
            cmd.Parameters.AddWithValue("@status", this.sellerStatus);
            cmd.Parameters.AddWithValue("@buyerID", this.Id);

            if (db.ExecuteCommand(cmd))
            {
                MessageBox.Show("Seller information updated successfully!", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Error updating seller information!", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /* Populate seller DGV headers and rows
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
        }

    }
}
