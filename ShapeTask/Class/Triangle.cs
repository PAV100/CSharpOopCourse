using System;

namespace ShapeTask
{
    internal class Triangle : IShape
    {
        private readonly double x1;
        private readonly double y1;
        private readonly double x2;
        private readonly double y2;
        private readonly double x3;
        private readonly double y3;

        private const double Epsilon = 1.0e-10;

        public double X1
        {
            get { return x1; }
        }
        public double Y1
        {
            get { return y1; }
        }
        public double X2
        {
            get { return x2; }
        }
        public double Y2
        {
            get { return y2; }
        }
        public double X3
        {
            get { return x3; }
        }
        public double Y3
        {
            get { return y3; }
        }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double straightLineEquation = (x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1);

            if (Math.Abs(straightLineEquation) <= Epsilon)
            {
                throw new ArgumentException("Points lie on the same straight line. It is impossible to build a traingle");
            }

            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
        }
        public double GetArea()
        {
            return 0.5 * Math.Abs((x1 - x3) * (y2 - y3) - (x2 - x3) * (y1 - y3));
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(y1, y2), y3) - Math.Min(Math.Min(y1, y2), y3);
        }

        public double GetPerimeter()
        {
            return GetSide(x1, y1, x2, y2) + GetSide(x2, y2, x3, y3) + GetSide(x3, y3, x1, y1);
        }

        private static double GetSide(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(x1, x2), x3) - Math.Min(Math.Min(x1, x2), x3);
        }

        /// <summary>
        /// Converts to string Triangle class instance. Returns instance type (Triangle) and three sides lengths
        /// </summary>
        public override string ToString()
        {
            return $"Triangle, vertices (x, y): ({x1}, {y1}), ({x2}, {y2}), ({x3}, {y3})";
        }

        /// <summary>
        /// Returns the hash code for a Triangle class instance
        /// </summary>
        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + x1.GetHashCode();
            hash = prime * hash + y1.GetHashCode();
            hash = prime * hash + x2.GetHashCode();
            hash = prime * hash + y2.GetHashCode();
            hash = prime * hash + x3.GetHashCode();
            hash = prime * hash + y3.GetHashCode();

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

            return x1 == triangle.x1 && y1 == triangle.y1
                && x2 == triangle.x2 && y2 == triangle.y2
                && x3 == triangle.x3 && y3 == triangle.y3;
        }
    }
}
