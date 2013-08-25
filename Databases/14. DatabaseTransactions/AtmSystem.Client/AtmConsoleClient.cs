namespace AtmSystem.Client
{
    using System;
    using System.Linq;
    using System.Transactions;
    using System.Threading;
    using AtmSystem.Data;

    public class AtmConsoleClient
    {
        static string fails = "n";
        static void Main()
        {
            Console.Write("Fail (y/n)");
            fails = Console.ReadLine();
            string accountNumber = "0123456789";
            string accountPin = "1234";
            decimal ammount = 200;

            using (var atmContext = new AtmSystemEntities())
            {
                WithdrowMoney(accountNumber, accountPin, ammount);
                var currentAccountInfo = GetAccountInformation(accountNumber, accountPin);
                Console.WriteLine("{0}: {1} - {2}, Balance: {3}",
                    currentAccountInfo.Id,
                    currentAccountInfo.CardNumber,
                    currentAccountInfo.CardPIN, 
                    currentAccountInfo.CardCash);
            }
        }

        public static void WithdrowMoney(string accountNumber, string pin, decimal amount)
        {
            using (var atmContext = new AtmSystemEntities())
            {
                using (var ts = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions()
                    { 
                        IsolationLevel= IsolationLevel.RepeatableRead
                    }
                    ))
                {
                    var cardAccount = GetValidAccount(accountNumber, pin, amount);
                    atmContext.CardAccounts.Attach(cardAccount);
                    var oldAmount = cardAccount.CardCash;
                    Console.ReadLine();
                    var currentAccountInfo = GetAccountInformation(accountNumber, pin);
                    Console.WriteLine("{0}: {1} - {2}, Balance: {3}",
                        currentAccountInfo.Id,
                        currentAccountInfo.CardNumber,
                        currentAccountInfo.CardPIN,
                        currentAccountInfo.CardCash);
                    var newAmount = oldAmount - amount;
                    cardAccount.CardCash = newAmount;
                    LogTransaction(cardAccount.Id, oldAmount, newAmount.Value);
                    atmContext.SaveChanges();
                    AtmMachineWithdrowMoneyMechanics(amount);
                    ts.Complete();
                }
            }
        }

        private static CardAccount GetValidAccount(string accountNumber, string pin, decimal amount)
        {
            using (var context = new AtmSystemEntities())
            {
                using (var ts = new TransactionScope())
                {
                    var matched = context.CardAccounts.Where(x =>
                        (x.CardNumber == accountNumber
                        && x.CardPIN == pin));
                    if (matched.Count() != 1)
                    {
                        throw new ArgumentException("Account validation failed!");
                    }

                    if (matched.First().CardCash - amount < 0)
                    {
                        throw new InvalidOperationException("Insufficient funds!");
                    }

                    var validAcc = matched.First();
                    ts.Complete();
                    return validAcc;
                }
            }

        }

        private static void AtmMachineWithdrowMoneyMechanics(decimal ammount)
        {

            decimal amountInAtmMachine = 10000;
            using (var ts = new TransactionScope())
            {
                if (amountInAtmMachine - ammount < 0 || fails != "n")
                {
                    throw new InvalidOperationException("There is not enough money in the Atm Machine.");
                }

                // Thread.Sleep(10000);
                Console.WriteLine("You have withdrawn the ammount of {0} price units", ammount);
                amountInAtmMachine -= ammount;

                ts.Complete();
            }
        }

        private static CardAccount GetAccountInformation(string accountNumber, string pin)
        {
            var dbContext = new AtmSystemEntities();

            using (var context = new AtmSystemEntities())
            {
                using (var ts = new TransactionScope())
                {
                    var matched = context.CardAccounts.Where(x =>
                        (x.CardNumber == accountNumber
                        && x.CardPIN == pin));
                    if (matched.Count() != 1)
                    {
                        throw new ArgumentException("Account validation failed!");
                    }

                    var validAcc = matched.First();
                    ts.Complete();
                    return validAcc;
                }
            }
        }

        private static void LogTransaction(int cardId, decimal? oldAmount, decimal newAmount)
        {
            using (var context = new AtmSystemEntities())
            {
                using (var ts = new TransactionScope())
                {
                    var newLog = new Log()
                    {
                        CardId = cardId,
                        OldAmount = oldAmount,
                        NewAmount = newAmount,
                    };

                    context.Logs.Add(newLog);
                    context.SaveChanges();
                    
                    ts.Complete();
                }
            }
        }
    }
}
