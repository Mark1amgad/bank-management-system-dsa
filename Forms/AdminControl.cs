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
    public partial class AdminControl : UserControl
    {
        public AdminControl()
        {
            InitializeComponent();
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            // Calculate statistics
            int totalAccounts = Manage_Account_UC.accounts.Count;
            int vipAccounts = Manage_Account_UC.accounts.Count(acc => acc.IsVIP);
            int regularAccounts = totalAccounts - vipAccounts;
            
            int regularType = Manage_Account_UC.accounts.Count(acc => acc.Type == AccountType.Regular);
            int savingsType = Manage_Account_UC.accounts.Count(acc => acc.Type == AccountType.Savings);
            int businessType = Manage_Account_UC.accounts.Count(acc => acc.Type == AccountType.Business);
            
            decimal totalBalance = Manage_Account_UC.accounts.Sum(acc => acc.Balance);
            decimal vipBalance = Manage_Account_UC.accounts.Where(acc => acc.IsVIP).Sum(acc => acc.Balance);
            decimal regularBalance = totalBalance - vipBalance;

            // Update labels
            lblTotalAccounts.Text = totalAccounts.ToString();
            lblVIPAccounts.Text = vipAccounts.ToString();
            lblRegularAccounts.Text = regularAccounts.ToString();
            lblTotalBalance.Text = totalBalance.ToString("C");
            lblVIPBalance.Text = vipBalance.ToString("C");
            lblRegularBalance.Text = regularBalance.ToString("C");
            
            lblRegularType.Text = regularType.ToString();
            lblSavingsType.Text = savingsType.ToString();
            lblBusinessType.Text = businessType.ToString();
            
            // Calculate percentages - ensure they add up to exactly 100%
            if (totalAccounts > 0)
            {
                double vipPercentDouble = (vipAccounts / (double)totalAccounts) * 100.0;
                double regularPercentDouble = (regularAccounts / (double)totalAccounts) * 100.0;
                
                // Round to nearest integer
                int vipPercent = (int)Math.Round(vipPercentDouble);
                int regularPercent = (int)Math.Round(regularPercentDouble);
                
                // Ensure they add up to 100% (adjust for rounding errors)
                int sum = vipPercent + regularPercent;
                if (sum != 100)
                {
                    // Adjust the larger percentage to make sum = 100
                    if (vipPercent >= regularPercent)
                    {
                        vipPercent += (100 - sum);
                    }
                    else
                    {
                        regularPercent += (100 - sum);
                    }
                }
                
                lblVIPPercent.Text = $"{vipPercent}%";
                lblRegularPercent.Text = $"{regularPercent}%";
            }
            else
            {
                lblVIPPercent.Text = "0%";
                lblRegularPercent.Text = "0%";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            CreateLoginAccountForm form = new CreateLoginAccountForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Login account created successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnManageAccounts_Click(object sender, EventArgs e)
        {
            Manage_Account_UC manageaccount = new Manage_Account_UC();
            // Find parent form and add control
            Form parentForm = this.FindForm();
            if (parentForm != null && parentForm is mainform)
            {
                ((mainform)parentForm).AddUserControl(manageaccount);
            }
        }
    }
}

