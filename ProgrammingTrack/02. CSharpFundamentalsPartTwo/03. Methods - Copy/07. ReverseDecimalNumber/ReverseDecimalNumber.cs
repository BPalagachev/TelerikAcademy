// Write a method that reverses the digits of given decimal number. Example: 256  652

using System;

class ReverseDecimalNumber
{
    static void Main()
    {
        Console.Write("Number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Reversed number: {0}", ReverseDigits(number));
    }
    static int ReverseDigits(int number)
    {
        int newNumber = 0;
        while (number > 0)
        {
            newNumber *= 10;
            newNumber += number % 10;
            number /= 10;
        }
        return newNumber;
    }
}