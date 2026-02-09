using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace project_datahave_
{
    public partial class Manage_Account_UC : UserControl
    {
        public static LinkedList<Bank_Account> accounts = new LinkedList<Bank_Account>();
        // Dictionary for O(1) lookup by NationalID - optimized search structure
        public static Dictionary<string, Bank_Account> accountsDictionary = new Dictionary<string, Bank_Account>();

        public static DataTable dt;
        public Manage_Account_UC()
        {
            InitializeComponent();
            dt = new DataTable();
            InitializeDataTable();
            StyleDataGridView();
            Handel_Files.LoadAccountsFromFile();
            RefreshGrid();
        }

        private void StyleDataGridView()
        {
            // Style the DataGridView with modern dark theme
            dgvAccounts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);
            dgvAccounts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAccounts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvAccounts.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 60);
            dgvAccounts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvAccounts.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dgvAccounts.DefaultCellStyle.ForeColor = Color.White;
            dgvAccounts.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvAccounts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180);
            dgvAccounts.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvAccounts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dgvAccounts.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgvAccounts.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180);
            dgvAccounts.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;

            dgvAccounts.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dgvAccounts.RowHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        public void RefreshGrid()
        {
            dt.Rows.Clear();

            foreach (var acc in accounts)
            {
                // Update VIP status based on balance (more than 10,000,000)
                acc.IsVIP = acc.Balance > 10000000;
                
                dt.Rows.Add(
                    acc.Name,
                    acc.NationalID,
                    acc.Bank_ID,
                    acc.Age,
                    acc.Gender.ToString(),
                    acc.PhoneNumber,
                    acc.Balance,
                    acc.Type.ToString(),
                    acc.IsVIP ? "Yes" : "No" // VIP status
                );
            }
            
            // Ensure columns fill the DataGridView width
            if (dgvAccounts.Columns.Count > 0)
            {
                dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }



        private void InitializeDataTable()
        {
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("NationalID", typeof(string));
            dt.Columns.Add("Bank_ID", typeof(Guid));
            dt.Columns.Add("Age", typeof(int));
            dt.Columns.Add("Gender", typeof(string));
            dt.Columns.Add("PhoneNumber", typeof(string));
            dt.Columns.Add("Balance", typeof(decimal));
            dt.Columns.Add("AccountType", typeof(string));
            dt.Columns.Add("VIP", typeof(string)); // VIP status column

            dgvAccounts.DataSource = dt;
            
            // Configure columns to fill the entire DataGridView width
            dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Set fill weights for proportional column sizing (optional - can be adjusted)
            if (dgvAccounts.Columns.Count > 0)
            {
                dgvAccounts.Columns["Name"].FillWeight = 13;
                dgvAccounts.Columns["NationalID"].FillWeight = 13;
                dgvAccounts.Columns["Bank_ID"].FillWeight = 18;
                dgvAccounts.Columns["Age"].FillWeight = 7;
                dgvAccounts.Columns["Gender"].FillWeight = 9;
                dgvAccounts.Columns["PhoneNumber"].FillWeight = 11;
                dgvAccounts.Columns["Balance"].FillWeight = 11;
                dgvAccounts.Columns["AccountType"].FillWeight = 7;
                dgvAccounts.Columns["VIP"].FillWeight = 5; // VIP column
            }
        }

        /// <summary>
        /// Optimized search method using Dictionary for O(1) lookup by NationalID
        /// This is the best search algorithm for this use case since we're searching by a unique key
        /// </summary>
        /// <param name="nationalID">The National ID to search for</param>
        /// <returns>The Bank_Account if found, null otherwise</returns>
        public static Bank_Account FindAccountByNationalID(string nationalID)
        {
            if (string.IsNullOrWhiteSpace(nationalID))
                return null;

            // O(1) lookup using Dictionary - much faster than linear search O(n)
            if (accountsDictionary.TryGetValue(nationalID, out Bank_Account account))
            {
                return account;
            }

            // If not found in Dictionary, try DataTable (fallback for data consistency)
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row.RowState != DataRowState.Deleted &&
                        row["NationalID"].ToString() == nationalID)
                    {
                        // Create account object from DataRow
                        Bank_Account accountFromTable = new Bank_Account()
                        {
                            Name = row["Name"].ToString(),
                            NationalID = row["NationalID"].ToString(),
                            Bank_ID = (Guid)row["Bank_ID"],
                            Age = (int)row["Age"],
                            Gender = (Gender)Enum.Parse(typeof(Gender), row["Gender"].ToString()),
                            PhoneNumber = row["PhoneNumber"].ToString(),
                            Balance = (decimal)row["Balance"],
                            Type = (AccountType)Enum.Parse(typeof(AccountType), row["AccountType"].ToString())
                        };
                        
                        // Update VIP status based on balance (more than 10,000,000)
                        accountFromTable.IsVIP = accountFromTable.Balance > 10000000;
                        
                        // Add to both LinkedList and Dictionary to keep them in sync
                        accounts.AddLast(accountFromTable);
                        accountsDictionary[nationalID] = accountFromTable;
                        
                        return accountFromTable;
                    }
                }
            }

            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Account_detailes form = new Add_Account_detailes();

            if (form.ShowDialog() == DialogResult.OK)
            {
                // Update VIP status based on balance (more than 10,000,000)
                form.NewAccount.IsVIP = form.NewAccount.Balance > 10000000;
                
                accounts.AddLast(form.NewAccount);
                // Add to dictionary for fast lookup
                accountsDictionary[form.NewAccount.NationalID] = form.NewAccount;
                RefreshGrid();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an account to delete.", "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this account?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    DataGridViewRow selectedRow = dgvAccounts.SelectedRows[0];
                    DataRowView rowView = (DataRowView)selectedRow.DataBoundItem;
                    DataRow row = rowView.Row;
                    string nationalID = row["NationalID"].ToString();
                    
                    // Remove from Dictionary
                    if (accountsDictionary.ContainsKey(nationalID))
                    {
                        accountsDictionary.Remove(nationalID);
                    }
                    
                    // Remove from LinkedList
                    var node = accounts.First;
                    while (node != null)
                    {
                        var next = node.Next;
                        if (node.Value.NationalID == nationalID)
                        {
                            accounts.Remove(node);
                            break;
                        }
                        node = next;
                    }
                    
                    // Delete from DataTable
                    row.Delete();
                    
                    //SaveAllAccountsToFile();
                    Handel_Files.SaveAllAccountsToFile();
                    MessageBox.Show("Account deleted successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting account: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Loadbut_Click(object sender, EventArgs e)
        {
            // Open file dialog to select a text file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Select a file to load accounts from";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    int loadedCount = 0;
                    int skippedCount = 0;

                    // Read all lines from the selected file
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        try
                        {
                            string[] data = line.Split(',');
                            if (data.Length < 8) continue;

                            // Create account from data
                            Bank_Account account = Handel_Files.CreateAccountFromData(data);

                            // Check if National ID already exists using O(1) dictionary lookup
                            bool exists = accountsDictionary.ContainsKey(account.NationalID);
                            
                            if (!exists)
                            {
                                // Also check in DataTable as fallback
                                foreach (DataRow row in dt.Rows)
                                {
                                    if (row.RowState != DataRowState.Deleted && 
                                        row["NationalID"].ToString() == account.NationalID)
                                    {
                                        exists = true;
                                        skippedCount++;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                skippedCount++;
                            }

                            // If National ID doesn't exist, add the account
                            if (!exists)
                            {
                                // Update VIP status based on balance (more than 10,000,000)
                                account.IsVIP = account.Balance > 10000000;
                                
                                accounts.AddLast(account);
                                // Add to dictionary for fast lookup
                                accountsDictionary[account.NationalID] = account;
                                dt.Rows.Add(
                                    account.Name,
                                    account.NationalID,
                                    account.Bank_ID,
                                    account.Age,
                                    account.Gender.ToString(),
                                    account.PhoneNumber,
                                    account.Balance,
                                    account.Type.ToString(),
                                    account.IsVIP ? "Yes" : "No" // VIP status
                                );
                                loadedCount++;
                            }
                        }
                        catch (Exception ex)
                        {
                            // Skip invalid lines and continue
                            Console.WriteLine($"Error processing line: {ex.Message}");
                            continue;
                        }
                    }

                    // Save all accounts to the main file
                    Handel_Files.SaveAllAccountsToFile();

                    // Show summary message
                    MessageBox.Show(
                        $"Load completed!\n\nLoaded: {loadedCount} account(s)\nSkipped (duplicate National ID): {skippedCount} account(s)",
                        "Load Accounts",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    RefreshGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error loading file: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void Updatebut_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dgvAccounts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an account to update.", "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgvAccounts.SelectedRows[0];
                DataRowView rowView = (DataRowView)selectedRow.DataBoundItem;
                DataRow row = rowView.Row;

                // Create a Bank_Account object from the selected row data
                Bank_Account accountToUpdate = new Bank_Account()
                {
                    Name = row["Name"].ToString(),
                    NationalID = row["NationalID"].ToString(),
                    Bank_ID = (Guid)row["Bank_ID"],
                    Age = (int)row["Age"],
                    Gender = (Gender)Enum.Parse(typeof(Gender), row["Gender"].ToString()),
                    PhoneNumber = row["PhoneNumber"].ToString(),
                    Balance = (decimal)row["Balance"],
                    Type = (AccountType)Enum.Parse(typeof(AccountType), row["AccountType"].ToString())
                };

                // Open Add_Account_detailes form with the account data for editing
                Add_Account_detailes form = new Add_Account_detailes(accountToUpdate);

                if (form.ShowDialog() == DialogResult.OK && form.NewAccount != null)
                {
                    // Find and update the existing account in LinkedList
                    var node = accounts.First;
                    Bank_Account existingAccount = null;
                    while (node != null)
                    {
                        if (node.Value.NationalID == accountToUpdate.NationalID)
                        {
                            existingAccount = node.Value;
                            break;
                        }
                        node = node.Next;
                    }

                    if (existingAccount != null)
                    {
                        // Update the existing account object properties
                        existingAccount.Name = form.NewAccount.Name;
                        existingAccount.Age = form.NewAccount.Age;
                        existingAccount.Gender = form.NewAccount.Gender;
                        existingAccount.PhoneNumber = form.NewAccount.PhoneNumber;
                        existingAccount.Type = form.NewAccount.Type;
                        
                        // Update NationalID if changed (update dictionary keys)
                        if (accountToUpdate.NationalID != form.NewAccount.NationalID)
                        {
                            accountsDictionary.Remove(accountToUpdate.NationalID);
                            existingAccount.NationalID = form.NewAccount.NationalID;
                            accountsDictionary[form.NewAccount.NationalID] = existingAccount;
                        }
                        else
                        {
                            existingAccount.NationalID = form.NewAccount.NationalID;
                            accountsDictionary[form.NewAccount.NationalID] = existingAccount;
                        }
                        
                        // Update VIP status based on balance
                        existingAccount.IsVIP = existingAccount.Balance > 10000000;

                        // Update the DataTable row
                        row["Name"] = existingAccount.Name;
                        row["NationalID"] = existingAccount.NationalID;
                        row["Age"] = existingAccount.Age;
                        row["Gender"] = existingAccount.Gender.ToString();
                        row["PhoneNumber"] = existingAccount.PhoneNumber;
                        row["Balance"] = existingAccount.Balance;
                        row["AccountType"] = existingAccount.Type.ToString();
                        row["VIP"] = existingAccount.IsVIP ? "Yes" : "No";

                        // Save to file
                        Handel_Files.SaveAllAccountsToFile();

                        // Refresh the grid
                        RefreshGrid();

                        MessageBox.Show("Account updated successfully!", "Success",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating account: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
