using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTask
{
    internal class Triangle : IShape
    {
        private readonly double vertex1X;
        private readonly double vertex1Y;
        private readonly double vertex2X;
        private readonly double vertex2Y;
        private readonly double vertex3X;
        private readonly double vertex3Y;

        private readonly double Epsilon = 1.0e-10;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double straightLineEquation = (x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1);

            if (Math.Abs(straightLineEquation) <= Epsilon)
            {
                throw new ArgumentException($"Points lie on the same straight line. It is impossible to build a traingle");
            }

            vertex1X = x1;
            vertex1Y = y1;
            vertex2X = x2;
            vertex2Y = y2;
            vertex3X = x3;
            vertex3Y = y3;
        }
        public double GetArea()
        {
            return 0.5 * Math.Abs((vertex1X - vertex3X) * (vertex2Y - vertex3Y) - (vertex2X - vertex3X) * (vertex1Y - vertex3Y));
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(vertex1Y, vertex2Y), vertex3Y) - Math.Min(Math.Min(vertex1Y, vertex2Y), vertex3Y);
        }

        public double GetPerimeter()
        {
            double sideAB = Math.Sqrt(Math.Pow(vertex1X - vertex2X, 2) + Math.Pow(vertex1Y - vertex2Y, 2));
            double sideBC = Math.Sqrt(Math.Pow(vertex2X - vertex3X, 2) + Math.Pow(vertex2Y - vertex3Y, 2));
            double sideCA = Math.Sqrt(Math.Pow(vertex3X - vertex1X, 2) + Math.Pow(vertex3Y - vertex1Y, 2));

            return sideAB + sideBC + sideCA;
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(vertex1X, vertex2X), vertex3X) - Math.Min(Math.Min(vertex1X, vertex2X), vertex3X);
        }

        /// <summary>
        /// Converts to string Triangle class instance. Returns instance type (Triangle) and three sides lengths
        /// </summary>
        public override string ToString()
        {
            double sideAB = Math.Sqrt(Math.Pow(vertex1X - vertex2X, 2) + Math.Pow(vertex1Y - vertex2Y, 2));
            double sideBC = Math.Sqrt(Math.Pow(vertex2X - vertex3X, 2) + Math.Pow(vertex2Y - vertex3Y, 2));
            double sideCA = Math.Sqrt(Math.Pow(vertex3X - vertex1X, 2) + Math.Pow(vertex3Y - vertex1Y, 2));

            return $"Triangle, sides: AB = {sideAB:f3}, BC = {sideBC:f3}, CA = {sideCA:f3}";
        }

        /// <summary>
        /// Returns the hash code for a Triangle class instance
        /// </summary>
        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + "Triangle".GetHashCode();
            hash = prime * hash + vertex1X.GetHashCode();
            hash = prime * hash + vertex1Y.GetHashCode();
            hash = prime * hash + vertex2X.GetHashCode();
            hash = prime * hash + vertex2Y.GetHashCode();
            hash = prime * hash + vertex3X.GetHashCode();
            hash = prime * hash + vertex3Y.GetHashCode();

            return hash;
        }

        /// <summary>
        /// Returns a value indicating whether the current Triangle class instance is equal to specified Triangle class instance
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is null || GetType() != obj.GetType())
            {
                return false;
            }

            Triangle triangle = (Triangle)obj;

            return this.vertex1X == triangle.vertex1X &&
                this.vertex1Y == triangle.vertex1Y &&
                this.vertex2X == triangle.vertex2X &&
                this.vertex2Y == triangle.vertex2Y &&
                this.vertex3X == triangle.vertex3X &&
                this.vertex3Y == triangle.vertex3Y;
        }
    }
}
