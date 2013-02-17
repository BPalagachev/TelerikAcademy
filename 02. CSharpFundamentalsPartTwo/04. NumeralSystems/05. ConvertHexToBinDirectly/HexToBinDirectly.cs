// Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;
using System.Collections.Generic;

class HexToBinDirectly
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter hex number: ");
        List<byte> hexRepresentation = ReadHexNumber(Console.ReadLine());
        Console.WriteLine("Binary: ");
        List<byte> binaryRepresentation = ConvertHexToBinDirectly(hexRepresentation);
        DisplayBinaryRepresentation(binaryRepresentation);

    }
    static List<byte> ReadHexNumber(string hexNumber)
    {
        List<byte> hexRepresentation = new List<byte>();
        for (int i = hexNumber.Length - 1; i >= 0; i--)
        {
            byte digit = new byte();
            switch (hexNumber[i])
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    digit = (byte)(hexNumber[i] - (byte)'0');
                    break;
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                    digit = (byte)(hexNumber[i] - ('A' - (char)10));
                    break;
                default:
                    break;

            }

            hexRepresentation.Add(digit);
        }

        return hexRepresentation;
    }

    static List<byte> ConvertHexToBinDirectly(List<byte> hexRepresentation)
    {
        List<byte> BinaryRepresentation = new List<byte>();
        for (int i = 0; i < hexRepresentation.Count; i++)
        {
            switch (hexRepresentation[i])
            {
                case 0:
                    AddBits(BinaryRepresentation, "0000");
                    break;
                case 1:
                    AddBits(BinaryRepresentation, "0001");
                    break;
                case 2:
                    AddBits(BinaryRepresentation, "0010");
                    break;
                case 3:
                    AddBits(BinaryRepresentation, "0011");
                    break;
                case 4:
                    AddBits(BinaryRepresentation, "0100");
                    break;
                case 5:
                    AddBits(BinaryRepresentation, "0101");
                    break;
                case 6:
                    AddBits(BinaryRepresentation, "0110");
                    break;
                case 7:
                    AddBits(BinaryRepresentation, "0111");
                    break;
                case 8:
                    AddBits(BinaryRepresentation, "1000");
                    break;
                case 9:
                    AddBits(BinaryRepresentation, "1001");
                    break;
                case 10:
                    AddBits(BinaryRepresentation, "1010");
                    break;
                case 11:
                    AddBits(BinaryRepresentation, "1011");
                    break;
                case 12:
                    AddBits(BinaryRepresentation, "1100");
                    break;
                case 13:
                    AddBits(BinaryRepresentation, "1101");
                    break;
                case 14:
                    AddBits(BinaryRepresentation, "1110");
                    break;
                case 15:
                    AddBits(BinaryRepresentation, "1111");
                    break;
                default:
                    break;
            }
        }
        return BinaryRepresentation;
    }
    static void AddBits( List<byte> BinaryRepresentation, string bits)
    {
        char[] bitReversed = bits.ToCharArray();
        Array.Reverse(bitReversed);
        for (int i = 0; i < bitReversed.Length; i++)
        {
            BinaryRepresentation.Add((byte)(bitReversed[i] - '0'));
        }
    }
    static void DisplayBinaryRepresentation(List<byte> binaryRepresentation)
    {
        for (int i = binaryRepresentation.Count-1; i >= 0; i--)
        {
            Console.Write(binaryRepresentation[i]);
        }
        Console.WriteLine();
    }
}