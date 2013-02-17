using System;
using System.Text;
using System.Threading;
using System.Globalization;

class SubsetSums
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        long S = long.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        long[] set = new long[N];
        long counterOfSums = 0;
        long sumOfSubset = 0;

        for (int i = 0; i < N; i++)
        {
            set[i] = long.Parse(Console.ReadLine());
        }

        for (int i = 1; i <= Math.Pow(2,N)-1; i++)
        {
            sumOfSubset = 0;
            for (int j = 0; j < set.Length; j++)
            {
                if ((i & 1 << j) != 0)
                {
                    sumOfSubset += set[j];
                }
                
            }
            if (sumOfSubset == S)
            {
                counterOfSums++;
            }
        }
        Console.WriteLine(counterOfSums);

    }
}