/*********************************************************
 * KP Restoration VMS                                    *
 * Created 4/12/19 by Kyle Price                         *
 * TitleHolder.cs - data and operations related to       *
 *      title holders                                    *
 *  Child class of Customer                              *
 * ******************************************************/

using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace KPRestoration
{
    class TitleHolder : Customer
    {
        DatabaseHelper db = new DatabaseHelper();
        string defaultDGVQuery = "SELECT titleHolderID AS ID, CONCAT(firstName, ' ', lastName) AS Name, email, phone, address AS Address, city AS City, state AS State, zip AS Zip, fee, feeType, holderStatus FROM TitleHolders ORDER BY Name";

        // Members
        private int fee;
        private string feeType;
        private string status;

        // Getters and setters
        public int Fee { get => fee; set => fee = value; }
        public string FeeType { get => feeType; set => feeType = value; }
        public string Status { get => status; set => status = value; }


        /* Overloaded version of AddTitleHolder() that takes values 
         * *****************************************/
        public bool Add(string fName, string lName, string phone, string email, string holderStatus)
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


        /* Updates title holder information
         * *****************************************/
        public override bool Update()
        {
            string query = "Update TitleHolders SET firstName = @fName, lastName = @lName, address = @address, city = @city, state = @state, zip = @zip, phone = @phone, email = @email, fee = @fee, feeType = @feeType, holderStatus = @status WHERE titleHolderID = @titleHolderID";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@fName", this.FirstName);
            cmd.Parameters.AddWithValue("@lName", this.LastName);
            cmd.Parameters.AddWithValue("@address", this.Address);
            cmd.Parameters.AddWithValue("@city", this.City);
            cmd.Parameters.AddWithValue("@state", this.State);
            cmd.Parameters.AddWithValue("@zip", this.Zip);
            cmd.Parameters.AddWithValue("@phone", this.Phone);
            cmd.Parameters.AddWithValue("@email", this.Email);
            cmd.Parameters.AddWithValue("@status", this.Status);
            cmd.Parameters.AddWithValue("@fee", this.Fee);
            cmd.Parameters.AddWithValue("@feeType", this.FeeType);
            cmd.Parameters.AddWithValue("@titleHolderID", this.Id);

            if (db.ExecuteCommand(cmd))
            {
                MessageBox.Show("Title holder information updated successfully!", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Error updating title holder information!", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        

        /* Populate title holder DGV headers and rows
         * *****************************/
        public override void PopulateDGV(DataGridView DGV)
        {
            db.OpenConnection();
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand(defaultDGVQuery, db.conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("Service Fee", typeof(string), "");

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["feeType"].ToString().ToLower() == "percentage")
                    dr["Service Fee"] = dr["fee"] + "%";
                else
                    dr["Service Fee"] = "$" + dr["fee"];
            }

            dt.Columns.Remove("fee");
            dt.Columns.Remove("feeType");
            DGV.DataSource = dt;
            db.CloseConnection();

            if (dt != null)
            {
                DGV.Columns[0].HeaderText = "ID";
                DGV.Columns[1].HeaderText = "Name";
                DGV.Columns[2].HeaderText = "Email";
                DGV.Columns[3].HeaderText = "Phone";
                DGV.Columns[4].HeaderText = "Address";
                DGV.Columns[5].HeaderText = "City";
                DGV.Columns[6].HeaderText = "State";
                DGV.Columns[7].HeaderText = "Zip";
                DGV.Columns[8].HeaderText = "Status";
                DGV.Columns[9].HeaderText = "Fee";
                DGV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;    // Fixed issue with address not being fully displayed
                DGV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
    }
}
