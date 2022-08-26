using System;
using System.Collections.Generic;

namespace ShapeTask
{
    internal class ShapeAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (shape1 is null)
            {
                throw new ArgumentNullException(nameof(shape1), "Shape1 must not be null");
            }

            if (shape2 is null)
            {
                throw new ArgumentNullException(nameof(shape2), "Shape2 must not be null");
            }

            return shape1.GetArea().CompareTo(shape2.GetArea());
        }
    }
}
