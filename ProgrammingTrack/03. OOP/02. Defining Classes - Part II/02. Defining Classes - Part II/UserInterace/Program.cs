using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1 - create structure Point and override ToString()
            Point3D newPoint = new Point3D() { CoordX = 1, CoordY = 1, CoordZ = 1 };
            Console.WriteLine("New Point at " + newPoint.ToString());
            // Task 2 - Create static read-only field to hold the start of the coordinate system
            Console.WriteLine("Coordinate system center is at " + Point3D.CoordinateStart);
            // Task 3 - Create a static class with a static method to calculate the distance between two points in the 3D space.
            Console.WriteLine(Colculation3D.CalculateDistance(Point3D.CoordinateStart, newPoint));
            // Task 4 - Create class path to hold a sequence of points in the 3D space.
            Path newPath = new Path();
            newPath.Add(Point3D.CoordinateStart);
            newPath.Add(newPoint);
            newPath.Add(new Point3D() { CoordX = 10, CoordY = 10, CoordZ = 10 });
            newPath.Add(new Point3D() { CoordX = 100, CoordY = 100, CoordZ = 100 });
            newPath.Remove(new Point3D() { CoordX = 10, CoordY = 10, CoordZ = 10 });
            Console.WriteLine(newPath.ToString());
            // Task 4 - Create a static class PathStorage with static method to save and load paths from text file. Use a file format of your choice.
            Console.WriteLine("Printing a test file\n\r" + PathStorage.ReadPathFromFile("testFile.txt"));
            PathStorage.WritePathToFile(newPath, "newPath.txt");
            Console.WriteLine("Printing a newly created file: newPath.txt\n\r" + PathStorage.ReadPathFromFile("newPath.txt"));
            // Task 5 - Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
            // Keep the elements of the list in an array with fixed capacity which is given as parameter in the class 
            // constructor. Implement methods for adding element, accessing element by index, removing element by 
            // index, inserting element at given position, clearing the list, finding element by its value and ToString().
            // Check all input parameters to avoid accessing elements at invalid positions.
            GenericList<int> intList = new GenericList<int>();
            intList.InsertAt(0, 999);
            intList.Add(10);
            intList.Add(20);
            intList.InsertAt(3, 650);
            intList.Add(30);
            // task 6 auto-geow functionality
            intList.InsertAt(4, 4);
            intList.RemoveAt(0);
            Console.WriteLine(intList.Find(4));
            Console.WriteLine(intList.ToString());
            // task 7 - GetMin and GetMax Methods
            Console.WriteLine("Min element: " + intList.GetMin());
            Console.WriteLine("Max element: " + intList.GetMax());
            intList.ClearAll();
            Console.WriteLine(intList.ToString());
            // Generic List of Point3d (implementing IComperable)
            GenericList<Point3D> pointList = new GenericList<Point3D>();
            pointList.Add(Point3D.CoordinateStart);
            pointList.Add(newPoint);
            pointList.Add(new Point3D() { CoordX = 10, CoordY = 10, CoordZ = 10 });
            pointList.Add(new Point3D() { CoordX = 100, CoordY = 100, CoordZ = 100 });
            Console.WriteLine(pointList.ToString());
            Console.WriteLine("Max Value: " + pointList.GetMax());
            Console.WriteLine("Min Value: " + pointList.GetMin());
            // Task 8 - Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals).
            Matrix<int> mat1 = new Matrix<int>(2, 2);
            Matrix<int> mat2 = new Matrix<int>(2, 2);
            // Task 9 - Implement an indexer this[row, col] to access the inner matrix cells
            mat1[0, 0] = 1; mat1[0, 1] = 2; mat1[1, 0] = 3; mat1[1, 1] = 4;
            mat2[0, 0] = 1; mat2[0, 1] = 2; mat2[1, 0] = 3; mat2[1, 1] = 4;
            // Task 10 - Implement the operators + and - (addition and subtraction of matrices of the same size) 
            // and * for matrix multiplication. Throw an exception when the operation cannot be performed. 
            // Implement the true operator (check for non-zero elements).
            Console.WriteLine(mat1 + mat2);
            Console.WriteLine(mat1 - mat2);
            // Task 10 - Testing multiplying
            mat1 = new Matrix<int>(2, 3);
            mat1[0, 0] = 1; mat1[0, 1] = 2; mat1[0, 2] = 3;
            mat1[1, 0] = 4; mat1[1, 2] = 5; mat1[1, 2] = 6;

            mat2 = new Matrix<int>(3, 2);
            mat2[0, 0] = 1; mat2[0, 1] = 2;
            mat2[1, 0] = 3; mat2[1, 1] = 4;
            mat2[2, 0] = 5; mat2[2, 1] = 6;
            Console.WriteLine(mat1*mat2);
            // Task 10 - Override true operator
            if (mat2)
            {
                Console.WriteLine("Mat2 has elements diferent than zero!");
            }
            else
            {
                Console.WriteLine("Mat2 is a zero matrix!");
            }
            Matrix<int> zeroMatrix = new Matrix<int>(1, 2);
            if (zeroMatrix)
            {
                Console.WriteLine("zeroMatrix has elements diferent than zero!");
            }
            else
            {
                Console.WriteLine("zeroMatrix is a zero matrix!");
            }
            // Task 11 - Create a [Version] attribute that can be applied to structures, 
            // classes, interfaces, enumerations and methods and holds a version in the 
            // format major.minor (e.g. 2.11). Apply the version attribute to a sample class 
            // and display its version at runtime.

            Type type = typeof(Matrix<>);
            object[] allAttributes = type.GetCustomAttributes(false);
            Console.WriteLine(String.Format("Version: {0}.{1}", ((VersionAttribute)allAttributes[0]).Major, ((VersionAttribute)allAttributes[0]).Minor));
        }
    }
}
