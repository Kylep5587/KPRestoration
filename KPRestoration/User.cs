using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPRestoration
{
    class User
    {
        int id = 0;
        int rank = 1;
        string firstName = null;
        string lastName = null;
        string email = null;
        string phone = null;
        string status = null;
        string username = null;

        public void createUser(int userID, int userRank, string userFName, string userLName, string userEmail, string userPhone, string userStatus, string userName)
        {
            id = userID;
            rank = userRank;
            firstName = userFName;
            lastName = userLName;
            email = userEmail;
            phone = userPhone;
            status = userStatus;
            username = userName;
        }

        /* Setters
         * *******************************/
        public void setRank(int i) { rank = i; }
        public void setFName(string s) { firstName = s; }
        public void setLName(string s) { lastName = s; }
        public void setEmail(string s) { email = s; }
        public void setPhone(string s) { phone = s; }
        public void setStatus(string s) { status = s; }
        public void setUsername(string s) { username = s; }

        /* Getters
         * *******************************/
        public int getRank() { return rank; }
        public string getFullName() { return firstName + " " + lastName; }
        public string getFName() { return firstName; }
        public string getLName() { return lastName; }
        public string getEmail() { return email; }
        public string getPhone() { return String.Format("{0:(###) ###-####}", Convert.ToDouble(phone)); }
        public string getUsername() { return username; }

        /* Verify user rank
         * *******************************/
        public bool verifyRank(int requiredRank, Form form)
        {
            if (requiredRank <= rank)
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
    }
}
