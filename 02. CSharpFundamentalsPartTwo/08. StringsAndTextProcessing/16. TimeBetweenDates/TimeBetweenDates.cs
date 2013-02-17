// Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.

using System;

class TimeBetweenDates
{
    static void Main()
    {
        Console.WriteLine("Enter first date (dd.mm.yyyy):");
        DateTime firstDate = ParseDateTime(Console.ReadLine());
        Console.WriteLine("Enter second date (dd.mm.yyyy):");
        DateTime secondDate = ParseDateTime(Console.ReadLine());
        TimeSpan result = firstDate - secondDate;
        Console.WriteLine(Math.Abs(result.Days));

    }
    static DateTime ParseDateTime(string dateStr)
    {
        string[] components = dateStr.Split('.');
        int day = int.Parse(components[0]);
        int month = int.Parse(components[1]);
        int year = int.Parse(components[2]);
        DateTime date = new DateTime(1000,month, day);
        return date;
    }
}