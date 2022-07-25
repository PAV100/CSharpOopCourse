using System;

namespace RangeTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("The program demonstrates initialisation and modification of Range class instances");
            Console.WriteLine();

            double from = -5; // 1. normal limits order 
            double to = 5;
            double testPoint = 0;

            Range range1 = new Range(from, to);
            double length = range1.GetLength();
            bool isInside = range1.IsInside(testPoint);
            string isInsideText = isInside ? "is inside" : "is not inside";

            Console.WriteLine("from = {0}, to = {1}, class instance: [{2}, {3}], length = {4}, test point {5} {6}",
                from, to, range1.From, range1.To, length, testPoint, isInsideText);

            range1.From = -7; // set new "from" value, without limits swaping
            length = range1.GetLength();
            isInside = range1.IsInside(testPoint);
            isInsideText = isInside ? "is inside" : "is not inside";

            Console.WriteLine("from = {0}, to = {1}, class instance: [{2}, {3}], length = {4}, test point {5} {6}",
                from, to, range1.From, range1.To, length, testPoint, isInsideText);
            Console.WriteLine();

            from = 0; // 3. equal limits
            to = 0;
            testPoint = 0;

            Range range3 = new Range(from, to);
            length = range3.GetLength();
            isInside = range3.IsInside(testPoint);
            isInsideText = isInside ? "is inside" : "is not inside";

            Console.WriteLine("from = {0}, to = {1}, class instance: [{2}, {3}], length = {4}, test point {5} {6}",
                from, to, range3.From, range3.To, length, testPoint, isInsideText);

            range3.From = -0.01; // set new "from" and "to" values, without limits swaping
            range3.To = -0.001;
            length = range3.GetLength();
            isInside = range3.IsInside(testPoint);
            isInsideText = isInside ? "is inside" : "is not inside";

            Console.WriteLine("from = {0}, to = {1}, class instance: [{2}, {3}], length = {4}, test point {5} {6}",
                from, to, range3.From, range3.To, length, testPoint, isInsideText);
            Console.WriteLine();
        }
    }
}