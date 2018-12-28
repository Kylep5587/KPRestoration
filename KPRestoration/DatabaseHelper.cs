/******************************************
 * KP Restoration VMS                     *
 * Created 12/12/18 by Kyle Price         *
 * DatabaseHelper.cs - Handles tasks      *
 *  related to MySQL database             *
 * ***************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace KPRestoration
{
    class DatabaseHelper
    {
        private MySqlConnection connection;
        private string server;
        private string dbName;
        private string dbUser;
        private string dbPass;

        public DatabaseHelper()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "RMSERVER";
            dbName = "KPRestoration";
            dbUser = "Kylep5587";
            dbPass = "slack1";
            string connectionString = "SERVER = " + server + "; DATABASE = " + dbName + "; UID = " + dbUser + "; PASSWORD = " + dbPass + ";";
            connection = new MySqlConnection(connectionString);
        }

        /*  Open database connection
         *  **************************************/
         private bool OpenConnection()
         {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 0: // Cannot connect to server
                        MessageBox.Show("Failed to connect to SQL server. Please contact the system administrator.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case 1045:
                        MessageBox.Show("Invalid SQL username or password.", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    default: // Invalid user/pass
                        MessageBox.Show("Error establishing SQL connection.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }
                return false;
            }
         }

        /*  Close database connection
         *  **************************************/
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error: " + e.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        /*  Populate targeted DGV with SQL Query results
         *  **************************************/
        public void populateDGV(DataGridView dgv, string query) 
        {
            try
            {
                if (this.OpenConnection() == true)
                {
                    // Store database data in dataAdapter
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                    dataAdapter.SelectCommand = new MySqlCommand(query, connection);

                    // Store data from adapter in DataTable
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);

                    // Move data to BindingSource
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = table;

                    // Dislay in DGV
                    dgv.DataSource = bSource;

                    this.connection.Close();
                }
            }
            catch
            {
                this.CloseConnection();
            }
        }

        /*  Insert data
         *  **************************************/
        public bool Insert(string query)
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    // Create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    this.CloseConnection();
                    return true;
                }
                catch
                {
                    this.CloseConnection();
                    return false;
                }
            }
            return false;
        }

        /*  Update data
         *  **************************************/
        public bool Update(string query)
        {
            try
            {
                // Open connection
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    // Assign the query using CommandText
                    cmd.CommandText = query;
                    // Assign the connection 
                    cmd.Connection = connection;
                    
                    cmd.ExecuteNonQuery();
                    
                    this.CloseConnection();
                    return true;
                }
            }
            catch
            {

                this.CloseConnection();
                return false;
            }
            return false;
        }

        /*  Delete data
         *  **************************************/
        public void Delete(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        /*  Get data
         *  **************************************/
        public string getData(string query)
        {

            string data;
            if (this.OpenConnection() == true)
            {
                try
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();

                    //Assign the query using CommandText
                    cmd.CommandText = query;

                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    //Execute query
                    data = cmd.ExecuteScalar().ToString();

                    //close connection
                    this.CloseConnection();
                    return data;
                }
                catch
                {
                    this.CloseConnection();
                    return null;
                }

            }
            return null;
        }
    }
}
