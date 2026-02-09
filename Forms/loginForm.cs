using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_datahave_
{
    public partial class login_form : Form
    {
        public static LinkedList<Login_Account> accounts;        // Normal users (static for access)
        public static LinkedList<Login_Account> adminAccounts;   // Admin users (static for access)

        public login_form()
        {
            InitializeComponent();

            if (accounts == null)
                accounts = new LinkedList<Login_Account>();
            if (adminAccounts == null)
                adminAccounts = new LinkedList<Login_Account>();  // ★ NEW admin list

            // Normal Users (only add if list is empty)
            if (accounts.Count == 0)
            {
                accounts.AddLast(new Login_Account("mark", "mark101"));
                accounts.AddLast(new Login_Account("hossam", "hossam101"));
                accounts.AddLast(new Login_Account("abdulrhman", "abdulrhamn101"));
                accounts.AddLast(new Login_Account("abdalhalem", "abdalhalem101"));
                accounts.AddLast(new Login_Account("khaled", "khaled101"));
            }

            // Admin Users ★ (only add if list is empty)
            if (adminAccounts.Count == 0)
            {
                adminAccounts.AddLast(new Login_Account("ibrahim", "ibrahim101"));
            }
        }

        // Login Account Class
        public class Login_Account
        {
            public string name;
            public string password;

            public Login_Account(string Username, string pass)
            {
                name = Username;
                password = pass;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Password_textBox.PasswordChar = Show_passeord.Checked ? '\0' : '•';
        }

        private void Login_button_Click(object sender, EventArgs e)
        {
            string username = usernam_textBox.Text;
            string password = Password_textBox.Text;

            bool loggedIn = false;
            bool isAdmin = false;

            // --- Check Admins First ---
            foreach (var admin in adminAccounts)
            {
                if (username == admin.name && password == admin.password)
                {
                    isAdmin = true;
                    loggedIn = true;
                    break;
                }
            }

            // --- If not admin, check normal users ---
            if (!loggedIn)
            {
                foreach (var account in accounts)
                {
                    if (username == account.name && password == account.password)
                    {
                        isAdmin = false;
                        loggedIn = true;
                        break;
                    }
                }
            }

            // --- Login Results ---
            if (loggedIn)
            {
                MessageBox.Show(isAdmin ? "Welcome Admin!" : "Login successful!");

                mainform Main_Form = new mainform(username, isAdmin);
                Main_Form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
                Password_textBox.Clear();
                usernam_textBox.Focus();
            }
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void usernam_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void Password_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Login_button.PerformClick();
            }
        }
        
    }
}
