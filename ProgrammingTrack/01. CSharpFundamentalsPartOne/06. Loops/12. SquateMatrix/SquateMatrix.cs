using System;

class SquateMatrix
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            for (int j = 1+i; j <= N+i; j++)
            {
                Console.Write("{0,3}", j);
            }
            Console.WriteLine();
        }
    }
}