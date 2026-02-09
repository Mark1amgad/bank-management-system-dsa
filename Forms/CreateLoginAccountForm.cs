using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_datahave_
{
    public partial class CreateLoginAccountForm : Form
    {
        public CreateLoginAccountForm()
        {
            InitializeComponent();
        }

        private void CreateLoginAccountForm_Load(object sender, EventArgs e)
        {
            // Reset form state when form loads
            txtUsername.Clear();
            txtPassword.Clear();
            chkIsAdmin.Checked = false;
            txtUsername.Focus();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            bool isAdmin = chkIsAdmin.Checked;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if username already exists (using static accounts)
            bool exists = false;
            if (login_form.adminAccounts != null)
            {
                foreach (var admin in login_form.adminAccounts)
                {
                    if (admin.name == username)
                    {
                        exists = true;
                        break;
                    }
                }
            }
            if (!exists && login_form.accounts != null)
            {
                foreach (var account in login_form.accounts)
                {
                    if (account.name == username)
                    {
                        exists = true;
                        break;
                    }
                }
            }

            if (exists)
            {
                MessageBox.Show("Username already exists. Please choose a different username.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Initialize lists if null
            if (login_form.accounts == null)
                login_form.accounts = new LinkedList<login_form.Login_Account>();
            if (login_form.adminAccounts == null)
                login_form.adminAccounts = new LinkedList<login_form.Login_Account>();

            // Create new account
            login_form.Login_Account newAccount = new login_form.Login_Account(username, password);
            
            if (isAdmin)
            {
                login_form.adminAccounts.AddLast(newAccount);
                MessageBox.Show($"Admin account '{username}' created successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                login_form.accounts.AddLast(newAccount);
                MessageBox.Show($"Regular account '{username}' created successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

