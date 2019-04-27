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
    public partial class AddBuyer : Form
    {
        User currentUser;
        ManageUsers owner;

        /* Constructor
         * ******************************/
        public AddBuyer(User userInfo, ManageUsers formOwner)
        {
            currentUser = userInfo;
            InitializeComponent();
            owner = formOwner;  // Set the owner of this form 
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddBuyer_FormClosing); // Calls the FormClosing method upon form closure
            currentUser = userInfo;
            Globals.PopulateStateList(cbState);
            cbStatus.SelectedIndex = 0;
        }


        /* Closes Add Buyer Window
         * ******************************/
        private void btnCancelAdd_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /* Inserts new buyer into database
         * ******************************/
        private void btnAddBuyer_Click(object sender, EventArgs e)
        {
            bool inputError = false;
            bool dataConflict = false;
            string errorMessage = "Please fix the following input errors: \n\n";
            string errors = "";
            string phone = txtPhone.Text;
            bool isValidEmail = false;

            // Phone validation and formatting
            if ((phone != "" && phone.Length >= 10) && Globals.IsPhoneNumber(phone))
                phone = Globals.FormatPhoneNumber(phone);
            else if (phone != "" && !Globals.IsPhoneNumber(phone))
            {
                errors += "\u2022 Invalid phone number\n";
                inputError = true;
            }
            else if (phone == "")
            {
                errors += "\u2022 Phone number required\n";
                inputError = true;
            }

            // Email validation
            if (txtEmail.Text != "")
                isValidEmail = Globals.IsEmail(txtEmail.Text);
            else
            {
                errors += "\u2022 Email address required\n";
                inputError = true;
            }

            if (txtEmail.Text != "" && !isValidEmail)
            {
                errors += "\u2022 Invalid email address\n";
                inputError = true;
            }

            // Check if zip code the correct length
            if (txtZip.Text.Length != 5 || !Globals.IsNumeric(txtZip.Text))
            {
                errors += "\u2022 Invalid zip code\n";
                inputError = true;
            }

            // Create user if proper input detected
            if (!inputError)
            {
                // Create buyer
                Buyer newBuyer = new Buyer
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    Phone = phone,
                    Address = txtAddress.Text,
                    City = txtCity.Text,
                    State = cbState.SelectedItem.ToString(),
                    Zip = Convert.ToInt32(txtZip.Text),
                    BuyerStatus = cbStatus.SelectedItem.ToString()
                };

                // Check for email already registered
                if (newBuyer.EmailExists(newBuyer.Email))
                {
                    dataConflict = true;
                    errors += "\u2022 Email address already registered\n";
                }

                // Check if name is already used
                if (newBuyer.NameExists())
                {
                    dataConflict = true;
                    errors += "\u2022 Buyer name already exists\n";
                }

                // Insert buyer data
                if (!dataConflict)
                {
                    bool buyerAdded = newBuyer.Add(); // Attempt to insert buyer data

                    if (!buyerAdded)
                    {
                        MessageBox.Show("Buyer added successfully!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error adding buyer!\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(errorMessage + errors, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
                MessageBox.Show(errorMessage + errors, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }


        /* Refresh DGV upon add form closing
         * ******************************/
        private void AddBuyer_FormClosing(object sender, FormClosingEventArgs e)
        {
            owner.RefreshBuyerDGV();
        }
    }
}
