using ShapesTask.Shapes;
using System;

namespace ShapesTask
{
    class ShapeMain
    {
        static int FindShapeWithMaximumArea(IShape[] shapes)
        {
            Array.Sort(shapes, new AreaComparer());

            int lastElementIndex = shapes.GetLength(0) - 1;
            return lastElementIndex;
        }

        static int FindShapeWithSecondPerimeter(IShape[] shapes)
        {
            Array.Sort(shapes, new PerimeterComparer());

            int prelastElementIndex = shapes.GetLength(0) - 2;
            return prelastElementIndex;
        }

        static void Main(string[] args)
        {
            IShape[] shapes = { new Square(2), new Square(2), new Triangle(2, 3, 6, 3, 4, 12), new Triangle(3, 3, 6, 3, 4, 12), new Rectangle(4, 4), new Rectangle(3, 4), new Circle(4), new Circle(3) };

            Console.WriteLine("Фигура с максимальной площадью - " + shapes[FindShapeWithMaximumArea(shapes)]);
            Console.WriteLine("Фигура со вторым по величине периметром - " + shapes[FindShapeWithSecondPerimeter(shapes)]);

            Console.WriteLine("Фигура - " + shapes[0] + " равна " + "фигуре - " + shapes[1] + " ?");
            Console.WriteLine(shapes[0].Equals(shapes[1]) ? "Да" : "Нет");
        }
    }
}


