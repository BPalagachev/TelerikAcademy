// * Write a program that sorts an array of integers using the 
// merge sort algorithm (find it in Wikipedia).

using System;
using System.Collections.Generic;

class MergeSort
{
    static void Main()
    {
        Console.Write("Array Size: ");
        int listSize = int.Parse(Console.ReadLine());
        List<int> listToSort = new List<int>();
        for (int i = 0; i < listSize; i++)
        {
            Console.Write("Element {0} = ",i);
            listToSort.Add(int.Parse(Console.ReadLine()));
        }
        List<int> sorted = MergeSortMethod(listToSort);
        Console.WriteLine(new string ('-', 40));
        Console.WriteLine("The sorted Array is: ");
        for (int i = 0; i < sorted.Count; i++)
        {
            Console.WriteLine("Array[{0}] = {1}", i, sorted[i]);
        }

    }

    // Using recursive implementation of the merge algorithm
    static List<int> Merge(List<int> left, List<int> right)
    {
        List<int> result = new List<int>();
        while (left.Count > 0 || right.Count > 0)
        {
            if(left.Count >0 && right.Count >0)
            {
                if (left[0] <= right[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else 
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            else if (left.Count > 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }
            else if (right.Count > 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }
        }
        return result;
    }

    static List<int> MergeSortMethod(List<int> arrayToSort)
    {
        if (arrayToSort.Count <= 1)
        {
            return arrayToSort;
        }

        List<int> left = new List<int>();
        List<int> right = new List<int>();
        int middle = arrayToSort.Count / 2;
        
        for (int i = 0; i < arrayToSort.Count; i++)
        {
            if (i < middle)
            {
                left.Add(arrayToSort[i]);
            }
            else
            {
                right.Add(arrayToSort[i]);
            }
        }
        left = MergeSortMethod(left);
        right = MergeSortMethod(right);
        return Merge(left, right);
    }

}