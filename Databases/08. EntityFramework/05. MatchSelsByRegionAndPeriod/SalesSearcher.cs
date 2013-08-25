using System;
using System.Linq;
using EntityFrameworkHomework.Data;


namespace _05.MatchSelsByRegionAndPeriod
{
    public class SalesSearcher
    {
        public static void Main()
        {
            var northwindEntities = new NorthwindEntities();
            var startDate = new DateTime(1997, 5, 3);
            var endDate = new DateTime(1998, 5, 3);
            string region = "NM";
            using (northwindEntities)
            {
                var matched = northwindEntities.Orders
                    .Where(x => x.ShipRegion == region && x.OrderDate >= startDate && x.OrderDate <= endDate)
                    .Select(x=> new{
                        ShipName = x.ShipName,
                        OrderDate = x.OrderDate
                    });

                foreach (var sale in matched)
                {
                    Console.WriteLine("Name: {0}, OrderDate: {1}", sale.ShipName, sale.OrderDate);
                }
                    

            }
        }
    }


}
