using System;

class RectangleArea
{
    static void Main()
    {
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());
        double area = height * width;
        Console.WriteLine("Rectangle area is: {0}.", area);
    }
}
