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
            Vector vector4 = new Vector(5, new double[] { 7, 8 });

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

            vector3.MultiplyByScalar(-2);
            Console.WriteLine("vector3 {0}, dim {1}, len {2}", vector3.ToString(), vector3.GetSize(), vector3.GetLength());

            vector3.ReverseVector();
            Console.WriteLine("vector3 {0}, dim {1}, len {2}", vector3.ToString(), vector3.GetSize(), vector3.GetLength());

            Console.WriteLine("{0}, {1}, {2}", vector3.GetComponent(0), vector3.GetComponent(1), vector3.GetComponent(2));

            vector3.SetComponent(0, 10);
            vector3.SetComponent(2, -10);
            Console.WriteLine("vector3 {0}, dim {1}, len {2}", vector3.ToString(), vector3.GetSize(), vector3.GetLength());

            //vector1.Equals(vector2);

            Vector vector5 = Vector.AddVectors(vector3, vector4);
            Console.WriteLine("vector5 {0}, dim {1}, len {2}", vector5.ToString(), vector5.GetSize(), vector5.GetLength());

            Vector vector6 = Vector.SubtractVectors(vector3, vector1);
            Console.WriteLine("vector6 {0}, dim {1}, len {2}", vector6.ToString(), vector6.GetSize(), vector6.GetLength());

            Console.WriteLine("{0}, {1}, {2}", 
                Vector.GetScalarProduct(vector1, vector3), Vector.GetScalarProduct(vector3, vector4), Vector.GetScalarProduct(vector3, vector5));
        }
    }
}
