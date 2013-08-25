using System;
using System.Linq;
using EntityFrameworkHomework.Data;
using System.Data.Objects;

namespace _04.CustomerMatchNaviteQuery
{
    public class CustomerSearcher
    {
        public static void Main()
        {
            NorthwindEntities dbContext = new NorthwindEntities();

            using (dbContext)
            {
                string nativeQuery = @"SELECT c.ContactName, o.OrderDate, o.ShipName, o.ShipCountry
                                       FROM Orders o
                                       JOIN Customers c
                                       ON o.CustomerID = c.CustomerID
                                       WHERE year(o.OrderDate) = 1997 AND o.ShipCountry = 'Canada'
                                       ORDER BY c.ContactName";

                var a = dbContext.Database.SqlQuery<CustimersAndOrderInformation>(nativeQuery);

                foreach (var item in a)
                {
                    string formaterdDate = item.OrderDate.ToString("dd-MM-yyyy");
                    Console.WriteLine("{0} ordered {1} on {2} - {3}", item.ContactName, item.ShipName, formaterdDate, item.ShipCountry);
                }
            }
        }
    }

    public class CustimersAndOrderInformation
    {
        public string ContactName { get; set; }

        public DateTime OrderDate { get; set; }

        public string ShipName { get; set; }

        public string ShipCountry { get; set; }
    }

    
}
