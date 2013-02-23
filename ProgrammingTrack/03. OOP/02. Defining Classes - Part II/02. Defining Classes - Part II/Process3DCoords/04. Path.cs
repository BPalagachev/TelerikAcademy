using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    // Task 4 - Create a class Path to hold a sequence of points in the 3D space.
    public class Path
    {
        private List<Point3D> pathOfPoints;

        public List<Point3D> PathOfPoints
        {
            get
            {
                return this.pathOfPoints;
            }
        }

        public Path()
        {
            pathOfPoints = new List<Point3D>();
        }

        public void Add(Point3D newPoint)
        {
            pathOfPoints.Add(newPoint);
        }
        public void Remove(Point3D pointToRemove)
        {
            pathOfPoints.Remove(pointToRemove);
        }
        public void ClearPath()
        {
            pathOfPoints.Clear();
        }

        public override string ToString()
        {
            if (this.pathOfPoints.Count == 0)
            {
                return "No points in this path!";
            }
            StringBuilder pathTextRepresentation = new StringBuilder();
            StringFormater.IsIndent = false;
            StringFormater.LineLength = 50;
            string title = "A path from " + pathOfPoints[0].ToString() + " to " + pathOfPoints[pathOfPoints.Count - 1];
            pathTextRepresentation.Append(StringFormater.CenterTitle(title) + "\n\r");
            for (int i = 0; i < pathOfPoints.Count; i++)
			{
                pathTextRepresentation.Append(StringFormater.FormatLine<string>(
                    String.Format("point {0}", i), pathOfPoints[i].ToString()));			 
			}
            return pathTextRepresentation.ToString();
        }
    }
}
