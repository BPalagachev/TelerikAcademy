using System;

class SwapMultipleBits
{
    static void Main()
    {
        uint n = (uint)Convert.ToInt32("00000101000000000000000000010000", 2);
        Console.WriteLine("{0}  - > {1}", Convert.ToString(n, 2).PadLeft(32, '0'), n);

        uint maskFirstThreeBits = (uint)(7 << 3);
        uint firstThreeBits = n & maskFirstThreeBits;         // get the values of the first three bit sequence
        firstThreeBits = (uint)(firstThreeBits << 21);        // move the first three bit sequence to desired location (pos 24)
        n = (uint)(n & (uint)(~maskFirstThreeBits));          // set the first three bit sequence (in n) to zero

        uint maskSecondThreeBits = (uint)(7 << 24);
        uint secondThreeBits = n & maskSecondThreeBits;       // get the values of the second three bit sequence
        secondThreeBits = (uint)(secondThreeBits >> 21);      // move the second three bit sequence to desired location (pos 3)
        n = (uint)(n & (uint)(~maskSecondThreeBits));         // set the second three bi sequencet (in n) to zero

        // form the new number n
        n = (uint)(n | firstThreeBits);
        n = (uint)(n | secondThreeBits);
        Console.WriteLine("{0}  - > {1}", Convert.ToString(n, 2).PadLeft(32, '0'), n);
    }
}