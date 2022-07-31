using System;

namespace RangeTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("The program demonstrates operations on sets of Range class instances");
            Console.WriteLine();

            Range range1 = new Range(10, 30);
            Range[] range2 = new Range[]
            {
                new Range(0, 5),     // 1. range2 does not overlap range1
                new Range(0, 10),    // 2. range2 touches range1 in left endpoint
                new Range(0, 15),    // 3. range2 partially overlaps range1 from left side
                new Range(0, 30),    // 4. range1 inside range2 and ranges have the same right endpoint
                new Range(15, 30),   // 5. range2 inside range1 and ranges have the same right endpoint
                new Range(0, 40),    // 6. range1 inside range2
                new Range(10, 30),   // 7. ranges are the same
                new Range(15, 25),   // 8. range2 inside range1
                new Range(10, 25),   // 9. range2 inside range1 and ranges have the same left endpoint
                new Range(10, 40),   // 10. range1 inside range2 and ranges have the same left endpoint
                new Range(25, 40),   // 11. range2 partially overlaps range1 from right side
                new Range(30, 40),   // 12. range2 touches range1 in right endpoint
                new Range(35, 40)    // 13. range2 does not overlap range1
            };

            string formatString = "{0,-15}{1,-15}{2,-15}{3,-25}{4}";

            Console.WriteLine(formatString, "range1", "range2", "Intersection", "Union", "Difference");

            foreach (Range e in range2)
            {
                Range rangesIntersection = range1.GetIntersection(e);
                
                string range1Text = range1.ToString();
                string range2Text = e.ToString();
                string rangesIntersectionText = (rangesIntersection is null) ? "null" : rangesIntersection.ToString();
                string rangesUnionText= Range.ToString(range1.GetUnion(e));
                string rangesDifferenceText= Range.ToString(range1.GetDifference(e));

                Console.WriteLine(formatString, range1Text, range2Text, rangesIntersectionText, rangesUnionText, rangesDifferenceText);
            }
        }
    }
}