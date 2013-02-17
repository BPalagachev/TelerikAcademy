// Write a program that reads a string from the console and replaces all 
// series of consecutive identical letters with a single one. 

using System;
using System.Text;

class ConsecutiveIdenticalLetter
{
    static void Main()
    {
        string text = "aaaaabbbbbcdddeeeedssaadddd";
        StringBuilder united = new StringBuilder();
        int index = 1;
        do
        {
            if (text[index]!=text[index-1])
            {
                united.Append(text[index-1]);
            }
            index++;
        } while (index<text.Length);
        united.Append(text[text.Length - 1]);
        Console.WriteLine(united);
    }
}