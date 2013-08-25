using System;
using System.Linq;
using EntityFrameworkHomework.Data;

namespace _08.EmplyeeExtention
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new NorthwindEntities();
            //dbContext.Employees.First().Territories
        }
    }

    public class SpecialEmplyee : Employee
    {

    }
}
