#nullable enable
using System;
using System.Collections.Generic;

namespace BankAccountConsole
{
    public class BankAccount
    {
        private static int accountNumberSeeder = 0100000001;

        private readonly decimal minimumBalance;

        //This property is a getter to compute the total balance of a bank account
        public decimal Balance
        {
            get
            {
                decimal balance = 0;

                foreach (var item in transactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        public string Owner { get; }

        public string Number { get; }

        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

        public BankAccount(string name, decimal initialDeposit, decimal minimumBalance)
        {
            this.Owner = name;
            this.Number = accountNumberSeeder.ToString();
            accountNumberSeeder++;
            this.minimumBalance = minimumBalance;

            if (initialDeposit > 0)
            {
                Deposit(initialDeposit, DateTime.Now, "Initial Balance");
            }
        }

        //A virtual method is a method where any derived class may choose to reimplement. 
        //The derived classes use the override keyword to define the new implementation.
        public virtual void PerformMonthEndTransactions() { }

        private List<Transaction> transactions = new List<Transaction>();

        public void Deposit(decimal amount, DateTime date, string note)
        {
            if (amount <= minimumBalance)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }

            var deposit = new Transaction(amount, date, note);
            transactions.Add(deposit);
        }

        public void Withdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            var overdraftTransaction = CheckWithdrawalLimit((Balance - amount) < minimumBalance);
            var withdrawal = new Transaction(-amount, date, note);
            transactions.Add(withdrawal);

            if (overdraftTransaction != null)
            {
                transactions.Add(overdraftTransaction);
            }

        }

        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            else
            {
                return default;
            }
        }

        public string TransactionHistory()
        {
            var report = new System.Text.StringBuilder();
            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");

            foreach (var item in transactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }
            return report.ToString();
        }
    }
}