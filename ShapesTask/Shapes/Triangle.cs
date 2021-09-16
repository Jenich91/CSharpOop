using System;

namespace ShapesTask.Shapes
{
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

        public override string ToString()
        {
            return $"Триугольник  высотой {GetWidth()},  шириной {GetHeight()}, площадью {GetArea():N2} и периметром {GetPerimeter():N2}";
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
            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();

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

        private static double GetSideLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
        }

        public double GetArea()
        {
            double sideLength1 = GetSideLength(X1, Y1, X2, Y2);
            double sideLength2 = GetSideLength(X2, Y2, X3, Y3);
            double sideLength3 = GetSideLength(X3, Y3, X1, Y1);

            double semiPerimeter = (sideLength1 + sideLength2 + sideLength3) / 2;

            return Math.Sqrt(semiPerimeter * (semiPerimeter - sideLength1) * (semiPerimeter - sideLength2) * (semiPerimeter - sideLength3));
        }

        public double GetPerimeter()
        {
            double sideAB = GetSideLength(X1, Y1, X2, Y2);
            double sideBC = GetSideLength(X2, Y2, X3, Y3);
            double sideCA = GetSideLength(X3, Y3, X1, Y1);

            return sideAB + sideBC + sideCA;
        }
    }
}
