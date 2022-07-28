using System;

namespace VectorTask
{
    /// <summary>
    /// Provides vectors of dimention n with real-number components and static and non-static methods for operations with vectors
    /// </summary>
    internal class Vector
    {
        private double[] components;

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Number of components must be > 0", nameof(n));
            }

            components = new double[n];
        }

        public Vector(Vector vector)
        {
            components = new double[vector.components.Length];

            for (int i = 0; i < vector.components.Length; i++)
            {
                components[i] = vector.components[i];
            }
        }

        public Vector(double[] components)
        {
            if (components.Length == 0)
            {
                throw new ArgumentException("Array length must be > 0", nameof(components));
            }

            this.components = new double[components.Length];

            for (int i = 0; i < components.Length; i++)
            {
                this.components[i] = components[i];
            }
        }

        public Vector(int n, double[] components)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Number of components must be > 0", nameof(n));
            }

            if (components.Length == 0)
            {
                throw new ArgumentException("Array length must be > 0", nameof(components));
            }

            this.components = (n <= components.Length) ? new double[components.Length] : new double[n];

            for (int i = 0; i < components.Length; i++)
            {
                this.components[i] = components[i];
            }
        }

        /// <summary>
        /// Gets vector dimention
        /// </summary>        
        public int GetSize()
        {
            return this.components.Length;
        }

        public override string ToString()
        {
            return "{" + String.Join(", ", this.components) + "}";
        }

        /// <summary>
        /// Adds a vector to a current vector. Returns modified vector
        /// </summary>
        public Vector AddVector(Vector vector)
        {
            if (this.components.Length >= vector.components.Length)
            {
                for (int i = 0; i < vector.components.Length; i++)
                {
                    this.components[i] += vector.components[i];
                }
            }
            else
            {
                Vector vectorsSum = new Vector(vector);

                for (int i = 0; i < this.components.Length; i++)
                {
                    vectorsSum.components[i] += this.components[i];
                }

                this.components = vectorsSum.components;
            }

            return this;
        }

        /// <summary>
        /// Subtracts a vector from a current vector. Returns modified vector
        /// </summary>
        public Vector SubtractVector(Vector vector)
        {
            if (this.components.Length >= vector.components.Length)
            {
                for (int i = 0; i < vector.components.Length; i++)
                {
                    this.components[i] -= vector.components[i];
                }
            }
            else
            {
                Vector vectorsDifference = new Vector(vector.ReverseVector());

                for (int i = 0; i < this.components.Length; i++)
                {
                    vectorsDifference.components[i] += this.components[i];
                }

                this.components = vectorsDifference.components;
            }

            return this;
        }

        /// <summary>
        /// Multiplies a current vector by a scalar. Returns modified vector
        /// </summary>
        public Vector MultiplyByScalar(double value)
        {
            for (int i = 0; i < this.components.Length; i++)
            {
                this.components[i] *= value;
            }

            return this;
        }

        /// <summary>
        /// Multiplies a current vector by -1. Returns modified vector
        /// </summary>
        public Vector ReverseVector()
        {
            for (int i = 0; i < this.components.Length; i++)
            {
                this.components[i] *= -1;
            }

            return this;
        }

        /// <summary>
        /// Gets current vector length
        /// </summary>
        public double GetLength()
        {
            double squaresSum = 0;

            for (int i = 0; i < this.components.Length; i++)
            {
                squaresSum += this.components[i] * this.components[i];
            }

            return Math.Sqrt(squaresSum);
        }

        /// <summary>
        /// Gets a value of a current vector Nth component by index
        /// </summary>
        public double GetComponent(int componentIndex)
        {
            int componentsLength = this.components.Length;

            if (componentIndex < 0 || componentIndex >= componentsLength)
            {
                throw new ArgumentException("componentIndex must be between 0 and vector size", nameof(componentIndex));
            }

            return this.components[componentIndex];
        }

        /// <summary>
        /// Sets a value of a current vector Nth component by index
        /// </summary>
        public void SetComponent(int componentIndex, double component)
        {
            int componentsLength = this.components.Length;

            if (componentIndex < 0 || componentIndex >= componentsLength)
            {
                throw new ArgumentException("componentIndex must be between 0 and vector size", nameof(componentIndex));
            }

            this.components[componentIndex] = component;
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

            if (this.components.Length != vector.components.Length)
            {
                return false;
            }

            bool equalVectors = true;

            for (int i = 0; i < this.components.Length; i++)
            {
                if (this.components[i]==vector.components[i])
                {
                    continue;
                }

                equalVectors = false;
                break;
            }

            return equalVectors;
        }

        /// <summary>
        /// Returns the hash code for a Vector class instance
        /// </summary>
        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            return prime * hash + this.components.GetHashCode();
        }

        /// <summary>
        /// Adds two vectors and returnes the result as a vector object
        /// </summary>
        public static Vector AddVectors(Vector vector1, Vector vector2)
        {
            Vector majorVector;
            Vector minorVector;

            if (vector1.components.Length >= vector2.components.Length)
            {
                majorVector = vector1;
                minorVector = vector2;
            }
            else
            {
                majorVector = vector2;
                minorVector = vector1;
            }

            Vector vectorsSum = new Vector(majorVector);

            for (int i = 0; i < minorVector.components.Length; i++)
            {
                vectorsSum.components[i] += minorVector.components[i];
            }

            return vectorsSum;
        }

        /// <summary>
        /// Subtracts vectors (vector1 - vector2) and returnes the result as a vector object
        /// </summary>
        public static Vector SubtractVectors(Vector vector1, Vector vector2)
        {
            Vector minorVector;
            Vector vectorsDifference;
            int negationMultiplier;

            if (vector1.components.Length >= vector2.components.Length)
            {
                minorVector = vector2;
                vectorsDifference = new Vector(vector1);
                negationMultiplier = -1;
            }
            else
            {
                minorVector = vector1;
                (vectorsDifference = new Vector(vector2)).ReverseVector();
                negationMultiplier = 1;
            }

            for (int i = 0; i < minorVector.components.Length; i++)
            {
                vectorsDifference.components[i] += minorVector.components[i] * negationMultiplier;
            }

            return vectorsDifference;
        }

        /// <summary>
        /// Gets a value of scalar product of 2 vectors
        /// </summary>
        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            int maxIndex = Math.Min(vector1.components.Length, vector2.components.Length);

            double scalarProduct = 0;

            for (int i = 0; i < maxIndex; i++)
            {
                scalarProduct += vector1.components[i] * vector2.components[i];
            }

            return scalarProduct;
        }
    }
}
