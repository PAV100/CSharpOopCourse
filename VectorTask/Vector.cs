using System;

namespace VectorTask
{
    /// <summary>
    /// Provides vectors of dimension n with real-number components and static and non-static methods for operations with vectors
    /// </summary>
    public class Vector
    {
        private double[] components;

        public Vector(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Number of components = {size}, but it must be > 0", nameof(size));
            }

            components = new double[size];
        }

        public Vector(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), "vector must not be null");
            }

            components = new double[vector.components.Length];

            Array.Copy(vector.components, components, vector.components.Length);
        }

        public Vector(double[] components)
        {
            if (components is null)
            {
                throw new ArgumentNullException(nameof(components), "Array must not be null");
            }

            if (components.Length == 0)
            {
                throw new ArgumentException("Array length = 0, but it must be > 0", nameof(components));
            }

            this.components = new double[components.Length];

            Array.Copy(components, this.components, components.Length);
        }

        public Vector(int size, double[] components)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Number of components = {size}, but it must be > 0", nameof(size));
            }

            if (components is null)
            {
                throw new ArgumentNullException(nameof(components), "Array must not be null");
            }

            this.components = new double[size];

            Array.Copy(components, this.components, Math.Min(size, components.Length));
        }

        /// <summary>
        /// Gets vector dimension
        /// </summary>        
        public int GetSize()
        {
            return components.Length;
        }

        public override string ToString()
        {
            return "{" + string.Join(", ", components) + "}";
        }

        /// <summary>
        /// Adds a vector to a current vector. Returns modified vector
        /// </summary>
        public Vector Add(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), "vector must not be null");
            }

            if (components.Length < vector.components.Length)
            {
                //double[] newComponents = new double[vector.components.Length];
                //Array.Copy(components, newComponents, components.Length);
                //components = newComponents;
                Array.Resize(ref components, vector.components.Length);
            }

            for (int i = 0; i < vector.components.Length; i++)
            {
                components[i] += vector.components[i];
            }

            return this;
        }

        /// <summary>
        /// Subtracts a vector from a current vector. Returns modified vector
        /// </summary>
        public Vector Subtract(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), "vector must not be null");
            }

            if (components.Length < vector.components.Length)
            {
                //double[] newComponents = new double[vector.components.Length];
                //Array.Copy(components, newComponents, components.Length);
                //components = newComponents;
                Array.Resize(ref components, vector.components.Length);
            }

            for (int i = 0; i < vector.components.Length; i++)
            {
                components[i] -= vector.components[i];
            }

            return this;
        }

        /// <summary>
        /// Multiplies a current vector by a scalar. Returns modified vector
        /// </summary>
        public Vector MultiplyByScalar(double value)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i] *= value;
            }

            return this;
        }

        /// <summary>
        /// Multiplies a current vector by -1. Returns modified vector
        /// </summary>
        public Vector Reverse()
        {
            return MultiplyByScalar(-1);
        }

        /// <summary>
        /// Gets current vector length
        /// </summary>
        public double GetLength()
        {
            double squaresSum = 0;

            foreach (double component in components)
            {
                squaresSum += component * component;
            }

            return Math.Sqrt(squaresSum);
        }

        /// <summary>
        /// Gets a value of a current vector Nth component by index
        /// </summary>
        public double GetComponent(int componentIndex)
        {
            if (componentIndex < 0 || componentIndex >= components.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(componentIndex), $"componentIndex = {componentIndex}, but it must be in range [0; {components.Length - 1}]");
            }

            return components[componentIndex];
        }

        /// <summary>
        /// Sets a value of a current vector Nth component by index
        /// </summary>
        public void SetComponent(int componentIndex, double component)
        {
            if (componentIndex < 0 || componentIndex >= components.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(componentIndex), $"componentIndex = {componentIndex}, but it must be in range [0; {components.Length - 1}]");
            }

            components[componentIndex] = component;
        }

        /// <summary>
        /// Returns a value indicating whether the current Vector class instance is equal to specified Vector class instance
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

            Vector vector = (Vector)obj;

            if (components.Length != vector.components.Length)
            {
                return false;
            }

            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] != vector.components[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns the hash code for a Vector class instance
        /// </summary>
        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            foreach (double component in components)
            {
                hash = prime * hash + component.GetHashCode();
            }

            return hash;
        }

        /// <summary>
        /// Adds two vectors and returnes the result as a vector object
        /// </summary>
        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            if (vector1 is null)
            {
                throw new ArgumentNullException(nameof(vector1), "vector1 must not be null");
            }

            if (vector2 is null)
            {
                throw new ArgumentNullException(nameof(vector2), "vector2 must not be null");
            }

            return new Vector(vector1).Add(vector2);
        }

        /// <summary>
        /// Subtracts vectors (vector1 - vector2) and returnes the result as a vector object
        /// </summary>
        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            if (vector1 is null)
            {
                throw new ArgumentNullException(nameof(vector1), "vector1 must not be null");
            }

            if (vector2 is null)
            {
                throw new ArgumentNullException(nameof(vector2), "vector2 must not be null");
            }

            return new Vector(vector1).Subtract(vector2);
        }

        /// <summary>
        /// Gets a value of scalar product of 2 vectors
        /// </summary>
        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            if (vector1 is null)
            {
                throw new ArgumentNullException(nameof(vector1), "vector1 must not be null");
            }

            if (vector2 is null)
            {
                throw new ArgumentNullException(nameof(vector2), "vector2 must not be null");
            }

            int minSize = Math.Min(vector1.components.Length, vector2.components.Length);

            double scalarProduct = 0;

            for (int i = 0; i < minSize; i++)
            {
                scalarProduct += vector1.components[i] * vector2.components[i];
            }

            return scalarProduct;
        }
    }
}