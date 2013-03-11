using System;
using _02.Bank.Customers;

namespace _02.Bank.Accounts
{
    public class Loan : Account, IDepositable
    {
        public Loan(Customer aCustomer, decimal aBalance, decimal aInterestRate) : base(aCustomer, aBalance, aInterestRate)
        {
        }

        public override decimal CalculateInterest(int numberOfMonths)
        {
            switch (this.Customer.CustomerType)
            {
                case CustomerType.Individual:
                    numberOfMonths = numberOfMonths - 3 >= 0 ? numberOfMonths - 3 : 0;
                    break;
                case CustomerType.Company:
                    numberOfMonths = numberOfMonths - 2 >= 0 ? numberOfMonths - 2 : 0;
                    break;
                default:
                    break;
            }

            return base.CalculateInterest(numberOfMonths);
        }

        public void DepositAmount(decimal amount)
        {
            if (amount < 0m)
            {
                throw new ArgumentOutOfRangeException("Cannot deposit negative amount!");
            }

            this.Balance += amount;
        }
    }
}
