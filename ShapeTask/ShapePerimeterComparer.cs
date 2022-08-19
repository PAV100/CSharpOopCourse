using System;
using System.Collections.Generic;

namespace ShapeTask
{
    internal class ShapePerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape x, IShape y)
        {
            if (x is null || y is null)
            {
                throw new ArgumentNullException(nameof(x) + ", " + nameof(x), "Compared shapes must not be null");
            }

            double xPerimeter = x.GetPerimeter();
            double yPerimeter = y.GetPerimeter();

            if (xPerimeter > yPerimeter)
            {
                return 1;
            }

            if (xPerimeter < yPerimeter)
            {
                return -1;
            }

            return 0;
        }
    }    
}
