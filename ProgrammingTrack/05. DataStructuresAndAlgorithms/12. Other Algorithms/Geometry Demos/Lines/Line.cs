using System;

namespace Lines
{
    class Line
    {
        public Point A { get; set; }
        public Point B { get; set; }

        public Line(Point a, Point b)
        {
            this.A = a;
            this.B = b;
        }

        public double Distance(Point a, Point b)
        {
            double dist = Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
            return dist;
        }
    }
}
