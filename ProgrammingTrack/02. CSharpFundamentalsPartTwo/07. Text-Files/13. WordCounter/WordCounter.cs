// Write a program that reads a list of words from a file words.txt and finds 
// how many times each of the words is contained in another file test.txt. 
// The result should be written in the file result.txt and the words should be 
// sorted by the number of their occurrences in descending order.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class WordCounter
{
    static void Main()
    {
        string listFile = @"..\..\list.txt";
        string sourcePath = @"..\..\text.txt";
        string destinationPath =@"..\..\destination.txt";
        Dictionary<string, int> listOfWords = new Dictionary<string, int>();

        StreamReader reader = new StreamReader(listFile);
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                listOfWords.Add(line, 0);
                line = reader.ReadLine();
            }
        }
        Console.WriteLine("List: ");
        int counter = 1;
        foreach (var item in listOfWords)
        {
            Console.WriteLine("{0}: {1}", counter, item.Key);
            counter++;
        }

        reader = new StreamReader(sourcePath);
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] words = line.Split(new char[] { ' ', ',', '/', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in words)
                {
                    if (listOfWords.ContainsKey(item))
                    {
                        listOfWords[item] += 1;
                    }
                }
                line = reader.ReadLine();
            }

        }
        StreamWriter writer = new StreamWriter(destinationPath);

        using (writer)
        {
            foreach (var item in listOfWords.OrderByDescending(i => i.Value))
            {
                writer.WriteLine(item.Key+ " " + item.Value);
            }
        }
        

    }
}
