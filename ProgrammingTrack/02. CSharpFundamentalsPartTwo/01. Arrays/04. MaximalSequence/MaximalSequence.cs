using System;

class MaximalSequence
{
    static void Main(string[] args)
    {
        Console.Write("Array Size: ");
        int arraySize = int.Parse(Console.ReadLine());
        int[] array = new int[arraySize];
        Console.WriteLine("Input Array!");
        InputArray(array);
        int currentCounter = 1;
        int maxCounter = 0;
        int bestIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i]==array[i-1])
            {
                currentCounter++;
            }
            else
            {
                if (currentCounter>maxCounter)
                {
                    maxCounter = currentCounter;
                    bestIndex = i;
                }
                currentCounter = 1;
            }
        }
        if (currentCounter > maxCounter)
        {
            maxCounter = currentCounter;
            bestIndex = array.Length;
        }
        Console.WriteLine("Longest sequence of {0} elements", maxCounter);
        for (int i = bestIndex-maxCounter; i < bestIndex; i++)
        {
            Console.Write("{0} ", array[i]);   
        }
        Console.WriteLine();
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
}