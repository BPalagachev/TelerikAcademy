// Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

using System;
using System.Text.RegularExpressions;


class FindPalindromes
{
    static void Main()
    {
        string text = @"Write a program that extracts from a given text all palindromes, e.g. ""ABBA"", ""lamal"", ""exe"".";
        string regExpression = @"\w{2,}";
        MatchCollection matches = Regex.Matches(text, regExpression);
        foreach (Match item in matches)
        {
            if (isPalindrome(item.Value))
            {
                Console.WriteLine(item.Value);
            }
        }

    }
    static bool isPalindrome(string word)
    {
        for (int i = 0; i < word.Length/2; i++)
        {
            if (word[i]!=word[word.Length-1-i])
            {
                return false;
            }
        }
        return true;
    }
}