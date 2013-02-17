using System;
using System.Text;
using System.Threading;
using System.Globalization;

class CirclePerimeterArea
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("Enter the radius of the circle: ");
        double radius = double.Parse(Console.ReadLine());

        double perimeter = 2 * Math.PI * radius;
        double area = Math.PI * Math.PI * radius;
        Console.WriteLine("The perimeter of the circle is: {0,10:F4}", perimeter);
        Console.WriteLine("The aera of the circle is: {0,15:F4}", area);
    }
}