using System;
using System.Text;
using System.Threading;
using System.Globalization;

class Number1ToN
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int n;
        do
        {
            Console.WriteLine("Input possitive number n: ");
            n = int.Parse(Console.ReadLine());
        }
        while (n <= 0);

        Console.WriteLine("Numbers in [1..n]:");
        for (int i = 1; i <=n; i++)
        {
            Console.WriteLine(i);
        }


    }
}