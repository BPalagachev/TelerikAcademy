// Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. Example:
//	N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}

using System;
using System.Collections.Generic;

class Variations
{
    static void Main()
    {
        Console.Write("Variations of K elements. K:  ");
        int subsetLength = int.Parse(Console.ReadLine());
        Console.Write("Input array size: ");
        int arraySize = int.Parse(Console.ReadLine());
        List<int> arrayOfInts = new List<int>();
        Console.WriteLine("Input array elements: ");
        InputArray(arrayOfInts, arraySize);

        for (int i = 1; i < 1 << arraySize; i++)
        {
            List<int> subset = new List<int>();
            for (int j = 0; j < arrayOfInts.Count; j++)
            {
                if ((i & (1 << j)) != 0)
                {
                    subset.Add(arrayOfInts[j]);
                }
            }
            if (subset.Count == subsetLength)
            {
                    Console.WriteLine("---->{0}", i);
                    Permute.Permutation(subset, 0, subset.Count);
            }
            Console.WriteLine(new string('-', 40));
        }
        
    }

    static void InputArray(IList<int> array, int length)
    {
        for (int i = 0; i < length; i++)
        {
            Console.Write("Element:{0} = ", i);
            array.Add(int.Parse(Console.ReadLine()));
        }
    }
}
static class Permute
{
    private static void Swap(List<int> set, int k, int i)
    {
        int temp = set[k];
        set[k] = set[i];
        set[i] = temp;
    }
    static public void Permutation(List<int> set, int start, int end)
    {
        if (start == end)
        {
            foreach (var item in set)
            {
                Console.Write("{0}    ", item);
            }
            Console.WriteLine();
        }
        else
        {
            for (int i = start; i < end; i++)
            {

                Permutation(set, start + 1, end);

            }
        }
    }
}