// Write a program that compares two text files line by line and 
// prints the number of lines that are the same and the number 
// of lines that are different. Assume the files have equal number 
// of lines.

using System;
using System.IO;

class CompareFiles
{
    static void Main()
    {
        string CompareFirstName = @"..\..\file1.txt";
        string CompareSecondName = @"..\..\file2.txt";

        StreamReader readerForFirst = new StreamReader(CompareFirstName);
        StreamReader readerForSecond = new StreamReader(CompareSecondName);

        int counterSame = 0;
        int counterDiff = 0;
        using (readerForFirst)
        {
            using (readerForSecond)
            {

                string lineFirstFile = readerForFirst.ReadLine();
                string lineSecondFile = readerForSecond.ReadLine();
                while (lineFirstFile != null && lineSecondFile != null)
                {
                    if (lineFirstFile == lineSecondFile)
                    {
                        counterSame++;
                    }
                    else
                    {
                        counterDiff++;
                    }
                    lineFirstFile = readerForFirst.ReadLine();
                    lineSecondFile = readerForSecond.ReadLine();
                }
            }
        }
        Console.WriteLine("Equal lines: {0}", counterSame);
        Console.WriteLine("Different lines: {0}", counterDiff);
    }
}