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
    public partial class Transfer : UserControl
    {
        private Bank_Account senderAccount = null; // Store the sender account
        private Bank_Account receiverAccount = null; // Store the receiver account

        public Transfer()
        {
            InitializeComponent();
            ClearSenderDisplay();
            ClearReceiverDisplay();
            // Attach click event handlers to picture boxes
            pictureBox1.Click += pictureBox1_Click;
            pictureBox2.Click += pictureBox2_Click;
            // Attach click event handlers to buttons
            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }

        private void ClearSenderDisplay()
        {
            label7.Text = "";
            label8.Text = "";
            label10.Text = "";
            label9.Text = "";
        }

        private void ClearReceiverDisplay()
        {
            label19.Text = "";
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Get the Sender National ID from textBox1
            string senderNID = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(senderNID))
            {
                MessageBox.Show("Please enter a National ID to search for sender.", "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Use optimized O(1) search using Dictionary instead of O(n) linear search
            senderAccount = Manage_Account_UC.FindAccountByNationalID(senderNID);

            if (senderAccount != null)
            {
                // Display sender account information
                label7.Text = senderAccount.Name;
                label8.Text = senderAccount.PhoneNumber;
                label10.Text = senderAccount.Bank_ID.ToString();
                label9.Text = senderAccount.Balance.ToString("C"); // Format as currency
            }
            else
            {
                MessageBox.Show("Sender account not found with the provided National ID.", "Not Found",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearSenderDisplay();
                senderAccount = null;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Get the Receiver National ID from textBox3
            string receiverNID = textBox3.Text.Trim();

            if (string.IsNullOrWhiteSpace(receiverNID))
            {
                MessageBox.Show("Please enter a National ID to search for receiver.", "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Use optimized O(1) search using Dictionary instead of O(n) linear search
            receiverAccount = Manage_Account_UC.FindAccountByNationalID(receiverNID);

            if (receiverAccount != null)
            {
                // Display receiver account information
                label19.Text = receiverAccount.Name;
            }
            else
            {
                MessageBox.Show("Receiver account not found with the provided National ID.", "Not Found",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearReceiverDisplay();
                receiverAccount = null;
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
            // Validate sender account
            if (senderAccount == null)
            {
                MessageBox.Show("Please search for a sender account first.", "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate receiver account
            if (receiverAccount == null)
            {
                MessageBox.Show("Please search for a receiver account first.", "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if sender or receiver is VIP and user is not admin
            if ((senderAccount.IsVIP || receiverAccount.IsVIP) && !IsCurrentUserAdmin())
            {
                MessageBox.Show("Need admin access to perform operations on VIP accounts.",
                              "Admin Access Required",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            // Check if sender and receiver are the same account
            if (senderAccount.NationalID == receiverAccount.NationalID)
            {
                MessageBox.Show("Cannot transfer money to the same account. Sender and receiver must be different accounts.",
                              "Invalid Transfer",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            // Get the transfer amount from textBox2
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter an amount to transfer.", "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal transferAmount;
            if (!decimal.TryParse(textBox2.Text, out transferAmount) || transferAmount <= 0)
            {
                MessageBox.Show("Please enter a valid positive amount.", "Invalid Amount",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate amount limits: minimum 100, maximum 1,000,000
            const decimal MIN_AMOUNT = 100;
            const decimal MAX_AMOUNT = 1000000;
            
            if (transferAmount < MIN_AMOUNT)
            {
                MessageBox.Show($"Minimum transfer amount is {MIN_AMOUNT:C}. Please enter an amount between {MIN_AMOUNT:C} and {MAX_AMOUNT:C}.",
                              "Invalid Amount",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }
            
            if (transferAmount > MAX_AMOUNT)
            {
                MessageBox.Show($"Maximum transfer amount is {MAX_AMOUNT:C}. Please enter an amount between {MIN_AMOUNT:C} and {MAX_AMOUNT:C}.",
                              "Invalid Amount",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Perform the transfer
                bool success = senderAccount.TransferTo(receiverAccount, transferAmount);

                if (!success)
                {
                    MessageBox.Show($"Insufficient funds. Sender's current balance: {senderAccount.Balance:C}",
                                  "Transfer Failed",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }
                
                // Update VIP status for both accounts based on balance (more than 10,000,000)
                senderAccount.IsVIP = senderAccount.Balance > 10000000;
                receiverAccount.IsVIP = receiverAccount.Balance > 10000000;

                // Update sender account in the LinkedList
                var senderNode = Manage_Account_UC.accounts.First;
                while (senderNode != null)
                {
                    if (senderNode.Value.NationalID == senderAccount.NationalID)
                    {
                        senderNode.Value.Balance = senderAccount.Balance;
                        senderNode.Value.IsVIP = senderAccount.IsVIP;
                        break;
                    }
                    senderNode = senderNode.Next;
                }

                // Update receiver account in the LinkedList
                var receiverNode = Manage_Account_UC.accounts.First;
                while (receiverNode != null)
                {
                    if (receiverNode.Value.NationalID == receiverAccount.NationalID)
                    {
                        receiverNode.Value.Balance = receiverAccount.Balance;
                        receiverNode.Value.IsVIP = receiverAccount.IsVIP;
                        break;
                    }
                    receiverNode = receiverNode.Next;
                }

                // Update the DataTable for both sender and receiver
                if (Manage_Account_UC.dt != null)
                {
                    foreach (DataRow row in Manage_Account_UC.dt.Rows)
                    {
                        if (row.RowState != DataRowState.Deleted)
                        {
                            if (row["NationalID"].ToString() == senderAccount.NationalID)
                            {
                                row["Balance"] = senderAccount.Balance;
                                row["VIP"] = senderAccount.IsVIP ? "Yes" : "No";
                            }
                            else if (row["NationalID"].ToString() == receiverAccount.NationalID)
                            {
                                row["Balance"] = receiverAccount.Balance;
                                row["VIP"] = receiverAccount.IsVIP ? "Yes" : "No";
                            }
                        }
                    }
                }

                // Save to file
                Handel_Files.SaveAllAccountsToFile();

                // Update the balance display for sender
                label9.Text = senderAccount.Balance.ToString("C");

                // Clear the transfer amount textbox
                textBox2.Clear();

                MessageBox.Show($"Successfully transferred {transferAmount:C} from {senderAccount.Name} to {receiverAccount.Name}.\n" +
                              $"Sender's New Balance: {senderAccount.Balance:C}\n" +
                              $"Receiver's New Balance: {receiverAccount.Balance:C}",
                              "Transfer Successful",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing transfer: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Clear all fields
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            senderAccount = null;
            receiverAccount = null;
            ClearSenderDisplay();
            ClearReceiverDisplay();
        }
    }
}
