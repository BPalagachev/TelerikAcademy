// Write a program that prints from given array of integers all numbers that are divisible by 7 and 3.
// Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

using System;
using System.Collections.Generic;
using System.Linq;

class DivisivleByWithLambda
{
    static void Main()
    {
        List<int> numbers = new List<int>() { 1, 5, 7, 21, 63, 189, 11, 17};
        List<int> devisibleBy7and3 = numbers.FindAll((x) => 
            (x % 7 == 0) && 
            (x % 3 == 0));
        foreach (var num in devisibleBy7and3)
        {
            Console.WriteLine(num);
        }
    }
}
