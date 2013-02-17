using System;

class DevisionWithoutReminder
{
    static void Main()
    {
        int argument = int.Parse(Console.ReadLine()); 
        bool dividedWithoutReminder = ((argument % 7 == 0) && (argument % 5 == 0));
        Console.WriteLine("{0} is divided both by 5 and 7 without reminder! -> {1}", argument, dividedWithoutReminder);
    }
}
