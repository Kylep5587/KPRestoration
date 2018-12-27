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

        public Main()
        {
            InitializeComponent();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ManageUsers userForm = new ManageUsers();
            userForm.TopLevel = false;
            userForm.AutoScroll = true;
            panelContent.Controls.Add(userForm);
            userForm.Show();

            this.Text = "Manage Users";
            this.Refresh();
        }
    }
}
