// Implement a set of extension methods for IEnumerable<T> that implement 
// the following group functions: sum, product, min, max, average.

using System;
using System.Collections.Generic;

public static class IEnumerableExtensions 
{
    // this delegate is for aritmetic operations of custom classes
    public delegate T AritmeticDelegate<T>(T param1, T param2);
    // this delegate is for devision custom class of ints (if its meaningfull). used for finding avarage value of IEnumerable sequance of custom classes
    public delegate T DevisibleByInt<T>(T param, int devisor);

    // method using IEnumerator for finding first element in IEnumerable;
    private static T First<T>(this IEnumerable<T> items)
    {
        IEnumerator<T> iter = items.GetEnumerator();
        iter.MoveNext();
        return iter.Current;
    }

    // Min and Max require for T to implement IComperable
    public static T Max<T>(this IEnumerable<T> enumerable) where T : IComparable
    {
        var max = enumerable.First<T>();
        foreach (var item in enumerable)
        {
            if (item.CompareTo(max) > 0)
            {
                max = item;
            }
        }
        return max;
    }
    public static T Min<T>(this IEnumerable<T> enumerable) where T : IComparable
    {
        var min = enumerable.First<T>();
        foreach (var item in enumerable)
        {
            if (item.CompareTo(min) < 0)
            {
                min = item;
            }
        }
        return min;
    }

    // Sum and Product use IEnumerator to implement foreach, using while cycle
    public static T Sum<T>(this IEnumerable<T> enumerable, AritmeticDelegate<T> sumator)
    {
        IEnumerator<T> iter = enumerable.GetEnumerator();
        if (!iter.MoveNext())
        {
            throw new ArgumentException("IEnumerable instance must not me empty!");
        }
        var sum = iter.Current;
        while (iter.MoveNext())
        {
            sum = sumator(sum, iter.Current);
        }
        return sum;
    }

    public static T Product<T>(this IEnumerable<T> enumerable, AritmeticDelegate<T> multiplier)
    {
        IEnumerator<T> iter = enumerable.GetEnumerator();
        if (!iter.MoveNext())
        {
            throw new ArgumentException("IEnumerable instance must not me empty!");
        }
        var product = iter.Current;
        while (iter.MoveNext())
        {
            product = multiplier(product, iter.Current);
        }
        return product;
    }

    public static T Average<T>(this IEnumerable<T> enumerable, AritmeticDelegate<T> sumator, DevisibleByInt<T> devisor)
    {
        var sum = enumerable.Sum<T>(sumator);
        int counter = 0;
        foreach (var item in enumerable)
        {
            counter++;
        }
        return devisor(sum, counter);

    }
}
class Program
{
    static void Main(string[] args)
    {
        // reference type test of Min, Max
        string[] testReference = new string[]{"a", "b", "c", "d", "e", "f", "z"};
        // value type test of Min, Max
        int[] testValue = new int[] { -75, 3, 7, 9, 111, 3, 6, 10 };
        Console.WriteLine("Value type: Min: {0}; Max: {1}",testValue.Min<int>(), testValue.Max<int>());
        Console.WriteLine("Value type: Min: {0}; Max: {1}", testReference.Min<string>(), testReference.Max<string>());

        // Test for Sum, product, max of ints
        int[] array = new int[]{1,2,3,4,5} ;       
        Console.WriteLine("Sum: " + array.Sum<int>( delegate(int x, int y)
        {
            return x + y;
        }));
        Console.WriteLine("Product: " + array.Product<int>((x,y) =>x*y));
        Console.WriteLine("Avarage: " + array.Average<int>(
            (x,y) => x+y, 
            (x,y) => x/y
            ));
    }    
}


