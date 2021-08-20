using System.Collections.Generic;

namespace AcademIT.Vyatkin
{
    class AreaComparer : IComparer<IShape>
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

    class PerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (Shape.GetPerimeter(shape1) < Shape.GetPerimeter(shape2))
            {
                return -1;
            }
            else if (Shape.GetPerimeter(shape1) > Shape.GetPerimeter(shape2))
            {
                return 1;
            }

            return 0;
        }
    }
}