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
            Components = vector.Components;
        }

        public Vector(double[] components)
        {
            if (components.Length == 0)
            {
                throw new ArgumentException("Array length must be > 0", nameof(components));
            }

            Components = components;
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

            if (n <= components.Length)
            {
                Components = components;
            }
            else
            {
                Components = new double[n];

                for (int i = 0; i < components.Length; i++)
                {
                    Components[i] = components[i];
                }
            }
        }


    }
}
