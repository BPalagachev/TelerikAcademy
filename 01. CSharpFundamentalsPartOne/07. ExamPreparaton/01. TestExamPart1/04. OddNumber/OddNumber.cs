using System;
using System.Globalization;
using System.Text;
using System.Threading;

class OddNumber
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int N = int.Parse(Console.ReadLine());
        long[] numbers = new long[N];
        long tempNumber;
        int counter = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = long.Parse(Console.ReadLine());
        }

        Array.Sort(numbers);
        tempNumber = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (tempNumber == numbers[i])
            {
                counter++;
            }
            else
            {
                if (counter % 2 != 0)
                {
                    Console.WriteLine(tempNumber);
                    return;
                }
                counter = 1;
                tempNumber = numbers[i];
            }

        }
        if (counter % 2 != 0)
        {
            Console.WriteLine(tempNumber);
            return;
        }


    }
}