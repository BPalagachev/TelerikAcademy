using System;
using System.Text;
using System.Threading;
using System.Globalization;

class SumNMoreNumbers
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int sum;
        int n;
        do
        {
            Console.WriteLine("Input possitive number n:");
            n = int.Parse(Console.ReadLine());
            sum = n;
        }
        while (sum <= 0);
        for (int i = 0; i < n; i++)
        {
            sum += int.Parse(Console.ReadLine());
        }
        Console.WriteLine("The sum is: {0} ", sum);
    }
}