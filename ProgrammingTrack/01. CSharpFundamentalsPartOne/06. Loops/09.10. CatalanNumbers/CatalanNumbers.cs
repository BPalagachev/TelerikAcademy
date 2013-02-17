using System;

class CatalanNumbers
{
    static void Main()
    {
        uint N = uint.Parse(Console.ReadLine());
        for (uint i = 0; i < N; i++)
        {
            Console.WriteLine("C({0})={1}",i, calcCatalan(i));
        }
    }

    static double calcCatalan(uint N)
    {
        double catalanNumber = 1;
        for (uint i = 2; i <= N; i++)
        {
            catalanNumber *= ((double)N + i) / i;
        }
        return catalanNumber;
    }
}