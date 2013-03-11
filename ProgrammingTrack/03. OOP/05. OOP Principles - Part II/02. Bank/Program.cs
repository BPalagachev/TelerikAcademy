using System;
using _02.Bank.Accounts;
using _02.Bank.Customers;

namespace _02.Bank
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Account individualAccount = new Loan(new Individual(), 100, 10);
            Console.WriteLine(individualAccount.CalculateInterest(1));

            Account morgage = new Morgage(new Company(), 1000, 10);
            Console.WriteLine(morgage.CalculateInterest(6));

            Deposit deposit = new Deposit(new Individual(), 10, 10);

            deposit.DepositAmount(3000);
            Console.WriteLine(deposit.Balance);

            deposit.WithdrawAmount(750);
            Console.WriteLine(deposit.Balance);

            Console.WriteLine(deposit.CalculateInterest(12));
        }
    }
}
