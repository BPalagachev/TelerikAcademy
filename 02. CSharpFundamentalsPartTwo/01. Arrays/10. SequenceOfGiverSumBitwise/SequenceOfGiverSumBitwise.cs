using System;

class SequenceOfGiverSumBitwise
{
    static void Main()
    {
        Console.Write("Sum: ");
        int sumToFind = int.Parse(Console.ReadLine());
        Console.Write("Write array size: ");
        int arraySize = int.Parse(Console.ReadLine());
        int[] arrayToCheck = new int[arraySize];
        InputArray(arrayToCheck);
        int sum = 0;
        int mask = 1;
        for (int i = 1; i < 1 << arraySize; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if ((i & (7 << j)) != 0)
                {

                    sum += arrayToCheck[j];
                    if (sum == sumToFind)
                    {
                        Console.WriteLine("Found");
                    }


                }

                sum = 0;
            }

        }
    }
    static void InputArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Element:{0} = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
    }
}