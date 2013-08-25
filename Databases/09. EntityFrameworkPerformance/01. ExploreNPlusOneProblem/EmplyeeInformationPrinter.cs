// Using Entity Framework write a SQL query to select all employees from the Telerik Academy 
// database and later print their name, department and town. Try the both variants: with and 
// without .Include(…). Compare the number of executed SQL statements and the performance.

namespace _01.ExploreNPlusOneProblem
{
    using System;
    using System.Linq;
    using PerformanceHomework.Data;

    public class EmplyeeInformationPrinter
    {
        public static void Main(string[] args)
        {
            var dbContext = new TelerikAcademyEntities();
            using (dbContext)
            {
                //PrintWithoutInclude(dbContext);
                PrintWithInclude(dbContext);
            }
        }

        public static void PrintWithoutInclude(TelerikAcademyEntities dbContext)
        {
            var emplyees = dbContext.Employees;

            foreach (var employee in emplyees)
            {
                Console.WriteLine("{0} From {1} - {2}",
                    employee.FirstName + employee.LastName,
                    employee.Address.Town.Name,
                    employee.Department.Name);
            }
        }

        public static void PrintWithInclude(TelerikAcademyEntities dbContext)
        {
            foreach (var employee in dbContext.Employees
                .Include("Department")
                .Include("Address.Town"))
            {
                Console.WriteLine("{0} From {1} - {2}",
                    employee.FirstName + employee.LastName,
                    employee.Address.Town.Name,
                    employee.Department.Name);
            }
        }

    }
}
