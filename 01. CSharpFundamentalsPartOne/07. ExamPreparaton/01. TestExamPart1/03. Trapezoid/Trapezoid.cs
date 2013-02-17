using System;
using System.Globalization;
using System.Text;
using System.Threading;

class Trapezoid
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int N = int.Parse(Console.ReadLine());
        int side = N - 1;

        for (int i = 0; i < N; i++)
        {
            Console.Write(".");
        }
        for (int i = 0; i < N; i++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
        for (int i = 1; i < N; i++)
        {
            for (int j = 0; j < 2 * N; j++)
            {
                if (j == side || j == 2 * N - 1)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            side--;
        }
        for (int i = 0; i < 2 * N; i++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
    }
}