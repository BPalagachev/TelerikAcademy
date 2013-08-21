namespace CohesionAndCoupling
{
    using System;
    using CohesionAndCoupling.Utilities;
    using CohesionAndCoupling.Utilities.GeometryUtilities;

    public class UtilsExamples
    {
        private static void Main()
        {
            Console.WriteLine(FileNameUtils.GetFileExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Point2D first2DTestPoint = new Point2D { XCoord = 1, YCoord = -2 };
            Point2D second2DTestPoint = new Point2D { XCoord = 3, YCoord = 4 };
            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                Geometry2DUtils.CalcDistance2D(first2DTestPoint, second2DTestPoint));

            Point3D first3DTestPoint = new Point3D { XCoord = 5, YCoord = 3, ZCoord = -1 };
            Point3D second3DTestPoint = new Point3D { XCoord = 3, YCoord = -6, ZCoord = 4 };
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                Geometry3DUtils.CalcDistance3D(first3DTestPoint, second3DTestPoint));

            Parallelepiped testParallelepiped = new Parallelepiped(3, 4, 5);
            Console.WriteLine("Volume = {0:f2}", testParallelepiped.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", testParallelepiped.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", testParallelepiped.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", testParallelepiped.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", testParallelepiped.CalcDiagonalYZ());
        }
    }
}
