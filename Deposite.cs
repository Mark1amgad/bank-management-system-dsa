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
    public partial class Deposite : UserControl
    {
        private Bank_Account currentAccount = null; // Store the currently searched account
        public Deposite()
        {
            InitializeComponent();
            ClearAccountDisplay();
        }
        private void ClearAccountDisplay()
        {
            label7.Text = "";
            label8.Text = "";
            label10.Text = "";
            label9.Text = "";
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Get the National ID from textBox1
            string nationalID = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(nationalID))
            {
                MessageBox.Show("Please enter a National ID to search.", "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Use optimized O(1) search using Dictionary instead of O(n) linear search
            currentAccount = Manage_Account_UC.FindAccountByNationalID(nationalID);

            if (currentAccount != null)
            {
                // Display account information in labels
                label7.Text = currentAccount.Name;
                label8.Text = currentAccount.PhoneNumber;
                label10.Text = currentAccount.Bank_ID.ToString();
                label9.Text = currentAccount.Balance.ToString("C"); // Format as currency
            }
            else
            {
                MessageBox.Show("Account not found with the provided National ID.", "Not Found",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAccountDisplay();
            }
        }

        private bool IsCurrentUserAdmin()
        {
            Form parentForm = this.FindForm();
            if (parentForm != null && parentForm is mainform)
            {
                return ((mainform)parentForm).IsAdmin;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentAccount == null)
            {
                MessageBox.Show("Please search for an account first.", "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if account is VIP and user is not admin
            if (currentAccount.IsVIP && !IsCurrentUserAdmin())
            {
                MessageBox.Show("Need admin access to perform operations on VIP accounts.",
                              "Admin Access Required",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            // Get the deposit amount from textBox2
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter an amount to deposit.", "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal depositAmount;
            if (!decimal.TryParse(textBox2.Text, out depositAmount) || depositAmount <= 0)
            {
                MessageBox.Show("Please enter a valid positive amount.", "Invalid Amount",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate amount limits: minimum 100, maximum 1,000,000
            const decimal MIN_AMOUNT = 100;
            const decimal MAX_AMOUNT = 1000000;
            
            if (depositAmount < MIN_AMOUNT)
            {
                MessageBox.Show($"Minimum deposit amount is {MIN_AMOUNT:C}. Please enter an amount between {MIN_AMOUNT:C} and {MAX_AMOUNT:C}.",
                              "Invalid Amount",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }
            
            if (depositAmount > MAX_AMOUNT)
            {
                MessageBox.Show($"Maximum deposit amount is {MAX_AMOUNT:C}. Please enter an amount between {MIN_AMOUNT:C} and {MAX_AMOUNT:C}.",
                              "Invalid Amount",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Deposit the amount to the account
                currentAccount.Deposit(depositAmount);
                
                // Update VIP status based on balance (more than 10,000,000)
                currentAccount.IsVIP = currentAccount.Balance > 10000000;

                // Update the account in the LinkedList
                var node = Manage_Account_UC.accounts.First;
                while (node != null)
                {
                    if (node.Value.NationalID == currentAccount.NationalID)
                    {
                        node.Value.Balance = currentAccount.Balance;
                        node.Value.IsVIP = currentAccount.IsVIP;
                        break;
                    }
                    node = node.Next;
                }

                // Update the DataTable
                if (Manage_Account_UC.dt != null)
                {
                    foreach (DataRow row in Manage_Account_UC.dt.Rows)
                    {
                        if (row.RowState != DataRowState.Deleted &&
                            row["NationalID"].ToString() == currentAccount.NationalID)
                        {
                            row["Balance"] = currentAccount.Balance;
                            row["VIP"] = currentAccount.IsVIP ? "Yes" : "No";
                            break;
                        }
                    }
                }

                // Save to file
                Handel_Files.SaveAllAccountsToFile();

                // Update the balance display
                label9.Text = currentAccount.Balance.ToString("C");

                // Clear the deposit amount textbox
                textBox2.Clear();

                MessageBox.Show($"Successfully deposited {depositAmount:C} to account.\nNew Balance: {currentAccount.Balance:C}",
                              "Deposit Successful",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing deposit: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Clear all fields
            textBox1.Clear();
            textBox2.Clear();
            currentAccount = null;
            ClearAccountDisplay();
        }
    }
}
