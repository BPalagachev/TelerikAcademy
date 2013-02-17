using System;

class SequenceOfMaxSum
{
    static void Main(string[] args)
    {
        Console.Write("Array Size:");
        int arraySize = int.Parse(Console.ReadLine());
        int[] array = new int[arraySize];
        Console.WriteLine("Input Array!");
        
        InputArray(array);

        int sequenceLength = 0;
        int currentSum = 0;
        int maxSum = 0;
        int maxSeqEnd = 0;
        int maxSumIndex = 0;

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length-sequenceLength; j++)
            {

                currentSum += array[j];
            }

            if (currentSum>maxSum)
            {
                maxSeqEnd = sequenceLength;
                maxSumIndex = i;
            }
            currentSum = 0;
            sequenceLength++;
        }
        Console.WriteLine(maxSum);
        Console.WriteLine("Max sequence is: ");
        for (int i = maxSumIndex; i <= maxSeqEnd; i++)
        {
            Console.Write("{0}", array[i]);
        }
        Console.WriteLine(maxSumIndex);
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