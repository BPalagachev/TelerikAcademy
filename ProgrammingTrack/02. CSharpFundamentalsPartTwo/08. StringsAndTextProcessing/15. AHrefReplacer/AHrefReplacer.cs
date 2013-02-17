// Write a program that replaces in a HTML document given as string all 
// the tags <a href="…">…</a> with corresponding tags [URL=…]…[/URL]. 

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class AHrefReplacer
{
    static void Main(string[] args)
    {
        string text=@"<p>Please visit <a href=""http://academy.telerik.com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses. <a href=""rakiq</p>";
        string expression = @"<a href=\""(.*?)\"">(.*?)</a>";
        Console.WriteLine(Regex.Replace(text, expression, m => String.Format("[URL={0}]{1}[/URL]", m.Groups[1].Value, m.Groups[2].Value)));
    }
}