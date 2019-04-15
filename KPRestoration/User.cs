using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPRestoration
{
    public class User
    {
        DatabaseHelper db = new DatabaseHelper();

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
        public string Phone { get => String.Format("{0:(###) ###-####}", Convert.ToDouble(phone)); set => phone = value; }
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
            string query = "SELECT email FROM Users WHERE username = @email LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@username", username);
            bool emailExists = db.ExecuteCommand(cmd);
            return emailExists;
        }

    }
}
