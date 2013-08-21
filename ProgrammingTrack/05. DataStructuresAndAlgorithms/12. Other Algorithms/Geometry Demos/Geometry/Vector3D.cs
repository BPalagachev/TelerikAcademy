using System;

namespace Geometry
{
    class Vector3D
    {
        private double x;
        private double y;
        private double z;

        public double X
        {
            get
            {
                return this.x;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }
        }

        public double Z
        {
            get
            {
                return this.z;
            }
        }

        public double Length
        {
            get
            {
                double result = Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
                return result;
            }
        }

        public Vector3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3D operator +(Vector3D first, Vector3D second)
        {
            double resultX = first.X + second.X;
            double resultY = first.Y + second.Y;
            double resultZ = first.Z + second.Z;
            Vector3D result = new Vector3D(resultX, resultY, resultZ);

            return result;
        }

        public static Vector3D operator -(Vector3D first, Vector3D second)
        {
            double resultX = first.X - second.X;
            double resultY = first.Y - second.Y;
            double resultZ = first.Z - second.Z;
            Vector3D result = new Vector3D(resultX, resultY, resultZ);

            return result;
        }

        public double DotProduct(Vector3D other)
        {
            double result = this.X * other.X + this.Y * other.Y + this.Z * other.Z;
            return result;
        }

        public Vector3D CrossProduct(Vector3D other)
        {
            double resultX = this.Y * other.Z - this.Z * other.Y;
            double resultY = this.Z * other.X - this.X * other.Z;
            double resultZ = this.X * other.Y - this.Y * other.X;
            Vector3D result = new Vector3D(resultX, resultY, resultZ);

            return result;
        }

        public override string ToString()
        {
            string result = string.Format("({0}, {1}, {2})", this.X, this.Y, this.Z);
            return result;
        }
    }
}
