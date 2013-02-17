using System;

class CalculateFactorials
{
    static void Main()
    {
        int K = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        int denum = (K - N);
        int nFactorial = 1;
        int kFactorial = 1;
        int denumFactorial = 1;

        while (K > 0)
        {
            nFactorial *= K--;
            if (N > 0)
            {
                kFactorial *= N--;
            }
            if (denum > 0)
            {
                denumFactorial *= denum--;
            }
        }
        Console.WriteLine("N!/K!={0}", ((double)nFactorial * kFactorial)/denumFactorial);
    }
}