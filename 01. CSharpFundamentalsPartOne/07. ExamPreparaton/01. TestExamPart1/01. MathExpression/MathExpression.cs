using System;
using System.Globalization;
using System.Text;
using System.Threading;

class MathExpression
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        double N = double.Parse(Console.ReadLine());
        double M = double.Parse(Console.ReadLine());
        double P = double.Parse(Console.ReadLine());
        double result;

        if (M * P == 0 || (N - 128.523123123 * P) == 0)
        {
            return;
        }
        result = ((N * N + (1 / (M * P)) + 1337.0) / (N - (double)128.523123123 * P)) + Math.Sin((int)(M % 180.0));
        Console.WriteLine("{0:f6}", result);
    }
}