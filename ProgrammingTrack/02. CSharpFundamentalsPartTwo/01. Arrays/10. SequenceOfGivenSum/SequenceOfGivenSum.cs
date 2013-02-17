// Write a program that finds in given array of integers a sequence of given sum S (if present).
// Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}
using System;

class SequenceOfGivenSum
{
    static void Main()
    {
        Console.Write("Sum: ");
        int sumToFind = int.Parse(Console.ReadLine());
        Console.Write("Write array size: ");
        int arraySize = int.Parse(Console.ReadLine());
        int[] arrayToCheck = new int[arraySize];
        InputArray(arrayToCheck);
        int sum = 0;
        for (int sumSize = arrayToCheck.Length; sumSize >= 0; sumSize--)
        {
            for (int i = 0; i <= arrayToCheck.Length - sumSize; i++)
            {
                for (int j = 0; j < sumSize; j++)
                {
                    sum += arrayToCheck[i + j];
                    if (sum == sumToFind)
                    {
                        Console.WriteLine(i);
                        Console.WriteLine("Found");
                        return;
                    }
                }
                sum = 0;
            }
        }
    }

    static void InputArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Element:{0} = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
    }
}