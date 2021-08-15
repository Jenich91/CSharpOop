using System;
using ShapesTask;

namespace ShapesTask
{
    class ShapeTask : IComparable
    {
        public int CompareTo(object obj)
        {
            Shape shape = obj as Shape;

            if (shape != null)
            {
                if (this.GetArea() < shape.GetArea())
                {
                    return -1;
                }
                else if (this.GetArea() > shape.GetArea())
                {
                    return 1;
                }

                return 0;
            }
            else
            {
                throw new Exception("Параметр должен быть типа Shape");
            }

        }

        static double GetMaxArea(IShape[] shapes)
        {
            Array.Sort(shapes);

            return 0;
        }
        static void Main(string[] args)
        {
            Shape.Square s = new Square();
            IShape[] shapes = { new Shape.Square(2), new Shape.Triangle(2, 3, 6, 3, 4, 0), new Shape.Triangle(12, -3, 6, 3, 2, 0), new Shape.Rectangle(3, 4), new Shape.Circle(3) };
            Console.WriteLine(GetMaxArea(shapes));
        }
    }
}