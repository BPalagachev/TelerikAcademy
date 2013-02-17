using System;

class isPrime
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        bool isPrime = true;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                isPrime = false;
                break;
            }
        }
        if (n == 1) isPrime = false;
        Console.WriteLine(isPrime);
    }
}