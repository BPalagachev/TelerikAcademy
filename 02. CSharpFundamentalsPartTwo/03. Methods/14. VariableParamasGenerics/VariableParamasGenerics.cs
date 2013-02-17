// * Modify your last program and try to make it work for any number type, 
// not just integer (e.g. decimal, float, byte, etc.). Use generic method 
// (read in Internet about generic methods in C#).

using System;

class VariableParamasGenerics
{
    static void Main()
    {
        Console.WriteLine("Min: {0}", CalcMin(1.0, 2.0, 3.0, 4.0, 7.0));
        Console.WriteLine("Max: {0}", CalcMax(1L, 2L, 3L, 4L, 7L));
        Console.WriteLine("Average: {0}", CalcAverage(1m, 2m, 3m, 4m, 7m));
        Console.WriteLine("Sum: {0}", CalcSum((sbyte)1, (sbyte)2, (sbyte)3, (sbyte)4, (sbyte)7));
        Console.WriteLine("Product: {0}", CalcProduct(1, 2, 3, 4, 7));

    }
    static T CalcMin<T>(params T[] set)
    {
        dynamic min = int.MaxValue;
        foreach (T item in set)
        {
            if (min > item)
            {
                min = item;
            }
        }
        return (T)min;
    }
    static T CalcMax<T>(params T[] set)
    {
        dynamic max = int.MinValue;
        foreach (T item in set)
        {
            if (max < item)
            {
                max = item;
            }
        }
        return (T)max;
    }
    static T CalcAverage<T>(params T[] set)
    {
        dynamic average = 0;
        foreach (T item in set)
        {
            average =average+ item;
        }
        return average / set.Length;
    }
    static T CalcSum<T>(params T[] set)
    {
        dynamic sum = 0;
        foreach (T item in set)
        {
            sum += item;
        }
        return (T)sum;
    }
    static T CalcProduct<T>(params T[] set)
    {
        dynamic product = 1;
        foreach (T item in set)
        {
            product *= item;
        }
        return (T)product;
    }
}
