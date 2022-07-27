using System;

namespace VectorTask
{
    /// <summary>Provides vectors of dimention n with real-number components and static and non-static methods for operations with vectors</summary>
    internal class Vector
    {
        public double[] Components { get; set; }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Number of components must be > 0", nameof(n));
            }

            Components = new double[n];
        }

        public Vector(Vector vector)
        {
            Components = new double[vector.Components.Length];

            for (int i = 0; i < vector.Components.Length; i++)
            {
                Components[i] = vector.Components[i];
            }
        }

        public Vector(double[] components)
        {
            if (components.Length == 0)
            {
                throw new ArgumentException("Array length must be > 0", nameof(components));
            }

            Components = new double[components.Length];

            for (int i = 0; i < components.Length; i++)
            {
                Components[i] = components[i];
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

            Components = (n <= components.Length) ? new double[components.Length] : new double[n];

            for (int i = 0; i < components.Length; i++)
            {
                Components[i] = components[i];
            }
        }

        /// <summary>Gets vector dimention</summary>        
        public int GetSize()
        {
            return this.Components.Length;
        }

        public override string ToString()
        {
            return "{" + String.Join(", ", this.Components) + "}";
        }

        /// <summary>Adds a vector to a current vector. Returns modified vector</summary>
        public Vector AddVector(Vector vector)
        {
            if (this.Components.Length >= vector.Components.Length)
            {
                for (int i = 0; i < vector.Components.Length; i++)
                {
                    this.Components[i] += vector.Components[i];
                }
            }
            else
            {
                Vector vectorsSum = new Vector(vector);

                for (int i = 0; i < this.Components.Length; i++)
                {
                    vectorsSum.Components[i] += this.Components[i];
                }

                this.Components = vectorsSum.Components;
            }

            return this;
        }

        /// <summary>Subtracts a vector from a current vector. Returns modified vector</summary>
        public Vector SubtractVector(Vector vector)
        {
            if (this.Components.Length >= vector.Components.Length)
            {
                for (int i = 0; i < vector.Components.Length; i++)
                {
                    this.Components[i] -= vector.Components[i];
                }
            }
            else
            {
                Vector vectorsDifference = new Vector(vector.ReverseVector());

                for (int i = 0; i < this.Components.Length; i++)
                {
                    vectorsDifference.Components[i] += this.Components[i];
                }

                this.Components = vectorsDifference.Components;
            }

            return this;
        }

        /// <summary>Multiplies a current vector by a scalar. Returns modified vector</summary>
        public Vector MultiplyByScalar(double value)
        {
            for (int i = 0; i < this.Components.Length; i++)
            {
                this.Components[i] *= value;
            }

            return this;
        }

        /// <summary>Multiplies a current vector by -1. Returns modified vector</summary>
        public Vector ReverseVector()
        {
            for (int i = 0; i < this.Components.Length; i++)
            {
                this.Components[i] *= -1;
            }

            return this;
        }

        public double GetLength()
        {
            double squaresSum = 0;

            for (int i = 0; i < this.Components.Length; i++)
            {
                squaresSum += this.Components[i] * this.Components[i];
            }

            return Math.Sqrt(squaresSum);
        }

        public double GetComponent(int componentIndex)
        {
            int componentsLength = this.Components.Length;

            if (componentIndex < 0 || componentIndex >= componentsLength)
            {
                throw new ArgumentException("componentIndex must be between 0 and vector size", nameof(componentIndex));
            }

            return this.Components[componentIndex];
        }

        public void SetComponent(int componentIndex, double component)
        {
            int componentsLength = this.Components.Length;

            if (componentIndex < 0 || componentIndex >= componentsLength)
            {
                throw new ArgumentException("componentIndex must be between 0 and vector size", nameof(componentIndex));
            }

            this.Components[componentIndex] = component;
        }

        /*public override bool Equals(object obj)
        {
            if (obj is Vector vector)
            { 

            }

                return Name == person.Name;
            

            return false;
        }*/

        public static Vector AddVectors(Vector vector1, Vector vector2)
        {
            Vector majorVector;
            Vector minorVector;

            if (vector1.Components.Length >= vector2.Components.Length)
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

            for (int i = 0; i < minorVector.Components.Length; i++)
            {
                vectorsSum.Components[i] += minorVector.Components[i];
            }

            return vectorsSum;
        }

        public static Vector SubtractVectors(Vector vector1, Vector vector2)
        {
            Vector minorVector;
            Vector vectorsDifference;
            int negationMultiplier;

            if (vector1.Components.Length >= vector2.Components.Length)
            {
                minorVector = vector2;
                vectorsDifference = new Vector(vector1);
                negationMultiplier = -1;
            }
            else
            {
                minorVector = vector1;
                vectorsDifference = new Vector(vector2.ReverseVector());
                negationMultiplier = 1;
            }

            for (int i = 0; i < minorVector.Components.Length; i++)
            {
                vectorsDifference.Components[i] += minorVector.Components[i] * negationMultiplier;
            }

            return vectorsDifference;
        }

        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            int maxIndex = Math.Min(vector1.Components.Length, vector2.Components.Length);

            double scalarProduct = 0;

            for (int i = 0; i < maxIndex; i++)
            {
                scalarProduct += vector1.Components[i] * vector2.Components[i];
            }

            return scalarProduct;
        }
    }
}
