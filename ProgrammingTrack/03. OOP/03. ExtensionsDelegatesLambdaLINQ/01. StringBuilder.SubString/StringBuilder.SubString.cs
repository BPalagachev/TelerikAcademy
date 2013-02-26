// Implement an extension method Substring(int index, int length) for the class StringBuilder
// that returns new StringBuilder and has the same functionality as Substring in the class String.

using System;
using System.Text;

public static class StringBuilderExtensions
{
    public static StringBuilder Substring(this StringBuilder text, int startIndex)
    {
        StringBuilder substring = new StringBuilder();
        for (int i = startIndex; i < text.Length; i++)
        {
            substring.Append(text[i]);
        }
        return substring;
    }
    public static StringBuilder Substring(this StringBuilder text, int startIndex, int length)
    {
        StringBuilder substring = new StringBuilder();
        while (length > 0)
        {
            substring.Append(text[startIndex]);
            startIndex++;
            length--;
        }
        return substring;
    }
}
class StringBuilderSubString
{
    static void Main(string[] args)
    {
        StringBuilder bbb = new StringBuilder();
        bbb.Append("aaabbbccc");
        string aaa = "aaabbbccc";

        Console.WriteLine(bbb.Substring(3));
        Console.WriteLine(aaa.Substring(3));

        Console.WriteLine(bbb.Substring(3, 3));
        Console.WriteLine(aaa.Substring(3, 3));       
    }
}
