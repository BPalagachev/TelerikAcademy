// Sorting an array means to arrange its elements in increasing order.
// Write a program to sort an array. Use the "selection sort" algorithm: 
// Find the smallest element, move it at the first position, find the 
// smallest from the rest, move it at the second position, etc.

using System;

class SelectionSort
{
    static void Main()
    {
        int arrayLength = int.Parse(Console.ReadLine());
        int[] arrayToSort = new int[arrayLength];
        InputArray(arrayToSort);
        for (int i = 0; i < arrayToSort.Length; i++)
        {
            int indexOfMinimal = IndexMinElementInRange(arrayToSort, i, arrayToSort.Length - 1);
            SwapElement(arrayToSort, indexOfMinimal, i);
        }
        OutputArray(arrayToSort);


    }

    static void InputArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Element:{0} = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
    }
    static void OutputArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Array[{0}] = {1}", i, array[i]);
        }
    }
    static int IndexMinElementInRange(int[] array, int startIndex, int endIndex)
    {
        int minimal = int.MaxValue;
        int index = 0;
        for (int i = startIndex; i <= endIndex; i++)
        {
            if (array[i] < minimal)
            {
                minimal = array[i];
                index = i;
            }
        }
        return index;
    }
    static void SwapElement(int[] array, int elementOne, int elementTwo)
    {
        int temp = array[elementOne];
        array[elementOne] = array[elementTwo];
        array[elementTwo] = temp;
    }

}
