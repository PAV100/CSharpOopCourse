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

            Console.WriteLine("Constructor of zero matrix, size r(rows) x c(columns)");

            Matrix matrix1 = new Matrix(2, 3);

            Console.WriteLine($"matrix1 = {matrix1}, size {matrix1.GetRowsCount()} x {matrix1.GetColumnsCount()}");
            Console.WriteLine();

            Console.WriteLine("Copying constructor");

            Matrix matrix2 = new Matrix(matrix1);

            Console.WriteLine($"matrix2 = {matrix2}, size {matrix2.GetRowsCount()} x {matrix2.GetColumnsCount()}");
            Console.WriteLine();

            //matrix1.Add(new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } }));
            //Console.WriteLine($"matrix1 = {matrix1}, size {matrix1.GetRowsCount()} x {matrix1.GetColumnsCount()}");
            //Console.WriteLine($"matrix2 = {matrix2}, size {matrix2.GetRowsCount()} x {matrix2.GetColumnsCount()}");

            Console.WriteLine("Constructor from 2D array");

            Matrix matrix3 = new Matrix(new double[,]
            {
                { 0, 1, 6 },
                { 0, 3, 4 },
                { 1, 8, 9 },
                { 10, -8, 2 }
            });

            Console.WriteLine($"matrix3 = {matrix3}, size {matrix3.GetRowsCount()} x {matrix3.GetColumnsCount()}");
            Console.WriteLine();

            Console.WriteLine("Constructor from vectors array");

            Matrix matrix4 = new Matrix(new Vector[]
            {
                new Vector(new double[] { 2, 3 }),
                new Vector(new double[] { 0, 1, 2 }),
                new Vector(new double[] { 0, 1, 1, 3 }),
                new Vector(new double[] { 1, 5, 2, 1 })
            });

            Console.WriteLine($"matrix4 = {matrix4}, size {matrix4.GetRowsCount()} x {matrix4.GetColumnsCount()}");
            Console.WriteLine();

            Console.WriteLine("Method GetRow(...)");
            Console.WriteLine($"matrix3 = {matrix3}, size {matrix3.GetRowsCount()} x {matrix3.GetColumnsCount()}");
            Console.WriteLine($"matrix3 row[1] = {matrix3.GetRow(1)}");
            Console.WriteLine();

            Console.WriteLine("Method GetColumn(...)");
            Console.WriteLine($"matrix3 = {matrix3}, size {matrix3.GetRowsCount()} x {matrix3.GetColumnsCount()}");
            Console.WriteLine($"matrix3 column[1] = {matrix3.GetColumn(1)}");
            Console.WriteLine();

            Console.WriteLine("Method SetRow(...)");

            Vector vector = new Vector(new double[] { 7, 8, 1 });

            Console.WriteLine($"matrix3 = {matrix3}, size {matrix3.GetRowsCount()} x {matrix3.GetColumnsCount()}");
            Console.WriteLine($"matrix3 row[0] new vector {vector}");

            matrix3.SetRow(0, vector);

            Console.WriteLine($"matrix3 = {matrix3}, size {matrix3.GetRowsCount()} x {matrix3.GetColumnsCount()}");
            Console.WriteLine();

            Console.WriteLine("Method Transpose()");
            Console.WriteLine($"matrix3 = {matrix3}, size {matrix3.GetRowsCount()} x {matrix3.GetColumnsCount()}");
            Console.WriteLine("Transposition...");

            matrix3.Transpose();

            Console.WriteLine($"matrix3 = {matrix3}, size {matrix3.GetRowsCount()} x {matrix3.GetColumnsCount()}");
            Console.WriteLine();

            Console.WriteLine("Method MultiplyByScalar(...)");
            Console.WriteLine($"matrix3 = {matrix3}, size {matrix3.GetRowsCount()} x {matrix3.GetColumnsCount()}");
            int number = -2;
            Console.WriteLine($"Multiplication by {number}...");

            matrix3.MultiplyByScalar(number);

            Console.WriteLine($"matrix3 = {matrix3}, size {matrix3.GetRowsCount()} x {matrix3.GetColumnsCount()}");
            Console.WriteLine();

            Console.WriteLine("Method GetDeterminant()");
            Console.WriteLine($"matrix4 = {matrix4}, size {matrix4.GetRowsCount()} x {matrix4.GetColumnsCount()}");
            Console.WriteLine($"matrix4 determinant = {matrix4.GetDeterminant()}");
            Console.WriteLine();

            Console.WriteLine("Method MultiplyByColumnVector(...)");
            Console.WriteLine($"matrix3 = {matrix3}, size {matrix3.GetRowsCount()} x {matrix3.GetColumnsCount()}");

            Vector vector2 = new Vector(new double[] { 5, 0, 4, 1 });

            Console.WriteLine($"multiply by vector2 {vector2}");

            Vector vector3 = matrix3.MultiplyByColumnVector(vector2);

            Console.WriteLine($"equals vector3 = {vector3}");
            Console.WriteLine($"matrix3 = {matrix3}, size {matrix3.GetRowsCount()} x {matrix3.GetColumnsCount()} unchanged!");
            Console.WriteLine();

            Console.WriteLine("Method Add(...)");
            Console.WriteLine($"matrix3 = {matrix3}, size {matrix3.GetRowsCount()} x {matrix3.GetColumnsCount()}");
            Console.WriteLine("+");
            Console.WriteLine($"matrix3 = {matrix3}, size {matrix3.GetRowsCount()} x {matrix3.GetColumnsCount()}");

            matrix3.Add(matrix3);

            Console.WriteLine("=");
            Console.WriteLine($"matrix3 = {matrix3}, size {matrix3.GetRowsCount()} x {matrix3.GetColumnsCount()}");
            Console.WriteLine();

            Console.WriteLine("Method Subtract(...)");
            Console.WriteLine($"matrix3 = {matrix3}, size {matrix3.GetRowsCount()} x {matrix3.GetColumnsCount()}");
            Console.WriteLine("-");
            Console.WriteLine($"matrix3 = {matrix3}, size {matrix3.GetRowsCount()} x {matrix3.GetColumnsCount()}");

            matrix3.Subtract(matrix3);

            Console.WriteLine("=");
            Console.WriteLine($"matrix3 = {matrix3}, size {matrix3.GetRowsCount()} x {matrix3.GetColumnsCount()}");
            Console.WriteLine();

            Console.WriteLine("Method GetSum(...)");
            Console.WriteLine($"matrix4 = {matrix4}, size {matrix4.GetRowsCount()} x {matrix4.GetColumnsCount()}");
            Console.WriteLine("+");
            Console.WriteLine($"matrix4 = {matrix4}, size {matrix4.GetRowsCount()} x {matrix4.GetColumnsCount()}");

            Matrix matrix5 = Matrix.GetSum(matrix4, matrix4);

            Console.WriteLine("=");
            Console.WriteLine($"matrix5 = {matrix5}, size {matrix5.GetRowsCount()} x {matrix5.GetColumnsCount()}");
            Console.WriteLine();

            Console.WriteLine("Method GetDifference(...)");
            Console.WriteLine($"matrix4 = {matrix4}, size {matrix4.GetRowsCount()} x {matrix4.GetColumnsCount()}");
            Console.WriteLine("-");
            Console.WriteLine($"matrix4 = {matrix4}, size {matrix4.GetRowsCount()} x {matrix4.GetColumnsCount()}");

            Matrix matrix6 = Matrix.GetDifference(matrix4, matrix4);

            Console.WriteLine("=");
            Console.WriteLine($"matrix6 = {matrix6}, size {matrix6.GetRowsCount()} x {matrix6.GetColumnsCount()}");
            Console.WriteLine();

            Console.WriteLine("Method GetProduct(...)");

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

            Console.WriteLine($"matrix8 = {matrix8}, size {matrix8.GetRowsCount()} x {matrix8.GetColumnsCount()}");
            Console.WriteLine("*");
            Console.WriteLine($"matrix7 = {matrix7}, size {matrix7.GetRowsCount()} x {matrix7.GetColumnsCount()}");

            Matrix matrix9 = Matrix.GetProduct(matrix8, matrix7);
            //Matrix matrix9 = Matrix.GetProduct(matrix7, matrix8);

            Console.WriteLine("=");
            Console.WriteLine($"matrix9 = {matrix9}, size {matrix9.GetRowsCount()} x {matrix9.GetColumnsCount()}");
        }
    }
}