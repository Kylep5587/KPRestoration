using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace KPRestoration
{
    public partial class UserLogin : Form
    {
        bool isNewInstall = false;
        DatabaseHelper db = new DatabaseHelper();
        User currentUser;

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
            string retrievedUsername = null;
            string retrievedPass = null;
            string encryptedPassword = Globals.Encrypt(password);

            string query = "SELECT * FROM Users WHERE username = @username AND pass = @password LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", encryptedPassword);

            // Compare retrieved username and password with the user/pass entered by user
            if (db.ExecuteCommand(cmd))
            {
                db.OpenConnection();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retrievedUsername = dr["username"].ToString();
                    retrievedPass = dr["pass"].ToString();
                }

                if ((retrievedUsername == username) && (retrievedPass == encryptedPassword))
                {
                    string phone = "";

                    if (dr["phone"].ToString() != "")
                        phone = Globals.FormatPhoneNumber(dr["phone"].ToString());

                    // Create user object
                    currentUser = new User(
                        Convert.ToInt16(dr["userID"].ToString()),             // ID
                        Convert.ToInt16(dr["rank"].ToString()),               // Rank
                        dr["firstName"].ToString(),                           // First Name
                        dr["lastName"].ToString(),                            // Last Name
                        dr["email"].ToString(),                               // Email
                        phone,                                                // Phone
                        dr["userStatus"].ToString(),                          // Status
                        dr["username"].ToString(),                            // Username
                        dr["pass"].ToString()                                 // Password
                    );
                    db.CloseConnection();

                    // Stop login if user status not active
                    if (currentUser.Status != "Active")
                    {
                        lblError.Visible = true;
                        MessageBox.Show("Your credentials have been suspened or deactivated. Please contact a system administrator to regain access.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    // Open main form and return true
                    Main form = new Main(currentUser);
                    form.Show();
                    this.Hide();
                    return true;
                }
                else // Invalid credentials entered
                {
                    db.CloseConnection();
                    lblError.Visible = true;
                    return false;
                }
            }
            else // Command to retrieve user data failed
            {
                MessageBox.Show("An error occured during login.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
