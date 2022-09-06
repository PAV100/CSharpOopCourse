using ShapeTask.Interfaces;
using System;

namespace ShapeTask.Shapes
{
    internal class Triangle : IShape
    {
        private const double Epsilon = 1.0e-10;

        public double X1 { get; }

        public double Y1 { get; }

        public double X2 { get; }

        public double Y2 { get; }

        public double X3 { get; }

        public double Y3 { get; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double straightLineEquation = (x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1);

            if (Math.Abs(straightLineEquation) <= Epsilon)
            {
                throw new ArgumentException("Points lie on the same straight line. It is impossible to build a traingle");
            }

            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        public double GetArea()
        {
            return 0.5 * Math.Abs((X1 - X3) * (Y2 - Y3) - (X2 - X3) * (Y1 - Y3));
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(Y1, Y2), Y3) - Math.Min(Math.Min(Y1, Y2), Y3);
        }

        public double GetPerimeter()
        {
            return GetSideLength(X1, Y1, X2, Y2) + GetSideLength(X2, Y2, X3, Y3) + GetSideLength(X3, Y3, X1, Y1);
        }

        private static double GetSideLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(X1, X2), X3) - Math.Min(Math.Min(X1, X2), X3);
        }

        /// <summary>
        /// Converts to string Triangle class instance. Returns instance type (Triangle) and three sides lengths
        /// </summary>
        public override string ToString()
        {
            return $"Triangle, vertices (x, y): ({X1}, {Y1}), ({X2}, {Y2}), ({X3}, {Y3})";
        }

        /// <summary>
        /// Returns the hash code for a Triangle class instance
        /// </summary>
        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();

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

            return X1 == triangle.X1 && Y1 == triangle.Y1
                && X2 == triangle.X2 && Y2 == triangle.Y2
                && X3 == triangle.X3 && Y3 == triangle.Y3;
        }
    }
}