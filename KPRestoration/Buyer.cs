using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPRestoration
{
    class Buyer : Customer
    {
        DatabaseHelper db = new DatabaseHelper();
        private string buyerStatus;

        public string BuyerStatus { get => buyerStatus; set => buyerStatus = value; }

        /* Enters current User object data into database
         * *****************************************/
        public bool AddBuyer()
        {
            bool buyerCreated = false;
            string query = "INSERT INTO Buyers (firstName, lastName, phone, email, buyerStatus) VALUES " +
                "(@fName, @lName, @phone, @email, @status)";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@fName", this.FirstName);
            cmd.Parameters.AddWithValue("@lName", this.LastName);
            cmd.Parameters.AddWithValue("@phone", this.Phone);
            cmd.Parameters.AddWithValue("@email", this.Email);
            cmd.Parameters.AddWithValue("@status", this.BuyerStatus);
            return buyerCreated = db.ExecuteCommand(cmd);
        }


        /* Overloaded version of AddBuyer() that takes values 
         * *****************************************/
        public bool AddBuyer(string fName, string lName, string phone, string email, string buyerStatus)
        {
            bool buyerCreated = false;
            string query = "INSERT INTO Buyers (firstName, lastName, phone, email, buyerStatus) VALUES " +
                "(@fName, @lName, @phone, @email, @status)";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@fName", fName);
            cmd.Parameters.AddWithValue("@lName", lName);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@status", buyerStatus);
            return buyerCreated = db.ExecuteCommand(cmd);
        }

        
    }
}
