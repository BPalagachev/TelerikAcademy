// Write a program that encodes and decodes a string using given encryption key (cipher).
// The key consists of a sequence of characters. The encoding/decoding is done by performing
// XOR (exclusive or) operation over the first letter of the string with the first of the 
// key, the second – with the second, etc. When the last key character is reached, the next is the first.

using System;

class Cipher
{
    static void Main()
    {
        Console.WriteLine("Text: ");
        string line = Console.ReadLine();
        Console.WriteLine("Key: ");
        string key = Console.ReadLine();
        ushort[] ciphered = new ushort[line.Length];


        // Cipher
        for (int i = 0; i < ciphered.Length; i++)
        {
            // Console.WriteLine(i % key.Length);
            ciphered[i] = (ushort)(line[i] ^ key[i%key.Length]);
        }
        // Display
        for (int i = 0; i < ciphered.Length; i++)
        {
            Console.Write((char)ciphered[i]);
            //Console.Write(@"\u{0:x4}", ciphered[i]);
        }
        Console.WriteLine();
        // Decipher
        for (int i = 0; i < ciphered.Length; i++)
        {
            ciphered[i] = (ushort)(ciphered[i] ^ key[i % key.Length]);
        }
        // Display
        for (int i = 0; i < ciphered.Length; i++)
        {
            Console.Write((char)ciphered[i]);
        }
        Console.WriteLine();

       

    }
}