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
        public MySqlConnection conn;
        private static string server = Globals.dbHost;
        private static string dbName = "KPRestoration";
        private static string dbUser = "kyle";
        private static string dbPass = "slack1";
        public static string connectionString = "SERVER = " + server + "; DATABASE = " + dbName + "; UID = " + dbUser + "; PASSWORD = " + dbPass + ";";

        public DatabaseHelper()
        {
            Initialize();
        }

        private void Initialize()
        {
            conn = new MySqlConnection(connectionString);
        }

        /*  Open database connection
         *  **************************************/
        public bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 0: // Cannot connect to server
                        MessageBox.Show("Failed to connect to SQL server. Please contact the system administrator.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case 1045: // Invalid user/pass
                        MessageBox.Show("Invalid SQL username or password.", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    default:
                        MessageBox.Show("Error establishing SQL connection.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }
                return false;
            }
        }

        /*  Close database connection
         *  **************************************/
        public bool CloseConnection()
        {
            try
            {
                conn.Close();
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
        public bool populateDGV(DataGridView dgv, string query)
        {
            try
            {
                if (this.OpenConnection() == true)
                {
                    // Store database data in dataAdapter
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                    dataAdapter.SelectCommand = new MySqlCommand(query, conn);

                    // Store data from adapter in DataTable
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);

                    // Move data to BindingSource
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = table;

                    // Dislay in DGV
                    dgv.DataSource = bSource;

                    this.conn.Close();
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                this.CloseConnection();
                return false;
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
                    MySqlCommand cmd = new MySqlCommand(query, conn);
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
        public bool Update(MySqlCommand cmd)
        {
            try
            {
                // Open connection
                if (OpenConnection() == true)
                {
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
            }
            catch (Exception ex)
            {
                CloseConnection();
                MessageBox.Show(ex.Message);
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
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        /*  Get data in string form
         *  **************************************/
        public string GetString(string query)
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
                    cmd.Connection = conn;

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

        /*  Get data in integer form
         *  **************************************/
        public int getInt(string query)
        {
            int data;
            if (this.OpenConnection() == true)
            {
                try
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();

                    //Assign the query using CommandText
                    cmd.CommandText = query;

                    //Assign the connection using Connection
                    cmd.Connection = conn;

                    //Execute query
                    data = Convert.ToInt32(cmd.ExecuteScalar());

                    //close connection
                    this.CloseConnection();
                    return data;
                }
                catch
                {
                    this.CloseConnection();
                    return 0;
                }

            }
            return 0;
        }

        /*  Get data in bool form
         *  **************************************/
        public bool getBool(string query, bool requireBool)
        {
            if (this.OpenConnection() == true)
            {
                try
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();

                    //Assign the query using CommandText
                    cmd.CommandText = query;

                    //Assign the connection using Connection
                    cmd.Connection = conn;

                    //Execute query
                    cmd.ExecuteScalar();

                    //close connection
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

    }
}
