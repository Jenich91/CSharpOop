using System;

namespace VectorTask
{
    class VectorTask
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            double[] vectors = { 1, 2, 3, 4};
            Vector vector = new Vector(n, vectors);
            Console.WriteLine(vector.pointA.X + "," + vector.pointA.Y + "-" + vector.pointB.X + "," + vector.pointB.Y);
        }
    }
}
