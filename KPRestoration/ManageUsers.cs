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
using System.Net.Mail;

namespace KPRestoration
{
    public partial class ManageUsers : Form
    {
        private User currentUser = new User();
        private DatabaseHelper db = new DatabaseHelper();
        private string query = null;
        private int selectedID;
        private string defaultDGVQuery = "SELECT userID, username, firstName, lastName, email, phone, rank, userStatus FROM Users ORDER BY lastName";


        /* Constructor with userInfo parameter
         * *****************************/
        public ManageUsers(User userInfo)
        {
            InitializeComponent();
            currentUser = userInfo; 
            currentUser.PopulateRanks(cbRank);
            currentUser.PopulateUserDGV(dgvUsers, defaultDGVQuery);
        }


        /* Empty Constructor used by AddUser.cs
         * *****************************/
        public ManageUsers()
        {

        }


        /* Handles "Add User" menu option
         * *****************************/
        public void RefreshDGV()
        {
            currentUser.PopulateUserDGV(dgvUsers, "SELECT userID, username, firstName, lastName, email, phone, rank, userStatus FROM Users ORDER BY lastName");
        }


        /* Handles "Add User" menu option
         * *****************************/
        private void btnAddUser_Click_1(object sender, EventArgs e)
        {
            AddUser addUserForm = new AddUser(currentUser, this);
            addUserForm.Show();
        }


        /* Clears user information fields
         * *****************************/
        private void ResetFields()
        {
            username.Clear();
            firstName.Clear();
            lastName.Clear();
            email.Clear();
            phone.Clear();
            cbRank.SelectedIndex = -1;
            cbUserStatus.SelectedIndex = -1;
            btnSaveEdit.Enabled = false;
            btnEnable.Enabled = false;
            btnDeleteUser.Enabled = false;
            lblCurrentUser.Visible = false;

            userSearch.Select(); // Place cursor in search field
            currentUser.PopulateUserDGV(dgvUsers, defaultDGVQuery);
        }


        /* Disables all fields
         * *****************************/
        private void DisableFields()
        {
            username.Enabled = false;
            firstName.Enabled = false;
            lastName.Enabled = false;
            email.Enabled = false;
            phone.Enabled = false;
            cbUserStatus.Enabled = false;
            cbRank.Enabled = false;
            btnSaveEdit.Enabled = false;
        }


        /* Enable all user info fields when "Enable Editing" clicked
         * **************************************/
        private void btnEnable_Click(object sender, EventArgs e)
        {
            if (username.Text == "" || firstName.Text == "")
            {
                MessageBox.Show("Please select a user to edit.");
            }
            else
            {
                username.Enabled = true;
                firstName.Enabled = true;
                lastName.Enabled = true;
                email.Enabled = true;
                phone.Enabled = true;
                cbUserStatus.Enabled = true;
                cbRank.Enabled = true;
                btnSaveEdit.Enabled = true;
            }
        }


        /* Updates database when edit clicked
         * *****************************/
        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            string phoneNumber = null;
            bool isValidPhone = false;
            string errors = null;

            // Validate email
            bool isValidEmail = Globals.IsEmail(email.Text);
            if (!isValidEmail) { errors += "\u2022 Invalid email address\n"; }

            // Verify phone can be formatted properly if entered
            if (phone.Text != "" || phone.Text != null)
            {
                if (Globals.IsPhoneNumber(phone.Text))
                {
                    phoneNumber = Globals.FormatPhoneNumber(phone.Text);
                    isValidPhone = true; 
                }
                else
                {
                    isValidPhone = false;
                    errors += "\u2022 Invalid phone number\n";
                }
            }


            if (!isValidEmail || !isValidPhone) // Show error and do not execute update query if invalid input is found
                MessageBox.Show("Please fix the following errors and try again: \n\n" + errors + "\n", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else // Execute query if inpout is valid
            {
                // Prevent user from modifying rank or access level of themselves
                if (selectedID == currentUser.Id && (username.Text != currentUser.Username || Convert.ToInt32(cbRank.Text.ToString()) != currentUser.Rank || cbUserStatus.Text != currentUser.Status))
                {
                    MessageBox.Show("You cannot modify the rank or status of the account you are currently logged in on. To modify these values for this user, please login from a different account.", "Edit Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string updateQuery = "UPDATE Users SET username = @user, firstName = @firstName, lastName = @lastName, email = @email, phone = @phone, rank = @rank, userStatus = @userStatus  WHERE userID = @selectedID";
                    MySqlCommand cmd = new MySqlCommand(updateQuery, db.conn);
                    cmd.Parameters.AddWithValue("@user", username.Text);
                    cmd.Parameters.AddWithValue("@firstName", firstName.Text);
                    cmd.Parameters.AddWithValue("@lastName", lastName.Text);
                    cmd.Parameters.AddWithValue("@email", email.Text);
                    cmd.Parameters.AddWithValue("@phone", phoneNumber);
                    cmd.Parameters.AddWithValue("@rank", Convert.ToInt32(cbRank.Text.ToString()));
                    cmd.Parameters.AddWithValue("@userStatus", cbUserStatus.Text.ToString());
                    cmd.Parameters.AddWithValue("@selectedID", selectedID);

                    if (db.ExecuteCommand(cmd))
                    {
                        MessageBox.Show("User information updated.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetFields();
                        DisableFields();
                        currentUser.PopulateUserDGV(dgvUsers, defaultDGVQuery);
                    }
                    else
                    {
                        MessageBox.Show("Error encountered while updating user information!", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        

        /* Populates user info fields when selected
         * *****************************/
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDeleteUser.Enabled = true;
            btnEnable.Enabled = true;
            DisableFields();

            int index = e.RowIndex;
            DataGridViewRow selectedRow = dgvUsers.Rows[index];

            selectedID = Convert.ToInt32(selectedRow.Cells[0].Value);
            username.Text = selectedRow.Cells[1].Value.ToString();
            firstName.Text = selectedRow.Cells[2].Value.ToString();
            lastName.Text = selectedRow.Cells[3].Value.ToString();
            email.Text = selectedRow.Cells[4].Value.ToString();
            phone.Text = selectedRow.Cells[5].Value.ToString();
            cbRank.SelectedItem = selectedRow.Cells[6].Value;
            cbUserStatus.SelectedItem = selectedRow.Cells[7].Value.ToString();

            // Show or hide current user warning 
            if (currentUser.Username == selectedRow.Cells[1].Value.ToString())
            {
                lblCurrentUser.Visible = true;
                btnDeleteUser.Enabled = false;
            }
            else
            {
                lblCurrentUser.Visible = false;
                btnDeleteUser.Enabled = true;
            }
        }


        /* Removes selected user from the database
         * *****************************/
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string deleteUsername = username.Text;

            if (selectedID == currentUser.Id || deleteUsername == currentUser.Username) // Prevent deletion of current user
            {
                MessageBox.Show("You cannot delete the current user. To delete this user, login from another account and try again.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = MessageBox.Show("Are you sure you want to delete the user with username \"" + deleteUsername + "\"?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (DialogResult == DialogResult.Yes) // User confirmed delete
                {
                    if (deleteUsername == "") // No user selected
                        MessageBox.Show("Please select a user to delete.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        query = "DELETE FROM Users WHERE username = '" + deleteUsername + "' AND userID = " + selectedID;

                        try
                        {
                            db.Delete(query);
                            currentUser.PopulateUserDGV(dgvUsers, defaultDGVQuery);
                        }
                        catch
                        {
                            MessageBox.Show("Error while attempting to delete the user!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    // Do nothing
                }
            }
            
        }


        /* Populates dgvUsers with search results
         *      Called when user types in search box or clicks search
         * *****************************/
        private void SearchUsers()
        {
            query = "SELECT userID, username, firstName, lastName, email, phone, rank, userStatus FROM Users WHERE (username LIKE '%" + userSearch.Text.ToString() + "%') OR (email LIKE '%"+ userSearch.Text.ToString() + "%') OR (CONCAT(firstName, ' ', lastName) LIKE '%" + userSearch.Text.ToString() + "%') ORDER BY username";
            currentUser.PopulateUserDGV(dgvUsers, query);
        }


        private void btnSearchUsers_Click(object sender, EventArgs e)
        {
            SearchUsers();
        }


        private void userSearch_TextChanged(object sender, EventArgs e)
        {
            SearchUsers();
        }
        
    }
}
