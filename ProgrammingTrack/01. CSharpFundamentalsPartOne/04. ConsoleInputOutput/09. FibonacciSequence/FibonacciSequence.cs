using System;
using System.Text;
using System.Threading;
using System.Globalization;

class FibonacciSequence
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        decimal nFirst = 0m;
        decimal nSecond = 1m;
        Console.WriteLine(nFirst);
        Console.WriteLine(nSecond);

        for (int i = 0; i < 97; i++)
        {
            decimal temp = nSecond;
            nSecond = nSecond + nFirst;
            nFirst = temp;
            Console.WriteLine(nSecond);
        }

    }
}