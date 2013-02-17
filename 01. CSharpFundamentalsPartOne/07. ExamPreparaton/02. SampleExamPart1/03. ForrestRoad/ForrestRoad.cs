using System;
using System.Text;
using System.Threading;
using System.Globalization;

class ForrestRoad
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        byte N = byte.Parse(Console.ReadLine());
        short colIndex = 0;
        short rowIndex = 0;
        sbyte incrementor = 1;
        for (int row = 0; row < 2*N-1; row++)
        {
            for (int col = 0; col < N; col++)
            {
                
                if (row == rowIndex && col == colIndex)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            if (colIndex >= N-1 || colIndex < 0)
            {
                incrementor *= -1;
            }
            colIndex += incrementor;
            rowIndex++;
            Console.WriteLine();
        }

    }
}