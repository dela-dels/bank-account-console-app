using System;

namespace BankAccountConsole
{
    public class InterestEarningAccount : BankAccount
    {
        //Since the InterestEarningAccount extends the base BankAccount Class
        //a constructor must be initialised 
        public InterestEarningAccount(string name, decimal initialDeposit) : base(name, initialDeposit)
        { }

        public override void PerformMonthEndTransactions()
        {
            //In C# the suffix m means decimal. The m suffix is used instead of d becuase d represents double.
            if (Balance > 500m)
            {
                var interest = Balance * 0.05m;
                Deposit(interest, DateTime.Now, "End of Month Interest");
            }
        }
    }
}