// Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).

using System;
using System.Collections.Generic;

class ConvertFromAnyToAny
{
    static void Main(string[] args)
    {
        Console.Write("Choose source numeral system base: ");
        int numeralBase = int.Parse(Console.ReadLine());
        Console.Write("Use multiple digits for every digit larger than 9 e.g. A3 in hex would be \"10 3\". Do not forget the empty space separator! Choose source number: ");
        string sourceNumberString = Console.ReadLine();
        AnyNumSystem sourceNumber = new AnyNumSystem(sourceNumberString, numeralBase);
        Console.Write("Choose destination numerial system base: ");
        int destinationBase = int.Parse(Console.ReadLine());
        AnyNumSystem destinationNumber = AnyNumSystem.ConverAnyToAny(sourceNumber, destinationBase);
        AnyNumSystem.Display(destinationNumber);

    }

}

class AnyNumSystem
{
    // Use multiple digits for every digit larger than 9 e.g. A3 in hex would be "10 3"
    private List<byte> arrayRepresentation;
    private int numeralSystemBase;

    public int NumeralSystemBase
    {
        get { return this.numeralSystemBase; }
    }

    public AnyNumSystem(List<byte> arrayRepresentation, int numBase)
    {
        this.arrayRepresentation = arrayRepresentation;
        this.numeralSystemBase = numBase;
    }
    public AnyNumSystem(string number, int numBase)
    {
        this.arrayRepresentation = AnyNumSystem.ConstructArrayRepresentation(number);
        this.numeralSystemBase = numBase;
    }

    static public int ConvertAnyToDec(AnyNumSystem number)
    {
        List<byte> anyRepresentation = number.arrayRepresentation;
        int numberBase = number.numeralSystemBase;
        int decNumber = 0;
        for (int i = 0; i < anyRepresentation.Count; i++)
        {
            decNumber += anyRepresentation[i] * (int)(Math.Pow(numberBase, i));
        }
        return decNumber;
    }
    static public AnyNumSystem ConvertDecToAny(int decNumber, int destinationBase)
    {
        List<byte> destinationNumber = new List<byte>();
        while (decNumber > 0)
        {
            destinationNumber.Add((byte)(decNumber % destinationBase));
            decNumber /= destinationBase;
        }
        return new AnyNumSystem(destinationNumber, destinationBase);
    }
    static public AnyNumSystem ConverAnyToAny(AnyNumSystem number, int destinationBase)
    {
        int decNumber = AnyNumSystem.ConvertAnyToDec(number);
        AnyNumSystem newNumSysNumber = AnyNumSystem.ConvertDecToAny(decNumber, destinationBase);
        return newNumSysNumber;
    }
    static public void Display(AnyNumSystem number)
    {
        for (int i = number.arrayRepresentation.Count - 1; i >= 0; i--)
        {
            Console.Write(number.arrayRepresentation[i] + " ");
        }
        Console.WriteLine();
    }

    static private List<byte> ConstructArrayRepresentation(string num)
    {
        List<byte> binaryRepresentation = new List<byte>();
        string[] digits = num.Split(' ');
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            binaryRepresentation.Add(byte.Parse(digits[i]));
        }
        return binaryRepresentation;
    }


}