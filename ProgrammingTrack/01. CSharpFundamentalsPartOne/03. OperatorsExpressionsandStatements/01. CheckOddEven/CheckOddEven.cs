using System;

class CheckOddEven
{
    static void Main()
    {
        int argument = int.Parse(Console.ReadLine());
        bool isEven = (argument % 2 == 0);
        Console.WriteLine("{0} is an even number! -> {1}", argument, isEven);
    }
}