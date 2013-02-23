using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    // Task 3 - Write a static class that with static method to calculate the distance between two points in 3D space
    public static class Colculation3D
    {
        public static double CalculateDistance(Point3D A, Point3D B)
        {
            return Math.Sqrt(Math.Pow((A.CoordX - B.CoordX), 2)
                + Math.Pow((A.CoordY - B.CoordY), 2)
                + Math.Pow((A.CoordZ - B.CoordZ), 2));
        }
    }
}
