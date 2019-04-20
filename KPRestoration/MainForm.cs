using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

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
            ManageUsers userForm = new ManageUsers(currentUser);
            userForm.TopLevel = false;
            userForm.AutoScroll = true;
            panelContent.Controls.Add(userForm);
            userForm.Show();
            this.Text = "Manage Users";
            this.Refresh();
        }

        // Fixes: application remains running after closing window
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnVehicleManager_Click(object sender, EventArgs e)
        {
            VehicleManager vehicleForm = new VehicleManager(currentUser);
            vehicleForm.TopLevel = false;
            vehicleForm.AutoScroll = true;
            panelContent.Controls.Add(vehicleForm);
            vehicleForm.Show();
            this.Text = "Vehicle Manager";
            this.Refresh();
        }
    }
}
