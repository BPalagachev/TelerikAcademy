using System;

class Sequence
{
    static void Main()
    {
        int sign = 1;
        for (int i = 2; i < 2+10; i++)
        {
            Console.WriteLine(i*sign);
            sign *= -1;
        }
    }
}

