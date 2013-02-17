// Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).

using System;

class UnsignedShort
{
    static void Main(string[] args)
    {
        Console.Write("Dec number: ");
        short dec = short.Parse(Console.ReadLine());
        byte[] bin = ConvertDecToBin(dec);
        Console.WriteLine("The Binary representation of the 16 bit number is: ");
        DisplayBinaryRepresentation(bin);
    }
    static byte[] ConvertDecToBin(short number)
    {
        byte[] binaryRepresentation = new byte[16];
        if (number < 0)
        {
            number = (short)(short.MaxValue + number + 1);
            binaryRepresentation[15] = 1;
        }

        int position = 0;
        while (position < 15)
        {
            if ((number & 1) != 0)
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
        for (int i = binaryRepresentation.Length - 1; i >= 0; i--)
        {
            if ((i+1)%4==0)
            {
                Console.Write(" ");
            }
            Console.Write(binaryRepresentation[i]);
        }
        Console.WriteLine();
    }
}