using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPRestoration
{
    public partial class AddTitleHolder : Form
    {
        TitleHolder newHolder = new TitleHolder();
        User currentUser;
        ManageUsers owner;

        public AddTitleHolder(User userInfo, ManageUsers formOwner)
        {
            currentUser = userInfo;
            InitializeComponent();
            owner = formOwner;  // Set the owner of this form 
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddTitleHolder_FormClosing); // Calls the FormClosing method upon form closure
            currentUser = userInfo;
            Globals.PopulateStateList(cbHolderState);
            cbHolderStatus.SelectedIndex = 0;
        }

        private void btnAddHolder_Click(object sender, EventArgs e)
        {
            string errorMessage = "Please fix the following input errors: \n\n";

            // Remove $ or % from holder fee
            if (txtHolderFee.Text != "")
            {
                Regex pattern = new Regex("[$%]");
                pattern.Replace(txtHolderFee.Text, "");
            }

            string errors = newHolder.CheckData("holder", "New", txtHolderPhone.Text, txtHolderEmail.Text, txtHolderFname.Text, txtHolderLName.Text, txtHolderZip.Text, txtHolderFee.Text); // Check for valid data

            // Create user if proper input detected
            if (errors == null)
            {
                string phone = Globals.FormatPhoneNumber(txtHolderPhone.Text);
                // Create buyer
                TitleHolder newHolder = new TitleHolder
                {
                    FirstName = txtHolderFname.Text.Trim(),
                    LastName = txtHolderLName.Text.Trim(),
                    Email = txtHolderEmail.Text.Trim(),
                    Phone = phone.Trim(),
                    Address = txtHolderAddress.Text,
                    City = txtHolderCity.Text.Trim(),
                    State = cbHolderState.SelectedItem.ToString(),
                    Zip = Convert.ToInt32(txtHolderZip.Text.Trim()),
                    Status = cbHolderStatus.SelectedItem.ToString(),
                    Fee = Convert.ToInt32(txtHolderFee.Text.Trim()),
                    FeeType = cbHolderFeeType.SelectedItem.ToString()
                };

                var holderParams = new Dictionary<string, string>
                {
                    { "@fName", newHolder.FirstName },
                    { "@lName", newHolder.LastName },
                    { "@address", newHolder.Address },
                    { "@city", newHolder.City },
                    { "@state", newHolder.State },
                    { "@zip", newHolder.Zip.ToString() },
                    { "@phone", newHolder.Phone },
                    { "@email", newHolder.Email },
                    { "@status", newHolder.Status },
                    { "@fee", newHolder.Fee.ToString() },
                    { "@feeType", newHolder.FeeType }
                };

                    if (newHolder.Add("holder", holderParams))
                        this.Close();
                    else
                        MessageBox.Show("Error adding title holder!\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show(errorMessage + errors, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        /* Refresh DGV upon add form closing
         * ******************************/
        private void AddTitleHolder_FormClosing(object sender, FormClosingEventArgs e)
        {
            owner.RefreshHolderDGV();
        }


        /* Close the form
         * ******************************/
        private void btnCancelAdd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
