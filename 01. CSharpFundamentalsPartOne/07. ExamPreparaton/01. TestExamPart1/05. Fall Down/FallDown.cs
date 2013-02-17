using System;
using System.Globalization;
using System.Text;
using System.Threading;

class FallDown
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        byte[] lines = new byte[8];
        byte mask = 1;
        byte[] counters = new byte[8];

        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = byte.Parse(Console.ReadLine());
        }

        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((lines[i] & (mask << j)) != 0)
                {
                    counters[j]++;
                }
            }
        }

        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = 0;
        }

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < counters[i]; j++)
            {
                lines[j] = SetBit(lines[j], 1, i);
            }
        }

        for (int i = lines.Length - 1; i >= 0; i--)
        {
            Console.WriteLine(lines[i]);
        }

    }
    static byte SetBit(byte word, byte value, int position)
    {
        byte mask = 1;
        if (value == 1)
        {
            word = (byte)(word | (mask << position));
            return word;
        }
        else
        {
            word = (byte)(word & ~(mask << position));
            return word;
        }
    }
}