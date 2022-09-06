using ShapeTask.Interfaces;
using System;

namespace ShapeTask.Shapes
{
    internal class Square : IShape
    {
        private const double Epsilon = 1.0e-10;

        public double SideLength { get; }

        public Square(double sideLength)
        {
            if (sideLength <= Epsilon)
            {
                throw new ArgumentException($"Side length = {sideLength}, but it must be > 0", nameof(sideLength));
            }

            SideLength = sideLength;
        }

        public double GetArea()
        {
            return SideLength * SideLength;
        }

        public double GetHeight()
        {
            return SideLength;
        }

        public double GetPerimeter()
        {
            return SideLength * 4;
        }

        public double GetWidth()
        {
            return SideLength;
        }

        /// <summary>
        /// Converts to string Square class instance. Returns instance type (Square) and a square side length
        /// </summary>
        public override string ToString()
        {
            return $"Square, side = {SideLength:f3}";
        }

        /// <summary>
        /// Returns the hash code for a Square class instance
        /// </summary>
        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            return prime * hash + SideLength.GetHashCode();
        }

        /// <summary>
        /// Returns a value indicating whether the current Square class instance is equal to specified Square class instance
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

            Square square = (Square)obj;

            return SideLength == square.SideLength;
        }
    }
}