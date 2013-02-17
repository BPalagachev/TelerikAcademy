using System;

class NotDevisibleBy3And7
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        for (int i = 1; i <= N; i++)
        {
            if (i%7 == 0 && i%3 == 0)
            {
                continue;
            }
            Console.WriteLine(i);
        }
    }
}