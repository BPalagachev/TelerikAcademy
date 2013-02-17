using System;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Numerics;

class Tribonacci
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        BigInteger numberOne = BigInteger.Parse(Console.ReadLine());
        BigInteger numberTwo = BigInteger.Parse(Console.ReadLine());
        BigInteger numberThree = BigInteger.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());

        BigInteger tempNumber = 0;

        switch (N)
        {
            case 1:
                Console.WriteLine(numberOne);
                break;
            case 2:
                Console.WriteLine(numberTwo);
                break;
            default:
                for (int i = 0; i < N - 3; i++)
                {
                    tempNumber = numberOne + numberTwo;
                    numberOne = numberTwo;
                    numberTwo = numberThree;
                    numberThree += tempNumber;
                }
                Console.WriteLine(numberThree);
                break;
        }

    }
}