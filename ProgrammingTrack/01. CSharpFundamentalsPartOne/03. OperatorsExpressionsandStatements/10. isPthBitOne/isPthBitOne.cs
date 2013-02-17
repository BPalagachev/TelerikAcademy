using System;

class isPthBitOne
{
    static void Main()
    {
        int v = 5;
        int p = 2;
        int mask = (1 << p);
        bool result = ((v & mask) != 0);
        Console.WriteLine("v = {0}; p = {1} -> {2}", v, p , result);
    }
}