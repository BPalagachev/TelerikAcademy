// Write methods to calculate minimum, maximum, average, sum and product of
// given set of integer numbers. Use variable number of arguments.

using System;

class VariableParams
{
    static void Main()
    {
        Console.WriteLine("Min: {0}", CalcMin(1, 2, 3, 4, 7));
        Console.WriteLine("Max: {0}", CalcMax(1, 2, 3, 4, 7));
        Console.WriteLine("Average: {0}", CalcAverage(1, 2, 3, 4, 7));
        Console.WriteLine("Sum: {0}", CalcSum(1, 2, 3, 4, 7));
        Console.WriteLine("Product: {0}", CalcProduct(1, 2, 3, 4, 7));

    }
    static int CalcMin(params int[] set)
    {
        int min = int.MaxValue;
        foreach (int item in set)
        {
            if (min>item)
            {
                min = item;
            }
        }
        return min;
    }
    static int CalcMax(params int[] set)
    {
        int max = int.MinValue;
        foreach (int item in set)
        {
            if (max < item)
            {
                max = item;
            }
        }
        return max;
    }
    static double CalcAverage(params int[] set)
    {
        int average = 0;
        foreach (int item in set)
        {
            average += item;
        }
        return (double)average / set.Length;
    }
    static int CalcSum(params int[] set)
    {
        int sum = 0;
        foreach (int item in set)
        {
            sum+=item;
        }
        return sum;
    }
    static int CalcProduct(params int[] set)
    {
        int product = 1;
        foreach (int item in set)
        {
            product *= item;
        }
        return product;
    }
}