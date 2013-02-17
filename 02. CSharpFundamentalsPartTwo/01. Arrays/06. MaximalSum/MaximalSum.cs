// Write a program that reads two integer numbers N and K and an array 
// of N elements from the console. Find in the array those K elements 
// that have maximal sum.

using System;

class MaximalSum
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()); // Array Size
        int K = int.Parse(Console.ReadLine()); // Number of elements with max sum
        int[] array = new int[N]; ;
        InputArray(array);
        Array.Sort(array);
        int[] maxElements = new int[K];
        Array.Copy(array, N - K, maxElements, 0, K);
        Console.WriteLine("The eleements with max sum of {0} are:", SumArray(maxElements));
        OutputArray(maxElements);
        Console.WriteLine();

        //Array.Sort(array);

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
    static long SumArray(int[] array)
    {
        long sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        return sum;
    }
}