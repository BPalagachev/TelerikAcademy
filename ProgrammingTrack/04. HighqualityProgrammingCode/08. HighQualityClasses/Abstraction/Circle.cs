using System;

namespace Abstraction
{
    class Circle : Figure
    {
        public double Radius { get; protected set; }

        public Circle(double radius)
            : base()
        {
            if (radius < 0)
            {
                throw new ArgumentOutOfRangeException("A circle cannot have negative value for radius!");
            }

            this.Radius = radius;
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
