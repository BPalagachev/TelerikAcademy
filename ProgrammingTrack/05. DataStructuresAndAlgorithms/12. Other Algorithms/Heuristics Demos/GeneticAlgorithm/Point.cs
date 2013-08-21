using System;

namespace GeneticAlgorithm
{
    class Point
    {
        private int x;
        private int y;

        public int X
        {
            get
            {
                return this.x;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
        }

        public Point(int xValue, int yValue)
        {
            x = xValue;
            y = yValue;
        }

        public double Distance(Point p)
        {
            double diff = Math.Sqrt(Math.Pow(this.X - p.X, 2) + Math.Pow(this.Y - p.Y, 2));
            return diff;
        }

    }
}
