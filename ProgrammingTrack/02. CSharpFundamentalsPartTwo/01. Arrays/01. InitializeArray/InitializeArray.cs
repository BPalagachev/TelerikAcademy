// Write a program that allocates array of 20 integers and initializes
// each element by its index multiplied by 5. Print the obtained 
// array on the console.
using System;

class InitializeArray
{
    static void Main()
    {
        int[] integerArray = new int[20];
        for (int i = 0; i < integerArray.Length; i++)
        {
            integerArray[i] = i * 5;
        }
        foreach (var item in integerArray)
        {
            Console.WriteLine("{0}",item);
        }
    }
}