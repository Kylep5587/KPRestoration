/*********************************************************
 * KP Restoration VMS                                    *
 * Created 4/12/19 by Kyle Price                         *
 * Customer.cs - stores data related to buyers, sellers, *
 *  and title holders.                                   *
 *  Parent class of Buyer, Seller, & TitleHolder         *
 * ******************************************************/

using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace KPRestoration
{
    abstract class Customer
    {
        DatabaseHelper db = new DatabaseHelper();

        // Members
        private int id;
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string state;
        private int? zip;   // nullable
        private string phone;
        private string email;

        // Getters and setters
        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string State { get => state; set => state = value; }
        public int? Zip { get => zip; set => zip = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string City { get => city; set => city = value; }

        /* Determines if email is present in the database
         * *********************************************/
        public bool EmailExists(string customerType, string email)
        {
            string retrievedEmail = "";
            string query = null;

            switch (customerType) // Determine which queries to use based on customer type = Buyer, Seller, or TitleHolder
            {
                case "Buyer":
                    query = "SELECT email FROM Buyers WHERE email = @email LIMIT 1";
                    break;
                case "Seller":
                    query = "SELECT email FROM Sellers WHERE email = @email LIMIT 1";
                    break;
                case "Holder":
                    query = "SELECT email FROM TitleHolders WHERE email = @email LIMIT 1";
                    break;
            }

            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@email", email);

            if (db.ExecuteCommand(cmd))
            {
                db.OpenConnection();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    retrievedEmail = dr["email"].ToString();

                db.CloseConnection();
                if (retrievedEmail == email)
                    return true;
                else
                    return false;
            }
            return false;
        }


        /* Checks if name present in database
         * *******************************/
        public bool NameExists(string customerType, string firstName, string lastName)
        {
            string name = firstName + " " + lastName;
            string retrievedName = null;
            string query = null;

            switch (customerType) // Determine which queries to use based on customer type = Buyer, Seller, or TitleHolder
            {
                case "Buyer":
                    query = "SELECT CONCAT(firstName, ' ', lastName) AS RetrievedName FROM Buyers WHERE CONCAT(firstName, ' ', lastName) = @name LIMIT 1";
                    break;
                case "Seller":
                    query = "SELECT CONCAT(firstName, ' ', lastName) AS RetrievedName FROM Sellers WHERE CONCAT(firstName, ' ', lastName) = @name LIMIT 1";
                    break;
                case "Holder":
                    query = "SELECT CONCAT(firstName, ' ', lastName) AS RetrievedName FROM TitleHolders WHERE CONCAT(firstName, ' ', lastName) = @name LIMIT 1";
                    break;
            }
            
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@name", name);

            if (db.ExecuteCommand(cmd))
            {
                db.OpenConnection();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    retrievedName = dr["RetrievedName"].ToString();

                db.CloseConnection();
                if (name == retrievedName)
                    return true;
                else
                    return false;
            }
            return false;
        }


        /* Vefifies data before creating new customer or updating existing customer
         * *****************************/
        public string CheckData(string customerType, string checkType, string phone, string email, string firstName, string lastName, string zip)
        {
            bool inputError = false;
            bool dataConflict = false;
            string errors = "";

            // Phone validation and formatting
            if ((phone != "" && phone.Length >= 10) && Globals.IsPhoneNumber(phone))
                phone = Globals.FormatPhoneNumber(phone);
            else if (phone != "" && !Globals.IsPhoneNumber(phone))
            {
                errors += "\u2022 Invalid phone number\n";
                inputError = true;
            }
            else if (phone == "")
            {
                errors += "\u2022 Phone number required\n";
                inputError = true;
            }

            // Email validation
            if (email == "" || !Globals.IsEmail(email))
            {
                errors += "\u2022 Valid email address required\n";
                inputError = true;
            }

            // Check for first name
            if (firstName.Length < 2)
            {
                errors += "\u2022 First name required\n";
                inputError = true;
            }

            // Check if zip code is numeric and equal to 5 numbers if entered
            if (zip != "" && (!Globals.IsNumeric(zip) || zip.Length != 5))
            {
                errors += "\u2022 Invalid zip code\n";
                inputError = true;
            }

            if (!inputError && checkType == "New") // Check if email address and name are already in use if not updating existing user
            {
                if (this.EmailExists(customerType, email))
                {
                    dataConflict = true;
                    errors += "\u2022 Email address already registered\n";
                }

                // Check if name is already used
                if (this.NameExists(customerType, lastName, firstName))
                {
                    dataConflict = true;
                    errors += "\u2022 Name already in use\n";
                }
            }

            if (inputError || dataConflict)
                return errors;
            else
                return null;
        }


        /* Abstract Methods
         * *********************************************/
        public abstract bool Add();
        public abstract bool Update();
        public abstract void Delete();
        public abstract void Delete(string name, DataGridView DGV);
        
        public abstract void Search(DataGridView DGV, string query);
        public abstract void PopulateDGV(DataGridView DGV);

    }
}
