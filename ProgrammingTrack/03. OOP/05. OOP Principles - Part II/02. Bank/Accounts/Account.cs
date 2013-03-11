using _02.Bank.Customers;

namespace _02.Bank.Accounts
{
    public abstract class Account : IInterest
    {
        public Account(Customer aCustomer, decimal aBalance, decimal aInterestRate)
        {
            this.Customer = aCustomer;
            this.Balance = aBalance;
            this.InterestRate = aInterestRate;
        }

        public Customer Customer { get; protected set; }

        public decimal Balance { get; protected set; }

        public decimal InterestRate { get; protected set; }

        public virtual decimal CalculateInterest(int numberOfMonths)
        {
            return numberOfMonths * this.InterestRate;
        }
    }
}
