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

            Console.WriteLine("Creating vectors by constructors:");
            Console.WriteLine("vector1 {0}, dim {1}, len {2}, hash {3}", vector1.ToString(), vector1.GetSize(), vector1.GetLength(), vector1.GetHashCode());
            Console.WriteLine("vector2 {0}, dim {1}, len {2}, hash {3}", vector2.ToString(), vector2.GetSize(), vector2.GetLength(), vector2.GetHashCode());
            Console.WriteLine("vector3 {0}, dim {1}, len {2}, hash {3}", vector3.ToString(), vector3.GetSize(), vector3.GetLength(), vector3.GetHashCode());
            Console.WriteLine("vector4 {0}, dim {1}, len {2}, hash {3}", vector4.ToString(), vector4.GetSize(), vector4.GetLength(), vector4.GetHashCode());
            Console.WriteLine();
            //
            Console.WriteLine("Method AddVector: vector3 = vector3 + vector2");
            Console.WriteLine("vector3 {0}, dim {1}, len {2}", vector3.ToString(), vector3.GetSize(), vector3.GetLength());
            Console.WriteLine("vector2 {0}, dim {1}, len {2}", vector2.ToString(), vector2.GetSize(), vector2.GetLength());

            vector3.AddVector(vector2);

            Console.WriteLine("vector3 {0}, dim {1}, len {2}", vector3.ToString(), vector3.GetSize(), vector3.GetLength());
            Console.WriteLine();
            //
            Console.WriteLine("Method SubtractVector: vector2 = vector2 - vector3");
            Console.WriteLine("vector2 {0}, dim {1}, len {2}", vector2.ToString(), vector2.GetSize(), vector2.GetLength());
            Console.WriteLine("vector3 {0}, dim {1}, len {2}", vector3.ToString(), vector3.GetSize(), vector3.GetLength());

            vector2.SubtractVector(vector3);

            Console.WriteLine("vector2 {0}, dim {1}, len {2}", vector2.ToString(), vector2.GetSize(), vector2.GetLength());
            Console.WriteLine();
            //
            Console.WriteLine("Method MultiplyByScalar: vector2 = vector2 * 2");
            Console.WriteLine("vector2 {0}, dim {1}, len {2}", vector2.ToString(), vector2.GetSize(), vector2.GetLength());

            vector2.MultiplyByScalar(2);

            Console.WriteLine("vector2 {0}, dim {1}, len {2}", vector2.ToString(), vector2.GetSize(), vector2.GetLength());
            Console.WriteLine();
            //
            Console.WriteLine("Method ReverseVector: vector2 = -vector2");
            Console.WriteLine("vector2 {0}, dim {1}, len {2}", vector2.ToString(), vector2.GetSize(), vector2.GetLength());

            vector2.ReverseVector();

            Console.WriteLine("vector2 {0}, dim {1}, len {2}", vector2.ToString(), vector2.GetSize(), vector2.GetLength());
            Console.WriteLine();
            //
            Console.WriteLine("Method GetComponent:");
            Console.WriteLine("vector2 components: {0}, {1}, {2}, {3}",
                vector2.GetComponent(0), vector2.GetComponent(1), vector2.GetComponent(2), vector2.GetComponent(3));
            Console.WriteLine();
            //           
            vector2.SetComponent(0, 21);
            vector2.SetComponent(1, 22);
            vector2.SetComponent(2, 23);
            vector2.SetComponent(3, 24);

            Console.WriteLine("Method SetComponent:");
            Console.WriteLine("vector2 {0}, dim {1}, len {2}", vector2.ToString(), vector2.GetSize(), vector2.GetLength());
            Console.WriteLine();
            //
            Vector vector7 = new(vector1);
            Console.WriteLine("Overrided methods Equals and GetHashCode:");
            Console.WriteLine("vector1 {0}, dim {1}, len {2}, hash {3}", vector1.ToString(), vector1.GetSize(), vector1.GetLength(), vector1.GetHashCode());
            Console.WriteLine("vector1 {0}, dim {1}, len {2}, hash {3}", vector1.ToString(), vector1.GetSize(), vector1.GetLength(), vector1.GetHashCode());
            Console.WriteLine(vector1.Equals(vector1));
            Console.WriteLine("vector1 {0}, dim {1}, len {2}, hash {3}", vector1.ToString(), vector1.GetSize(), vector1.GetLength(), vector1.GetHashCode());
            Console.WriteLine("vector7 {0}, dim {1}, len {2}, hash {3}", vector7.ToString(), vector7.GetSize(), vector7.GetLength(), vector7.GetHashCode());
            Console.WriteLine(vector1.Equals(vector1));
            Console.WriteLine("vector1 {0}, dim {1}, len {2}, hash {3}", vector1.ToString(), vector1.GetSize(), vector1.GetLength(), vector1.GetHashCode());
            Console.WriteLine("vector2 {0}, dim {1}, len {2}, hash {3}", vector2.ToString(), vector2.GetSize(), vector2.GetLength(), vector2.GetHashCode());
            Console.WriteLine(vector1.Equals(vector2));
            Console.WriteLine();

            Console.WriteLine(vector1.Equals(vector3));
            //
            Vector vector5 = Vector.AddVectors(vector2, vector3);

            Console.WriteLine("Method AddVectors: vector5 = vector2 + vector3");
            Console.WriteLine("vector2 {0}, dim {1}, len {2}", vector2.ToString(), vector2.GetSize(), vector2.GetLength());
            Console.WriteLine("vector3 {0}, dim {1}, len {2}", vector3.ToString(), vector3.GetSize(), vector3.GetLength());
            Console.WriteLine("vector5 {0}, dim {1}, len {2}", vector5.ToString(), vector5.GetSize(), vector5.GetLength());
            Console.WriteLine();
            //
            Vector vector6 = Vector.SubtractVectors(vector5, vector4);

            Console.WriteLine("Method SubtractVectors: vector6 = vector5 - vector4");
            Console.WriteLine("vector5 {0}, dim {1}, len {2}", vector5.ToString(), vector5.GetSize(), vector5.GetLength());
            Console.WriteLine("vector4 {0}, dim {1}, len {2}", vector4.ToString(), vector4.GetSize(), vector4.GetLength());
            Console.WriteLine("vector6 {0}, dim {1}, len {2}", vector6.ToString(), vector6.GetSize(), vector6.GetLength());
            Console.WriteLine();
            //
            Console.WriteLine("Method GetScalarProduct: vector2 · vector4");
            Console.WriteLine("vector2 {0}, dim {1}, len {2}", vector2.ToString(), vector2.GetSize(), vector2.GetLength());
            Console.WriteLine("vector4 {0}, dim {1}, len {2}", vector4.ToString(), vector4.GetSize(), vector4.GetLength());
            Console.WriteLine("{0}", Vector.GetScalarProduct(vector2, vector4));
        }
    }
}
