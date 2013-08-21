namespace CohesionAndCoupling
{
    using System;
    using CohesionAndCoupling.Utilities.GeometryUtilities;

    public class Parallelepiped
    {
        public Parallelepiped(double width, double height, double depth)
        {
            if (width < 0 || height < 0 || depth < 0)
            {
                throw new ArgumentOutOfRangeException("A Parallelepiped cannot have negative value for its width, height or depth!");
            }

            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width { get; protected set; }

        public double Height { get; protected set; }

        public double Depth { get; protected set; }

        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            Point3D anyCorner = new Point3D() { XCoord = 0, YCoord = 0, ZCoord = 0 };
            Point3D theOppositeCorner = new Point3D() { XCoord = this.Width, YCoord = this.Height, ZCoord = this.Depth };

            double distance = Geometry3DUtils.CalcDistance3D(anyCorner, theOppositeCorner);
            return distance;
        }

        public double CalcDiagonalXY()
        {
            Point2D cornerOnTheFace = new Point2D { XCoord = 0, YCoord = 0 };
            Point2D theOppositeCornerOnTheFace = new Point2D { XCoord = this.Width, YCoord = this.Height };

            double distance = Geometry2DUtils.CalcDistance2D(cornerOnTheFace, theOppositeCornerOnTheFace);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            Point2D cornerOnTheBase = new Point2D { XCoord = 0, YCoord = 0 };
            Point2D theOppositeCornerOnTheFace = new Point2D { XCoord = this.Width, YCoord = this.Depth };

            double distance = Geometry2DUtils.CalcDistance2D(cornerOnTheBase, theOppositeCornerOnTheFace);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            Point2D cornerOnTheSide = new Point2D { XCoord = 0, YCoord = 0 };
            Point2D theOppositeCornerOnTheSide = new Point2D { XCoord = this.Height, YCoord = this.Depth };

            double distance = Geometry2DUtils.CalcDistance2D(cornerOnTheSide, theOppositeCornerOnTheSide);
            return distance;
        }
    }
}
