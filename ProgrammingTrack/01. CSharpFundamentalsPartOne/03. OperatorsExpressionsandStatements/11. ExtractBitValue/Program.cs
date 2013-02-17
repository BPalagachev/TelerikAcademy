using System;

class ExtractBitValue
{
    static void Main()
    {
        int i = 5;
        int b = 0;
        int mask = (1 << b);
        short bitValue = 0;
        if ((i & mask) != 0)
        {
            bitValue = 1;
        }
        Console.WriteLine("i = {0}; b = {1} -> value = {2}", i, b, bitValue);
    }
}