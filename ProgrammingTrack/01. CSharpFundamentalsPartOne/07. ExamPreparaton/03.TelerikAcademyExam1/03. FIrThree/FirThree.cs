using System;
using System.Text;
using System.Threading;
using System.Globalization;

class FirThree
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int N = int.Parse(Console.ReadLine());
        int rowLength = 2 * N - 2 - 1;
        int center = rowLength / 2 + 1;
        for (int rows = 0; rows < N-1; rows++)
        {
            for (int cols = 1; cols <= rowLength; cols++)
            {
                if ( (cols >= (center - rows)) && (cols <= (center + rows)) )
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
        for (int i = 1; i <= rowLength; i++)
        {
            if (i != center)
            {
                Console.Write(".");
            }
            else
            {
                Console.Write("*");
            }
        }
    }
}