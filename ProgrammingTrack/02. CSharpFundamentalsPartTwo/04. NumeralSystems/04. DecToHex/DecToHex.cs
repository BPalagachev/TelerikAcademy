// Write a program to convert decimal numbers to their hexadecimal representation.

using System;
using System.Collections.Generic;

class DecToHex
{
    static void Main()
    {
        Console.Write("Enter Dec Number: ");
        int decNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Its hex representation is:");
        DisplayHexNumber(ConvertDecToHex(decNumber));
    }
    static List<byte> ConvertDecToHex(int decNumber)
    {
        List<byte> hexNumber = new List<byte>();
        while (decNumber>0)
        {
            hexNumber.Add((byte)(decNumber % 16));
            decNumber /= 16;
        }
        return hexNumber;
    }
    static void DisplayHexNumber(List<byte> hexNumber)
    {
        for (int i = hexNumber.Count-1; i >= 0; i--)
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