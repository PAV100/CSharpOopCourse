using System;

namespace ShapeTask
{
    internal class Circle : IShape
    {
        private readonly double radius;

        private const double Epsilon = 1.0e-10;

        public double Radius
        {
            get { return radius; }
        }

        public Circle(double radius)
        {
            if (radius <= Epsilon)
            {
                throw new ArgumentException($"Radius = {radius}, but it must be > 0", nameof(radius));
            }

            this.radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public double GetHeight()
        {
            return radius * 2;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public double GetWidth()
        {
            return radius * 2;
        }

        /// <summary>
        /// Converts to string Circle class instance. Returns instance type (Circle) and a circle radius
        /// </summary>
        public override string ToString()
        {
            return $"Circle, radius = {radius:f3}";
        }

        /// <summary>
        /// Returns the hash code for a Circle class instance
        /// </summary>
        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            return prime * hash + radius.GetHashCode();
        }

        /// <summary>
        /// Returns a value indicating whether the current Circle class instance is equal to specified Circle class instance
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

            Circle circle = (Circle)obj;

            return radius == circle.radius;
        }
    }
}
