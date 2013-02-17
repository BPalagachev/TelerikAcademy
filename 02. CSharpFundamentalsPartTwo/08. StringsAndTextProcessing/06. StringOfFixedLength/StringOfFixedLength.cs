// Write a program that reads from the console a string of maximum 20 characters. 
// If the length of the string is less than 20, the rest of the characters should
// be filled with '*'. Print the result string into the console.

using System;

class StringOfFixedLength
{
    static void Main()
    {
        string line = Console.ReadLine();
        if (line.Length >20)
        {
            line = line.Substring(0, 20);
        }
        Console.WriteLine(line.PadRight(20, '*'));
    }
}