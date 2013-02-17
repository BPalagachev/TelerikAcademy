// * Write a program that reads an array of integers and removes from it a minimal number of elements in
// such way that the remaining array is sorted in increasing order. Print the remaining sorted array. Example:
//	{6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}

using System;
using System.Collections.Generic;

class IncreasingSubsequence
{
    static void Main()
    {
        
        bool isFound = true;
        Console.Write("Input array size: ");
        int arraySize = int.Parse(Console.ReadLine());
        int[] arrayOfInts = new int[arraySize];
        List<int> longestSubsequence = new List<int>();
        Console.WriteLine("Input array elements: ");
        InputArray(arrayOfInts);


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
            for (int k = 0; k < subsetIndex.Count - 1; k++)
            {
                if (arrayOfInts[subsetIndex[k]] > arrayOfInts[subsetIndex[k + 1]])
                {
                    isFound = false;
                }
            }
            if (isFound == true && subsetIndex.Count > longestSubsequence.Count)
            {
                longestSubsequence.Clear();
                longestSubsequence = subsetIndex;
            }
            isFound = true;
            subsetSum = 0;
        }
        for (int i = 0; i < longestSubsequence.Count; i++)
        {
            Console.WriteLine("{0}    ", arrayOfInts[longestSubsequence[i]]);
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