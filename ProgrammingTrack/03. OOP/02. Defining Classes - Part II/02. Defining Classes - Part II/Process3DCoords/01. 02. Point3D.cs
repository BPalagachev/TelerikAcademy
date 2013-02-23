using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public struct Point3D : IComparable
    {
        // task 3 - create static read-only field to hold the start of the coordinate system
        private static Point3D coordinateStart = new Point3D { CoordX = 0, CoordY = 0, CoordZ = 0 };
        public static Point3D CoordinateStart
        {
            get
            {
                return coordinateStart;
            }
        }
        // task 1 
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public int CoordZ { get; set; }

        // task 1
        public override string ToString()
        {
            return String.Format("[{0}, {1}, {2}]", CoordX, CoordY, CoordZ);
        }
        
        // Task 7 - optional


        public int CompareTo(object Point)
        {
            Point3D PointB = (Point3D)Point;
            double moduleOfPointA = Math.Sqrt(
                this.CoordX * this.CoordX
                + this.CoordY * this.CoordY
                + this.CoordZ * this.CoordZ);
            double moduleOfPointB = Math.Sqrt(
                PointB.CoordX * PointB.CoordX
                + PointB.CoordY * PointB.CoordY
                + PointB.CoordZ * PointB.CoordZ);
            if (moduleOfPointA < moduleOfPointB)
            {
                return -1;
            }
            else if (moduleOfPointA > moduleOfPointB)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
