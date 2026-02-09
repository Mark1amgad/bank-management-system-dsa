using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using project_datahave_;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project_datahave_
{
    public partial class Add_Account_detailes : Form
    {
        public Bank_Account NewAccount { get; private set; }
        private Bank_Account OriginalAccount;
        public Add_Account_detailes()
        {
            InitializeComponent();
            StyleControls();
            foreach (string type in Enum.GetNames(typeof(AccountType)))
            {
                cmbAccountType.Items.Add(type);
            }
            if (cmbAccountType.Items.Count > 0)
            {
                cmbAccountType.SelectedIndex = 0;
            }
        }

        private void StyleControls()
        {
            // Style RadioButtons
            MaleradioButton1.ForeColor = Color.White;
            FemaleradioButton2.ForeColor = Color.White;
            
            // Style ComboBox dropdown
            cmbAccountType.DrawMode = DrawMode.OwnerDrawFixed;
            cmbAccountType.DrawItem += CmbAccountType_DrawItem;
        }

        private void CmbAccountType_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            System.Windows.Forms. ComboBox combo = sender as System.Windows.Forms.ComboBox;
            if (combo == null) return;
            
            e.DrawBackground();
            
            Brush brush = new SolidBrush(Color.White);
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(70, 130, 180)), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(55, 55, 55)), e.Bounds);
            }
            
            e.Graphics.DrawString(combo.Items[e.Index].ToString(), 
                new Font("Segoe UI", 12F), 
                brush, 
                e.Bounds);
            
            e.DrawFocusRectangle();
            brush.Dispose();
        }
        public Add_Account_detailes(Bank_Account existingAccount) : this() // يستدعي المنشئ الافتراضي أولاً
        {
            this.OriginalAccount = existingAccount; // تخزين الكائن الأصلي
            this.Text = "Update Account Details";   // تغيير عنوان النموذج
            InitializeData(existingAccount);        // ملء الحقول بالبيانات
        }
        private void InitializeData(Bank_Account account)
        {
            // 1. ملء TextBoxes
            NameTextBox1.Text = account.Name;
            National_IDtextBox1.Text = account.NationalID;
            Age_textBox3.Text = account.Age.ToString();
            Phone_numTextbox.Text = account.PhoneNumber;

            // 2. تعيين Gender (الراديو بتن - حسب الصورة image_ab769a.png)
            if (account.Gender == Gender.Male)
            {
                MaleradioButton1.Checked = true;
            }
            else
            {
                FemaleradioButton2.Checked = true;
            }

            // 3. تعيين AccountType (الكومبو بوكس)
            // هذا يعين القيمة التي تم قراءتها من الـ DataGridView إلى الـ ComboBox
            cmbAccountType.SelectedItem = account.Type.ToString();
        }

        private void Add_but_Click(object sender, EventArgs e)
        {
            // --- INPUT VALIDATION AND PARSING ---

            // 1. Basic Field Check (Name)
            if (string.IsNullOrWhiteSpace(NameTextBox1.Text) ||
                string.IsNullOrWhiteSpace(National_IDtextBox1.Text) ||
                string.IsNullOrWhiteSpace(Phone_numTextbox.Text))
            {
                MessageBox.Show("Please fill in all required text fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Age Validation
            int age;
            if (!int.TryParse(Age_textBox3.Text, out age))
            {
                MessageBox.Show("Please enter a valid numeric age.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check the required range
            if (age < 18 || age > 100)
            {
                MessageBox.Show("Age must be between 18 and 100 to open an account.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Gender Determination (Using Radio Buttons)
            Gender selectedGender;
            if (MaleradioButton1.Checked) // Assuming your Male radio button is named MaleradioButton1
            {
                selectedGender = Gender.Male;
            }
            else if (FemaleradioButton2.Checked) // Assuming your Female radio button is named FemaleradioButton2
            {
                selectedGender = Gender.Female;
            }
            else
            {
                MessageBox.Show("Please select the account holder's Gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. AccountType Determination (Using ComboBox)
            AccountType selectedAccountType;
            try
            {
                // NOTE: The cmbAccountType needs to be available and its items must match 
                // the enum names (Regular, Savings, Business).
                selectedAccountType = (AccountType)Enum.Parse(
                    typeof(AccountType),
                    cmbAccountType.SelectedItem.ToString(),
                    true // true ignores case for safer parsing
                );
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a valid Account Type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string nationalID = National_IDtextBox1.Text;
            if (nationalID.Length != 14 || !nationalID.All(char.IsDigit))
            {
                MessageBox.Show("National ID must be exactly 14 numeric digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Make sure that national id doesn't exist before
            if (Manage_Account_UC.dt != null)
            {
                bool nationalIdExists = Manage_Account_UC.dt.AsEnumerable()
                    .Any(row => row.Field<string>("NationalID") == nationalID);

                // For updates, if National ID hasn't changed, it's the same account - allow it
                if (OriginalAccount != null && nationalID == OriginalAccount.NationalID)
                {
                    nationalIdExists = false;
                }

                if (nationalIdExists)
                {
                    MessageBox.Show("This National ID already exists in our system!", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    National_IDtextBox1.Focus();
                    return;
                }
            }
            string phoneNumber = Phone_numTextbox.Text;
            if (phoneNumber.Length != 11 || !phoneNumber.StartsWith("01") || !phoneNumber.All(char.IsDigit))
            {
                MessageBox.Show("Phone Number must be 11 digits long and start with '01'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- OBJECT CREATION ---

            // If updating an existing account, preserve the Bank_ID
            if (OriginalAccount != null)
            {
                NewAccount = new Bank_Account()
                {
                    Name = NameTextBox1.Text,
                    NationalID = National_IDtextBox1.Text,
                    PhoneNumber = Phone_numTextbox.Text,
                    Age = age,
                    Gender = selectedGender,
                    Type = selectedAccountType,
                    Bank_ID = OriginalAccount.Bank_ID, // Preserve the original Bank_ID
                    Balance = OriginalAccount.Balance  // Preserve the balance
                };
            }
            else
            {
                NewAccount = new Bank_Account()
                {
                    Name = NameTextBox1.Text,
                    NationalID = National_IDtextBox1.Text,
                    PhoneNumber = Phone_numTextbox.Text,
                    Age = age,
                    Gender = selectedGender,
                    Type = selectedAccountType
                };
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}