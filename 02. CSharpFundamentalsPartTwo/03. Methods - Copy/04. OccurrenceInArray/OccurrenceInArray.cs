// Write a method that counts how many times given number appears in given array.
// Write a test program to check if the method is working correctly.

using System;

class OccurrenceInArray
{
    static void Main()
    {
        Console.WriteLine("Array size: ");
        int arraySize = int.Parse(Console.ReadLine());
        int[] array = new int[arraySize];
        InputArray(array);
        Console.Write("Choose value of count: ");
        int value = int.Parse(Console.ReadLine());
        Console.WriteLine("There are {0} occurrences of {1} in the array", CountElemetsOfValue(array, value), value);

    }
    static void InputArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Element[{0}] =  ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
    }
    static int CountElemetsOfValue(int[] array, int value)
    {
        int counter = 0;
        foreach (var item in array)
        {
            if (item == value)
            {
                counter++;
            }
        }
        return counter;
    }
}