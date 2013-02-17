using System;

class SwapMultipleBitsV2
{
    static void Main()
    {
        // Assuming valid input data 
        uint number = 56u;
        int pos1 = 3;           // Start position
        int pos2 = 7;           // Target position
        
        int numberOfBits = 3;   // Number of bit to be swaped

        Console.WriteLine("{0}  - > {1}", Convert.ToString(number, 2).PadLeft(32, '0'), number);
        for (int i = 0; i < numberOfBits; i++)
        {
            number = swapBits(number, pos1+i, pos2+i);
        }
        Console.WriteLine("{0}  - > {1}", Convert.ToString(number, 2).PadLeft(32, '0'), number);
    }
    public static uint setBit(uint number, uint value, int pos)
    {
        if (value == 1)
        {
            return number | (uint)(1 << pos);
        }
        else
        {
            return number & (uint)(~(1 << pos));
        }
    }

    public static uint swapBits(uint number, int posBit1, int posBit2)
    {
        // Construct needed masks
        int maskPos1 = (1 << posBit1);
        int maskPos2 = (1 << posBit2);
        // Get values of the bits in the given positions
        uint valBit1 = ((number & (uint)maskPos1) != 0u) ? 1u : 0u;
        uint valBit2 = ((number & (uint)maskPos2) != 0u) ? 1u : 0u;
        // use setBit to swap(reset) their values: value 1 -> position 2 
        number = setBit(number, valBit1, posBit2);
        number = setBit(number, valBit2, posBit1);
        return number;
    }
}