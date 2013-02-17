// Write a program that finds all prime numbers in the range [1...10 000 000]. 
// Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

using System;

class Eratosthenes
{
    static void Main()
    {
        bool[] isNotPrime = new bool[10000000];

        for (int i = 2; i < isNotPrime.Length; i++)
        {
            //Console.Write("{0}%   ", (i*100)/isNotPrime.Length);
            if (isNotPrime[i] == false)
            {
                for (int j = i+1; j < isNotPrime.Length; j++)
                {
                    if (j % i == 0)
                    {
                        isNotPrime[j] = true;
                    }
                }
            }
        }

        for (int i = 0; i < isNotPrime.Length; i++)
        {
            if (isNotPrime[i] == false)
            {
                Console.WriteLine(i);
            }
        }
    }
}

