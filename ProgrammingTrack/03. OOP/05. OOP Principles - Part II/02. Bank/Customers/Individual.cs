namespace _02.Bank.Customers
{
    public class Individual : Customer
    {
        public Individual()
            : base()
        {
            this.CustomerType  = CustomerType.Individual;
        }

        public override CustomerType CustomerType { get; protected set; }
    }
}
