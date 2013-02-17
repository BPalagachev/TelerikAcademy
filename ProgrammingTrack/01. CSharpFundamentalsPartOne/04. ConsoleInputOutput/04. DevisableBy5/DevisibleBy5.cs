using System;
using System.Globalization;
using System.Text;
using System.Threading;

class DevisibleBy5
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("Assign Interval [a,b]");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        if (a < 0 || b < 0)
        {
            Console.WriteLine("Arguments out of range");
        }
        else
        {
            int range = Math.Abs(a - b);
            int devisibleBy5 = range / 5;
            Console.WriteLine("There are {0} integer numbers devisible by 5 in [a,b]", (b%5!=0) ? devisibleBy5:(devisibleBy5+1));
            //Console.WriteLine("There are {0} integer numbers devisible by 5 in [a,b]", devisibleBy5);

        }
    }
}