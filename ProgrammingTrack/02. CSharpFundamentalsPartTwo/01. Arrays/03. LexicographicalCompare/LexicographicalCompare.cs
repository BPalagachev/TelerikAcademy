// Write a program that compares two char 
// arrays lexicographically (letter by letter).
using System;

class LexicographicalCompare
{
    static void Main()
    {
        char[] wordOne = readCharArray();
        char[] wordTwo = readCharArray();
        int i = 0;

        // find the position where there is a diference bewtween the two arrays
        while (true) 
        {
            if ((i >= wordOne.Length-1 || i >= wordTwo.Length-1) || (wordOne[i] != wordTwo[i]))
            {
                break;
            }
            i++;
        }
        // checks which arrays has a smaller code letter
        if (wordOne[i]-wordTwo[i] < 0)
        {
            Console.WriteLine(new string(wordOne) + " is lexicographiclly first");
        }
        else if (wordOne[i] - wordTwo[i] > 0)
        {
            Console.WriteLine(new string(wordTwo) + " is lexicographiclly first");
        }
        // if the letter are equal and the length of the two arrays are equal => they are equal
        else if (wordOne.Length == wordTwo.Length)
        {
            Console.WriteLine(new string(wordOne) + " is equal to " + new string(wordTwo));
        }
        // if not the shorter one is lexicographically first
        else if (wordOne.Length < wordTwo.Length)
        {
            Console.WriteLine(new string(wordOne) + " is lexicographiclly first");
        }
        else
        {
            Console.WriteLine(new string(wordTwo) + " is lexicographiclly first");
        }

        

    }
    static char[] readCharArray()
    {
        string tempWord = Console.ReadLine();
        char[] charArray = new char[tempWord.Length];
        charArray = tempWord.ToCharArray();
        return charArray;
    }
}