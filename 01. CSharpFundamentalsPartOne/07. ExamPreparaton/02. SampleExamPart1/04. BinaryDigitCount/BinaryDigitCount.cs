using System;
using System.Text;
using System.Threading;
using System.Globalization;

class BinaryDigitCount
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        byte B = byte.Parse(Console.ReadLine());
        ushort N = ushort.Parse(Console.ReadLine());
        uint[] numbers = new uint[N];
        uint mask = 1;
        int counter = 0;
        int mostSignificantBitPosition = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = uint.Parse(Console.ReadLine());
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            counter = 0;
            mostSignificantBitPosition = 0;
            for (int j = 0; j < 32; j++)
            {
                if ((numbers[i] & (mask << j)) != 0)
                {
                    counter++;
                    mostSignificantBitPosition = j+1;
                }
            }
            if (B>0)
            {
                Console.WriteLine(counter);
            }
            else
            {
                Console.WriteLine(mostSignificantBitPosition - counter);
            }
        }


    }
}