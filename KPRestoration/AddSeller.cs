using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KPRestoration
{
    public partial class AddSeller : Form
    {
        Seller newSeller = new Seller();
        ManageUsers owner;
        User currentUser;

        public AddSeller(User userInfo, ManageUsers formOwner)
        {
            InitializeComponent();
            owner = formOwner;  // Set the owner of this form 
            currentUser = userInfo;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddSeller_FormClosing); // Calls the FormClosing method upon form closure
            Globals.PopulateStateList(cbState);
            cbStatus.SelectedIndex = 0;
        }

        private void btnAddSeller_Click(object sender, EventArgs e)
        {
            string errorMessage = "Please fix the following input errors: \n\n";
            string errors = newSeller.CheckData("seller", "New", txtPhone.Text, txtEmail.Text, txtFirstName.Text, txtLastName.Text, txtSellerZip.Text, null); // Check for valid data

            // Create user if proper input detected
            if (errors == null)
            {
                string phone = Globals.FormatPhoneNumber(txtPhone.Text);
                // Create buyer
                Seller newSeller = new Seller
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = phone.Trim(),
                    Address = txtAddress.Text,
                    City = txtCity.Text.Trim(),
                    State = cbState.SelectedItem.ToString(),
                    Zip = Convert.ToInt32(txtSellerZip.Text.Trim()),
                    SellerStatus = cbStatus.SelectedItem.ToString()
                };

                // Insert seller data
                if (errors == null)
                {
                    var sellerParams = new Dictionary<string, string>
                    {
                        { "@fName", newSeller.FirstName },
                        { "@lName", newSeller.LastName },
                        { "@address", newSeller.Address },
                        { "@city", newSeller.City },
                        { "@state", newSeller.State },
                        { "@zip", newSeller.Zip.ToString() },
                        { "@phone", newSeller.Phone },
                        { "@email", newSeller.Email },
                        { "@status", newSeller.SellerStatus }
                    };

                    if (newSeller.Add("seller", sellerParams))
                        this.Close();
                    else
                        MessageBox.Show("Error adding seller!\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show(errorMessage + errors, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show(errorMessage + errors, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        /* Refresh DGV upon add form closing
         * ******************************/
        private void AddSeller_FormClosing(object sender, FormClosingEventArgs e)
        {
            owner.RefreshSellerDGV();
        }


        /* Close the form
         * ******************************/
        private void btnCancelAdd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
