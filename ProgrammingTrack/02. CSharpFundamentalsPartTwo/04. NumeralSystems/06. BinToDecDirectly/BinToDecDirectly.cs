// Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;
using System.Collections.Generic;


class BinToDecDirectly
{
    static void Main(string[] args)
    {
        List<byte> binaryRepresentation = new List<byte>();
        Console.WriteLine("Enter binary number: ");
        binaryRepresentation = ReadBinaryRepresentation(Console.ReadLine());
        List<byte> hexRepresentation = ConvertBinToHecDirectly(binaryRepresentation);
        DisplayHexRepresentation(hexRepresentation);
        //DisplayBinaryRepresentation(binaryRepresentation);
    }
    static List<byte> ReadBinaryRepresentation(string binNum)
    {
        List<byte> binaryRepresentation = new List<byte>();
        char[] bitReversed = binNum.ToCharArray();
        Array.Reverse(bitReversed);
        for (int i = 0; i < bitReversed.Length; i++)
        {
            binaryRepresentation.Add((byte)(bitReversed[i] - '0'));
        }
        return binaryRepresentation;
    }
    static void DisplayBinaryRepresentation(List<byte> binaryRepresentation)
    {
        for (int i = binaryRepresentation.Count - 1; i >= 0; i--)
        {
            Console.Write(binaryRepresentation[i]);
        }
        Console.WriteLine();
    }
    static List<byte> ConvertBinToHecDirectly(List<byte> binaryRepresentation)
    {
        List<byte> hexRepresentation = new List<byte>();
        for (int i = 0; i < binaryRepresentation.Count; i = i + 4)
        {
            List<byte> temp = new List<byte>();
            for (int j = i; j < i + 4; j++)
            {

                if (j < binaryRepresentation.Count)
                {
                    temp.Add(binaryRepresentation[j]);
                }
            }
            int hexNumber = 0;
            for (int k = temp.Count-1; k >=0; k--)
            {
                hexNumber += temp[k] * (1 << k);
            }
            hexRepresentation.Add((byte)hexNumber);
        }
        return hexRepresentation;
    }
    static void DisplayHexRepresentation(List<byte> hexNumber)
    {
        for (int i = hexNumber.Count - 1; i >= 0; i--)
        {
            char symbol = new char();
            switch (hexNumber[i])
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    symbol = (char)(hexNumber[i] + (byte)'0');
                    break;
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    symbol = (char)(hexNumber[i] + (byte)('A' - (char)10));
                    break;
                default:
                    break;

            }

            Console.Write(symbol);
        }
        Console.WriteLine();
    }
}