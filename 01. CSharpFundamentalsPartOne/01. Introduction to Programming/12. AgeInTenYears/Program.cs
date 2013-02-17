using System;

class Program
{
    static void Main()
    {
        int age = int.Parse(Console.ReadLine());
        DateTime years = new DateTime(age, 1, 1);
        years = years.AddYears(10);
        Console.WriteLine("You will be {0} years old in ten years.", years.Year);
    }
}