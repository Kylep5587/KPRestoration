/*********************************************************
 * KP Restoration VMS                                    *
 * Created 4/12/19 by Kyle Price                         *
 * AddBuyer.cs - used to add a buyer to the database     *
 *  Opened from ManageUsers.cs                           *
 * ******************************************************/

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPRestoration
{
    public partial class AddBuyer : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        User currentUser;
        ManageUsers owner;
        Buyer tempBuyer = new Buyer();

        /* Constructor
         * ******************************/
        public AddBuyer(User userInfo, ManageUsers formOwner)
        {
            currentUser = userInfo;
            InitializeComponent();
            owner = formOwner;  // Set the owner of this form 
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddBuyer_FormClosing); // Calls the FormClosing method upon form closure
            currentUser = userInfo;
            Globals.PopulateStateList(cbState);
            cbStatus.SelectedIndex = 0;
        }


        /* Closes Add Buyer Window
         * ******************************/
        private void btnCancelAdd_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /* Inserts new buyer into database
         * ******************************/
        private void btnAddBuyer_Click(object sender, EventArgs e)
        {
            bool dataConflict = false;
            string errorMessage = "Please fix the following input errors: \n\n";
            string errors = tempBuyer.CheckData("Buyer", "New", txtPhone.Text, txtEmail.Text, txtFirstName.Text, txtLastName.Text, txtBuyerZip.Text); // Check for valid data

            // Create user if proper input detected
            if (errors == null)
            {
                string phone = Globals.FormatPhoneNumber(txtPhone.Text);
                // Create buyer
                Buyer newBuyer = new Buyer
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = phone.Trim(),
                    Address = txtAddress.Text,
                    City = txtCity.Text.Trim(),
                    State = cbState.SelectedItem.ToString(),
                    Zip = Convert.ToInt32(txtBuyerZip.Text.Trim()),
                    BuyerStatus = cbStatus.SelectedItem.ToString()
                };
                
                if (errors != null)
                    dataConflict = true; // Set data conflict to true if CheckDataConflict returns an error string that is not null

                // Insert buyer data
                if (!dataConflict)
                {
                    bool buyerAdded = newBuyer.Add(); // Attempt to insert buyer data

                    if (buyerAdded)
                        this.Close();
                    else
                        MessageBox.Show("Error adding buyer!\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show(errorMessage + errors, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show(errorMessage + errors, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }


        /* Refresh DGV upon add form closing
         * ******************************/
        private void AddBuyer_FormClosing(object sender, FormClosingEventArgs e)
        {
            owner.RefreshBuyerDGV();
        }
    }
}
