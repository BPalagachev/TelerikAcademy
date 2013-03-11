namespace _02.Bank.Customers
{
    public class Company : Customer
    {
        public Company() : base()
        {
            this.CustomerType = CustomerType.Company;
        }

        public override CustomerType CustomerType { get; protected set; }
    }
}
