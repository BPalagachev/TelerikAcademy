using System;
using System.Text;
using System.Threading;
using System.Globalization;

class QuadraticEquation
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        double D = b * b - 4 * a * c;

        if (D > 0)
        {
            double x1 = (-b + Math.Sqrt(D)) / (2 * a);
            double x2 = (-b - Math.Sqrt(D)) / (2 * a);
            Console.WriteLine("Equation has two real roots: x1 = {0:F2}, x2 = {1:F2}", x1, x2);
        }
        else if (D == 0)
        {
            double x = (-b) / (2 * a);
            Console.WriteLine("The equation has one real root: x = {0:F2}", x);
        }
        else
        {
            Console.WriteLine("No real roots");
        }
    }
}