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
    public class User
    {
        DatabaseHelper db = new DatabaseHelper();
        private string defaultDGVQuery = "SELECT userID, username, firstName, lastName, email, phone, rank, userStatus FROM Users ORDER BY lastName";

        // Members
        private int id;
        private int rank;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string status;
        private string username;
        private string password;
        private DateTime registrationDate;


        /* Getters and setters
         * *******************************/
        public int Id { get => id; set => id = value; }
        public int Rank { get => rank; set => rank = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
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
        public bool UpdateUser(User myUser)
        {
            bool updated = false;

            string query = "UPDATE Users SET username = @username, pass = @password, firstName = @fName, lastName = @lName, email = @email, rank = @rank, userStatus = @status WHERE userID = @userID";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@username", myUser.Username);
            cmd.Parameters.AddWithValue("@password", myUser.Password);
            cmd.Parameters.AddWithValue("@fName", myUser.FirstName);
            cmd.Parameters.AddWithValue("@lName", myUser.LastName);
            cmd.Parameters.AddWithValue("@email", myUser.Email);
            cmd.Parameters.AddWithValue("@rank", myUser.Rank);
            cmd.Parameters.AddWithValue("@status", myUser.Status);

            if (db.ExecuteCommand(cmd))
                updated = true;

            return updated;
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


        /* Add user to database
         * *******************************/
        public bool AddUser()
        {
            bool userCreated = false;
            string query = "INSERT INTO Users (username, pass, firstName, lastName, email, phone, registrationDate, rank, userStatus) VALUES " +
                "(@username, @password, @fName, @lName, @email, @phone, @dateAdded, @rank, @status)";
            MySqlCommand addUserCMD = new MySqlCommand(query, db.conn);
            addUserCMD.Parameters.AddWithValue("@username", this.Username);
            addUserCMD.Parameters.AddWithValue("@password", this.Password);
            addUserCMD.Parameters.AddWithValue("@fName", this.FirstName);
            addUserCMD.Parameters.AddWithValue("@lName", this.LastName);
            addUserCMD.Parameters.AddWithValue("@email", this.Email);
            addUserCMD.Parameters.AddWithValue("@phone", this.Phone);
            addUserCMD.Parameters.AddWithValue("@dateAdded", this.RegistrationDate);
            addUserCMD.Parameters.AddWithValue("@rank", this.Rank);
            addUserCMD.Parameters.AddWithValue("@status", this.Status);
            return userCreated = db.ExecuteCommand(addUserCMD);
        }


        /* Checks if email present in database
         * *******************************/
        public bool EmailExists(string email)
        {
            string emailAddress = "";
            string query = "SELECT email FROM Users WHERE username = @email LIMIT 1";
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
        public void PopulateDGV(DataGridView DGV)
        {
            if (db.PopulateDGV(DGV, defaultDGVQuery))
            {
                DGV.Columns[0].HeaderText = "ID";
                DGV.Columns[1].HeaderText = "Username";
                DGV.Columns[2].HeaderText = "First";
                DGV.Columns[3].HeaderText = "Last";
                DGV.Columns[4].HeaderText = "Email Address";
                DGV.Columns[5].HeaderText = "Phone";
                DGV.Columns[6].HeaderText = "Rank";
                DGV.Columns[7].HeaderText = "Status";
                DGV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;    // Fixed issue with email address not being fully displayed
            }
            else
                MessageBox.Show("There are currently no users in the database.", "No Users Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }


        /* Populates access level dropdown with ranks up to the current user's rank
         * *****************************/
        public void PopulateUserRanks(ComboBox cb)
        {
            for (int i = 1; i <= this.Rank; i++)
                cb.Items.Add(i);
        }


        /* Populates dgvUsers with search results
         *      Called when user types in search box or clicks search
         * *****************************/
        public void Search(DataGridView DGV, string searchQuery)
        {
            searchQuery = "%" + searchQuery + "%";                              // Add wildcards to the search query
            MySqlCommand cmd = new MySqlCommand("SEARCH_USERS", db.conn);
            cmd.CommandType = CommandType.StoredProcedure;                               // Name of the stored procedure
            cmd.Parameters.AddWithValue("@searchQuery", searchQuery.Trim());
            db.PopulateDGV(DGV, cmd);
        }
    }
}
