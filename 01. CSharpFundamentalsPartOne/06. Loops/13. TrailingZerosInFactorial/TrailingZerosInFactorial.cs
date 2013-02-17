using System;

class TrailingZerosInFactorial
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int counter = 0;
        int devisor = 5;
        while (N/devisor != 0)
        {
            counter += N / devisor;
            devisor *= 5;
        }
        Console.WriteLine(counter);
    }
}