using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static project_datahave_.Bank_Account;

namespace project_datahave_
{
    public class Handel_Files
    {

        public static void SaveAllAccountsToFile()
        {
            string filePath = "accounts.txt";
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (DataRow row in Manage_Account_UC.dt.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        string line = string.Join(",", row.ItemArray);
                        sw.WriteLine(line);
                    }
                }
            }
        }
        public static void SaveAccountToFile(Bank_Account account)
        {
            string filePath = "accounts.txt";

            // Ensure valid account type
            string typeString = Enum.IsDefined(typeof(AccountType), account.Type.ToString())
                ? account.Type.ToString()
                : AccountType.Regular.ToString();

            string accountData = $"{account.Name},{account.NationalID},{account.Bank_ID}," +
                               $"{account.Age},{account.Gender},{account.PhoneNumber}," +
                               $"{account.Balance},{typeString}";

            File.AppendAllText(filePath, accountData + Environment.NewLine);

        }
        public static Bank_Account CreateAccountByType(string accountType)
        {
            switch (accountType)
            {
                case "Savings":
                    return new SavingsAccount();
                case "Business":
                    return new BusinessAccount();
                default:
                    return new Bank_Account();
            }
        }
        public static Bank_Account CreateAccountFromData(string[] data)
        {
            // Parse account type with default to Regular
            AccountType accountType;
            if (!Enum.TryParse(data[7], out accountType))
            {
                accountType = AccountType.Regular;
            }

            // Create the appropriate account type
            Bank_Account account = CreateAccountByType(accountType.ToString());

            // Set all properties
            account.Name = data[0];
            account.NationalID = data[1];

            // Handle Bank_ID parsing
            Guid bankId;
            if (!Guid.TryParse(data[2], out bankId))
            {
                bankId = Guid.NewGuid(); // Generate new ID if invalid
            }
            account.Bank_ID = bankId;

            // Parse age with validation
            int age;
            if (!int.TryParse(data[3], out age) || age < 0)
            {
                age = 0; // Default to 0 if invalid
            }
            account.Age = age;

            // Parse gender with default to Male
            Gender gender;
            if (!Enum.TryParse(data[4], out gender))
            {
                gender = Gender.Male;
            }
            account.Gender = gender;

            account.PhoneNumber = data[5];

            // Parse balance with validation
            decimal balance;
            if (!decimal.TryParse(data[6], out balance) || balance < 0)
            {
                balance = 0; // Default to 0 if invalid
            }
            account.Balance = balance;

            return account;
        }
        public static void LoadAccountsFromFile()
        {
            string filePath = "accounts.txt";
            if (!File.Exists(filePath)) return;

            // Clear existing data first
            Manage_Account_UC.dt.Rows.Clear();
            Manage_Account_UC.accounts.Clear();
            Manage_Account_UC.accountsDictionary.Clear();

            foreach (string line in File.ReadAllLines(filePath))
            {
                try
                {
                    string[] data = line.Split(',');
                    if (data.Length < 8) continue;

                    // Create and populate the account
                    Bank_Account account = CreateAccountFromData(data);
                    
                    // Update VIP status based on balance (more than 10,000,000)
                    account.IsVIP = account.Balance > 10000000;

                    // Add to LinkedList
                    Manage_Account_UC.accounts.AddLast(account);
                    
                    // Add to Dictionary for O(1) lookup
                    Manage_Account_UC.accountsDictionary[account.NationalID] = account;

                    // Add to DataTable
                    Manage_Account_UC.dt.Rows.Add(
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
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading account: {ex.Message}");
                    // Continue with next record even if one fails
                }
            }
        }

    }
}
