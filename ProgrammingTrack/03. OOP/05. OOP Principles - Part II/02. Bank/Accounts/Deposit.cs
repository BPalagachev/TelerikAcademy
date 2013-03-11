using System;
using _02.Bank.Customers;

namespace _02.Bank.Accounts
{
    public class Deposit : Account, IDepositable, IWithdrawable
    {
        public Deposit(Customer aCustomer, decimal aBalance, decimal aInterestRate)
            : base(aCustomer, aBalance, aInterestRate)
        {
        }

        public void DepositAmount(decimal amount)
        {
            if (amount < 0m)
            {
                throw new ArgumentOutOfRangeException("Cannot deposit negative amount!");
            }

            this.Balance += amount;
        }

        public void WithdrawAmount(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new ArgumentOutOfRangeException("Cannot withdraw more money then avaiable amount!");
            }

            this.Balance -= amount;
        }

        public override decimal CalculateInterest(int numberOfMonths)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }
            else
            {
                return base.CalculateInterest(numberOfMonths);
            }
        }
    }
}
