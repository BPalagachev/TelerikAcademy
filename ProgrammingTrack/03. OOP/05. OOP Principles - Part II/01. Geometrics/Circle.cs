namespace _01.Geometrics
{
    public class Circle : Shape
    {
        public Circle(int aWidth)
            : base(aWidth, aWidth)
        {
        }

        public override double CalculateSurface()
        {
            return System.Math.PI * this.Width * this.Width;
        }
    }
}
