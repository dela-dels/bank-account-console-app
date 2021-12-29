using System;
using System.Collections.Generic;

namespace BankAccountConsole
{
    public class BankAccount
    {
        private static int accountNumberSeeder = 0100000001;

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

        public BankAccount(string name, decimal initialDeposit)
        {
            this.Owner = name;
            Deposit(initialDeposit, DateTime.Now, "Initial Deposit");
            this.Number = accountNumberSeeder.ToString();
            accountNumberSeeder++;
        }

        private List<Transaction> transactions = new List<Transaction>();

        public void Deposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
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
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive");
            }

            if ((Balance - amount) < 0)
            {
                throw new InvalidOperationException("Insufficient funds for this withdrawal");
            }

            var withdrawal = new Transaction(-amount, date, note);
            transactions.Add(withdrawal);
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