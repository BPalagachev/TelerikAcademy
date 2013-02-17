using System;

class SumOfSubsets
{
    static void Main()
    {
        int[] integerNumbers = new int[5];

        for (int i = 0; i < integerNumbers.Length; i++)
        {
            integerNumbers[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 1; i < Math.Pow(2,integerNumbers.Length); i++)
        {
            int subsetSum = 0;
            for (int j = 0; j < i; j++)
            {
                if ((i & (1 << j)) !=0)
                {
                    subsetSum += integerNumbers[j];
                }
            }
            if (subsetSum == 0)
            {
                Console.WriteLine("There is INDEED a subset sum of zero");
                return;
            }
            subsetSum = 0;
            
        }
    }
}