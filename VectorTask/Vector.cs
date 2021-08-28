using System;

namespace VectorTask
{
    public class Vector
    {
        public int N { get; set; }
        public Point pointA { get; set; }
        public Point pointB { get; set; }

        public Direction direction;
        public enum Direction
        {
            ToA = 0,
            ToB = 1
        }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность вектора должна быть больше 0", nameof(n));
            }

            this.N = n;


            this.pointA = new Point(0, 0);
            this.pointB = new Point(0, 0);
            direction = Direction.ToA;
        }

        public Vector(Vector vectorToCopy)
        {
            this.N = vectorToCopy.N;
            this.pointA = vectorToCopy.pointA;
            this.pointB = vectorToCopy.pointB;
            this.direction = vectorToCopy.direction;
        }

        public Vector(double[] vectors)
        {
            this.pointA = new Point(vectors[0], vectors[1]);
            this.pointB = new Point(vectors[2], vectors[3]);
            direction = (Direction)(int)vectors[4];
        }

        public Vector(int n, double[] vectors)
        {
            if ((vectors.Length / 5) < n)
            {
                this.N = n;
                this.pointA = new Point(0, 0);
                this.pointB = new Point(0, 0);
                direction = Direction.ToA;

                return;
            }

            this.pointA = new Point(vectors[0], vectors[1]);
            this.pointB = new Point(vectors[2], vectors[3]);
            direction = (Direction)(int)vectors[4];
        }

    }
}
