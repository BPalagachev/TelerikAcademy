// * Write a program that reads three integer numbers N, K and S and an 
//array of N elements from the console. Find in the array a subset of
// K elements that have sum S or indicate about its absence
using System;
using System.Collections.Generic;

class SubsetOfGivenLength
{
    static void Main()
    {
        Console.Write("Length of the subset: ");
        int subsetLength = int.Parse(Console.ReadLine());
        Console.Write("Sum of the subset: ");
        int sumToLookFor = int.Parse(Console.ReadLine());
        bool isFound = false;
        Console.Write("Input array size: ");
        int arraySize = int.Parse(Console.ReadLine());
        int[] arrayOfInts = new int[arraySize];
        Console.WriteLine("Input array elements: ");
        InputArray(arrayOfInts);

        Console.WriteLine("List of all the sumsets with sum of {0}", sumToLookFor);
        for (int i = 1; i < 1 << arraySize; i++)
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
            if (subsetSum == sumToLookFor && subsetIndex.Count == subsetLength)
            {
                for (int k = 0; k < subsetIndex.Count; k++)
                {
                    Console.Write("{0} ", arrayOfInts[subsetIndex[k]]);
                }
                Console.WriteLine();
                isFound = true;
            }
            subsetSum = 0;
        }
        if (isFound==false)
        {
            Console.WriteLine("There is NO match!");
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