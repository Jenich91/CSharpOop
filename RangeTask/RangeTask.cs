using System;

namespace RangeTask
{
    class Range
    {
        private double from;
        private double to;

        public double From
        {
            get
            {
                return from;
            }

            set
            {
                from = value;
            }
        }

        public double To
        {
            get
            {
                return to;
            }

            set
            {
                to = value;
            }
        }

        public Range(double from, double to)
        {
            this.from = from;
            this.to = to;
        }

        public double GetLength()
        {
            return this.to - this.from;
        }

        public bool IsInside(double number)
        {
            if ((number >= From) && (number <= To))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        class Class
        {
            static void DistanceBetweenPoints()
            {
                //Найти расстояние между двумя точками в прямоугольной системе координат

                Console.WriteLine("Введите координаты точки A1, по оси X: ");
                double x1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Введите координаты точки A1, по оси Y: ");
                double y1 = Convert.ToDouble(Console.ReadLine());

                Range a1 = new Range(x1, y1);

                Console.WriteLine("Введите координаты точки A2, по оси X: ");
                double x2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Введите координаты точки A2, по оси Y: ");
                double y2 = Convert.ToDouble(Console.ReadLine());

                Range a2 = new Range(x2, y2);

                Range pointsX = new Range(x2, x1);
                Range pointsY = new Range(y2, y1);

                double result = Math.Sqrt((Math.Pow(pointsX.GetLength(), 2) + Math.Pow(pointsY.GetLength(), 2)));
                Console.WriteLine("Расстояние между двумя точками: " + result);
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

                Console.WriteLine();

                if (range.IsInside(number))
                {
                    Console.WriteLine("Число {0} принадлежит к диапазону от {1} до {2}", number, from, to);
                }
                else
                {
                    Console.WriteLine("Число {0} не принадлежит к диапазону от {1} до {2}", number, from, to);
                }

                // пример
                DistanceBetweenPoints();
            }
        }
    }

}