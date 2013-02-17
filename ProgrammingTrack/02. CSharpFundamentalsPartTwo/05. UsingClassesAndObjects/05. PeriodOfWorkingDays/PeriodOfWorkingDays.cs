// Write a method that calculates the number of workdays 
// between today and given date, passed as parameter. Consider
// that workdays are all days from Monday to Friday except a 
// fixed list of public holidays specified preliminary as array.

using System;

class PeriodOfWorkingDays
{
    static void Main()
    {
        DateTime[] holidays = { new DateTime(2012, 12, 24), new DateTime(2012, 12, 25), new DateTime(2012, 12, 31), new DateTime(2013, 01, 01) };
        DateTime start = new DateTime(2012, 12, 21);
        DateTime end = new DateTime(2013, 1, 10);

        bool itsWorkingDay = true;
        int counter = 0;
        while (start<end)
        {
            if (start.DayOfWeek == DayOfWeek.Saturday || start.DayOfWeek == DayOfWeek.Sunday)
            {
                itsWorkingDay = false;
            }
            for (int i = 0; i < holidays.Length; i++)
            {
                if (start == holidays[i])
                {
                    itsWorkingDay = false;
                }
            }
            if (itsWorkingDay)
            {
                counter++;
            }
            itsWorkingDay = true;
            start = start.AddDays(1);
        }
        Console.WriteLine("There are {0} working days!", counter);
    }
}