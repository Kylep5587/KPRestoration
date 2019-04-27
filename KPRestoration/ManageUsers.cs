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
        private User currentUser;
        private Buyer buyer = new Buyer();
        private Buyer selectedBuyer = new Buyer();
        private DatabaseHelper db = new DatabaseHelper();
        private string query = null;
        private int selectedUserID;


        /* Constructor with userInfo parameter
         * *****************************/
        public ManageUsers(User userInfo)
        {
            InitializeComponent();
            currentUser = userInfo;
            Globals.PopulateStateList(cbBuyerState);
            currentUser.PopulateUserRanks(cbRank);
            currentUser.PopulateDGV(dgvUsers);
        }


        /* Called when Add User window closes
         * *****************************/
        public void RefreshUserDGV()
        {
            currentUser.PopulateDGV(dgvUsers);
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

            txtUserSearch.Select(); // Place cursor in search field
            currentUser.PopulateDGV(dgvUsers);
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
                if (selectedUserID == currentUser.Id && (username.Text != currentUser.Username || Convert.ToInt32(cbRank.Text.ToString()) != currentUser.Rank || cbUserStatus.Text != currentUser.Status))
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
                    cmd.Parameters.AddWithValue("@selectedID", selectedUserID);

                    if (db.ExecuteCommand(cmd))
                    {
                        MessageBox.Show("User information updated.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetFields();
                        DisableFields();
                        currentUser.PopulateDGV(dgvUsers);
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

            selectedUserID = Convert.ToInt32(selectedRow.Cells[0].Value);
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

            if (selectedUserID == currentUser.Id || deleteUsername == currentUser.Username) // Prevent deletion of current user
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
                        query = "DELETE FROM Users WHERE username = '" + deleteUsername + "' AND userID = " + selectedUserID;

                        try
                        {
                            db.Delete(query);
                            currentUser.PopulateDGV(dgvUsers);
                        }
                        catch
                        {
                            MessageBox.Show("Error while attempting to delete the user!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


        /* Executes search
        * **************************************/
        private void btnSearchUsers_Click(object sender, EventArgs e)
        {
            currentUser.Search(dgvUsers, txtUserSearch.Text);
        }


        /* Executes database query when user starts typing in search field
        * **************************************/
        private void txtUserSearch_TextChanged(object sender, EventArgs e)
        {
            currentUser.Search(dgvUsers, txtUserSearch.Text);
        }

        /* ==============================================================
         ======================= Buyer Related Code =====================
         ================================================================*/

        
        /* Opens Add Buyer window
        * **************************************/
        private void addBuyerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBuyer addBuyerForm = new AddBuyer(currentUser, this);
            addBuyerForm.Show();
        }


        /* Called when Add Buyer window closes
         * *****************************/
        public void RefreshBuyerDGV()
        {
            buyer.PopulateDGV(dgvBuyers);
        }


        /* Populates buyer information fields when DGV row selected
        * **************************************/
        private void dgvBuyers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDeleteBuyer.Enabled = true;

            int index = e.RowIndex;
            DataGridViewRow selectedRow = dgvBuyers.Rows[index];

            string[] buyerNameArray = selectedRow.Cells[1].Value.ToString().Split(' ');     // Breaks last name and first name apart

            // Sets address fields if address provided
            if (selectedRow.Cells[4].Value.ToString() != "")
            {
                string[] buyerAddressArray = selectedRow.Cells[4].Value.ToString().Split(' '); // Breaks address into address, city, state, and zip
                txtBuyerAddress.Text = buyerAddressArray[0];
                txtBuyerCity.Text = buyerAddressArray[1];
                cbBuyerState.SelectedItem = buyerAddressArray[2];
                txtBuyerZip.Text = buyerAddressArray[3];
            }
            cbBuyerStatus.SelectedItem = selectedRow.Cells[5].Value.ToString();

            // Set selected buyer info
            selectedBuyer.Id = Convert.ToInt32(selectedRow.Cells[0].Value);
            selectedBuyer.FirstName = buyerNameArray[0];
            selectedBuyer.LastName = buyerNameArray[1];
            selectedBuyer.BuyerStatus = selectedRow.Cells[5].Value.ToString();
            if (selectedRow.Cells[4].Value.ToString() != "")
            {
                string[] buyerAddressArray = selectedRow.Cells[4].Value.ToString().Split(' '); // Breaks address into address, city, state, and zip
                selectedBuyer.Address = buyerAddressArray[0];
                selectedBuyer.City = buyerAddressArray[1];
                selectedBuyer.State = buyerAddressArray[2];
                selectedBuyer.Zip = Convert.ToInt32(buyerAddressArray[3]);
            }
            else
            {
                selectedBuyer.Address = "";
                selectedBuyer.City = "";
                selectedBuyer.State = "";
                selectedBuyer.Zip = null;
            }

            // Populate text fields
            txtFirstName.Text = selectedBuyer.FirstName;
            txtLastName.Text = selectedBuyer.LastName;
            txtBuyerEmail.Text = selectedBuyer.Email;
            txtBuyerPhone.Text = selectedBuyer.Phone;
            txtBuyerAddress.Text = selectedBuyer.Address;
            txtBuyerCity.Text = selectedBuyer.City;
            cbBuyerState.SelectedItem = selectedBuyer.State;
            txtBuyerZip.Text = selectedBuyer.Zip.ToString();
        }


        /* Deletes selected buyer
        * **************************************/
        private void btnDeleteBuyer_Click(object sender, EventArgs e)
        {
            string buyerName = selectedBuyer.FirstName + " " + selectedBuyer.LastName;
            DialogResult = MessageBox.Show("Are you sure you want to delete the buyer: \"" + buyerName + "\"?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (DialogResult == DialogResult.Yes) // User confirmed delete
            {
                if (buyerName == " ") // No user selected
                    MessageBox.Show("Please select a buyer to delete.", "No buyer Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    selectedBuyer.Delete();
            }
        }


        /* Populates dgvBuyers when "Buyer" tab clicked
        * **************************************/
        private void usersTabControl_Click(object sender, EventArgs e)
        {
            buyer.PopulateDGV(dgvBuyers);
        }


        /* Executes search as user types in search field
        * **************************************/
        private void txtBuyerSearch_TextChanged(object sender, EventArgs e)
        {
            buyer.Search(dgvBuyers, txtBuyerSearch.Text);
        }


        /* Executes search when user clicks "Search" button
        * **************************************/
        private void btnSearchBuyer_Click(object sender, EventArgs e)
        {
            buyer.Search(dgvBuyers, txtBuyerSearch.Text);
        }
    }
}
