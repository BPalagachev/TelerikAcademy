using System;
using System.Linq;
using EntityFrameworkHomework.Data;

namespace _07.ConcurencyConflict
{
    public class ContextConflicter
    {
        static void Main()
        {
            var firstDbContext = new NorthwindEntities();
            var secondDbContext = new NorthwindEntities();

            using (firstDbContext)
            {
                using (secondDbContext)
                {
                    var firstEmplyeeId1 = firstDbContext.Employees.Where(x => x.EmployeeID == 1).First();
                    var secondEmplyeeId1 = secondDbContext.Employees.Where(x => x.EmployeeID == 1).First();

                    firstEmplyeeId1.TitleOfCourtesy = "Gospoica";
                    secondEmplyeeId1.TitleOfCourtesy = "Mistar";

                    firstDbContext.SaveChanges();
                    secondDbContext.SaveChanges();
                }
            }
        }
    }
}
