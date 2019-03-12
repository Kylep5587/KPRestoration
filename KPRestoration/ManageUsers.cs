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
    public partial class ManageUsers : Form
    {
        private User currentUser = new User();
        private DatabaseHelper db = new DatabaseHelper();
        private string query = null;
        private int selectedID;
        private string defaultDGVQuery = "SELECT userID, username, firstName, lastName, email, phone, rank, userStatus FROM Users ORDER BY lastName";


        /* Constructor
         * *****************************/
        public ManageUsers(User userInfo)
        {
            InitializeComponent();
            currentUser = userInfo; 
            populateRanks(cbRank);
            populateUserDGV(defaultDGVQuery);
        }

        // Possibly second constructor for for redirecting

        /* Populates access level dropdown with ranks 
         *  up to the current user's rank
         * *****************************/
        private void populateRanks(ComboBox cb)
        {
            for (int i=1; i <= currentUser.getRank(); i++)
                cb.Items.Add(i);
        }


        /* Populate user DGV headers and rows
         * *****************************/
        private void populateUserDGV(string query)
        {
            if (db.populateDGV(dgvUsers, query))
            {
                dgvUsers.Columns[0].HeaderText = "ID";
                dgvUsers.Columns[1].HeaderText = "Username";
                dgvUsers.Columns[2].HeaderText = "First";
                dgvUsers.Columns[3].HeaderText = "Last";
                dgvUsers.Columns[4].HeaderText = "Email Address";
                dgvUsers.Columns[5].HeaderText = "Phone";
                dgvUsers.Columns[6].HeaderText = "Rank";
                dgvUsers.Columns[7].HeaderText = "Status";
                this.dgvUsers.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;    // Fixed issue with email address not being fully displayed
            }
            else
                MessageBox.Show("There are currently no users in the database.", "No Users Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }


        /* Handles "Add User" menu option
         * *****************************/
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser addUserForm = new AddUser(currentUser);
            addUserForm.Show();
        }


        /* Clears user information fields
         * *****************************/
        private void resetFields()
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
            populateUserDGV(defaultDGVQuery);
        }


        /* Disables all fields
         * *****************************/
        private void disableFields()
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
            string cleanUsername = username.Text.ToString();
            string cleanFName = firstName.Text.ToString();
            string cleanLName = lastName.Text.ToString();
            string cleanEmail = email.Text.ToString();
            string cleanPhone = phone.Text.ToString();
            int cleanRank = Convert.ToInt32(cbRank.Text.ToString());
            string cleanUserStatus = cbUserStatus.Text.ToString();

            // Prevent user from modifying rank or access level of themselves
            if (selectedID == currentUser.getID() && (cleanUsername != currentUser.getUsername() || cleanRank != currentUser.getRank() || cleanUserStatus != currentUser.getStatus()))
            {
                MessageBox.Show("You cannot modify the rank or status of the account you are currently logged in on. To modify these values for this user, please login from a different account.", "Edit Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                query = "UPDATE Users SET username = '" + cleanUsername + "', firstName = '" + cleanFName + "', lastName = '" + cleanLName + "', email = '" + cleanEmail + "', phone = '" + cleanPhone + "', rank = '" + cleanRank + "', userStatus = '" + cleanUserStatus + "' WHERE userID = " + selectedID;
                if (db.Update(query))
                {
                    MessageBox.Show("User information updated.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetFields();
                    disableFields();
                    populateUserDGV(defaultDGVQuery);
                }
                else
                {
                    MessageBox.Show("Error encountered while updating user information!", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        

        /* Populates user info fields when selected
         * *****************************/
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDeleteUser.Enabled = true;
            btnEnable.Enabled = true;
            disableFields();

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
            if (currentUser.getUsername() == selectedRow.Cells[1].Value.ToString())
                lblCurrentUser.Visible = true;
            else
                lblCurrentUser.Visible = false;
        }

        /* Removes selected user from the database
         * *****************************/
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string deleteUsername = username.Text;

            if (selectedID == currentUser.getID() || deleteUsername == currentUser.getUsername()) // Prevent deletion of current user
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
                            MessageBox.Show("User removed from the database.");
                        }
                        catch
                        {
                            MessageBox.Show("Error while attempting to remove the user from the database!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void searchUsers()
        {
            string cleanUserSearch = userSearch.Text.ToString();
            query = "SELECT userID, username, firstName, lastName, email, phone, rank, userStatus FROM Users WHERE (username LIKE '%" + cleanUserSearch + "%') OR (email LIKE '%" + cleanUserSearch + "%') OR (CONCAT(firstName, ' ', lastName) LIKE '%" + cleanUserSearch + "%') ORDER BY username";
            populateUserDGV(query);
        }


        private void btnSearchUsers_Click(object sender, EventArgs e)
        {
            searchUsers();
        }


        private void userSearch_TextChanged(object sender, EventArgs e)
        {
            searchUsers();
        }
    }
}
