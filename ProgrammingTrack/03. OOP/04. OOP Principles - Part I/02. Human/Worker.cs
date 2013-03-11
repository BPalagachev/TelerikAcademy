using System;

namespace _02.Human
{
    public class Worker : Human, IWorker
    {
        public Worker(string aFirstName, string aLastName, uint aWeekSelary, uint aWorkHoursPerDay)
            : base(aFirstName, aLastName)
        {
            this.WeekSelary = aWeekSelary;
            this.WorkHoursPerDay = aWorkHoursPerDay;
        }

        public uint WeekSelary { get; set; }

        public uint WorkHoursPerDay { get; set; }

        public double MoneyPerHour()
        {
            return this.WeekSelary / (this.WorkHoursPerDay * 5.0d);
        }
    }
}
