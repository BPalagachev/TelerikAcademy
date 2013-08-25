using System;
using System.Linq;
using EntityFrameworkHomework.Data;

namespace _03.CustomerMatch
{
    public class CustomerSearcher
    {
        public static void Main()
        {
            using (var dbContext = new NorthwindEntities())
            {
                var matchedCustomersInfo = MatchCustomerByOrderDetails(dbContext, 1997, "Canada");

                foreach (var details in matchedCustomersInfo.OrderBy(x => x.ContactName))
                {
                    string formaterdDate = details.OrderDate.Value.ToString("dd-MM-yyyy");
                    Console.WriteLine("{0} ordered {1} on {2} - {3}",
                        details.ContactName, details.ShipName, formaterdDate, details.ShipCountry);
                }
            }
        }

        public static IQueryable<CustomerAndOrderDetails> MatchCustomerByOrderDetails
            (NorthwindEntities dbContext, int year, string shipCountry)
        {
            var matched = dbContext.Orders.Include("Customers")
                .Where(x => x.OrderDate.Value.Year == year && x.ShipCountry == shipCountry)
                .Select((x) => new CustomerAndOrderDetails
                {
                    ContactName = x.Customer.ContactName,
                    ShipName = x.ShipName,
                    OrderDate = x.OrderDate,
                    ShipCountry = x.ShipCountry
                });

            return matched;
        }
    }

    public class CustomerAndOrderDetails
    {
        public string ContactName { get; set; }
        public string ShipName { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipCountry { get; set; }
    }
}
