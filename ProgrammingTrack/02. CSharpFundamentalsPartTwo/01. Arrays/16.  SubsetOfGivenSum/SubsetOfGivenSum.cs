// * We are given an array of integers and a number S. Write a program to find 
// if there exists a subset of the elements of the array that has a sum S. Example:
//	arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)

using System;
using System.Collections.Generic;

class SubsetOfGivenSum
{
    static void Main()
    {
        Console.Write("Sum to look for: ");
        int sumToLookFor = int.Parse(Console.ReadLine());
        Console.Write("Input array size: ");
        int arraySize = int.Parse(Console.ReadLine());
        int[] arrayOfInts = new int[arraySize];
        Console.WriteLine("Input array elements: ");
        InputArray(arrayOfInts);

        Console.WriteLine("List of all the sumsets with sum of {0}", sumToLookFor);
        for (int i = 1; i < 1<<arraySize; i++)
        {
            List<int> subsetIndex = new List<int>();
            int subsetSum = 0;
            for (int j = 0; j < arrayOfInts.Length; j++)
            {
                if ((i & (1 << j)) != 0)
                {
                    subsetSum += arrayOfInts[j];
                    subsetIndex.Add(j);
                }
            }
            if (subsetSum == sumToLookFor)
            {
                for (int k = 0; k < subsetIndex.Count; k++)
                {
                    Console.Write("{0} ", arrayOfInts[subsetIndex[k]]);
                }
                Console.WriteLine();
            }
            subsetSum = 0;
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

