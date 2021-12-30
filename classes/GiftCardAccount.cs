using System;

namespace BankAccountConsole
{
    public class GiftCardAccount : BankAccount
    {
        private decimal _monthlyDeposit = 0m;

        public GiftCardAccount(string name, decimal initialDeposit, decimal monthlyDeposit = 0)
        : base(name, initialDeposit) => _monthlyDeposit = monthlyDeposit;

        public override void PerformMonthEndTransactions()
        {
            if (_monthlyDeposit != 0)
            {
                Deposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
            }
        }
    }
}