// Write a program to convert binary numbers to their decimal representation.

using System;

class BinToDec
{
    static void Main()
    {
        Console.WriteLine("Enter 32-bit binary number starting from the MSB (31-bit): ");
        string binNum = Console.ReadLine();
        byte[] binaryRepresentation = ReadBinaryRepresentation(binNum);
        int decNum = CoverBinToDex(binaryRepresentation);
        Console.WriteLine(decNum);

    }
    static int CoverBinToDex(byte[] binaryRepresentation)
    {
        int decNumber = 0;
        for (int i = 0; i < binaryRepresentation.Length-2; i++)
        {
            decNumber +=(int) binaryRepresentation[i] * (1<<i);
        }
        if (binaryRepresentation[31] == 1)
        {
            decNumber = decNumber - int.MaxValue - 1;
        }
        return decNumber;
    }
    static byte[] ReadBinaryRepresentation(string binNum)
    {
        byte[] binaryRepresentation = new byte[32];
        int counter = 0;
        for (int i = binaryRepresentation.Length - 1; i >= 0; i--)
        {
            binaryRepresentation[counter] = (byte)(binNum[i] - '0');
            counter++;
        }
        return binaryRepresentation;
    }
}
