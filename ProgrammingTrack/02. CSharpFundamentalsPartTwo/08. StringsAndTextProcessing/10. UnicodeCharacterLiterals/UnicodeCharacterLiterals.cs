// Write a program that converts a string to a sequence of
// C# Unicode character literals. Use format strings. 

using System;
using System.Text;
using System.Text.RegularExpressions;

class UnicodeCharacterLiterals
{
    static void Main()
    {
        string line = Console.ReadLine();
        StringBuilder text = new StringBuilder();

        for (int i = 0; i < line.Length; i++)
        {
            text.Append(string.Format("\\u{0:x4} ", (ushort)line[i]));
        }
        Console.WriteLine(text);
        Console.WriteLine(Regex.Replace(line, @".", d => (string.Format("\\u{0:x4} ", (ushort)d.Value[0]))));
    }
}