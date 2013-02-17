// You are given a text. Write a program that changes the text 
// in all regions surrounded by the tags <upcase> and </upcase> to uppercase. 

using System;
using System.Text.RegularExpressions;

class UpcaseTags
{
    static void Main(string[] args)
    {

        // Console.WriteLine("Enter tagged file: ");
        // string line = Console.ReadLine();
        string line  = @"We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        string upCasedText = Regex.Replace(line, @"<upcase>(.*?)</upcase>", d => d.Groups[1].Value.ToUpper());
        Console.WriteLine(upCasedText);

    }
}