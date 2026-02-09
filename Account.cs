using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_datahave_;

namespace project_datahave_
{
    public enum Gender { Male, Female }
    public enum AccountType { Regular, Savings, Business }

    public class Bank_Account                   //class definitions  
    {
        public string Name { get; set; }
        public string NationalID { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public Guid Bank_ID { get; set; }
        public Gender Gender { get; set; }
        private decimal _balance;
        public AccountType Type { get;  set; }
        public bool IsVIP { get; set; }

        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }  // Changed from protected to public
        }
        public Bank_Account()
        {
            Bank_ID = Guid.NewGuid();
            Type = AccountType.Regular;
        }
        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive");

            Balance += amount;
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive");

            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
        public bool TransferTo(Bank_Account recipient, decimal amount)
        {
            if (this.Balance < amount)
                return false;

            this.Balance -= amount;
            recipient.Balance += amount;
            return true;
        }

        public virtual decimal CalculateInterest()
        {
            return 0; // Base accounts have no interest
        }
        public class SavingsAccount : Bank_Account
        {
            private decimal _interestRate;

            public SavingsAccount(decimal interestRate = 0.03m) // 3% default interest
            {
                Type = AccountType.Savings;
                _interestRate = interestRate;
            }

            public override decimal CalculateInterest()
            {
                return Balance * _interestRate;
            }

            public void ApplyInterest()
            {
                Balance += CalculateInterest();
            }

            public override bool Withdraw(decimal amount)
            {
                // Savings account might have withdrawal limits
                if (amount > Balance * 0.8m) // Can't withdraw more than 80% at once
                {
                    return false;
                }
                return base.Withdraw(amount);
            }
        }

        public class BusinessAccount : Bank_Account
        {
            public string CompanyName { get; set; }
            public string TaxID { get; set; }

            public BusinessAccount()
            {
                Type = AccountType.Business;

            }

            public override void Deposit(decimal amount)
            {
                // Business accounts might have different deposit rules
                if (amount > 10000)
                {
                    // Maybe log large deposits for business accounts
                    LogLargeDeposit(amount);
                }
                base.Deposit(amount);
            }

            private void LogLargeDeposit(decimal amount)
            {
                // Implementation for logging large deposits
            }
        }
    }
}
