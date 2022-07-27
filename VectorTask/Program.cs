using System;

namespace VectorTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Program demonstrates Vector class functionality");
            Console.WriteLine();

            Vector vector1 = new Vector(3);
            Vector vector2 = new Vector(vector1);
            Vector vector3 = new Vector(new double[] { 4, 5, 6, 0 });
            Vector vector4 = new Vector(6, new double[] { 7, 8 });

            Console.WriteLine("vector1 {0}, dim {1}, len {2}", vector1.ToString(), vector1.GetSize(), vector1.GetLength());
            Console.WriteLine("vector2 {0}, dim {1}, len {2}", vector2.ToString(), vector2.GetSize(), vector2.GetLength());
            Console.WriteLine("vector3 {0}, dim {1}, len {2}", vector3.ToString(), vector3.GetSize(), vector3.GetLength());
            Console.WriteLine("vector4 {0}, dim {1}, len {2}", vector4.ToString(), vector4.GetSize(), vector4.GetLength());
            Console.WriteLine();

            vector1.Components = new double[] { 1, 2, 3 };
            vector3.AddVector(vector1);
            Console.WriteLine("vector1 {0}, dim {1}, len {2}", vector1.ToString(), vector1.GetSize(), vector1.GetLength());
            Console.WriteLine("vector3 {0}, dim {1}, len {2}", vector3.ToString(), vector3.GetSize(), vector3.GetLength());

            vector3.SubtractVector(vector4);
            Console.WriteLine("vector3 {0}, dim {1}, len {2}", vector3.ToString(), vector3.GetSize(), vector3.GetLength());

            vector3.MultiplyByScalar(-1.1257);
            Console.WriteLine("vector3 {0}, dim {1}, len {2}", vector3.ToString(), vector3.GetSize(), vector3.GetLength());

            vector3.ReverseVector();
            Console.WriteLine("vector3 {0}, dim {1}, len {2}", vector3.ToString(), vector3.GetSize(), vector3.GetLength());
        }
    }
}
