using System;
using System.Collections.Generic;

namespace ShapesTask
{
    class ShapeTask// : IComparer<IShape>
    {
        //    public int Compare(IShape shape1, IShape shape2)
        //    {
        //        if (Shape.GetArea(shape1) < Shape.GetArea(shape2))
        //        {
        //            return -1;
        //        }
        //        else if (Shape.GetArea(shape1) > Shape.GetArea(shape2))
        //        {
        //            return 1;
        //        }

        //        return 0;
        //    }

        //public int CompareTo(IShape shape2)
        //{


        //    if (shape != null)
        //    {
        //        if (this.GetArea() < Shape.GetArea(shape2))
        //        {
        //            return -1;
        //        }
        //        else if (this.GetArea() > Shape.GetArea(shape2))
        //        {
        //            return 1;
        //        }

        //        return 0;
        //    }
        //    else
        //    {
        //        throw new Exception("Параметр должен быть типа Shape");
        //    }
        //}

        static double GetMaxArea(IShape[] shapes)
        {
            Array.Sort(shapes, new CompareClass());
            //TODO return area in last element
            return 0;
        }
        static void Main(string[] args)
        {
            IShape[] shapes = { new Square(2), new Triangle(2, 3, 6, 3, 4, 0), new Triangle(12, -3, 6, 3, 2, 0), new Rectangle(3, 4), new Circle(3) };
            Console.WriteLine(GetMaxArea(shapes));
            //IShape d = new Square(3);
            //Shape.GetArea(d);
        }
    }
}