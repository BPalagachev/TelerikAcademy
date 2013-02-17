// Write a program to convert decimal numbers to their binary representation.

using System;

class DecToBin
{
    static void Main(string[] args)
    {
        Console.Write("Dec number: ");
        int dec = int.Parse(Console.ReadLine());
        byte[] bin = ConvertDecToBin(dec);
        Console.WriteLine("The Binary representation of the 32 bit number is: ");
        DisplayBinaryRepresentation(bin);
    }
    static byte[] ConvertDecToBin(int number)
    {
        byte[] binaryRepresentation  = new byte[32];
        if (number < 0)
        {
            number = int.MaxValue + number +1;
            binaryRepresentation[31] = 1;
        }
        
        int position = 0;
        while (position<31)
        {
            if ((number&1)!=0)
            {
                binaryRepresentation[position] = 1;
            }
            number >>= 1;
            position++;
        }
        return binaryRepresentation;
    }
    static void DisplayBinaryRepresentation(byte[] binaryRepresentation)
    {
        for (int i = binaryRepresentation.Length-1; i >= 0; i--)
        {
            if ((i + 1) % 4 == 0)
            {
                Console.Write(" ");
            }
            Console.Write(binaryRepresentation[i]);
        }
        Console.WriteLine();
    }
}