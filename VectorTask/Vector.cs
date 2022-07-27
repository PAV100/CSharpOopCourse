using System;

namespace VectorTask
{
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

        public int GetSize()
        {
            return this.Components.Length;
        }

        public string ToString()
        {
            return "{" + String.Join(", ", this.Components) + "}";
        }

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
                Vector vectorsDifference = new Vector(vector);

                for (int i = 0; i < this.Components.Length; i++)
                {
                    vectorsDifference.Components[i] = this.Components[i] - vectorsDifference.Components[i];
                }

                this.Components = vectorsDifference.Components;
            }

            return this;
        }

        public Vector MultiplyByScalar(double value)
        {
            for (int i = 0; i < this.Components.Length; i++)
            {
                this.Components[i] *= value;
            }

            return this;
        }

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

        /*public double GetComponent(int componentIndex)
        {
            if (componentIndex <= 0)
            {
                throw new ArgumentException("Number of components must be > 0", nameof(componentIndex));
            }

            Components = new double[componentIndex];

            return 0;
        }*/

    }
}
