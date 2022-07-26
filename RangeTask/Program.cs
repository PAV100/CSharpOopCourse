using System;

namespace RangeTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("The program demonstrates operations on sets of Range class instances");
            Console.WriteLine();

            // 1. range2 does not overlap range1
            Range range1 = new Range(10, 20);
            Range range2 = new Range(0, 8);
            Range rangesIntersection1 = range1.GetIntersection(range2);
            Range[] rangesUnion1 = range1.GetUnion(range2);
            Range[] rangesDifference1 = range1.GetDifference(range2);

            Console.WriteLine("Intersection of {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesIntersection1));
            Console.WriteLine("Union of        {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesUnion1));
            Console.WriteLine("Difference of   {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesDifference1));
            Console.WriteLine();

            // 2. range2 touches range1 in one endpoint 
            range2.To = 10;
            Range rangesIntersection2 = range1.GetIntersection(range2);
            Range[] rangesUnion2 = range1.GetUnion(range2);
            Range[] rangesDifference2 = range1.GetDifference(range2);

            Console.WriteLine("Intersection of {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesIntersection2));
            Console.WriteLine("Union of        {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesUnion2));
            Console.WriteLine("Difference of   {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesDifference2));
            Console.WriteLine();

            // 3. range2 partially overlaps range1
            range2.To = 18;
            Range rangesIntersection3 = range1.GetIntersection(range2);
            Range[] rangesUnion3 = range1.GetUnion(range2);
            Range[] rangesDifference3 = range1.GetDifference(range2);

            Console.WriteLine("Intersection of {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesIntersection3));
            Console.WriteLine("Union of        {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesUnion3));
            Console.WriteLine("Difference of   {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesDifference3));
            Console.WriteLine();

            // 4. ranges have the same right endpoint
            range2.To = 20;
            Range rangesIntersection4 = range1.GetIntersection(range2);
            Range[] rangesUnion4 = range1.GetUnion(range2);
            Range[] rangesDifference4 = range1.GetDifference(range2);

            Console.WriteLine("Intersection of {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesIntersection4));
            Console.WriteLine("Union of        {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesUnion4));
            Console.WriteLine("Difference of   {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesDifference4));
            Console.WriteLine();

            // 5. range1 inside range2
            range2.To = 30;
            Range rangesIntersection5 = range1.GetIntersection(range2);
            Range[] rangesUnion5 = range1.GetUnion(range2);
            Range[] rangesDifference5 = range1.GetDifference(range2);

            Console.WriteLine("Intersection of {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesIntersection5));
            Console.WriteLine("Union of        {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesUnion5));
            Console.WriteLine("Difference of   {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesDifference5));
            Console.WriteLine();

            // 6. ranges are the same
            range2.From = 10;
            range2.To = 20;
            Range rangesIntersection6 = range1.GetIntersection(range2);
            Range[] rangesUnion6 = range1.GetUnion(range2);
            Range[] rangesDifference6 = range1.GetDifference(range2);

            Console.WriteLine("Intersection of {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesIntersection6));
            Console.WriteLine("Union of        {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesUnion6));
            Console.WriteLine("Difference of   {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesDifference6));
            Console.WriteLine();

            // 7. range2 inside range1
            range2.From = 12;
            range2.To = 18;
            Range rangesIntersection7 = range1.GetIntersection(range2);
            Range[] rangesUnion7 = range1.GetUnion(range2);
            Range[] rangesDifference7 = range1.GetDifference(range2);

            Console.WriteLine("Intersection of {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesIntersection7));
            Console.WriteLine("Union of        {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesUnion7));
            Console.WriteLine("Difference of   {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesDifference7));
            Console.WriteLine();

            // 8. ranges have the same left endpoint
            range2.From = 10;
            range2.To = 30;
            Range rangesIntersection8 = range1.GetIntersection(range2);
            Range[] rangesUnion8 = range1.GetUnion(range2);
            Range[] rangesDifference8 = range1.GetDifference(range2);

            Console.WriteLine("Intersection of {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesIntersection8));
            Console.WriteLine("Union of        {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesUnion8));
            Console.WriteLine("Difference of   {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesDifference8));
            Console.WriteLine();

            // 9. range2 partially overlaps range1
            range2.From = 18;
            Range rangesIntersection9 = range1.GetIntersection(range2);
            Range[] rangesUnion9 = range1.GetUnion(range2);
            Range[] rangesDifference9 = range1.GetDifference(range2);

            Console.WriteLine("Intersection of {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesIntersection9));
            Console.WriteLine("Union of        {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesUnion9));
            Console.WriteLine("Difference of   {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesDifference9));
            Console.WriteLine();

            // 10.  // range2 touches range1 in an endpoint
            range2.From = 20;
            Range rangesIntersection10 = range1.GetIntersection(range2);
            Range[] rangesUnion10 = range1.GetUnion(range2);
            Range[] rangesDifference10 = range1.GetDifference(range2);

            Console.WriteLine("Intersection of {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesIntersection10));
            Console.WriteLine("Union of        {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesUnion10));
            Console.WriteLine("Difference of   {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesDifference10));
            Console.WriteLine();

            // 11. range2 does not overlap range1
            range2.From = 22;
            Range rangesIntersection11 = range1.GetIntersection(range2);
            Range[] rangesUnion11 = range1.GetUnion(range2);
            Range[] rangesDifference11 = range1.GetDifference(range2);

            Console.WriteLine("Intersection of {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesIntersection11));
            Console.WriteLine("Union of        {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesUnion11));
            Console.WriteLine("Difference of   {0} and {1} is {2}", Range.ToString(range1), Range.ToString(range2), Range.ToString(rangesDifference11));
        }
    }
}