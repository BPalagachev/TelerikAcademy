// Write a program that reads a string, reverses it and prints the result at the console.
// Example: "sample"  "elpmas".

using System;
using System.Text;

class ReverseString
{
    static void Main()
    {
        string line = Console.ReadLine();
        StringBuilder reversed = new StringBuilder();
        foreach (char item in line)
        {
            reversed.Insert(0, item);
        }
        Console.WriteLine(reversed.ToString());
    }
}