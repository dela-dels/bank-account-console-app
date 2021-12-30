using System;

namespace BankAccountConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Kindly enter your name");
            // string clientName = Console.ReadLine();

            // Console.WriteLine("Enter your initial account balance.");
            // // We are using the Convert.ToDecimal here because the Console.ReadLine
            // // method only returns strings and hence, to use any other type, we will have to
            // // perform some casting
            // decimal initialAccountDeposit = Convert.ToDecimal(Console.ReadLine());

            //After taking the inputs from the user, we go ahead to create a new accoutn for them
            // by building a new BankAccount Object
            var account = new BankAccount("John Doe", 10000);
            Console.WriteLine($"Your Account with number {account.Number} was created with an initial balance of {account.Balance}");
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine($"Debit Transaction on {account.Number}");
            account.Withdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine($"Current Balance: {account.Balance}");
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine($"Credit Transaction on {account.Number}");
            account.Deposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine($"Current Balance: {account.Balance}");
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine($"Below is the Transaction History for {account.Number}");
            Console.WriteLine(account.TransactionHistory());

            var giftCard = new GiftCardAccount("Gift card", 100, 50);
            giftCard.Withdrawal(20, DateTime.Now, "Get expensive coffee");
            giftCard.Withdrawal(50, DateTime.Now, "Buy groceries");
            giftCard.PerformMonthEndTransactions();
            // can make additional deposits:
            giftCard.Deposit(27.50m, DateTime.Now, "Add some additional spending money");
            Console.WriteLine(giftCard.TransactionHistory());
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();

            var savings = new InterestEarningAccount("savings account", 10000);
            savings.Deposit(750, DateTime.Now, "save some money");
            savings.Deposit(1250, DateTime.Now, "Add more savings");
            savings.Withdrawal(250, DateTime.Now, "Needed to pay monthly bills");
            savings.PerformMonthEndTransactions();
            Console.WriteLine(savings.TransactionHistory());
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();

            var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
            // How much is too much to borrow?
            lineOfCredit.Withdrawal(1000m, DateTime.Now, "Take out monthly advance");
            lineOfCredit.Deposit(50m, DateTime.Now, "Pay back small amount");
            lineOfCredit.Withdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
            lineOfCredit.Deposit(150m, DateTime.Now, "Partial restoration on repairs");
            lineOfCredit.PerformMonthEndTransactions();
            Console.WriteLine(lineOfCredit.TransactionHistory());
        }
    }
}
