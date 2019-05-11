/*********************************************************
 * KP Restoration VMS                                    *
 * Created 4/12/19 by Kyle Price                         *
 * AddUser.cs - adds a user to the database              *
 *  Opened from ManageUsers.cs                           *
 *  Requires user rank of 3 to access                    *
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
    public partial class AddUser : Form
    {
        User currentUser = new User();
        ManageUsers owner;
        DatabaseHelper db = new DatabaseHelper();
        Seller newSeller = new Seller();
        TitleHolder newHolder = new TitleHolder();


        /* Constructor - Requires two objects: 
        *        User and ManageUsers
        * *****************************************/
        public AddUser(User userInfo, ManageUsers formOwner)
        {
            InitializeComponent();
            owner = formOwner;  // Set the owner of this form 
            
            currentUser = userInfo;
            currentUser.PopulateUserRanks(cbRank);
            cbRank.SelectedIndex = 0;
        }


        /* Closes Add User window when "Cancel" is clicked
        * *****************************************/
        private void btnCancelAdd_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /* Attempts to add new user to database
        * *****************************************/
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string errors = null;
            string password = Globals.Encrypt(txtInitialPass.Text);
            bool sellerCreated;
            bool holderCreated;

            User newUser = new User
            {
                Username = txtUsername.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Password = password,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Rank = Convert.ToInt16(cbRank.SelectedItem.ToString()),
                Status = "Active",
                RegistrationDate = DateTime.Now
            };

            // Check for input errors
            errors = newUser.CheckData("User", "New", newUser.Phone, newUser.Email, newUser.FirstName, newUser.LastName, null, null);

            if (errors == null)
            {
                newUser.Phone = Globals.FormatPhoneNumber(newUser.Phone.Trim());
                var userParams = new Dictionary<string, string>
                {
                    { "@username", newUser.Username },
                    { "@password", newUser.Password },
                    { "@fName", newUser.FirstName },
                    { "@lName", newUser.LastName },
                    { "@email", newUser.Email },
                    { "@phone", newUser.Phone },
                    { "@rank", newUser.Rank.ToString() },
                    { "@status", newUser.Status }
                };

                if (cbCreateSeller.Checked == true) { }
                sellerCreated = newSeller.Add(newUser.FirstName, newUser.LastName, newUser.Phone, newUser.Email, newUser.Status);

                if (cbCreateHolder.Checked == true)
                    holderCreated = newHolder.Add(newUser.FirstName, newUser.LastName, newUser.Phone, newUser.Email, newUser.Status);

                if (newUser.Add("user", userParams))
                    this.Close();
                else
                    MessageBox.Show("Error adding user!\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please correct the following errors and try again: \n" + errors, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        /* Refreshes userDGV when Add User window is closed
        * *****************************************/
        private void AddUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            owner.RefreshUserDGV();
        }
    }
}
