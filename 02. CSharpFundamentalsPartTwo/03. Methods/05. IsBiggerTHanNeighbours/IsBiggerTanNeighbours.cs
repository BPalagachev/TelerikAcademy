// Write a method that checks if the element at given position in given
// array of integers is bigger than its two neighbors (when such exist).

using System;

class IsBiggerTHanNeighbours
{
    static void Main()
    {
        Console.WriteLine("Array size: ");
        int arraySize = int.Parse(Console.ReadLine());
        int[] array = new int[arraySize];
        InputArray(array);
        Console.Write("Position: ");
        int position = int.Parse(Console.ReadLine());
        Console.WriteLine(IsBiggerThanNeighbours(array, position));
        

    }
    static void InputArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Element[{0}] =  ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
    }
    static bool IsBiggerThanNeighbours(int[] array, int position)
    {
        int nextIndex = position==array.Length-1?position:position+1;
        int previousIndex = position==0?position:position-1;
        return (array[position] >= array[nextIndex] && array[position] >= array[previousIndex] ? true : false);
    }
   
}