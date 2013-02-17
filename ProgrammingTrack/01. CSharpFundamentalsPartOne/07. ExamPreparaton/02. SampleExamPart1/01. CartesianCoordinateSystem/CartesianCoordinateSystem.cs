using System;
using System.Text;
using System.Threading;
using System.Globalization;

class CartesianCoordinateSystem
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        decimal xCoord = decimal.Parse(Console.ReadLine());
        decimal yCoord = decimal.Parse(Console.ReadLine());

        if (xCoord == 0.0M && yCoord == 0.0M)
        {
            Console.WriteLine("0");
        }
        else if (yCoord == 0.0M)
        {
            Console.WriteLine("6");
        }
        else if (xCoord == 0.0M)
        {
            Console.WriteLine("5");
        }
        else if (yCoord == 0.0M)
        {
            Console.WriteLine("6");
        }
        else if (xCoord > 0.0M && yCoord > 0.0M)
        {
            Console.WriteLine("1");
        }
        else if (xCoord > 0.0M && yCoord < 0.0M)
        {
            Console.WriteLine("4");
        }
        else if (xCoord < 0.0M && yCoord > 0.0M)
        {
            Console.WriteLine("2");
        }
        else if (xCoord < 0.0M && yCoord < 0.0M)
        {
            Console.WriteLine("3");
        }
    }
}