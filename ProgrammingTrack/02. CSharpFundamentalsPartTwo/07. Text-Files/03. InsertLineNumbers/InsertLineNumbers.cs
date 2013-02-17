// Write a program that reads a text file and inserts line numbers in front
// of each of its lines. The result should be written to another text file.

using System;
using System.IO;

class InsertLineNumbers
{
    static void Main()
    {
        string sourceFile = @"..\..\LoremIpsum.txt";
        string numeratedFile = @"..\..\NumeratedFile.txt";

        StreamReader reader = new StreamReader(sourceFile);
        StreamWriter writer = new StreamWriter(numeratedFile);

        using (reader)
        {
            using (writer)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    writer.WriteLine(string.Format("Line {0}: {1}", lineNumber, line));
                    line = reader.ReadLine();
                }
            }
        }
        Console.WriteLine("File numereted succsessfulluy!");
        reader = new StreamReader(numeratedFile);
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = reader.ReadLine();
            }
        }

    }
}