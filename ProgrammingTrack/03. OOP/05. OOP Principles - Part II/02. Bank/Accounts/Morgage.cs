using System;
using _02.Bank.Customers;

namespace _02.Bank.Accounts
{
    public class Morgage : Account, IDepositable
    {
        public Morgage(Customer aCustomer, decimal aBalance, decimal aInterestRate)
            : base(aCustomer, aBalance, aInterestRate)
        {
        }

        public override decimal CalculateInterest(int numberOfMonths)
        {
            switch (this.Customer.CustomerType)
            {
                case CustomerType.Individual:
                    if (numberOfMonths <= 12)
                    {
                        return base.CalculateInterest(numberOfMonths / 2);
                    }
                    else
                    {
                        return base.CalculateInterest(numberOfMonths);
                    }

                    break;
                case CustomerType.Company:
                    if (numberOfMonths <= 6)
                    {
                        return 0m;
                    }
                    else
                    {
                        return base.CalculateInterest(numberOfMonths);
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException("It is not clear how to calculate interest for this type of cutomers!");
                    break;
            }
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
