using System;
using System.Text;
using System.Threading;
using System.Globalization;

class SumAlternatingSequence
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        double sum = 1.0d;
        double sum_pre = 0.0d;
        int sign = 1;
        double denum = 2.0d;
        while (true)
        {
            sum = sum + (1 / denum) * sign;
            if (Math.Abs(sum-sum_pre) < 0.001) break;
            denum++;
            sign *= -1;
            sum_pre = sum;
        }
        Console.WriteLine(sum);
    }
}
