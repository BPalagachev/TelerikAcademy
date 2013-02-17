using System;

class BitModifier
{
    static void Main()
    {
        int n = 5;
        int maskedN;
        int v = 0;
        int p = 2;
        int mask = (1 << p);
        if (v == 1)
        {
            maskedN = n | mask;
        }
        else
        {
            maskedN = n & (~mask);
        }
        Console.WriteLine("n = {0} ({1}), p = {2} , v = {3} - > {4}({5})", n, Convert.ToString(n, 2).PadLeft(8, '0'), p, v, maskedN, Convert.ToString(maskedN, 2).PadLeft(8, '0'));
    }
}