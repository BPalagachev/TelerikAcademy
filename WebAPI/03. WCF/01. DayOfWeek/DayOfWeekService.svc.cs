using System;

namespace _01.DayOfWeek
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DayOfWeekService : IDayOfWeekService
    {
        public string ToWeekDay(DateTime date)
        {
            var dayOfWeek = date.DayOfWeek;
            switch (dayOfWeek)
            {
                case System.DayOfWeek.Monday:
                    return ("Понеделник");
                case System.DayOfWeek.Tuesday:
                    return ("Вторник");
                case System.DayOfWeek.Wednesday:
                    return ("Сряда");
                case System.DayOfWeek.Thursday:
                    return ("Четвъртък");
                case System.DayOfWeek.Friday:
                    return ("Петък");
                case System.DayOfWeek.Saturday:
                    return ("Събота");
                case System.DayOfWeek.Sunday:
                    return ("Неделя");
                default:
                    throw new ArgumentException("Пратееел! Стана тя, каквато стана.");
            }
        }
    }
}
