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
            Vector vector3 = new Vector(new double[] { 4, 5, 6 });
            Vector vector4 = new Vector(3, new double[] { 7, 8 });

            Console.WriteLine("vector1 ({0}, {1}, {2})", vector1.Components[0], vector1.Components[1], vector1.Components[2]);
            Console.WriteLine("vector2 ({0}, {1}, {2})", vector2.Components[0], vector2.Components[1], vector2.Components[2]);
            Console.WriteLine("vector3 ({0}, {1}, {2})", vector3.Components[0], vector3.Components[1], vector3.Components[2]);
            Console.WriteLine("vector4 ({0}, {1}, {2})", vector4.Components[0], vector4.Components[1], vector4.Components[2]);
            Console.WriteLine();

            vector1.Components = new double[] { 1, 2, 3 };

            Console.WriteLine("vector1 ({0}, {1}, {2})", vector1.Components[0], vector1.Components[1], vector1.Components[2]);
            Console.WriteLine("vector2 ({0}, {1}, {2})", vector2.Components[0], vector2.Components[1], vector2.Components[2]);
            Console.WriteLine("vector3 ({0}, {1}, {2})", vector3.Components[0], vector3.Components[1], vector3.Components[2]);
        }
    }
}
