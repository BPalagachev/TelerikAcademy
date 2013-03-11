namespace _01.Geometrics
{
    public abstract class Shape : ISurficable
    {
        public Shape(int aWidth, int aHeight)
        {
            this.Width = aWidth;
            this.Height = aHeight;
        }

        public virtual int Width { get; private set; }

        public int Height { get; private set; }

        public abstract double CalculateSurface();
    }
}
