﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeTask
{
    internal class Range
    {
        private const double Epsilon = 1.0e-10;

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
            return (number - From >= -Epsilon) && (number - To <= Epsilon); // (number >= from) && (number <= to)
        }
    }
}
