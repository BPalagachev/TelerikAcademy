// Write a program that replaces all occurrences of the substring "start" with the 
// substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;


class Replace
{
    static void Main()
    {
        string fileName = @"..\..\text.txt";
        string substitutedFile = @"..\..\subst.txt";

        StreamReader reader = new StreamReader(fileName);
        StreamWriter writer = new StreamWriter(substitutedFile);

        using (reader)
        {
            using (writer)
            {
                string line = reader.ReadLine();
                while (line!=null)
                {
                    line = line.Replace("start", "finish");
                    writer.WriteLine(line);
                    line = reader.ReadLine();
                }
                
            }
        }
        Console.WriteLine("Substituted successfully!");
    }
}