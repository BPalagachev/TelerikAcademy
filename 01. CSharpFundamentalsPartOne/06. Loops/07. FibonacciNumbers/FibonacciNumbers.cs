using System;

class FibonacciNumbers
{
    static void Main()
    {
        int previousNumber = 0;
        int currentNumber = 1;
        int sumOfFirstNNumbers = previousNumber + currentNumber;
        int tempNumber;
        int N = int.Parse(Console.ReadLine());

        for (int i = 2; i <N ; i++)
        {
            tempNumber = previousNumber + currentNumber;
            previousNumber = currentNumber;
            currentNumber = tempNumber;
            sumOfFirstNNumbers += currentNumber;
        }
        Console.WriteLine("the sum of the first {0} of the Fibonacci sequence is: {1}", N, sumOfFirstNNumbers);
    }
}