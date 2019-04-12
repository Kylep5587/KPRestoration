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
        // Members
        private int id = 0;
        private int rank = 1;
        private string firstName = null;
        private string lastName = null;
        private string email = null;
        private string phone = null;
        private string status = null;
        private string username = null;


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


        public void createUser(int userID, int userRank, string userFName, string userLName, string userEmail, string userPhone, string userStatus, string userName)
        {
            Id = userID;
            Rank = userRank;
            FirstName = userFName;
            LastName = userLName;
            Email = userEmail;
            Phone = userPhone;
            Status = userStatus;
            Username = userName;
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
    }
}
