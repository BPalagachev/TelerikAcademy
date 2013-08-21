using System;
using System.Collections.Generic;

namespace Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> points = new List<Point>();

            InitializePoints(points);

            double xSum = 0;
            double ySum = 0;

            for (int i = 0; i < points.Count - 1; i++)
            {
                xSum += (points[i].X * points[i + 1].Y);
            }

            for (int i = 0; i < points.Count - 1; i++)
            {
                ySum += (points[i].Y * points[i + 1].X);
            }

            double area = (xSum - ySum) / 2;
            Console.WriteLine(area);
        }

        private static void InitializePoints(List<Point> points)
        {
            Point a = new Point(-3, -2);
            Point b = new Point(-1, 4);
            Point c = new Point(6, 1);
            Point d = new Point(3, 10);
            Point e = new Point(-4, 9);

            points.Add(a);
            points.Add(b);
            points.Add(c);
            points.Add(d);
            points.Add(e);
            points.Add(a);
        }
    }
}
