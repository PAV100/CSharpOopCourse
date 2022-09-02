using ShapeTask.Interfaces;
using System;

namespace ShapeTask.ShapesClasses
{
    internal class Rectangle : IShape
    {
        private const double Epsilon = 1.0e-10;

        public double Height { get; }

        public double Width { get; }

        public Rectangle(double height, double width)
        {
            if (height <= Epsilon)
            {
                throw new ArgumentException($"Height = {height}, but it must be > 0", nameof(height));
            }

            if (width <= Epsilon)
            {
                throw new ArgumentException($"Width = {width}, but it must be > 0", nameof(width));
            }

            Height = height;
            Width = width;
        }

        public double GetArea()
        {
            return Height * Width;
        }

        public double GetHeight()
        {
            return Height;
        }

        public double GetPerimeter()
        {
            return (Height + Width) * 2;
        }

        public double GetWidth()
        {
            return Width;
        }

        /// <summary>
        /// Converts to string Rectangle class instance. Returns instance type (Rectangle), width and height 
        /// </summary>
        public override string ToString()
        {
            return $"Rectangle, width = {Width:f3}, height = {Height:f3}";
        }

        /// <summary>
        /// Returns the hash code for a Rectangle class instance
        /// </summary>
        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + Height.GetHashCode();
            hash = prime * hash + Width.GetHashCode();

            return hash;
        }

        /// <summary>
        /// Returns a value indicating whether the current Rectangle class instance is equal to specified Rectangle class instance
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

            Rectangle rectangle = (Rectangle)obj;

            return Width == rectangle.Width && Height == rectangle.Height;
        }
    }
}