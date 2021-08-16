using System;
using System.Collections.Generic;
using System.Text;

namespace ShapesTask
{
    class CompareClass : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (Shape.GetArea(shape1) < Shape.GetArea(shape2))
            {
                return -1;
            }
            else if (Shape.GetArea(shape1) > Shape.GetArea(shape2))
            {
                return 1;
            }

            return 0;
        }
    }
}
