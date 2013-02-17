// Write a program that reads a string from the console and prints all different letters
// in the string along with information how many times each letter is found. 

using System;
using System.Collections.Generic;
using System.Linq;

class CountLetters
{
    static void Main(string[] args)
    {
        string text = @"таралежът е птица упорита не го ли ритнеш не отлита";
        Dictionary<char, int> letterRepetitions = new Dictionary<char, int>();
        foreach (char letter in text)
        {
            if (letterRepetitions.ContainsKey(letter))
            {
                letterRepetitions[letter]++;
            }
            else
            {
                letterRepetitions.Add(letter, 1);
            }
        }
        var ordered = letterRepetitions.OrderBy(x => x.Value);
        foreach (var letter in ordered)
        {
            Console.WriteLine("{0} - {1} times", letter.Key, letter.Value);            
        }

    }
}
