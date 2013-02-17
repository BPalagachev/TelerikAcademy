// Write a method that return the maximal element in a portion of 
// array of integers starting at given index. Using it write
// another method that sorts an array in ascending / descending order.

using System;

class MaxInArray
{
    static void Main(string[] args)
    {
        Console.Write("array size: ");
        int arraySize = int.Parse(Console.ReadLine());
        int[] numbers = new int[arraySize];
        InputArray(numbers);
        Console.WriteLine("Sort Descending");
        SortArrayDescending(numbers);
        OutputArray(numbers);
        Console.WriteLine("Sord Ascending");
        SortArrayAscending(numbers);
        OutputArray(numbers);
    }
    static int FindMax(int[] array, int start, int end)
    {
        int max = Int32.MinValue;
        int maxIndex = 0; 
        for (int i = start; i <= end; i++)
        {
            if (max<array[i])
            {
                max = array[i];
                maxIndex = i;
            }
        }
        return maxIndex;
    }
    static void Swap(int[] array, int i, int j)
    {
        int temp = 0;
        temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
    static void SortArrayDescending(int[] array)
    {
        int maxIndex = 0;
        for (int i = 0; i < array.Length; i++)
        {
            maxIndex = FindMax(array, i, array.Length - 1);
            Swap(array, i, maxIndex);
        }
    }
    static void SortArrayAscending(int[] array)
    {
        int maxIndex = 0;
        for (int i = array.Length-1; i >= 0; i--)
        {
            maxIndex = FindMax(array, 0, i);
            Swap(array, i, maxIndex);
        }
    }


    static void InputArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Element[{0}] =  ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
    }
    static void OutputArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Array[{0}] = {1}",i , array[i] );
        }
    }
}
