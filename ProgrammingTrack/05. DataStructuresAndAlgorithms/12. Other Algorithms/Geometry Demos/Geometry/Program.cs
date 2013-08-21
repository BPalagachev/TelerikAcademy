using System;

namespace Geometry
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector3D first = new Vector3D(2, 4, 5);
            Vector3D second = new Vector3D(1, 3, 7);
            Console.WriteLine(first);
            Console.WriteLine("|{0}| = {1}", first, first.Length);
            Console.WriteLine(second);

            Vector3D sum = first + second;
            Vector3D subtract = first - second;
            Console.WriteLine("Sum is {0}", sum);
            Console.WriteLine("Subtract is {0}", subtract);

            double dotProduct = first.DotProduct(second);
            Console.WriteLine("Dot product is {0}", dotProduct);

            Vector3D crossProduct = first.CrossProduct(second);
            Console.WriteLine("Cross product is {0}", crossProduct);
        }
    }
}
