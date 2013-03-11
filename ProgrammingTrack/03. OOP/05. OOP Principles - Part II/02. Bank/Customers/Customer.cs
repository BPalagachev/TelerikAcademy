namespace _02.Bank.Customers
{
    public abstract class Customer
    {
        public abstract CustomerType CustomerType { get; protected set; }
    }
}
