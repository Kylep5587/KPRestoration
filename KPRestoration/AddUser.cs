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
        DatabaseHelper db = new DatabaseHelper();

        public AddUser(User userInfo)
        {
            InitializeComponent();
            currentUser = userInfo;
            PopulateRanks(cbRank);
            cbRank.SelectedIndex = 0;
        }

        /* Populates access level dropdown with ranks 
         *  up to the current user's rank
         * *****************************/
        private void PopulateRanks(ComboBox cb)
        {
            for (int i = 1; i <= currentUser.Rank; i++)
                cb.Items.Add(i);
        }

        private void btnCancelAdd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string password = Globals.Encrypt(txtInitialPass.Text);
            string query = null;
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
                Globals.FormatPhoneNumber(phone); 
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
                // Insert data into Users database
                query = "INSERT INTO Users (username, pass, firstName, lastName, email, phone, registrationDate, rank, userStatus) VALUES " +
                "(@username, @password, @fName, @lName, @email, @phone, @dateAdded, @rank, @status)";
                MySqlCommand addUserCMD = new MySqlCommand(query, db.conn);
                addUserCMD.Parameters.AddWithValue("@username", newUser.Username);
                addUserCMD.Parameters.AddWithValue("@password", newUser.Password);
                addUserCMD.Parameters.AddWithValue("@fName", newUser.FirstName);
                addUserCMD.Parameters.AddWithValue("@lName", newUser.LastName);
                addUserCMD.Parameters.AddWithValue("@email", newUser.Email);
                addUserCMD.Parameters.AddWithValue("@phone", newUser.Phone);
                addUserCMD.Parameters.AddWithValue("@dateAdded", newUser.RegistrationDate);
                addUserCMD.Parameters.AddWithValue("@rank", newUser.Rank);
                addUserCMD.Parameters.AddWithValue("@status", newUser.Status);
                bool userCreated = db.ExecuteCommand(addUserCMD);

                // Insert data into Buyers table - a buyer is created for each user
                query = "INSERT INTO Buyers (firstName, lastName, phone, email, buyerStatus) VALUES " +
                "(@fName, @lName, @email, @phone, @status)";
                MySqlCommand addBuyerCMD = new MySqlCommand(query, db.conn);
                addBuyerCMD.Parameters.AddWithValue("@fName", newUser.FirstName);
                addBuyerCMD.Parameters.AddWithValue("@lName", newUser.LastName);
                addBuyerCMD.Parameters.AddWithValue("@email", newUser.Email);
                addBuyerCMD.Parameters.AddWithValue("@phone", newUser.Phone);
                addBuyerCMD.Parameters.AddWithValue("@status", newUser.Status);
                bool buyerCreated = db.ExecuteCommand(addBuyerCMD);

                // Insert data into TitleHolders table - a TitleHolder is created for each user
                query = "INSERT INTO TitleHolders (firstName, lastName, phone, email, buyerStatus) VALUES " +
                "(@fName, @lName, @email, @phone, @status)";
                MySqlCommand addHolderCMD = new MySqlCommand(query, db.conn);
                addHolderCMD.Parameters.AddWithValue("@fName", newUser.FirstName);
                addHolderCMD.Parameters.AddWithValue("@lName", newUser.LastName);
                addHolderCMD.Parameters.AddWithValue("@email", newUser.Email);
                addHolderCMD.Parameters.AddWithValue("@phone", newUser.Phone);
                addHolderCMD.Parameters.AddWithValue("@status", newUser.Status);
                bool holderCreated = db.ExecuteCommand(addHolderCMD);

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
                MessageBox.Show(errorMessage + errors, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
