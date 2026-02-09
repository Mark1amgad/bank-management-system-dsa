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
    public partial class Withdraw : UserControl
    {
        private Bank_Account currentAccount = null; // Store the currently searched account
        public Withdraw()
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

            // Get the withdrawal amount from textBox2
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter an amount to withdraw.", "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal withdrawAmount;
            if (!decimal.TryParse(textBox2.Text, out withdrawAmount) || withdrawAmount <= 0)
            {
                MessageBox.Show("Please enter a valid positive amount.", "Invalid Amount",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate amount limits: minimum 100, maximum 1,000,000
            const decimal MIN_AMOUNT = 100;
            const decimal MAX_AMOUNT = 1000000;
            
            if (withdrawAmount < MIN_AMOUNT)
            {
                MessageBox.Show($"Minimum withdrawal amount is {MIN_AMOUNT:C}. Please enter an amount between {MIN_AMOUNT:C} and {MAX_AMOUNT:C}.",
                              "Invalid Amount",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }
            
            if (withdrawAmount > MAX_AMOUNT)
            {
                MessageBox.Show($"Maximum withdrawal amount is {MAX_AMOUNT:C}. Please enter an amount between {MIN_AMOUNT:C} and {MAX_AMOUNT:C}.",
                              "Invalid Amount",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Withdraw the amount from the account
                bool success = currentAccount.Withdraw(withdrawAmount);

                if (!success)
                {
                    MessageBox.Show($"Insufficient funds. Current balance: {currentAccount.Balance:C}",
                                  "Withdrawal Failed",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }
                
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

                // Clear the withdrawal amount textbox
                textBox2.Clear();

                MessageBox.Show($"Successfully withdrew {withdrawAmount:C} from account.\nNew Balance: {currentAccount.Balance:C}",
                              "Withdrawal Successful",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing withdrawal: {ex.Message}", "Error",
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
