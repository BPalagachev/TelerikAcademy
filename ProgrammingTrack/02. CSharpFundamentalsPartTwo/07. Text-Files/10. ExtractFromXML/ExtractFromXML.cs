// Write a program that extracts from given XML file all the text without the tags. 

using System;
using System.IO;
using System.Text;

class ExtractFromXML
{
    static void Main()
    {
        string file = @"..\..\XMLFile.txt";
        StreamReader reader = new StreamReader(file);
        int c;
        int k;
        using (reader)
        {
            while ((c = reader.Read()) != -1)
            {
                if (c == '>')
                {
                    StringBuilder toPrint = new StringBuilder();
                    while ((k = reader.Read()) != '<' && k != -1)
                    {
                        toPrint.Append((char)k);
                    }
                    if (!string.IsNullOrWhiteSpace(toPrint.ToString()))
                    {
                        Console.WriteLine(toPrint.ToString());
                    }
                }
            }
        }


    }
}