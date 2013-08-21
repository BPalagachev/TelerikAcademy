namespace FigureAPI
{
    using System;

    public struct Size
    {
        public Size(double width, double height) : this()
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; private set; }

        public double Height { get; private set; }

        /// <summary>
        /// Calculates the surrounding rectangle (minimal bounded box) of a figure, given its width and height and angle of rotation
        /// </summary>
        /// <param name="figureSize">Object containing the width and height of a figure</param>
        /// <param name="rotationAngle">Rotation angle in radians</param>
        /// <returns>The size of he surrounding figure</returns>
        /// <remarks>For aditional information on the subject http://stackoverflow.com/questions/9971230/calculate-rotated-rectangle-size-from-known-bounding-box-coordinates </remarks>
        public static Size CalculateSizeOfSurroundingQuadratic(Size figureSize, double rotationAngleInRad)
        {
            double widthProjectionOnX = Math.Abs(Math.Cos(rotationAngleInRad)) * figureSize.Width;
            double widthProjectionOnY = Math.Abs(Math.Sin(rotationAngleInRad)) * figureSize.Width;

            double heightProjectionOnX = Math.Abs(Math.Cos(rotationAngleInRad)) * figureSize.Height;
            double heightProjectionOnY = Math.Abs(Math.Sin(rotationAngleInRad)) * figureSize.Height;

            double surroundingQuadraticWidth = widthProjectionOnX + heightProjectionOnY;
            double surroundingQuadraticHeight = widthProjectionOnY + heightProjectionOnX;

            return new Size(surroundingQuadraticWidth, surroundingQuadraticHeight);
        }
    }
}
