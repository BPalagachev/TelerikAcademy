// Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

using System;

class IsLeap
{
    static void Main()
    {
        Console.Write("Year: ");
        int year = int.Parse(Console.ReadLine());
        DateTime checkYear = new DateTime(year, 1, 1);
        Console.WriteLine("Year {0} is a leap year? - {1}", checkYear.Year, DateTime.IsLeapYear(checkYear.Year));
    }
}
