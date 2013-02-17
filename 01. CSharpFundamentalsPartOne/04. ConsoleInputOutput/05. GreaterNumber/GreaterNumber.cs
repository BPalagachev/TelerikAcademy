using System;
using System.Text;
using System.Threading;
using System.Globalization;

class GreaterNumber
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("The greather number is: {0}", Math.Max(a, b));
    }
}