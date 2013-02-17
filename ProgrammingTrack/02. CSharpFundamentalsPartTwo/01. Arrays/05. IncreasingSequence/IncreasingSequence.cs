// Write a program that finds the maximal increasing 
// sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.

using System;

class IncreasingSequence
{
    static void Main()
    {
        Console.Write("Choose the length of the array: ");
        int arraySize = int.Parse(Console.ReadLine());
        int[] numbers = new int[arraySize];
        int counter = 1;
        int maxLength = 0;
        int startingIndex = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("numbers[{0}] = ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i - 1] < numbers[i])
            {
                counter++;
            }
            else
            {
                if (counter > maxLength)
                {
                    maxLength = counter;
                    startingIndex = i - maxLength;
                }
                counter = 1;
            }
        }
        if (counter > maxLength)
        {
            maxLength = counter;
            startingIndex = numbers.Length - maxLength;
        }

        Console.WriteLine("The maximal increasing sequence in the array starts at position {0} and has lenght of {1} elements", startingIndex, maxLength);
        for (int i = startingIndex; i < startingIndex + maxLength; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }
        Console.WriteLine();
    }
}