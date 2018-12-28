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
    public partial class ManageUsers : Form
    {
        private User currentUser = new User();
        private DatabaseHelper db = new DatabaseHelper();
        private string query = null;
        

        /* Constructor
         * *****************************/
        public ManageUsers(/*User clone*/)
        {
            InitializeComponent();
            //currentUser = clone; 
            populateRanks(cbRank);
        }


        /* Populates access level dropdown with ranks 
         *  up to the current user's rank
         * *****************************/
        private void populateRanks(ComboBox cb)
        {
            for (int i=0; i <= currentUser.getRank(); i++)
                cb.Items.Add(i);
        }


        /* Populate user DGV headers and rows
         * *****************************/
        private void populateUserDGV()
        {
            query = "SELECT userID, CONCAT(firstName, ' ', lastName) AS Name, email, phone, rank FROM Users ORDER BY firstName";
            db.populateDGV(dgvUsers, query);
        }
    }
}
