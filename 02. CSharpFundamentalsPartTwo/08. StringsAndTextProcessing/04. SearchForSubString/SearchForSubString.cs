// Write a program that finds how many times a substring is
// contained in a given text (perform case insensitive search).


using System;

class SearchForSubString
{
    static void Main()
    {
        Console.WriteLine("Text input: ");
        string text = Console.ReadLine().ToLower();
        Console.WriteLine("Substring to look for: ");
        string subString = Console.ReadLine().ToLower();
        int counter = 0;
        int index = -1;
        while ((index = text.IndexOf(subString, index+1))!=-1 )
        {
            counter++;
        }
        Console.WriteLine(counter);
    }
}