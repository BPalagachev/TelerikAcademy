// You are given an array of strings. Write a method that sorts the
// array by the length of its elements (the number of characters composing them).

using System;

class SortsByLength
{
    static void Main(string[] args)
    {
        Console.Write("String Array Length: ");
        int size = int.Parse(Console.ReadLine());
        string[] array = new string[size];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Word[{0}] = ", i);
            array[i] = Console.ReadLine();
        }
        Array.Sort(array , (s1, s2) => compareStrings(s1, s2));
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }
    }
    static int compareStrings(string str1, string str2)
    {
        if (str1.Length > str2.Length)
        {
            return 1;
        }
        else if (str1.Length < str2.Length)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}