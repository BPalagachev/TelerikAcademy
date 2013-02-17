// * Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. Example:
// 	n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}

using System;
using System.Collections.Generic;

class Permutations
{
    static void Main()
    {
        Console.Write("Set Size: ");
        int setSize = int.Parse(Console.ReadLine());
        List<int> set = new List<int>();
        for (int j = 0; j < setSize; j++)
        {
            set.Add(int.Parse(Console.ReadLine()));
        }
        Permute.Permutation(set, 0, set.Count);
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
                Swap(set, start, i);
                Permutation(set, start + 1, end);
                Swap(set, i, start);
            }
        }
    }
}