using System;

namespace ShapeTask
{
    internal class Rectangle : IShape
    {
        private readonly double height;
        private readonly double width;

        private const double Epsilon = 1.0e-10;

        public double Height
        {
            get { return height; }
        }
        public double Width
        {
            get { return width; }
        }

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

            this.height = height;
            this.width = width;
        }

        public double GetArea()
        {
            return height * width;
        }

        public double GetHeight()
        {
            return height;
        }

        public double GetPerimeter()
        {
            return (height + width) * 2;
        }

        public double GetWidth()
        {
            return width;
        }

        /// <summary>
        /// Converts to string Rectangle class instance. Returns instance type (Rectangle), width and height 
        /// </summary>
        public override string ToString()
        {
            return $"Rectangle, width = {width:f3}, height = {height:f3}";
        }

        /// <summary>
        /// Returns the hash code for a Rectangle class instance
        /// </summary>
        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
                        
            hash = prime * hash + height.GetHashCode();
            hash = prime * hash + width.GetHashCode();

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

            return width == rectangle.width && height == rectangle.height;
        }
    }
}
