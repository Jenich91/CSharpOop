using System;

namespace ShapesTask.Shapes
{
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
            return $"Прямоугольник высотой {GetWidth()},  шириной {GetHeight()}, площадью {GetArea():N2} и периметром {GetPerimeter():N2}";
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

            Rectangle rectangle = (Rectangle)obj;

            return Width == rectangle.Width && Heigth == rectangle.Heigth;
        }

        public override int GetHashCode()
        {
            int prime = 17;
            int hash = 1;
            hash = prime * hash + Width.GetHashCode();
            hash = prime * hash + Heigth.GetHashCode();

            return hash;
        }

        public double GetWidth()
        {
            return Width > Heigth ? Width : Heigth;
        }

        public double GetHeight()
        {
            return Width < Heigth ? Width : Heigth;
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
}
