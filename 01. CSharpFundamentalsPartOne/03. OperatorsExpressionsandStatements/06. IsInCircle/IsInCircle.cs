using System;

class IsInCircle
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double circleRadius = 5;
        bool isWithin = ((x * x + y * y) < circleRadius * circleRadius);
        Console.WriteLine("Point({0},{1}) is in the given circle! -> {2}", x, y, isWithin);
    }
}