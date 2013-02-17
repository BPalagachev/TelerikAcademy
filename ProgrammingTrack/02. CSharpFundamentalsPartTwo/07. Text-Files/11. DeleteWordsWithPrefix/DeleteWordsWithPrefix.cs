// Write a program that deletes from a text file all words that start with 
// the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _.

using System;
using System.IO;
using System.Text.RegularExpressions;

class DeleteWordsWithPrefix
{
    static void Main()
    {
        string sourcePath = @"..\..\text.txt";
        string destinationPath = @"..\..\destination.txt";
        string pattern = @"\btest\w*\b";
        StreamReader reader = new StreamReader(sourcePath);
        StreamWriter writer = new StreamWriter(destinationPath);
        using (reader)
        {
            using (writer)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    writer.WriteLine(Regex.Replace(line, pattern, ""));
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
        }

        reader = new StreamReader(destinationPath);
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
