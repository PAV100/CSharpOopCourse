using System;
using System.Text;

namespace RangeTask
{
    internal class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return (number >= From) && (number <= To); // (number >= from) && (number <= to)
        }

        public Range GetIntersection(Range range)
        {
            if (range.From >= To || range.To <= From)
            {
                return null;
            }

            return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
        }

        public Range[] GetUnion(Range range)
        {
            if (range.From > To)
            {
                return new Range[] { new Range(From, To), new Range(range.From, range.To) };
            }

            if (range.To < From)
            {
                return new Range[] { new Range(range.From, range.To), new Range(From, To) };
            }

            return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
        }

        public Range[] GetDifference(Range range)
        {
            if (range.From <= From && range.To >= To)
            {
                return new Range[] { };
            }

            if (range.From >= To || range.To <= From)
            {
                return new Range[] { new Range(From, To) };
            }

            if (range.From > From && range.To < To)
            {
                return new Range[] { new Range(From, range.From), new Range(range.To, To) };
            }

            if (range.From > From)
            {
                return new Range[] { new Range(From, range.From) };
            }

            return new Range[] { new Range(range.To, To) };
        }

        public override string ToString()
        {
            return $"({From}; {To})";
        }

        public static string ToString(Range[] rangesArray)
        {
            if (rangesArray is null)
            {
                return "null";
            }

            StringBuilder sb = new StringBuilder();

            sb.Append('[');

            for (int i = 0; i < rangesArray.Length; i++)
            {
                if (i != 0)
                {
                    sb.Append(", ");
                }

                sb.Append(rangesArray[i]);
            }

            sb.Append(']');

            return sb.ToString();
        }
    }
}