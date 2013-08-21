namespace FigureAPI
{
    using System;

    public abstract class Figure
    {
        public Size Size { get; private set; }

        protected Figure( Size size)
        {
            this.Size = size;
        }
    }
}

