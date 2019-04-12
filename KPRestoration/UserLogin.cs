using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPRestoration
{
    public partial class UserLogin : Form
    {
        bool isNewInstall = false;
        DatabaseHelper db = new DatabaseHelper();
        User currentUser = new User();

        public UserLogin()
        {
            InitializeComponent();
        }

        /* Used to handle default credential login
         * ****************************/
        private void newInstall()
        {
            if ((txtUsername.Text == "SuperUser") && (txtPassword.Text == "password"))
            {
                User defaultUser = new User();
                defaultUser.Username = txtUsername.Text;
                defaultUser.FirstName = "Default";
                defaultUser.LastName = "User";
                defaultUser.Rank = 3;
                MessageBox.Show("Login successful.");
                Main form = new Main(defaultUser);
                form.Show();
                this.Hide();
            }
        }

        /* Tests entered credentials
         * ****************************/
        private bool verifyCredentials(string username, string password)
        {
            string[] userInfo = new string[8];
            bool verified = false;
            string encryptedPassword = Globals.Encrypt(password);

            string query = "SELECT userID FROM Users WHERE username = '" + username + "' AND pass = '" + encryptedPassword + "' LIMIT 1";
            verified = db.getBool(query, true);

            if (verified)
            {
                // Get user info from database
                db.OpenConnection();
                query = "SELECT userID, firstName, lastName, email, phone, rank, userStatus FROM Users WHERE username = '" + username + "' AND pass = '" + encryptedPassword + "' LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, db.conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                // Store values in userInfo array
                if (dr.Read())
                {
                    userInfo[0] = dr["userID"].ToString();
                    userInfo[1] = username;
                    userInfo[2] = dr["firstName"].ToString();
                    userInfo[3] = dr["lastName"].ToString();
                    userInfo[4] = dr["email"].ToString();
                    userInfo[5] = dr["phone"].ToString();
                    userInfo[6] = dr["userStatus"].ToString();
                    userInfo[7] = dr["rank"].ToString();
                }
                db.CloseConnection();

                // Stop login if user status not active
                if (userInfo[6] != "Active")
                {
                    lblError.Visible = true;
                    MessageBox.Show("Your credentials have been suspened or deactivated. Please contact a system administrator to regain access.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                
                // Set user data
                currentUser.createUser(Convert.ToInt16(userInfo[0]), Convert.ToInt16(userInfo[7]), userInfo[2], userInfo[3], userInfo[4], userInfo[5], userInfo[6], userInfo[1]);

                Main form = new Main(currentUser);
                form.Show();
                this.Hide();
                return true;
            }
            else
            {
                lblError.Visible = true;
                return false;
            }
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            // Check SQL database connection
            bool pingDatabase = Globals.PingHost("rmserver");
            if (!pingDatabase)
            {
                MessageBox.Show("Unable to connect to database. Program will now exit.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            string query = "SELECT MAX(userID) FROM Users";
            int result = db.getInt(query);

            // If max user ID is 1, only default user credentials are present
            if (result == 0)
            {
                MessageBox.Show("No users found in the system. If this is a new installation, please enter default credentials.", "No Users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isNewInstall = true;
            }
        }

        /* Handles login button click
         * ****************************/
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (isNewInstall)
                newInstall();
            else
            {
                verifyCredentials(txtUsername.Text, txtPassword.Text);
            }
        }

       
    }
}
