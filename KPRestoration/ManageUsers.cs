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
using System.Globalization;
using System.Text.RegularExpressions;

namespace KPRestoration
{
    public partial class ManageUsers : Form
    {
        private User currentUser;
        private User selectedUser = new User();
        private Buyer buyer = new Buyer();
        private Buyer selectedBuyer = new Buyer();
        private Seller seller = new Seller();
        private Seller selectedSeller = new Seller();
        private TitleHolder titleHolder = new TitleHolder();
        private TitleHolder selectedHolder = new TitleHolder();
        private DatabaseHelper db = new DatabaseHelper();
        private bool userTabClicked = false;
        private bool buyerTabClicked = false;
        private bool sellerTabClicked = false;
        private bool holderTabClicked = false;


        /* Constructor with userInfo parameter
         * *****************************/
        public ManageUsers(User userInfo)
        {
            InitializeComponent();
            currentUser = userInfo;
            Globals.PopulateStateList(cbBuyerState);
            currentUser.PopulateUserRanks(cbUserRank);
            currentUser.PopulateDGV(dgvUsers);
        }

        // Refresh methods called when add forms are closed
        public void RefreshBuyerDGV()
        {
            buyer.PopulateDGV(dgvBuyers);
        }

        public void RefreshUserDGV()
        {
            currentUser.PopulateDGV(dgvUsers);
        }
        
        public void RefreshSellerDGV()
        {
            seller.PopulateDGV(dgvSellers);
        }

        public void RefreshHolderDGV()
        {
            titleHolder.PopulateDGV(dgvHolders);
        }


        /* Populates DGV when tab clicked for the first time
        * **************************************/
        private void usersTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (usersTabControl.SelectedTab.Name)
            {
                case "userTab":
                    if (!userTabClicked)
                    {
                        currentUser.PopulateDGV(dgvUsers);
                        userTabClicked = true;
                        txtUserSearch.Focus();
                    }
                    break;
                case "buyerTab":
                    if (!buyerTabClicked)
                    {
                        buyer.PopulateDGV(dgvBuyers);
                        buyerTabClicked = true;
                        txtBuyerSearch.Focus();
                    }
                    break;
                case "sellerTab":
                    if (!sellerTabClicked)
                    {
                        seller.PopulateDGV(dgvSellers);
                        sellerTabClicked = true;
                        txtSellerSearch.Focus();
                    }
                    break;
                case "holderTab":
                    if (!holderTabClicked)
                    {
                        titleHolder.PopulateDGV(dgvHolders);
                        holderTabClicked = true;
                        txtHolderSearch.Focus();
                    }
                    break;
            }
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
        private void ResetUserFields()
        {
            txtUsername.Clear();
            txtUserFName.Clear();
            txtUserLName.Clear();
            txtUserEmail.Clear();
            txtUserPhone.Clear();
            cbUserRank.SelectedIndex = -1;
            cbUserStatus.SelectedIndex = -1;
            btnSaveEdit.Enabled = false;
            btnDeleteUser.Enabled = false;
            lblCurrentUser.Visible = false;

            txtUserSearch.Select(); // Place cursor in search field
            currentUser.PopulateDGV(dgvUsers);
        }


        /* Populates user info fields when a user is selected
         * *****************************/
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0) // Only perform actions if the selected row is part of the table - Fixes issue error from clicking on cell header
            {
                DataGridViewRow selectedRow = dgvUsers.Rows[index];

                string[] nameArray = selectedRow.Cells[2].Value.ToString().Split(' '); // Breaks name into first and last

                // Assign values and populate editable fields
                selectedUser.Id = Convert.ToInt32(selectedRow.Cells[0].Value.ToString().Trim());
                selectedUser.Username = txtUsername.Text = selectedRow.Cells[1].Value.ToString();
                selectedUser.FirstName = txtUserFName.Text = nameArray[0];
                selectedUser.LastName = txtUserLName.Text = nameArray[1];
                selectedUser.Email = txtUserEmail.Text = selectedRow.Cells[3].Value.ToString();
                selectedUser.Phone = txtUserPhone.Text = selectedRow.Cells[4].Value.ToString();
                cbUserRank.SelectedItem = selectedUser.Rank = Convert.ToInt16(selectedRow.Cells[5].Value);
                cbUserStatus.SelectedItem = selectedUser.Status = selectedRow.Cells[6].Value.ToString();
            }

            // User tab inputs
            Label[] userLabels = { lblCurrentUser };
            TextBox[] userFields = { txtUsername, txtUserFName, txtUserLName, txtUserEmail, txtUserPhone };
            TextBox[] currentUserFields = { txtUsername };
            ComboBox[] userComboBoxes = { cbUserStatus, cbUserRank };
            Button[] userButtons = { btnSaveEdit, btnDeleteUser };
            Button[] currentUserBtns = { btnDeleteUser };

            // Enable delete button when user is selected only if user is not current user
            if (selectedUser.Id != currentUser.Id)
            {
                selectedUser.EnableFields(userFields, userComboBoxes, userButtons, userLabels);
                lblCurrentUser.Hide();
            }
            else  // Disable editing if current user selected
            {
                selectedUser.DisableFields(currentUserFields, userComboBoxes, currentUserBtns, userLabels);
                lblCurrentUser.Show();
            }
        }


        /* Updates database when edit clicked
         * *****************************/
        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            string errors = null;

            // Retrieve user password
            MySqlCommand cmd = new MySqlCommand("GET_USER_PASSWORD", db.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = selectedUser.Id;
            cmd.Parameters["@id"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@userPass", SqlDbType.VarChar).Direction = ParameterDirection.Output;
            db.ExecuteCommand(cmd);
            
            // Set values
            selectedUser.Password = cmd.Parameters["@userPass"].Value.ToString();   // Assign password retrieved from stored procedure exuction above
            selectedUser.FirstName = txtUserFName.Text;
            selectedUser.LastName = txtUserLName.Text;
            selectedUser.Email = txtUserEmail.Text;
            selectedUser.Phone = txtUserPhone.Text;
            selectedUser.Status = cbUserStatus.SelectedItem.ToString();
            selectedUser.Rank = Convert.ToInt16(cbUserRank.SelectedItem.ToString());
            
            // Check entered data
            errors = selectedUser.CheckData("user", "Update", selectedUser.Phone, selectedUser.Email, selectedUser.FirstName, selectedUser.LastName, selectedUser.Zip.ToString(), null);

            // Prevent user from modifying rank or access level of themselves
            if (selectedUser.Id == currentUser.Id && (selectedUser.Rank != currentUser.Rank || selectedUser.Username != currentUser.Username || selectedUser.Status != currentUser.Status))
                MessageBox.Show("You cannot modify the username, rank, or status of the account you are currently logged in on. To modify these values for this user, please login from a different account.", "Edit Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (errors == null) // Errors were found in submitted data
            {
                selectedUser.Update();
                selectedUser.PopulateDGV(dgvUsers);
            }
            else
                MessageBox.Show("Please correct the following errors and try again: \n" + errors, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        
        
        /* Removes selected user from the database
         * *****************************/
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string deleteUsername = txtUsername.Text;

            if (selectedUser.Id == currentUser.Id || deleteUsername == currentUser.Username) // Prevent deletion of current user
            {
                MessageBox.Show("You cannot delete the current user. To delete this user, login from another account and try again.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                selectedUser.Delete("user", deleteUsername, dgvUsers);
        }


        /* Executes search
        * **************************************/
        private void btnSearchUsers_Click(object sender, EventArgs e)
        {
            currentUser.Search(dgvUsers, txtUserSearch.Text, "users");
        }


        /* Executes database query when user starts typing in search field
        * **************************************/
        private void txtUserSearch_TextChanged(object sender, EventArgs e)
        {
            currentUser.Search(dgvUsers, txtUserSearch.Text, "users");
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


        /* Populates buyer information fields when DGV row selected
        * **************************************/
        private void dgvBuyers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Label[] buyerLabels = { };
            TextBox[] buyerFields = { txtBuyerFName, txtBuyerLName, txtBuyerEmail, txtBuyerPhone, txtBuyerAddress, txtBuyerCity, txtBuyerZip };
            ComboBox[] buyerComboBoxes = { cbBuyerState, cbBuyerStatus };
            Button[] buyerButtons = { btnSaveBuyerEdit, btnDeleteBuyer };
            selectedBuyer.EnableFields(buyerFields, buyerComboBoxes, buyerButtons, buyerLabels);

            int index = e.RowIndex;
            if (index >= 0) // Only perform actions if the selected row is part of the table - Fixes issue error from clicking on cell header
            {
                DataGridViewRow selectedRow = dgvBuyers.Rows[index];

                string[] buyerNameArray = selectedRow.Cells[1].Value.ToString().Split(' ');     // Breaks last name and first name apart
                int? zip = null;
                if (selectedRow.Cells[7].Value.ToString().Trim() != "")
                    zip = Convert.ToInt32(selectedRow.Cells[7].Value.ToString().Trim());

                // Set selected buyer info & populate text fields
                selectedBuyer.Id = Convert.ToInt32(selectedRow.Cells[0].Value.ToString().Trim());
                txtBuyerFName.Text = selectedBuyer.FirstName = buyerNameArray[0];
                txtBuyerLName.Text = selectedBuyer.LastName = buyerNameArray[1];
                txtBuyerEmail.Text = selectedBuyer.Email = selectedRow.Cells[2].Value.ToString().Trim();
                txtBuyerPhone.Text = selectedBuyer.Phone = selectedRow.Cells[3].Value.ToString().Trim();
                txtBuyerAddress.Text = selectedBuyer.Address = selectedRow.Cells[4].Value.ToString().Trim();
                txtBuyerCity.Text = selectedBuyer.City = selectedRow.Cells[5].Value.ToString().Trim();
                cbBuyerState.SelectedItem = selectedBuyer.State = selectedRow.Cells[6].Value.ToString().Trim();
                selectedBuyer.Zip = zip;
                txtBuyerZip.Text = zip.ToString();
                cbBuyerStatus.SelectedItem = selectedBuyer.BuyerStatus = selectedRow.Cells[8].Value.ToString().Trim();
                
            }
        }


        /* Deletes selected buyer
        * **************************************/
        private void btnDeleteBuyer_Click(object sender, EventArgs e)
        {
            string buyerName = selectedBuyer.FirstName + " " + selectedBuyer.LastName;
            selectedBuyer.Delete("buyer", buyerName, dgvBuyers);
        }


        /* Executes search as user types in search field
        * **************************************/
        private void txtBuyerSearch_TextChanged(object sender, EventArgs e)
        {
            buyer.Search(dgvBuyers, txtBuyerSearch.Text, "buyers");
        }


        /* Executes search when user clicks "Search" button
        * **************************************/
        private void btnSearchBuyer_Click(object sender, EventArgs e)
        {
            buyer.Search(dgvBuyers, txtBuyerSearch.Text, "buyers");
        }


        /* Updates selected user data when "Save" Button clicked
        * **************************************/
        private void btnSaveBuyerEdit_Click(object sender, EventArgs e)
        {
            string errors = null;
            if (txtBuyerZip.Text.Length == 5)
                selectedBuyer.Zip = Convert.ToInt32(txtBuyerZip.Text.Trim());

            selectedBuyer.FirstName = txtBuyerFName.Text;
            selectedBuyer.LastName = txtBuyerLName.Text;
            selectedBuyer.Email = txtBuyerEmail.Text;
            selectedBuyer.Phone = txtBuyerPhone.Text;
            selectedBuyer.Address = txtBuyerAddress.Text;
            selectedBuyer.City = txtBuyerCity.Text;
            if (cbBuyerState.SelectedItem != null) { selectedBuyer.State = cbBuyerState.SelectedItem.ToString(); }
            selectedBuyer.BuyerStatus = cbBuyerStatus.SelectedItem.ToString();

            errors = selectedBuyer.CheckData("Buyer", "Update", selectedBuyer.Phone, selectedBuyer.Email, selectedBuyer.FirstName, selectedBuyer.LastName, selectedBuyer.Zip.ToString(), null);

            if (errors == null)
            {
                //selectedBuyer.Phone = Globals.FormatPhoneNumber(txtBuyerPhone.Text.Trim());
                selectedBuyer.Update();
                selectedBuyer.PopulateDGV(dgvBuyers);
            }
            else
                MessageBox.Show("Please correct the following errors and try again: \n" + errors, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /* ==============================================================
         ======================= Seller Related Code =====================
         ================================================================*/
        /* Populates seller information fields when DGV row selected
       * **************************************/
        private void dgvSellers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Label[] sellerLabels = { };
            TextBox[] sellerFields = { txtSellerFName, txtSellerLName, txtSellerEmail, txtSellerPhone, txtSellerAddress, txtSellerCity, txtSellerZip };
            ComboBox[] sellerComboBoxes = { cbSellerState, cbSellerStatus };
            Button[] sellerButtons = { btnSaveSellerEdit, btnDeleteSeller };
            selectedSeller.EnableFields(sellerFields, sellerComboBoxes, sellerButtons, sellerLabels);

            int index = e.RowIndex;
            if (index >= 0) // Only perform actions if the selected row is part of the table - Fixes issue error from clicking on cell header
            {
                DataGridViewRow selectedRow = dgvSellers.Rows[index];

                string[] sellerName = selectedRow.Cells[1].Value.ToString().Split(' ');     // Breaks last name and first name apart
                int? zip = null;
                if (selectedRow.Cells[7].Value.ToString().Trim() != "")
                    zip = Convert.ToInt32(selectedRow.Cells[7].Value.ToString().Trim());

                // Set selected buyer info & populate text fields
                selectedBuyer.Id = Convert.ToInt32(selectedRow.Cells[0].Value.ToString().Trim());
                txtSellerFName.Text = selectedSeller.FirstName = sellerName[0];
                txtSellerLName.Text = selectedSeller.LastName = sellerName[1];
                txtSellerEmail.Text = selectedSeller.Email = selectedRow.Cells[2].Value.ToString().Trim();
                txtSellerPhone.Text = selectedSeller.Phone = selectedRow.Cells[3].Value.ToString().Trim();
                txtSellerAddress.Text = selectedSeller.Address = selectedRow.Cells[4].Value.ToString().Trim();
                txtSellerCity.Text = selectedSeller.City = selectedRow.Cells[5].Value.ToString().Trim();
                cbSellerState.SelectedItem = selectedSeller.State = selectedRow.Cells[6].Value.ToString().Trim();
                selectedSeller.Zip = zip;
                txtBuyerZip.Text = zip.ToString();
                cbSellerStatus.SelectedItem = selectedSeller.SellerStatus = selectedRow.Cells[8].Value.ToString().Trim();
            }
        }


        /* Open add seller window
         * *********************************/
        private void btnAddSeller_Click(object sender, EventArgs e)
        {
            AddSeller form = new AddSeller(currentUser, this);
            form.Show();
        }


        /* ==============================================================
         ==================== Title Holder Related Code =================
         ================================================================*/
        /* Populates title holder information fields when DGV row selected
        * **************************************/
        private void dgvHolders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Label[] holderLabels = { };
            TextBox[] holderFields = { txtHolderFName, txtHolderLName, txtHolderEmail, txtHolderPhone, txtHolderAddress, txtHolderCity, txtHolderZip, txtHolderFee };
            ComboBox[] holderComboBoxes = { cbHolderState, cbHolderStatus, cbHolderFeeType };
            Button[] holderButtons = { btnSaveHolderEdit, btnDeleteHolder };
            selectedHolder.EnableFields(holderFields, holderComboBoxes, holderButtons, holderLabels);

            int index = e.RowIndex;
            if (index >= 0) // Only perform actions if the selected row is part of the table - Fixes issue error from clicking on cell header
            {
                DataGridViewRow selectedRow = dgvHolders.Rows[index];
                string fee = selectedRow.Cells[9].Value.ToString().Trim();     
                string[] holderName = selectedRow.Cells[1].Value.ToString().Split(' ');     // Breaks last name and first name apart
                string feeValue = " ";
                string feeType;
                int? zip = null;

                // Determine fee type 
                if (fee.Contains('$')) 
                {
                    feeValue = fee.Replace("$", "");
                    feeType = "Flat Fee";
                }
                else
                {
                    feeValue = fee.Replace("%", "");
                    feeType = "Percentage";
                }

                if (selectedRow.Cells[7].Value.ToString().Trim() != "")
                    zip = Convert.ToInt32(selectedRow.Cells[7].Value.ToString().Trim());
                
                // Set selected holder info & populate text fields
                selectedHolder.Id = Convert.ToInt32(selectedRow.Cells[0].Value.ToString().Trim());
                txtHolderFName.Text = selectedHolder.FirstName = holderName[0];
                txtHolderLName.Text = selectedHolder.LastName = holderName[1];
                txtHolderEmail.Text = selectedHolder.Email = selectedRow.Cells[2].Value.ToString().Trim();
                txtHolderPhone.Text = selectedHolder.Phone = selectedRow.Cells[3].Value.ToString().Trim();
                txtHolderAddress.Text = selectedHolder.Address = selectedRow.Cells[4].Value.ToString().Trim();
                txtHolderCity.Text = selectedHolder.City = selectedRow.Cells[5].Value.ToString().Trim();
                cbHolderState.SelectedItem = selectedHolder.State = selectedRow.Cells[6].Value.ToString().Trim();
                selectedHolder.Zip = zip;
                txtHolderZip.Text = zip.ToString();
                cbHolderStatus.SelectedItem = selectedHolder.Status = selectedRow.Cells[8].Value.ToString().Trim();
                txtHolderFee.Text = feeValue;
                selectedHolder.Fee = Convert.ToInt32(feeValue);
                cbHolderFeeType.SelectedItem = selectedHolder.FeeType = feeType;
                if (feeValue != "")
                    selectedHolder.Fee = Convert.ToInt16(feeValue);
                else
                    selectedHolder.Fee = 0;
            }
        }


        /* Edit title holder information
         * ***********************************/
        private void btnSaveHolderEdit_Click(object sender, EventArgs e)
        {
            string errors = null;

            selectedHolder.FirstName = txtHolderFName.Text;
            selectedHolder.LastName = txtHolderLName.Text;
            selectedHolder.Email = txtHolderEmail.Text;
            selectedHolder.Phone = txtHolderPhone.Text;
            selectedHolder.Address = txtHolderAddress.Text;
            selectedHolder.City = txtHolderCity.Text;
            if (cbHolderState.SelectedItem != null) { selectedHolder.State = cbHolderState.SelectedItem.ToString(); }
            if (cbHolderFeeType.SelectedItem != null) { selectedHolder.FeeType = cbHolderFeeType.SelectedItem.ToString(); }
            if (txtHolderZip.Text.Trim() != "") { selectedHolder.Zip = Convert.ToInt32(txtHolderZip.Text.Trim()); }
            selectedHolder.Status = cbHolderStatus.SelectedItem.ToString();

            if (txtHolderFee.Text != "")
            {
                Regex pattern = new Regex("[$%]");
                selectedHolder.Fee = Convert.ToInt32(pattern.Replace(txtHolderFee.Text, "").Trim());
            }

            // Check for input errors
            errors = selectedHolder.CheckData("Holder", "Update", selectedHolder.Phone, selectedHolder.Email, selectedHolder.FirstName, selectedHolder.LastName, selectedHolder.Zip.ToString(), selectedHolder.Fee.ToString());

            if (errors == null)
            {
                selectedHolder.Phone = Globals.FormatPhoneNumber(txtHolderPhone.Text.Trim());
                selectedHolder.Update();
                selectedHolder.PopulateDGV(dgvHolders);
            }
            else
                MessageBox.Show("Please correct the following errors and try again: \n" + errors, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        /* Open add title holder window
         * ***********************************/
        private void btnAddHolder_Click(object sender, EventArgs e)
        {
            AddTitleHolder form = new AddTitleHolder(currentUser, this);
            form.Show();
        }
    }
}
