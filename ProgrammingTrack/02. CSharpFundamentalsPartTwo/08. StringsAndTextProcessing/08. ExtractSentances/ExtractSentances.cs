// Write a program that extracts from a given text all sentences containing given word.

using System;
using System.Text.RegularExpressions;

class ExtractSentances
{
    static void Main()
    {
        string line = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string expression = @"[^\.]*?\bin\b.*?\.";
        MatchCollection sentances = Regex.Matches(line, expression);
        foreach (Match item in sentances)
        {
            Console.WriteLine(item.Value.Trim());
        }
    }
}