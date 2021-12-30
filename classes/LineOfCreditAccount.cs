using System;

namespace BankAccountConsole
{
    public class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialDeposit, decimal creditLimit) : base(name, initialDeposit, -creditLimit) { }

        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                // Negate the balance to get a positive interest charge:
                var interest = -Balance * 0.07m;
                Withdrawal(interest, DateTime.Now, "Charge monthly interest");
            }
        }
    }
}