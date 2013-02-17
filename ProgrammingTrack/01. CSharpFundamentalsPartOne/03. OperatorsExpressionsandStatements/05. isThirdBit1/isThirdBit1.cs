using System;

class isThirdBit1
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine()); // 15 is 1111 binary -> so true; 
                                                       // 7 is 0111 binary -> so false 
        int mask = 8;       // 8 = 1000 binary
        bool isOne = ((number & mask) != 0);
        Console.WriteLine("The third bit(counting from zero) in {0} is 1! -> {1}", number, isOne);
    }
}