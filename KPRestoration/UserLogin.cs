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
                User defaultUser = new User(txtUsername.Text, "Default", "User", 3);
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
            string[] userInfo = new string[9];
            bool verified = false;
            string encryptedPassword = Globals.Encrypt(password);

            string query = "SELECT * FROM Users WHERE username = @username AND pass = @password LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", encryptedPassword);
            verified = db.ExecuteCommand(cmd);

            if (verified)
            {
                db.OpenConnection();
                MySqlDataReader dr = cmd.ExecuteReader();
                
                // Store values in userInfo array
                if (dr.Read())
                {
                    userInfo[0] = dr["userID"].ToString();
                    userInfo[1] = dr["username"].ToString();
                    userInfo[2] = dr["pass"].ToString();
                    userInfo[3] = dr["firstName"].ToString();
                    userInfo[4] = dr["lastName"].ToString();
                    userInfo[5] = dr["email"].ToString();
                    userInfo[6] = dr["phone"].ToString();
                    userInfo[7] = dr["userStatus"].ToString();
                    userInfo[8] = dr["rank"].ToString();
                }
                db.CloseConnection();

                // Create user object
                User currentUser = new User(
                    Convert.ToInt16(userInfo[0]),                // ID
                    Convert.ToInt16(userInfo[8]),               // Rank
                    userInfo[3],                                // First Name
                    userInfo[4],                                // Last Name
                    userInfo[5],                                // Email
                    Globals.FormatPhoneNumber(userInfo[6]),     // Phone
                    userInfo[7],                                // Status
                    userInfo[1],                                // Username
                    userInfo[2]                                 // Password
                );

                // Stop login if user status not active
                if (currentUser.Status != "Active")
                {
                    lblError.Visible = true;
                    MessageBox.Show("Your credentials have been suspened or deactivated. Please contact a system administrator to regain access.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                // Set user data


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
            int result = db.GetInt(query);

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
