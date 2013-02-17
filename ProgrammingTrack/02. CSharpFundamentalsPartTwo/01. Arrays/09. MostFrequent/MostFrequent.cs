using System;

class MostFrequent
{
    static void Main()
    {
        int highestFrequency = 0;
        int indexOfHighestFrequency = 0;
        int currentFrequency = 1;

        Console.Write("Array Size = ");
        int arraySize = int.Parse(Console.ReadLine());
        int[] histArray = new int[arraySize];
        InputArray(histArray);
        Array.Sort(histArray);

        for (int i = 0; i < histArray.Length - 1; i++)
        {
            if (histArray[i] == histArray[i + 1])
            {
                currentFrequency++;
            }
            else
            {
                if (currentFrequency > highestFrequency)
                {
                    highestFrequency = currentFrequency;
                    indexOfHighestFrequency = i;
                }
                currentFrequency = 1;
            }
        }
        if (currentFrequency > highestFrequency)
        {
            highestFrequency = currentFrequency;
            indexOfHighestFrequency = histArray.Length;
        }
        Console.WriteLine("Value {0} occures {1} time in the array", histArray[indexOfHighestFrequency - (highestFrequency-1)], highestFrequency);
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