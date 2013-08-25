// Using Entity Framework write a query that selects all employees from the Telerik Academy database,
// then invokes ToList(), then selects their addresses, then invokes ToList(), then selects their towns,
// then invokes ToList() and finally checks whether the town is "Sofia". Rewrite the same in more 
// optimized way and compare the performance.

namespace _02.ExploreExtensiveToListUse
{
    using System;
    using System.Linq;
    using PerformanceHomework.Data;

    public class ToListTest
    {
        static void Main(string[] args)
        {
            var dbContext = new TelerikAcademyEntities();
            using (dbContext)
            {
                var slowQuery = dbContext.Employees.ToList()
                    .Select(x => x.Address).ToList();

                foreach (var item in slowQuery)
                {
                    Console.WriteLine(item.AddressText);
                }

                //var optimizedQuery = (
                //    from emp in dbContext.Employees
                //    select emp.Address
                //    ).ToList();

                //foreach (var item in optimizedQuery)
                //{
                //    Console.WriteLine(item.AddressText);
                //}
            }
        }
    }
}
