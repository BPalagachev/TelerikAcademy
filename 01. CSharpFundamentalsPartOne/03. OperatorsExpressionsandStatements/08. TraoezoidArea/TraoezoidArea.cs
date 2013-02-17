using System;

class TraoezoidArea
{
    static void Main()
    {
        double a = 5.0;
        double b = 7.0;
        double h = 8.0;
        double area = (h / 2) * (a + b);
        Console.WriteLine("The area of a Traoezoid with a = {0}, b = {1} and h = {2} is: {3} square units", a, b, h, area);
    }
}