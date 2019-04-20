using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPRestoration
{
    class TitleHolder : Customer
    {
        DatabaseHelper db = new DatabaseHelper();
        // Members
        private int fee;
        private string feeType;
        private string status;

        // Getters and setters
        public int Fee { get => fee; set => fee = value; }
        public string FeeType { get => feeType; set => feeType = value; }
        public string Status { get => status; set => status = value; }


        /* Enters current User object data into database
         * *****************************************/
        public bool AddTitleHolder()
        {
            bool holderCreated = false;
            string query = "INSERT INTO TitleHolders (firstName, lastName, phone, email, holderStatus) VALUES " +
                "(@fName, @lName, @phone, @email, @status)";
            MySqlCommand addHolderCMD = new MySqlCommand(query, db.conn);
            addHolderCMD.Parameters.AddWithValue("@fName", this.FirstName);
            addHolderCMD.Parameters.AddWithValue("@lName", this.LastName);
            addHolderCMD.Parameters.AddWithValue("@email", this.Email);
            addHolderCMD.Parameters.AddWithValue("@phone", this.Phone);
            addHolderCMD.Parameters.AddWithValue("@status", this.Status);
            return holderCreated = db.ExecuteCommand(addHolderCMD);
        }


        /* Overloaded version of AddTitleHolder() that takes values 
         * *****************************************/
        public bool AddTitleHolder(string fName, string lName, string phone, string email, string holderStatus)
        {
            bool holderCreated = false;
            string query = "INSERT INTO TitleHolders (firstName, lastName, phone, email, holderStatus) VALUES " +
                "(@fName, @lName, @phone, @email, @status)";
            MySqlCommand addHolderCMD = new MySqlCommand(query, db.conn);
            addHolderCMD.Parameters.AddWithValue("@fName", fName);
            addHolderCMD.Parameters.AddWithValue("@lName", lName);
            addHolderCMD.Parameters.AddWithValue("@email", email);
            addHolderCMD.Parameters.AddWithValue("@phone", phone);
            addHolderCMD.Parameters.AddWithValue("@status", holderStatus);
            return holderCreated = db.ExecuteCommand(addHolderCMD);
        }
    }
}
