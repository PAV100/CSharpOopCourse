using System;

namespace ShapeTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Program demonstrates Shape classes and interfaces family functionality");
            Console.WriteLine();

            string formatString = "{0,-15}{1,-20}{2,-20}{3,-20}{4}";

            Console.WriteLine("Let's create an array of several shapes:");
            Console.WriteLine(formatString, "TYPE", "WIDTH", "HEIGHT", "AREA", "PERIMETER");

            IShape[] shapes =
            {
                new Square(4),
                new Triangle(0, 0, 6, 0, 0, 10),
                new Rectangle(2, 3),
                new Circle(2),
                new Square(5),
                new Triangle(1, 2, 5, 7, 15, 15),
                new Rectangle(1.5, 3.5),
                new Circle(3)
            };

            foreach (IShape e in shapes)
            {
                Console.Write(formatString, e.GetType().Name, e.GetWidth(), e.GetHeight(), e.GetArea(), e.GetPerimeter());
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Let's apply GetMaxAreaShape method and get 1st max area = {GetMaxAreaShape(shapes, 1).GetArea()}");

            Console.WriteLine();
            Console.WriteLine($"Let's apply GetMaxPerimeterShape method and get 2nd max perimeter = {GetMaxPerimeterShape(shapes, 2).GetPerimeter()}");
            Console.WriteLine();

            Console.WriteLine("Let's create one more array, print it out with overrided ToString(), test overrided GetHashCode() and Equals():");

            IShape[] shapes2 =
            {
                new Square(4),
                new Circle(4),
                new Square(5),
                new Square(4),
                new Triangle(1, 1, 4, 1, 4, 5),
                new Rectangle(5, 6)
            };

            foreach (IShape e in shapes2)
            {
                Console.WriteLine($"{e}   hash = {e.GetHashCode()}   (shapes2[0] == shapes2[i]) == {shapes2[0].Equals(e)}");
            }
        }

        public static IShape GetMaxAreaShape(IShape[] shapes, int nthMaxNumber)
        {
            if (shapes is null)
            {
                throw new ArgumentNullException(nameof(shapes), "Shapes array must not be null");
            }

            if (nthMaxNumber < 1 || nthMaxNumber > shapes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(nthMaxNumber), $"NthMaxNumber = {nthMaxNumber}, but it must be in range [1; {shapes.Length}]");
            }

            Array.Sort(shapes, new ShapeAreaComparer());

            return shapes[^nthMaxNumber];
        }

        public static IShape GetMaxPerimeterShape(IShape[] shapes, int nthMaxNumber)
        {
            if (shapes is null)
            {
                throw new ArgumentNullException(nameof(shapes), "Shapes array must not be null");
            }

            if (nthMaxNumber < 1 || nthMaxNumber > shapes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(nthMaxNumber), $"NthMaxNumber = {nthMaxNumber}, but it must be in range [1; {shapes.Length}]");
            }

            Array.Sort(shapes, new ShapePerimeterComparer());

            return shapes[^nthMaxNumber];
        }
    }
}
