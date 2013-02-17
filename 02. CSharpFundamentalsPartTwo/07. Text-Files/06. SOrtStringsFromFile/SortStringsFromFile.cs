// Write a program that reads a text file containing a list of strings,
// sorts them and saves them to another text file. Example:
//    Ivan			George
//    Peter			Ivan
//    Maria			Maria
//    George		Peter

using System;
using System.IO;

class SortStringsFromFile
{
    static void Main()
    {
        string fileWithStrings = @"..\..\names.txt";
        string sortedFile = @"..\..\sorted.txt";

        StreamReader reader = new StreamReader(fileWithStrings);
        StreamWriter writer = new StreamWriter(sortedFile);
        using (reader)
        {
            using (writer)
            {
                string[] lines = reader.ReadToEnd().Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(lines);
                foreach (string item in lines)
                {
                    writer.WriteLine(item);
                }
                Console.WriteLine("Files Sorted!");
            }
        }
        reader = new StreamReader(sortedFile);
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
