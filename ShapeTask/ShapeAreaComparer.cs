using System;
using System.Collections.Generic;

namespace ShapeTask
{
    internal class ShapeAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape x, IShape y)
        {
            if (x is null || y is null)
            {
                throw new ArgumentNullException(nameof(x) + ", " + nameof(x), "Compared shapes must not be null");
            }

            double xArea = x.GetArea();
            double yArea = y.GetArea();

            if (xArea > yArea)
            {
                return 1;
            }
            
            if (xArea < yArea)
            {
                return -1;
            }

            return 0;
        }
    }
}
