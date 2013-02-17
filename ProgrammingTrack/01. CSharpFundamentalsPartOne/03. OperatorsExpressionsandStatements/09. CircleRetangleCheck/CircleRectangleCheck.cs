using System;

class CircleRectangleCheck
{
    static void Main()
    {
        double x = 1.5;
        double y = 0;
        bool isWithinCicle = ((Math.Pow((x - 1), 2) + Math.Pow((y - 1), 2)) < Math.Pow(3, 2));
        bool isWithinRectangle = (x > 1) && (x < 7) && (y < -1) && (y > -3);
        bool circleAndNotRect = isWithinCicle && !isWithinRectangle;
        Console.WriteLine("Point({0},{1}) is within the given circle and is not within the rectangle! -> {2}", x, y, circleAndNotRect);
    }
}