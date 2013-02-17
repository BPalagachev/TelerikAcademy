// A dictionary is stored as a sequence of text lines containing words and their explanations. 
// Write a program that enters a word and translates it by using the dictionary. 

using System;
using System.Collections.Generic;

class MyDictionary
{
    static void Main(string[] args)
    {
        Dictionary<string, string> myDictionary = new Dictionary<string, string>();
        myDictionary.Add(".Net", "platform for applications from Microsoft");
        myDictionary.Add("CLR", "maganed execution enciroment for .NET");
        myDictionary.Add("namespace", "hierarchical organization of classes");

        Console.WriteLine("Word to look for:");
        string word = Console.ReadLine();
        if (myDictionary.ContainsKey(word))
        {
            Console.WriteLine("{0} - {1}",word, myDictionary[word]);
        }
        else
        {
            Console.WriteLine("No match!");
        }

    }
}