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
        DatabaseHelper db = new DatabaseHelper();

        public AddUser(User userInfo)
        {
            InitializeComponent();
            currentUser = userInfo;
            populateRanks(cbRank);
        }

        /* Populates access level dropdown with ranks 
         *  up to the current user's rank
         * *****************************/
        private void populateRanks(ComboBox cb)
        {
            for (int i = 1; i <= currentUser.getRank(); i++)
                cb.Items.Add(i);
        }

        private void btnCancelAdd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string cleanUsername = username.Text;
            string cleanPassword = Globals.encrypt(initialPassword.Text);
            string cleanFName = firstName.Text;
            string cleanLName = lastName.Text;
            string cleanEmail = email.Text;
            string cleanPhone = phone.Text;
            string query = null;
            string errorMessage = null;
            string result = null;
            bool userConflict = false;


            // Check for username usage
            query = "SELECT username FROM Users WHERE username = '" + cleanUsername + "' LIMIT 1";
            result = db.getString(query);

            if (result == cleanUsername)
            {
                userConflict = true;
                errorMessage = "Username already in use\n";
            }

            // Check for email address
            query = "SELECT userID FROM Users WHERE email = '" + cleanEmail + "' LIMIT 1";
            result = db.getString(query);

            if (result == cleanEmail)
            {
                userConflict = true;
                errorMessage += "Email address already registered\n";
            }

            if (!userConflict)
            {
                query = "INSERT INTO Users (username, pass, firstName, lastName, email, phone, registrationDate, rank, userStatus) VALUES " +
                "('" + cleanUsername + "', '" + cleanPassword + "', '" + cleanFName + "', '" + cleanLName + "', '" + cleanEmail + "', '" + cleanPhone + "', " +
                "NOW(), '" + cbRank.SelectedItem.ToString() + "', 'Active')";

                if (db.Insert(query))
                {
                    MessageBox.Show("User added successfully!");
                    this.Close();
                }
                else
                    MessageBox.Show("Error adding user!\n" + query, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Please resolve the following errors: \n" + errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
