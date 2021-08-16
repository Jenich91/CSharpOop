using System;

namespace ShapesTask
{
    public class Shape
    {
        public static double GetArea(IShape shape)
        {
            return shape.GetArea();
        }
    }

    public class Square : IShape
    {
        private double SideLength { get; set; }

        public Square(double sideLength)
        {
            this.SideLength = sideLength;
        }

        public double GetWidth()
        {
            return SideLength;
        }

        public double GetHeight()
        {
            return SideLength;
        }

        public double GetArea()
        {
            return Math.Pow(SideLength, 2);
        }

        public double GetPerimeter()
        {
            return SideLength * 4;
        }
    }

    public class Triangle : IShape
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public double X3 { get; set; }
        public double Y3 { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        public double GetWidth()
        {
            return Math.Max(X1, Math.Max(X2, X3)) - Math.Min(X1, Math.Max(X2, X3));
        }

        public double GetHeight()
        {
            return Math.Max(Y1, Math.Max(Y2, Y3)) - Math.Min(Y1, Math.Max(Y2, Y3));
        }

        public double GetTriangleSideLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public double GetArea()
        {
            double sideAB = GetTriangleSideLength(X1, Y1, X2, Y2);
            double sideBC = GetTriangleSideLength(X2, Y2, X3, Y3);
            double sideCA = GetTriangleSideLength(X3, Y3, X1, Y1);

            double semiPerimeter = (sideAB + sideBC + sideCA) / 2;

            return Math.Sqrt(semiPerimeter * (semiPerimeter - sideAB) * (semiPerimeter - sideBC) * (semiPerimeter - sideCA));
        }

        public double GetPerimeter()
        {
            double sideAB = GetTriangleSideLength(X1, Y1, X2, Y2);
            double sideBC = GetTriangleSideLength(X2, Y2, X3, Y3);
            double sideCA = GetTriangleSideLength(X3, Y3, X1, Y1);

            return sideAB + sideBC + sideCA;
        }
    }

    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Heigth { get; set; }

        public Rectangle(double sideLength1, double sideLength2)
        {
            Width = sideLength1;
            Heigth = sideLength2;
        }

        public double GetWidth()
        {
            return (Width > Heigth) ? Width : Heigth;
        }

        public double GetHeight()
        {
            return (Width < Heigth) ? Width : Heigth;
        }

        public double GetArea()
        {
            return Width * Heigth;
        }

        public double GetPerimeter()
        {
            return 2 * (Width + Heigth);
        }
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetWidth()
        {
            return 2 * Radius;
        }

        public double GetHeight()
        {
            return 2 * Radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}