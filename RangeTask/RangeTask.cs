using System;

namespace RangeTask
{
    class RangeTask
    {
        public static double FindDistanceBetweenPoints(Range pointA, Range pointB)
        {
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
            Console.WriteLine();

            // Part_2______________________________________________

            // Вводим числа первого диапазона
            Console.WriteLine("Введите число начало первого диапазона: ");
            double rangeStart1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите число конец первого диапазона: ");
            double rangeEnd1 = Convert.ToDouble(Console.ReadLine());

            Range interval1 = new Range(rangeStart1, rangeEnd1);

            // Вводим числа второго диапазона
            Console.WriteLine("Введите число начало второго диапазона: ");
            double rangeStart2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите число конец второго диапазона: ");
            double rangeEnd2 = Convert.ToDouble(Console.ReadLine());

            Range interval2 = new Range(rangeStart2, rangeEnd2);

            if (rangeStart1 < rangeEnd1 || rangeStart2 < rangeEnd2)
            {
                if (interval1.From != interval2.From && interval1.To != interval2.To)
                {
                    // Пересечение
                    Range intersection = interval1.GetIntersection(interval2);

                    if (intersection != null)
                    {
                        Console.WriteLine("Интервал пересечения двух интервалов: " + intersection.From + " - " + intersection.To);
                    }
                    else
                    {
                        Console.WriteLine("Пересечение двух интервалов отсутвует");
                    }

                    // Объединение

                    Range[] union = interval1.GetUnion(interval2);

                    Console.WriteLine("Интервал объединения двух интервалов: ");
                    foreach (Range rangeObj in union)
                    {
                        Console.WriteLine(String.Join(", ", rangeObj));
                    }

                    // Разность
                    Range[] difference = interval1.GetDifferenceArray(interval2);

                    if (difference != null)
                    {
                        Console.WriteLine("Интервал разности двух интервалов: ");
                        foreach (Range rangeObj in difference)
                        {
                            Console.WriteLine(String.Join(", ", rangeObj));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Разность двух интервалов отсутвует");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Интервалы в одной точке, нечего считать");
                }
            }
            else
            {
                Console.WriteLine("Неправильный ввод, начало интервала больше конца");
            }
        }
    }
}
