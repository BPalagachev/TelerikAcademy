// We are given a string containing a list of forbidden words and a text 
// containing some of these words. Write a program that replaces the
// forbidden words with asterisks. 
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Censorship
{
    static void Main()
    {
        Console.WriteLine("Text: ");
        string text = Console.ReadLine();
        Console.Write("Size of the list: ");
        int size = int.Parse(Console.ReadLine());
        Console.WriteLine("List of forbidden words: ");
        List<string> list = new List<string>();
        for (int i = 0; i < size; i++)
        {
            list.Add(Console.ReadLine());
        }

        for (int i = 0; i < list.Count; i++)
        {
            text = Regex.Replace(text, list[i], new string('*', list[i].Length));
        }
        Console.WriteLine(text);

    }
}
