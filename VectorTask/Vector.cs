using System;

namespace VectorTask
{
    /// <summary>
    /// Provides vectors of dimention n with real-number components and static and non-static methods for operations with vectors
    /// </summary>
    public class Vector
    {
        private double[] components;

        public Vector(int Dimention)
        {
            if (Dimention <= 0)
            {
                throw new ArgumentException($"Number of components = {Dimention}, but it must be > 0", nameof(Dimention));
            }

            components = new double[Dimention];
        }

        public Vector(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException("vector must not be null", nameof(vector));
            }

            components = new double[vector.components.Length];

            Array.Copy(vector.components, components, vector.components.Length);
        }

        public Vector(double[] components)
        {
            if (components is null)
            {
                throw new ArgumentNullException("Array must not be null", nameof(components));
            }

            if (components.Length == 0)
            {
                throw new ArgumentException("Array length = 0, but it must be > 0", nameof(components));
            }

            this.components = new double[components.Length];

            Array.Copy(components, this.components, components.Length);
        }

        public Vector(int dimention, double[] components)
        {
            if (dimention <= 0)
            {
                throw new ArgumentException($"Number of components = {dimention}, but it must be > 0", nameof(dimention));
            }

            if (components is null)
            {
                throw new ArgumentNullException("Array must not be null", nameof(components));
            }

            this.components = new double[dimention];

            Array.Copy(components, this.components, Math.Min(dimention, components.Length));
        }

        /// <summary>
        /// Gets vector dimention
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
                throw new ArgumentNullException("vector must not be null", nameof(vector));
            }

            if (components.Length < vector.components.Length)
            {
                double[] newComponents = new double[vector.components.Length];
                Array.Copy(components, newComponents, components.Length);
                components = newComponents;
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
                throw new ArgumentNullException("vector must not be null", nameof(vector));
            }

            if (components.Length < vector.components.Length)
            {
                double[] newComponents = new double[vector.components.Length];
                Array.Copy(components, newComponents, components.Length);
                components = newComponents;
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
            return this.MultiplyByScalar(-1);
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
                throw new ArgumentOutOfRangeException($"componentIndex = {componentIndex}, but it must be in range [0; {components.Length - 1}]", nameof(componentIndex));
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
                throw new ArgumentOutOfRangeException($"componentIndex = {componentIndex}, but it must be in range [0; {components.Length - 1}]", nameof(componentIndex));
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

            if (ReferenceEquals(obj, null) || this.GetType() != obj.GetType())
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
                throw new ArgumentNullException("vector1 must not be null", nameof(vector1));
            }

            if (vector2 is null)
            {
                throw new ArgumentNullException("vector2 must not be null", nameof(vector2));
            }

            return (new Vector(vector1)).Add(vector2);
        }

        /// <summary>
        /// Subtracts vectors (vector1 - vector2) and returnes the result as a vector object
        /// </summary>
        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            if (vector1 is null)
            {
                throw new ArgumentNullException("vector1 must not be null", nameof(vector1));
            }

            if (vector2 is null)
            {
                throw new ArgumentNullException("vector2 must not be null", nameof(vector2));
            }

            return (new Vector(vector1)).Subtract(vector2);
        }

        /// <summary>
        /// Gets a value of scalar product of 2 vectors
        /// </summary>
        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            if (vector1 is null)
            {
                throw new ArgumentNullException("vector1 must not be null", nameof(vector1));
            }

            if (vector2 is null)
            {
                throw new ArgumentNullException("vector2 must not be null", nameof(vector2));
            }

            int lastIndex = Math.Min(vector1.components.Length, vector2.components.Length);

            double scalarProduct = 0;

            for (int i = 0; i < lastIndex; i++)
            {
                scalarProduct += vector1.components[i] * vector2.components[i];
            }

            return scalarProduct;
        }
    }
}