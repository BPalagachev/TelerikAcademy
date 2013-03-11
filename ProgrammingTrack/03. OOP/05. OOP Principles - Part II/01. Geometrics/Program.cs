using System;
using System.Collections.Generic;

namespace _01.Geometrics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IEnumerable<ISurficable> arrayOfShapes = new ISurficable[]
            {
                new Triangle(30, 10),
                new Rectangle(30, 10),
                new Circle(10),
            };
            foreach (var shape in arrayOfShapes)
            {
                Console.WriteLine(shape.CalculateSurface());
            }
        }
    }
}
