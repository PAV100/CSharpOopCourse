using System;

using VectorTask;

namespace MatrixTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Program demonstrates Matrix class functionality");
            Console.WriteLine();

            Console.WriteLine("Constructor of zero NxM matrix");

            Matrix matrix1 = new Matrix(2, 3);

            Console.WriteLine($"matrix1 = {matrix1}, n = {matrix1.GetHeight()}, m = {matrix1.GetWidth()}");
            Console.WriteLine();

            Console.WriteLine("Copying constructor");

            Matrix matrix2 = new Matrix(matrix1);

            Console.WriteLine($"matrix2 = {matrix2}, n = {matrix2.GetHeight()}, m = {matrix2.GetWidth()}");
            Console.WriteLine();

            Console.WriteLine("Constructor from 2D array");

            Matrix matrix3 = new Matrix(new double[,] {
                { 0, 1, 6 },
                { 0, 3, 4 },
                { 1, 8, 9 },
                { 10, -8, 2 } });

            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");
            Console.WriteLine();

            Console.WriteLine("Constructor from vectors array");

            Matrix matrix4 = new Matrix(new Vector[] {
                new Vector(new double[] { 2, 3 }),
                new Vector(new double[] { 0, 1, 2 }),
                new Vector(new double[] { 0, 1, 1, 3 }),
                new Vector(new double[] { 1, 5, 2, 1 }) });

            Console.WriteLine($"matrix4 = {matrix4}, n = {matrix4.GetHeight()}, m = {matrix4.GetWidth()}");
            Console.WriteLine();

            Console.WriteLine("Method GetRowVector(...)");
            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");
            Console.WriteLine($"matrix3 row[1] = {matrix3.GetRowVector(1)}");
            Console.WriteLine();

            Console.WriteLine("Method GetColumnVector(...)");
            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");
            Console.WriteLine($"matrix3 column[1] = {matrix3.GetColumnVector(1)}");
            Console.WriteLine();

            Console.WriteLine("Method SetRowVector(...)");

            Vector vector = new Vector(new double[] { 7, 8, 1 });

            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");
            Console.WriteLine($"matrix3 row[0] new vector = {vector}");

            matrix3.SetRowVector(0, vector);

            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");
            Console.WriteLine();

            Console.WriteLine("Method Transpose()");
            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");
            Console.WriteLine("Transposition...");

            matrix3.Transpose();

            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");
            Console.WriteLine();

            Console.WriteLine("Method MultiplyByScalar(...)");
            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");
            int number = -2;
            Console.WriteLine($"Multiplication by {number}...");

            matrix3.MultiplyByScalar(number);

            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");
            Console.WriteLine();

            Console.WriteLine("Method Determinant()");
            Console.WriteLine($"matrix4 = {matrix4}, n = {matrix4.GetHeight()}, m = {matrix4.GetWidth()}");
            Console.WriteLine($"matrix4 determinant = {matrix4.GetDeterminant()}");
            Console.WriteLine();

            Console.WriteLine("Method MultiplyByColumnVector(...)");
            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");

            Vector vector2 = new Vector(new double[] { 5, 0, 4, 1 });

            Console.WriteLine($"multiply by vector = {vector2}");

            matrix3.MultiplyByColumnVector(vector2);

            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");
            Console.WriteLine();

            Console.WriteLine("Method MultiplyByRowVector(...)");
            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");

            Vector vector3 = new Vector(new double[] { 3, 0, 1 });

            Console.WriteLine($"multiply by vector = {vector3}");

            matrix3.MultiplyByRowVector(vector3);

            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");
            Console.WriteLine();

            Console.WriteLine("Method Add(...)");
            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");
            Console.WriteLine("+");
            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");

            matrix3.Add(matrix3);

            Console.WriteLine("=");
            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");
            Console.WriteLine();

            Console.WriteLine("Method Subtract(...)");
            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");
            Console.WriteLine("-");
            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");

            matrix3.Subtract(matrix3);

            Console.WriteLine("=");
            Console.WriteLine($"matrix3 = {matrix3}, n = {matrix3.GetHeight()}, m = {matrix3.GetWidth()}");
            Console.WriteLine();

            Console.WriteLine("Method GetSum(...)");
            Console.WriteLine($"matrix4 = {matrix4}, n = {matrix4.GetHeight()}, m = {matrix4.GetWidth()}");
            Console.WriteLine("+");
            Console.WriteLine($"matrix4 = {matrix4}, n = {matrix4.GetHeight()}, m = {matrix4.GetWidth()}");

            Matrix matrix5 = Matrix.GetSum(matrix4, matrix4);

            Console.WriteLine("=");
            Console.WriteLine($"matrix5 = {matrix5}, n = {matrix5.GetHeight()}, m = {matrix5.GetWidth()}");
            Console.WriteLine();

            Console.WriteLine("Method GetDifference(...)");
            Console.WriteLine($"matrix4 = {matrix4}, n = {matrix4.GetHeight()}, m = {matrix4.GetWidth()}");
            Console.WriteLine("-");
            Console.WriteLine($"matrix4 = {matrix4}, n = {matrix4.GetHeight()}, m = {matrix4.GetWidth()}");

            Matrix matrix6 = Matrix.GetDifference(matrix4, matrix4);

            Console.WriteLine("=");
            Console.WriteLine($"matrix6 = {matrix6}, n = {matrix6.GetHeight()}, m = {matrix6.GetWidth()}");
            Console.WriteLine();

            Console.WriteLine("Method GetMultiplicationProduct(...)");

            Matrix matrix7 = new Matrix(new double[,] {
                { 0, 1 },
                { 0, 3 },
                { 1, 8 },
                { 10, -8 },
                { 0, 3 },
                { 2, 9 } });

            Matrix matrix8 = new Matrix(new double[,] {
                { 0, 1, 3, 4, 7, 8 },
                { 0, 3, 0, 2, 5, 6 } });

            Console.WriteLine($"matrix8 = {matrix8}, n = {matrix8.GetHeight()}, m = {matrix8.GetWidth()}");
            Console.WriteLine("*");
            Console.WriteLine($"matrix7 = {matrix7}, n = {matrix7.GetHeight()}, m = {matrix7.GetWidth()}");

            Matrix matrix9 = Matrix.GetMultiplicationProduct(matrix8, matrix7);
            //Matrix matrix9 = Matrix.GetMultiplicationProduct(matrix7, matrix8);

            Console.WriteLine("=");
            Console.WriteLine($"matrix9 = {matrix9}, n = {matrix9.GetHeight()}, m = {matrix9.GetWidth()}");
        }
    }
}