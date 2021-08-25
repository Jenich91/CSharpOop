using System;

namespace AcademIT.Vyatkin
{
    public class Shape
    {
        public double GetWidth(IShape shape)
        {
            return shape.GetWidth();
        }

        public double GetHeight(IShape shape)
        {
            return shape.GetHeight();
        }

        public static double GetArea(IShape shape)
        {
            return shape.GetArea();
        }

        public static double GetPerimeter(IShape shape)
        {
            return shape.GetPerimeter();
        }

        public string ToString(IShape shape)
        {
            return shape.ToString();
        }
    }

    public class Square : IShape
    {
        private double SideLength { get; set; }

        public Square(double sideLength)
        {
            this.SideLength = sideLength;
        }

        public override string ToString()
        {
            return string.Join(",", GetWidth(), GetHeight(), GetArea(), GetPerimeter());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || GetType() != obj.GetType())
            {
                return false;
            }

            return (SideLength == ((Square)obj).SideLength);
        }

        public override int GetHashCode()
        {
            return (int)SideLength;
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
        private double X1 { get; set; }
        private double Y1 { get; set; }
        private double X2 { get; set; }
        private double Y2 { get; set; }
        private double X3 { get; set; }
        private double Y3 { get; set; }

        private double sideAB { get; set; }
        private double sideBC { get; set; }
        private double sideCA { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;

            this.sideAB = GetTriangleSideLength(X1, Y1, X2, Y2);
            this.sideBC = GetTriangleSideLength(X2, Y2, X3, Y3);
            this.sideCA = GetTriangleSideLength(X3, Y3, X1, Y1);
        }

        public override string ToString()
        {
            return string.Join(", ", GetWidth(), GetHeight(), GetArea(), GetPerimeter());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || GetType() != obj.GetType())
            {
                return false;
            }

            return GetHashCode() == ((Triangle)obj).GetHashCode();
        }

        public override int GetHashCode()
        {
            int prime = 17;
            int hash = 1;
            hash = prime * hash + (int)this.sideAB;
            hash = prime * hash + (int)this.sideBC;
            hash = prime * hash + (int)this.sideCA;
            return hash;
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
            double semiPerimeter = (sideAB + sideBC + sideCA) / 2;

            return Math.Sqrt(semiPerimeter * (semiPerimeter - sideAB) * (semiPerimeter - sideBC) * (semiPerimeter - sideCA));
        }

        public double GetPerimeter()
        {
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

        public override string ToString()
        {
            return string.Join(",", GetWidth(), GetHeight(), GetArea(), GetPerimeter());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || GetType() != obj.GetType())
            {
                return false;
            }

            return GetHashCode() == ((Rectangle)obj).GetHashCode();
        }

        public override int GetHashCode()
        {
            int prime = 17;
            int hash = 1;
            hash = prime * hash + (int)this.Width;
            hash = prime * hash + (int)this.Heigth;
            return hash;
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

        public override string ToString()
        {
            return string.Join(",", GetWidth(), GetHeight(), GetArea(), GetPerimeter());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || GetType() != obj.GetType())
            {
                return false;
            }

            return GetHashCode() == ((Circle)obj).GetHashCode();
        }

        public override int GetHashCode()
        {
            int prime = 17;
            int hash = 1;
            hash = prime * hash + (int)this.Radius;
            return hash;
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