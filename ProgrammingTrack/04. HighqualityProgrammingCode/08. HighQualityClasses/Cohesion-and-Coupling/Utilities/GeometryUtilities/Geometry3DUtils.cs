namespace CohesionAndCoupling.Utilities.GeometryUtilities
{
    using System;

    public static class Geometry3DUtils
    {
        public static double CalcDistance3D(Point3D firstPoint, Point3D secondPoint)
        {
            double distanceProjectedOnX = secondPoint.XCoord - firstPoint.XCoord;
            double distanceProjectedOnY = secondPoint.YCoord - firstPoint.YCoord;
            double distanceProjectedOnZ = secondPoint.ZCoord - firstPoint.ZCoord;

            double distance = Math.Sqrt(distanceProjectedOnX * distanceProjectedOnX +
                                        distanceProjectedOnY * distanceProjectedOnY +
                                        distanceProjectedOnZ * distanceProjectedOnZ);

            return distance;
        }
    }
}
