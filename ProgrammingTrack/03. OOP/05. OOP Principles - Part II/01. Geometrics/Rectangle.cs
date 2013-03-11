namespace _01.Geometrics
{
    public class Rectangle : Shape
    {
        public Rectangle(int aWidth, int aHeight)
            : base(aWidth, aHeight)
        {
        }

        public override double CalculateSurface()
        {
            return this.Height * (double)this.Width;
        }
    }
}
