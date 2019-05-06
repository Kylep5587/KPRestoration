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
        Buyer newBuyer = new Buyer();
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
            string password = Globals.Encrypt(txtInitialPass.Text);
            bool dataConflict = false;
            string errorMessage = "Please fix the following input errors: \n\n";
            string errors = "";
            string phone = txtPhone.Text;
            bool isValidEmail = false;

            // No username entered
            if (txtUsername.Text == "")
                errors += "\u2022 Username required\n";

            // Phone validation and formatting
            if ((phone != "" && phone.Length >= 10) && Globals.IsPhoneNumber(phone))
                phone = Globals.FormatPhoneNumber(phone); 
            else if (phone != "" && !Globals.IsPhoneNumber(phone))
            {
                errors += "\u2022 Invalid phone number\n";
                dataConflict = true;
            }
            else if (phone == "")
            {
                errors += "\u2022 Phone number required\n";
                dataConflict = true;
            }

            // Email validation
            if (txtEmail.Text != "")
                isValidEmail = Globals.IsEmail(txtEmail.Text);
            else
            {
                errors += "\u2022 Email address required\n";
                dataConflict = true;
            }
                
            if (txtEmail.Text != "" && !isValidEmail)
            {
                errors += "\u2022 Invalid email address\n";
                dataConflict = true;
            }
                
            User newUser = new User
            {
                Username = txtUsername.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Password = password,
                Email = txtEmail.Text,
                Phone = phone,
                Rank = Convert.ToInt16(cbRank.SelectedItem.ToString()),
                Status = "Active",
                RegistrationDate = DateTime.Now
            };


            // Ensure username isn't already present
            if (newUser.Username != "")
            {
                if (newUser.UserExists(newUser.Username))
                {
                    dataConflict = true;
                    errors += "\u2022 Username already in use\n";
                }
            }

            // Ensure email isn't already present
            if (isValidEmail)
            {
                if (newUser.EmailExists(newUser.Email))
                {
                    dataConflict = true;
                    errors += "\u2022 Email address already registered\n";
                }
            }
            

            if (!dataConflict)
            {
                // Insert data into Users, Buyers, and TitleHolders tables - a buyer and title holder is created when a user is created
                bool userCreated = newUser.AddUser();
                bool buyerCreated = newBuyer.Add(newUser.FirstName, newUser.LastName, newUser.Phone, newUser.Email, newUser.Status);    
                bool holderCreated = newHolder.Add(newUser.FirstName, newUser.LastName, newUser.Phone, newUser.Email, newUser.Status);

                if (userCreated && buyerCreated && holderCreated)
                {
                    MessageBox.Show("User added successfully!");
                    this.Close();
                }
                else
                    MessageBox.Show("Error adding user!\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(errorMessage + errors, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        /* Refreshes userDGV when Add User window is closed
        * *****************************************/
        private void AddUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            owner.RefreshUserDGV();
        }
    }
}
