using ShapesTask.Shapes;
using System;

namespace ShapesTask
{
    class ShapeMain
    {
        static IShape FindShapeWithMaximumArea(IShape[] shapes)
        {
            Array.Sort(shapes, new AreaComparer());

            return shapes[shapes.Length - 1];
        }

        static IShape FindShapeWithSecondPerimeter(IShape[] shapes)
        {
            Array.Sort(shapes, new PerimeterComparer());

            return shapes[shapes.Length - 2];
        }

        static void Main(string[] args)
        {
            IShape[] shapes =
            {
                new Square(2),
                new Square(2),
                new Triangle(2, 3, 6, 3, 4, 12),
                new Triangle(3, 3, 6, 3, 4, 12),
                new Rectangle(4, 4),
                new Rectangle(3, 4),
                new Circle(4),
                new Circle(3)
            };

            Console.WriteLine("Фигура с максимальной площадью - " + FindShapeWithMaximumArea(shapes));
            Console.WriteLine("Фигура со вторым по величине периметром - " + FindShapeWithSecondPerimeter(shapes));

            Console.WriteLine("Фигура - " + shapes[0] + " равна " + "фигуре - " + shapes[1] + " ?");
            Console.WriteLine(shapes[0].Equals(shapes[1]) ? "Да" : "Нет");
        }
    }
}