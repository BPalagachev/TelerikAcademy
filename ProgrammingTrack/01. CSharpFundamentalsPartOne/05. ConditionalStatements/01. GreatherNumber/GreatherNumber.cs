using System;

class GreatherNumber
{
    static void Main()
    {
        Console.WriteLine("Write two integer values:");
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int tempSwap = 0;
        if (firstNumber > secondNumber)
        {
            tempSwap = firstNumber;
            firstNumber = secondNumber;
            secondNumber = tempSwap;
        }
        Console.WriteLine("First Nubers is: {0}; Second Number is {1}.", firstNumber, secondNumber);
    }
}