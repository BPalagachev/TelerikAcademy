using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.DayOfWeekConsoleClient.TestDayOfWeekService;

namespace _02.DayOfWeekConsoleClient
{
    public class DayOfWeekConsoleClient
    {
        public static void Main()
        {
            DayOfWeekServiceClient client = new DayOfWeekServiceClient();
            var today = DateTime.Now;
            var weekDay = client.ToWeekDay(today);
            Console.WriteLine(weekDay);
        }
    }
}
