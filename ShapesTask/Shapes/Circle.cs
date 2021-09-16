using System;

namespace ShapesTask.Shapes
{
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override string ToString()
        {
            return $"Круг высотой {GetWidth()},  шириной {GetHeight()}, площадью {GetArea():N2} и периметром {GetPerimeter():N2}";
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

            return Radius == ((Circle)obj).Radius;
        }

        public override int GetHashCode()
        {
            int prime = 17;
            int hash = 1;
            hash = prime * hash + Radius.GetHashCode();

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
            return Math.PI * (Radius * Radius);
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
