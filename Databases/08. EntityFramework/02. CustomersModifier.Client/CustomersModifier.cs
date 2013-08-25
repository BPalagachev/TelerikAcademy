// Create a DAO class with static methods which provide functionality for inserting,
// modifying and deleting customers. Write a testing class
using System;
using System.Linq;
using EntityFrameworkHomework.Data;


namespace _02.CustomersModifier.Client
{
    public class CustomersModifier
    {
        public static void Main()
        {
            Customer newCustomer = new Customer()
            {
                CustomerID = "SPIRO",
                CompanyName = "Pavilion za semki",
                ContactName = "Spiro Spirta",
                ContactTitle = "Top Sellsman",
                Address = "ot Lulina",
                City = "Lulin X",
                PostalCode = "1000",
                Country ="Lulin",
                Phone = "123 Spiro",
                Fax = "123 SpirO"
            };

            using (var dbContext = new NorthwindEntities())
            {
                InserCustomer(dbContext, newCustomer);
                SaveChanges(dbContext);

                UpdateCustomersName<string>(dbContext, x => x.CustomerID == "SPIRO",
                    (x, y) => x.ContactName = y,
                    "Spirooooo");
                SaveChanges(dbContext);

                var toBeDeleted = dbContext.Customers.Where(x => x.CustomerID == "SPIRO").First();
                DeleteCustomer(dbContext, toBeDeleted);
                
                SaveChanges(dbContext);
            }
        }

        public static void InserCustomer(NorthwindEntities dbContext, Customer newCustomer)
        {
            dbContext.Customers.Add(newCustomer);
        }

        public static void DeleteCustomer(NorthwindEntities dbContext, Customer toBeDeleted)
        {
            dbContext.Customers.Remove(toBeDeleted);
        }

        public static void UpdateCustomersName<T>(NorthwindEntities dbContext, 
            Func<Customer, bool> selector, 
            Action<Customer, T> properyUpdater,
            T newValue)
        {
            var customers = dbContext.Customers.Where(selector);
            foreach (var customer in customers)
            {
                properyUpdater(customer, newValue);
            }
        }


        public static void SaveChanges(NorthwindEntities dbContext)
        {
            dbContext.SaveChanges();
        }
    }

}
