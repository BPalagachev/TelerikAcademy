using System;

namespace _02.Human
{
    public interface IWorker
    {
        uint WeekSelary { get; set; }

        uint WorkHoursPerDay { get; set; }

        double MoneyPerHour();
    }
}
