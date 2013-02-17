// Write a program that deletes from given text file all odd lines. 
// The result should be in the same file.

using System;
using System.IO;
using System.Linq;

class DeleteOddFiles
{
    static int counter = 0;
    static void Main()
    {
        string path = @"..\..\LoremIpsum.txt";
        var linesToKeep = File.ReadLines(path).Where(line => (LineCounter()) % 2 != 0).ToArray();
        File.WriteAllLines(path, linesToKeep);
        Console.WriteLine("Completed Sucessfully!");
    }
    public static int LineCounter()
    {
        counter++;
        return counter;
    }
}