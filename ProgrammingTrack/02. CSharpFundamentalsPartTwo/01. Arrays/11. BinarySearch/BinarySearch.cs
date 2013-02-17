// Write a program that finds the index of given element in a sorted array of 
// integers by using the binary search algorithm (find it in Wikipedia).

using System;

class BinarySearch
{
    static void Main()
    {
        Console.Write("Array Size: ");
        int arraySize = int.Parse(Console.ReadLine());
        int[] arrayToSearch = new int[arraySize]; // The array to be worked with
        InputArray(arrayToSearch);
        Array.Sort(arrayToSearch);                // The array needs to be sorted
        Console.Write("Element to look for: ");
        int elementToLookFor = int.Parse(Console.ReadLine()); // The element that is to be found in the array
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Array after sorting:");
        OutputArray(arrayToSearch);

        int binirySearchResult = BinarySearchIterative(arrayToSearch, elementToLookFor); 
        string messege = (binirySearchResult >= 0) ? "Element found at possition {0}" : "Element not found";
        Console.WriteLine(messege, binirySearchResult);

        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Result using recursive binary search algorithm:");
        binirySearchResult = BinarySearchRecursive(arrayToSearch, elementToLookFor, 0, arrayToSearch.Length);
        messege = (binirySearchResult >= 0) ? "Element found at possition {0}" : "Element not found";
        Console.WriteLine(messege, binirySearchResult);



    }
    static int BinarySearchIterative (int[] array, int ElementToLookFor)
    {
        // Iterative procedure implementing Binary search
        int start = 0;
        int end = array.Length;
        int middle = 0;

        while (start <= end)
        {
            middle = (end - start) / 2 + start;
            if (ElementToLookFor < array[middle])
            {
                end = middle - 1;
            }
            else if (ElementToLookFor > array[middle])
            {
                start = middle + 1;
            }
            else
            {
                return middle;
            }
        }
        return -1;
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

    static int BinarySearchRecursive(int[] array, int elementToLookFor, int start, int end)
    {
        // recursive procedure imprementing Binary search
        if (end < start)
        {
            return -1;
        }
        int middle = (end - start) / 2 + start;
        if (elementToLookFor < array[middle])
        {
            return BinarySearchRecursive(array, elementToLookFor, start, middle - 1);
        }
        else if (elementToLookFor > array[middle])
        {
            return BinarySearchRecursive(array, elementToLookFor, middle+1, end);
        }
        return middle;
    }
}