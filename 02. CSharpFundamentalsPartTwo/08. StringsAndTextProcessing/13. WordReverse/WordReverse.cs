// Write a program that reverses the words in given sentence.

using System;
using System.Text;
using System.Text.RegularExpressions;

class WordReverse
{
    static void Main()
    {
        Console.WriteLine("Text: ");
        string textToReverse = Console.ReadLine();
        string reversed = Reverse(textToReverse);
        Console.WriteLine(Regex.Replace(reversed, @"\b\w*\b", m => Reverse(m.Value)));      

    }
    static string Reverse(string word)
    {
        StringBuilder reversed = new StringBuilder();
        for (int i = word.Length-1; i>=0; i--)
        {
            reversed.Append(word[i]);
        }
        return reversed.ToString();
    }
}