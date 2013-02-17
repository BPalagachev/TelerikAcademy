// Write a program that reads two arrays from
// the console and compares them element by element.

using System;

class CompareArrays
{
    static void Main()
    {
        Console.Write("Array Size: ");
        int arraySize = int.Parse(Console.ReadLine());
        int[] arrayOne = new int[arraySize];
        int[] arrayTwo = new int[arraySize];
        bool areEqual = true;

        for (int i = 0; i < arraySize; i++)
        {
            Console.Write("ArrayOne[{0}] = ", i);
            arrayOne[i] = int.Parse(Console.ReadLine());
            Console.Write("ArrayTwo[{0}] = ", i);
            arrayTwo[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < arraySize; i++)
        {
            if (arrayOne[i] != arrayTwo[i])
            {
                areEqual = false;
            }
        }

        Console.WriteLine("Arrays are equal: {0}", areEqual);
    }
}