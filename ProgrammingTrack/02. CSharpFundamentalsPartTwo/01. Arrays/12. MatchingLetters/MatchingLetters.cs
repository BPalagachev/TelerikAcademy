// Write a program that creates an array containing all letters from the alphabet (A-Z). 
// Read a word from the console and print the index of each of its letters in the array.

using System;
using System.Text;

class MatchingLetters
{
    static void Main()
    {
        Console.WriteLine("Type your word: ");
        string word = Console.ReadLine();
        int[] alphabet = new int[26]; // allocating memory for the alpfabet array

        for (int i = 0; i < 26; i++) // initializing the array with the ascii codes of the capital letters
        {
            alphabet[i] = i+65;
        }
        word = word.ToUpper(); // Setting the word to Upper register in order the are small letters
        char[] wordArray = word.ToCharArray(); // converting to array
        Array.Sort(wordArray);

        for (int i = 0; i < wordArray.Length; i++)
        {
            int index = BinarySearchIterative(alphabet, (int)wordArray[i]); // using binary search to search through the alphabet
            if (index >=0)
            {
                Console.WriteLine("Letter {0} found. Index of the letter: {1}", wordArray[i], index+1);
            }
        }

    }
    static int BinarySearchIterative(int[] array, int ElementToLookFor)
    {
        int start = 0;
        int end = array.Length;
        int middle = 0;

        while (start <= end)
        {
            middle = (end - start) / 2 + start;
            if (ElementToLookFor < array[middle])
            {
                end = middle - 1;
            }
            else if (ElementToLookFor > array[middle])
            {
                start = middle + 1;
            }
            else
            {
                return middle;
            }
        }
        return -1;
    }

}