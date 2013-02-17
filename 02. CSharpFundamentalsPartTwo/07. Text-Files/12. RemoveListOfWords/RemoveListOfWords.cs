// Write a program that removes from a text file all words listed in
// given another text file. Handle all possible exceptions in your methods.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class RemoveListOfWords
{
    static void Main()
    {
        string listFile = @"..\..\list.txt";
        string sourcePath = @"..\..\text.txt";
        string destinationPath = @"..\..\output.txt";
        List<string> listToRemove = new List<string>();

        StreamReader reader = new StreamReader(listFile);
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                listToRemove.Add(line);
                line = reader.ReadLine();
            }
        }
        Console.WriteLine("List: ");
        for (int i = 0; i < listToRemove.Count; i++)
        {
            Console.WriteLine("{0}: {1}", i+1 , listToRemove[i]);
        }
        Console.WriteLine(new string('-', 40));
        reader = new StreamReader(sourcePath);
        StreamWriter writer = new StreamWriter(destinationPath);
        using (reader)
        {
            using (writer)
            {
                string line = reader.ReadLine();
                while (line!=null)
                {
                    foreach (var item in listToRemove)
                    {
                        line=Regex.Replace(line, item, string.Empty);
                    }
                    writer.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
        }

        Console.WriteLine("Source File:");
        reader = new StreamReader(sourcePath);
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = reader.ReadLine();
            }
        }
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("Destination File:");
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
        Console.WriteLine(new string('-', 40));
    }
    
}