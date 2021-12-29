﻿using System;

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
        }
    }
}
