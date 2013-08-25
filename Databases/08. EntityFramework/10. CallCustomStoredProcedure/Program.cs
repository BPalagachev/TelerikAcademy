using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkHomework.Data;

namespace _10.CallCustomStoredProcedure
{
    class Program
    {
        static void Main()
        {
            var dbContext = new NorthwindEntities();
            using (dbContext)
            {
                string suplierName = "Charlotte Cooper";
                var profits = CalculateProfits(dbContext, suplierName);
                Console.WriteLine("Profits for suplier {0} are {1} price units",suplierName, profits );
            }
        }

        private static decimal CalculateProfits(NorthwindEntities dbContext, string suplierName)
        {
            var profits = dbContext.usp_CalculateProfits(suplierName);
            return profits.First().Value;
        }
    }
}
