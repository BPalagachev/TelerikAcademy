// Write a program that concatenates two 
// text files into another text file.

using System;
using System.IO;

class ConcatenatesFiles
{
    static void Main()
    {
        string sourceDir = @"..\..\";
        string fileName1 = "file1.txt";
        string fileName2 = "file2.txt";
        string destinationDir = string.Copy(sourceDir);
        string mergedFileName = "merged.txt";


        File.Copy(Path.Combine(sourceDir, fileName1), Path.Combine(destinationDir, mergedFileName), true);

        StreamReader reader = new StreamReader(Path.Combine(sourceDir, fileName2));
        StreamWriter writer = File.AppendText(Path.Combine(destinationDir, mergedFileName));
        using (reader)
        {
            using (writer)
            {
                writer.WriteLine();
                string line = reader.ReadLine();
                while (line != null)
                {
                    writer.WriteLine(line);
                    line = reader.ReadLine();
                }
            }

        }
        Console.WriteLine("Files concatenated successfully!");
        reader = new StreamReader(Path.Combine(destinationDir, mergedFileName));
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