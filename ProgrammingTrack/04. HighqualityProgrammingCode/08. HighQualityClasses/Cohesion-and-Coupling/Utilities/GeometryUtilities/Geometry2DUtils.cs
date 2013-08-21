namespace CohesionAndCoupling.Utilities.GeometryUtilities
{
    using System;

    public static class Geometry2DUtils
    {
        public static double CalcDistance2D(Point2D firstPoint, Point2D secondPoint)
        {
            double distanceProjectedOnX = secondPoint.XCoord - firstPoint.XCoord;
            double distanceProjectedOnY = secondPoint.YCoord - firstPoint.YCoord;

            double distance = Math.Sqrt(distanceProjectedOnX * distanceProjectedOnX + distanceProjectedOnY * distanceProjectedOnY);
            return distance;
        }
    }
}
