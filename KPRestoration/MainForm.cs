/*********************************************************
 * KP Restoration VMS                                    *
 * Created 12/12/18 by Kyle Price                        *
 * MainForm.cs - main application form. All other forms  *
 *  open as child forms in the content panel of this form*
 * ******************************************************/

using System;
using System.Windows.Forms;

namespace KPRestoration
{
    public partial class Main : Form
    {
        User currentUser = new User();

        public Main(User userInfo)
        {
            InitializeComponent();
            currentUser = userInfo;
            lblUsername.Text = currentUser.Username;
        }
        

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ManageUsers u = new ManageUsers(currentUser);
            Globals.CreateForm(u, panelContent);
            Text = "Manage Users";
        }

        // Fixes: application remains running after closing window
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnVehicleManager_Click(object sender, EventArgs e)
        {
            VehicleManager v = new VehicleManager(currentUser);
            Globals.CreateForm(v, panelContent);
            Text = "Vehicle Manager";
        }
    }
}
