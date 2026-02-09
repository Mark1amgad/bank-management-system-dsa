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
    public partial class mainform : Form
    {
        bool sidebarExpand = false;
        bool Manage_moneyCollapse = false;
        private string _loggedInUsername;
        private bool _isAdmin;
        private const int ADMIN_PANEL_HEIGHT = 71;
        
        // Typing animation variables
        private int welcomeCharIndex = 0;
        private string welcomeFullText = "Welcome";
        
        public mainform(string username, bool isAdmin)
        {
            InitializeComponent();
            _loggedInUsername = username;
            DisplayWelcomeMessage();
            Sidebar2.Width = Sidebar2.MinimumSize.Width;
            ManageFlow_pnl.Height = ManageFlow_pnl.MinimumSize.Height;
            _isAdmin = isAdmin;
            ApplyPanelPermissions();
            this.Shown += Mainform_Shown;
        }

        private void Mainform_Shown(object sender, EventArgs e)
        {
            // Start welcome animation after form is fully shown
            InitializeWelcomeAnimation();
        }


        private void ApplyPanelPermissions()
        {
            if (_isAdmin)
            {
                panel6.Height = ADMIN_PANEL_HEIGHT;
                panel6.Visible = true;
            }
            else
            {
                // Not Admin: Set panel height to 0 to hide it
                panel6.Height = 0;
                panel6.Visible = false;
            }
        }
        private void DisplayWelcomeMessage()
        {
            lblWelcome.Text = _loggedInUsername;
        }

        private void InitializeWelcomeAnimation()
        {
            // Reset the welcome label
            label1.Text = "";
            welcomeCharIndex = 0;
            // Ensure timer is enabled and start the typing animation timer
            welcomeTimer.Enabled = true;
            welcomeTimer.Start();
        }

        private void welcomeTimer_Tick(object sender, EventArgs e)
        {
            if (welcomeCharIndex < welcomeFullText.Length)
            {
                label1.Text += welcomeFullText[welcomeCharIndex];
                welcomeCharIndex++;
            }
            else
            {
                welcomeTimer.Stop();
                welcomeTimer.Enabled = false;
            }
        }

        private void sidetimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {

                Sidebar2.Width -= 10;
                if (Sidebar2.Width <= Sidebar2.MinimumSize.Width)
                {
                    Sidebar2.Width = Sidebar2.MinimumSize.Width;
                    sidebarExpand = false;
                    sidetimer.Stop();
                }
            }
            else
            {

                Sidebar2.Width += 10;
                if (Sidebar2.Width >= Sidebar2.MaximumSize.Width)
                {
                    Sidebar2.Width = Sidebar2.MaximumSize.Width;
                    sidebarExpand = true;
                    sidetimer.Stop();
                }
            }
        }

        private void Manage_money_timer_Tick(object sender, EventArgs e)
        {
            if (Manage_moneyCollapse)
            {

                ManageFlow_pnl.Height += 10;
                if (ManageFlow_pnl.Height >= ManageFlow_pnl.MaximumSize.Height)
                {
                    ManageFlow_pnl.Height = ManageFlow_pnl.MaximumSize.Height;
                    Manage_moneyCollapse = false;
                    Manage_money_timer.Stop();
                }
            }
            else
            {

                 ManageFlow_pnl.Height -= 10;
                if (ManageFlow_pnl.Height <= ManageFlow_pnl.MinimumSize.Height)
                {
                    ManageFlow_pnl.Height = ManageFlow_pnl.MinimumSize.Height;
                    Manage_moneyCollapse = true;
                    Manage_money_timer.Stop();
                }
            }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            sidetimer.Start();
        }

        private void logout_button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                 "Are you sure you want to log out?",
                 "Confirm Logout",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question
          );


            if (dialogResult == DialogResult.Yes)
            {
                login_form login_Form = new login_form();
                login_Form.Show();
                this.Close();
            }
        }

        private void Manage_Money_but_Click(object sender, EventArgs e)
        {
            Manage_money_timer.Start();
            Deposite deposite = new Deposite();
            AddUserControl(deposite);
        }
        public void AddUserControl(UserControl userControl)
        {
            pnlMainContainer.Controls.Clear();
            userControl.Dock = DockStyle.Fill; 
            pnlMainContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        
        public bool IsAdmin
        {
            get { return _isAdmin; }
        }
        
        private void admin_acces_Click(object sender, EventArgs e)
        {
            AdminControl adminControl = new AdminControl();
            AddUserControl(adminControl);
        }

        private void Deposit_butt_Click(object sender, EventArgs e)
        {
            Deposite deposite = new Deposite();
            AddUserControl(deposite);
        }

        private void Withdraw_butt_Click(object sender, EventArgs e)
        {
            Withdraw withdraw = new Withdraw();
            AddUserControl(withdraw);
        }

        private void Transfer_butt_Click(object sender, EventArgs e)
        {
            Transfer transfer = new Transfer();
            AddUserControl(transfer);
        }

        private void Manage_Account_butt_Click(object sender, EventArgs e)
        {
            Manage_Account_UC manageaccount = new Manage_Account_UC();
            AddUserControl(manageaccount);
        }
    }
}
