using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class PathStorage
    {
        public static Path ReadPathFromFile(string pathToFile)
        {
            Path newPath = new Path();
            StreamReader reader = new StreamReader(pathToFile);
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] pointCoords = line.Split(new char[]{']', ' ', '[', ','}, StringSplitOptions.RemoveEmptyEntries );
                    for (int i = 0; i < pointCoords.Length; i+=3)
                    {
                        newPath.Add(new Point3D()
                        {
                            CoordX = int.Parse(pointCoords[i]), 
                            CoordY = int.Parse(pointCoords[i+1]),
                            CoordZ = int.Parse(pointCoords[i+2])
                        });
                    }
                    line = reader.ReadLine();
                }
            }
            return newPath;
        }

        public static void WritePathToFile(Path pathToSave, string pathToFile)
        {
            StreamWriter writer = new StreamWriter(pathToFile);
            using (writer)
            {
                List<Point3D> pathOfPoints = pathToSave.PathOfPoints;
                foreach (var point in pathToSave.PathOfPoints)
                {
                    writer.Write(point.ToString());
                }
            }
        }
    }
    
}
