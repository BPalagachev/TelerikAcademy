using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        public double Width { get; protected set; }

        public double Height { get; protected set; }

        public Rectangle(double width, double height)
            : base()
        {
            if (width < 0 || height < 0 )
            {
                throw new ArgumentOutOfRangeException("A rectangle cannot have negative value for its width or height!"); 
            }

            this.Width = width;
            this.Height = height;
        }
        
        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
