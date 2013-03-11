namespace _01.Geometrics
{
    public class Triangle : Shape
    {
        public Triangle(int aWidth, int aHeight)
            : base(aWidth, aHeight)
        {
        }

        public override double CalculateSurface()
        {
            return this.Height * this.Width / 2.0d;
        }
    }
}
