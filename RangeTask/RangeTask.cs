using System;

namespace RangeTask
{
    class RangeAndDistance
    {
        public static double FindDistanceBetweenPoints(Range pointA, Range pointB)
        {
            // Найти расстояние между двумя точками в прямоугольной системе координат

            return Math.Sqrt(Math.Pow(pointB.From - pointA.From, 2) + Math.Pow(pointB.To - pointA.To, 2));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите число начало диапазона: ");
            double from = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите число конец диапазона: ");
            double to = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите число которое надо проверить на принадлежность к диапазону: ");
            double number = Convert.ToDouble(Console.ReadLine());

            Range range = new Range(from, to);

            Console.WriteLine("Начало диапазона: " + range.From);
            Console.WriteLine("Конец диапазона: " + range.To);
            Console.WriteLine("Длина диапазона: " + range.GetLength());

            if (range.IsInside(number))
            {
                Console.WriteLine("Число {0} принадлежит к диапазону от {1} до {2}", number, from, to);
            }
            else
            {
                Console.WriteLine("Число {0} не принадлежит к диапазону от {1} до {2}", number, from, to);
                Console.WriteLine();
            }

            Console.WriteLine();

            // пример

            Console.WriteLine("Введите координаты точки A, по оси X: ");
            double x1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите координаты точки A, по оси Y: ");
            double y1 = Convert.ToDouble(Console.ReadLine());

            Range pointA = new Range(x1, y1);

            Console.WriteLine("Введите координаты точки B, по оси X: ");
            double x2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите координаты точки B, по оси Y: ");
            double y2 = Convert.ToDouble(Console.ReadLine());

            Range pointB = new Range(x2, y2);

            Console.WriteLine("Расстояние между двумя точками: " + FindDistanceBetweenPoints(pointA, pointB));
        }
    }
}