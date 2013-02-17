using System;

class ExchangeBitSequances
{
    static void Main()
    {
        //uint n = uint.Parse(Console.ReadLine());
        int pos1 = 0;
        int pos2 = 8;
        int bitsToMove = 3;
        uint n = (uint)Convert.ToInt32("00000101000000000000010100000111", 2);
        Console.WriteLine("{0}  - > {1}", Convert.ToString(n, 2).PadLeft(32, '0'), n);

        string maskPrototype = new string('1', bitsToMove);

        uint maskFirstThreeBits = (uint)(Convert.ToInt32(maskPrototype, 2) << pos1);
        uint firstThreeBits = n & maskFirstThreeBits;                     // get the values of the first three bit sequence
        firstThreeBits = (uint)(firstThreeBits << (pos2 - pos1));         // move the first three bit sequence to desired location (pos 24)
        n = n & (~(maskFirstThreeBits));                                  // set the first three bit sequence (in n) to zero

        uint maskSecondThreeBits = (uint)(Convert.ToInt32(maskPrototype, 2) << pos2);
        uint secondThreeBits = n & maskSecondThreeBits;                  // get the values of the second three bit sequence
        secondThreeBits = (uint)(secondThreeBits >> (pos2 - pos1));      // move the second three bit sequence to desired location (pos 3)
        n = (uint)(n & (uint)(~maskSecondThreeBits));                    // set the second three bit sequence (in n) to zero


        // construct the new number n
        n = (uint)(n | firstThreeBits);
        n = (uint)(n | secondThreeBits);
        Console.WriteLine("{0}  - > {1}", Convert.ToString(n, 2).PadLeft(32, '0'), n);
    }
}