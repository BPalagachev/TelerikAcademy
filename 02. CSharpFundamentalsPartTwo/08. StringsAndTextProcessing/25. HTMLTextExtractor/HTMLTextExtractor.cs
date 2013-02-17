// Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.

using System;
using System.Text;
using System.Text.RegularExpressions;

class HTMLTextExtractor
{
    static void Main(string[] args)
    {
        string text = 
@"<html>
  <head><title>News</title></head>
  <body><p><a href=""http://academy.telerik.com"">Telerik
    Academy</a>aims to provide free real-world practical
    training for young people who want to turn into
    skillful .NET software engineers.</p></body>
</html>
";
        text = RemoveNewLines(text);
        string regex = @">(.*?)<";
        MatchCollection matches= Regex.Matches(text, regex);
        foreach (Match item in matches)
        {
            if (!string.IsNullOrWhiteSpace(item.Groups[1].Value))
            {
                Console.WriteLine(item.Groups[1].Value.Trim());
            }
            
        }

    }
    static string RemoveNewLines(string text)
    {
        StringBuilder noNewLines = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] != '\r' && text[i] != '\n')
            {
                noNewLines.Append(text[i]);
            }
        }
        return noNewLines.ToString();
    }
}