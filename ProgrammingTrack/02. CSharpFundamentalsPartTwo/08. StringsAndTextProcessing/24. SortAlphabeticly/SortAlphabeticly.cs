// Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

using System;

class SortAlphabeticly
{
    static void Main(string[] args)
    {
        string text = @"Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.";
        string[] words = text.Split(new char[] { ' ', '.', ',', '!' }, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(words);
        Console.WriteLine(string.Join("\n", words) );
    }
}