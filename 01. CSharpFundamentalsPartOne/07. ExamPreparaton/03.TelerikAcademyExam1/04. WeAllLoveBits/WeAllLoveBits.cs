using System;
using System.Text;
using System.Threading;
using System.Globalization;

class WeAllLoveBits
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int pInversed;
        int pReversed;

        int n = int.Parse(Console.ReadLine());
        int[] p = new int[n];
        int[] pNew = new int[n];

        for (int i = 0; i < p.Length; i++)
        {
            p[i] = int.Parse(Console.ReadLine());
            pInversed=~p[i];
            pReversed=bitReverser(p[i]);
            pNew[i] = (p[i] ^ pInversed) & pReversed;
        }
        for (int i = 0; i < pNew.Length; i++)
        {
            Console.WriteLine(pNew[i]);
        }
    }
    static int bitReverser(int word)
    {
        int mask = 1;
        int tempMask; // used for swaping bits
        int reversedWord = 0;
        int MSBIndex = 0;

        for (int i = 0; i < 31; i++)
        {
            if ((word & mask << i) != 0)
            {
                MSBIndex = i;
            }
        }
        for (int i = MSBIndex, j = 0; i >= 0; i--, j++)
        {
            tempMask = word & (mask << i);
            tempMask = tempMask >> i;
            tempMask = tempMask << j;
            reversedWord = reversedWord | tempMask;

        }
        return reversedWord;
    }
}