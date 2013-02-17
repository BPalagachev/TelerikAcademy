// Write a program to convert hexadecimal numbers to their decimal representation.

using System;
using System.Collections.Generic;


class HexToDec
{
    static void Main()
    {
        Console.Write("Your hex number: ");
        List<byte> hexNumber = ReadHexNumber(Console.ReadLine());
        int decNumber = ConvertHexToDec(hexNumber);
        Console.WriteLine("The dec number is: {0}", decNumber);
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
    static int ConvertHexToDec(List<byte> hexRepresentation)
    {
        int decNumber = 0;
        for (int i = 0; i < hexRepresentation.Count; i++)
        {
            decNumber += hexRepresentation[i] * (1 << (4 * i));
        }
        return decNumber;
    }

}