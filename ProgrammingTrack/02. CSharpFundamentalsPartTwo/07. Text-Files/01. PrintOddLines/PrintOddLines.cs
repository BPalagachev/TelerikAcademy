// Write a program that reads a text file 
// and prints on the console its odd lines.

using System;
using System.IO;

class PrintOddLines
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader(@"..\..\text.txt"))
        {
            int lineNumber = 0;
            string line = reader.ReadLine();
            while (line!=null)
            {
                lineNumber++;
                if (lineNumber %2 != 0)
                {
                    Console.WriteLine(line);
                }
                line = reader.ReadLine();
            }
        }
    }
}