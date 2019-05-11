using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPRestoration
{
    public class User : Customer
    {
        DatabaseHelper db = new DatabaseHelper();
        private string defaultDGVQuery = "SELECT userID, username, CONCAT(firstName, ' ', lastName) AS Name, email, phone, rank, userStatus FROM Users ORDER BY lastName";

        // Members
        private int rank;
        private string status;
        private string username;
        private string password;
        private DateTime registrationDate;


        /* Getters and setters
         * *******************************/
        public int Rank { get => rank; set => rank = value; }
        public string Status { get => status; set => status = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public DateTime RegistrationDate { get => registrationDate; set => registrationDate = value; }
        

        // Default Constructor
        public User()
        {

        }

        /* Overloaded contstructor with values
         * ********************************/
        public User(int userID, int userRank, string userFName, string userLName, string userEmail, string userPhone, string userStatus, string userName, string password)
        {
            Id = userID;
            Rank = userRank;
            FirstName = userFName;
            LastName = userLName;
            Email = userEmail;
            Phone = userPhone;
            Status = userStatus;
            Username = userName;
            Password = password;
        }


        /* Overloaded constructor
         * *******************************/
        public User(string username, string firstName, string lastName, int rank)
        {
            Username = username;
            FirstName = FirstName;
            LastName = lastName;
            Rank = rank;
        }


        /* Verify user rank
         * *******************************/
        public bool VerifyRank(int requiredRank, Form form)
        {
            if (requiredRank <= Rank)
            {
                return true;
            }
            else
            {
                MessageBox.Show("You have insufficient priviledges to access this form. Contact an administrator for assistance", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                form.Close();
                return false;
            }
        }


        /* Checks if username present in database
         * *******************************/
        public override bool Update()
        {
            string query = "UPDATE Users SET username = @username, pass = @password, firstName = @fName, lastName = @lName, email = @email, phone = @phone, rank = @rank, userStatus = @status WHERE userID = @userID";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@username", this.Username);
            cmd.Parameters.AddWithValue("@password", this.Password);
            cmd.Parameters.AddWithValue("@fName", this.FirstName);
            cmd.Parameters.AddWithValue("@lName", this.LastName);
            cmd.Parameters.AddWithValue("@email", this.Email);
            cmd.Parameters.AddWithValue("@phone", this.Phone);
            cmd.Parameters.AddWithValue("@rank", this.Rank);
            cmd.Parameters.AddWithValue("@status", this.Status);
            cmd.Parameters.AddWithValue("@userID", this.Id);
            
            if (db.ExecuteCommand(cmd))
            {
                MessageBox.Show("User information updated successfully!", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Error updating user information!", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /* Checks if username present in database
         * *******************************/
        public bool UserExists(string username)
        {
            string user = "";
            string query = "SELECT username FROM Users WHERE username = @username LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@username", username);

            if (db.ExecuteCommand(cmd))
            {
                db.OpenConnection();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    user = dr["username"].ToString();

                db.CloseConnection();
                if (user == username)
                    return true;
                else
                    return false;
            }
            return false;
        }


        /* Checks if email present in database
         * *******************************/
        public bool EmailExists(string email)
        {
            string emailAddress = "";
            string query = "SELECT email FROM Users WHERE email = @email LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@email", email);

            if (db.ExecuteCommand(cmd))
            {
                db.OpenConnection();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    emailAddress = dr["email"].ToString();

                db.CloseConnection();
                if (emailAddress == email)
                    return true;
                else
                    return false;
            }
            return false;
        }


        /* Populate user DGV headers and rows
         * *****************************/
        public override void PopulateDGV(DataGridView DGV)
        {
            if (db.PopulateDGV(DGV, defaultDGVQuery))
            {
                DGV.Columns[0].HeaderText = "ID";
                DGV.Columns[1].HeaderText = "Username";
                DGV.Columns[2].HeaderText = "Name";
                DGV.Columns[3].HeaderText = "Email Address";
                DGV.Columns[4].HeaderText = "Phone";
                DGV.Columns[5].HeaderText = "Rank";
                DGV.Columns[6].HeaderText = "Status";
                DGV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;    // Fixed issue with email address not being fully displayed
            }

        }


        /* Populates access level dropdown with ranks up to the current user's rank
         * *****************************/
        public void PopulateUserRanks(ComboBox cb)
        {
            for (int i = 1; i <= this.Rank; i++)
                cb.Items.Add(i);
        }
    }
}
