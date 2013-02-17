// Modify the solution of the previous problem to replace only whole words (not substrings).

using System;
using System.IO;
using System.Text.RegularExpressions;

class ReplaceWords
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
                while (line != null)
                {
                    line = Regex.Replace(line, @"\bstart\b", "finish");
                    writer.WriteLine(line);
                    line = reader.ReadLine();
                }

            }
        }
        Console.WriteLine("Substituted successfully!");
    }
}