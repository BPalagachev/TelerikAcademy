using System;

class NFactorialOverKFactorial
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int K = int.Parse(Console.ReadLine());
        int nFactorial = 1;
        int kFactorial = 1;

        while (N > 0)
        {
            nFactorial *= N--;
            if (K > 0)
            {
                kFactorial *= K--;
            }
        }
        Console.WriteLine("N!/K!={0}", nFactorial/kFactorial);
    }
}