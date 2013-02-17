// Write a program that reads a date and time given in the format: day.month.year hour:minute:second 
// and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day
// of week in Bulgarian.

using System;
using System.Globalization;


class SixHoursLater
{
    static void Main()
    {

        string dateStr = "10.10.2010 15:15:15";
        //DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy HH:mm:ss", CultureInfo.InstalledUICulture);
        DateTime date = DateTime.ParseExact(dateStr, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        date = date.AddHours(6.5);
        Console.WriteLine("{0} {1}",date, date.ToString("dddd",new CultureInfo("bg-BG")) );
    }
}