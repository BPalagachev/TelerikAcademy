// Write a program that reads a string from the console and lists all different 
// words in the string along with information how many times each word is found.

using System;
using System.Collections.Generic;
using System.Linq;

class CountWords
{
    static void Main()
    {
        string text = @"таралежът е птица упорита не го ли ритнеш не отлита";
        Dictionary<string, int> letterRepetitions = new Dictionary<string, int>();
        string[] words = text.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            
            if (letterRepetitions.ContainsKey(word))
            {
                letterRepetitions[word]++;
            }
            else
            {
                letterRepetitions.Add(word, 1);
            }
        }
        var ordered = letterRepetitions.OrderBy(x => x.Value);
        foreach (var letter in ordered)
        {
            Console.WriteLine("{0} - {1} times", letter.Key, letter.Value);
        }
    }
}