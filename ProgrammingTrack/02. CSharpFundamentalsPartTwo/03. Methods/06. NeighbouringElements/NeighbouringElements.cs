// Write a method that returns the index of the first element in array 
// that is bigger than its neighbors, or -1, if there’s no such element.
// Use the method from the previous exercise.

using System;

class NeighbouringElements
{
    static void Main()
    {
        Console.WriteLine("Array size: ");
        int arraySize = int.Parse(Console.ReadLine());
        int[] array = new int[arraySize];
        InputArray(array);
        Console.WriteLine("The first element that is bigger the both his neighbours is at {0}",BiggerThanNeighboursPosition(array));

    }
    static void InputArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Element[{0}] =  ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
    }
    static bool IsBiggerThanNeighbours(int[] array, int position)
    {
        int nextIndex = position == array.Length - 1 ? position : position + 1;
        int previousIndex = position == 0 ? position : position - 1;
        return (array[position] >= array[nextIndex] && array[position] >= array[previousIndex] ? true : false);
    }
    static int BiggerThanNeighboursPosition(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (IsBiggerThanNeighbours(array, i))
            {
                return i;
            }
        }
        return -1;

    }
}