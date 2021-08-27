using System;

namespace AcademIT.Vyatkin
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
                    if (interval1.IsContinuousInterval(interval2))
                    {
                        Range сombination = interval1.GetCombination(interval2);
                        Console.WriteLine("Интервал объединения двух интервалов: " + сombination.From + " - " + сombination.To);
                    }
                    else
                    {
                        Range[] сombinationArray = interval1.GetCombinationArray(interval2);

                        Console.WriteLine("Первый интервал объединения двух интервалов: " + сombinationArray[0].From + " - " + сombinationArray[0].To);
                        Console.WriteLine("Второй интервал объединения двух интервалов: " + сombinationArray[1].From + " - " + сombinationArray[1].To);
                    }

                    // Разность
                    if (interval1.IsContinuousIntervalAfterDifference(interval2))
                    {
                        Range difference = interval1.GetDifference(interval2);

                        if (difference != null)
                        {
                            Console.WriteLine("Интервал разности двух интервалов: " + difference.From + " - " + difference.To);
                        }
                        else
                        {
                            Console.WriteLine("Разность двух интервалов отсутвует");
                        }
                    }
                    else
                    {
                        Range[] differenceArray = interval1.GetDifferenceArray(interval2);

                        Console.WriteLine("Первый интервал разности двух интервалов: " + differenceArray[0].From + " - " + differenceArray[0].To);
                        Console.WriteLine("Второй интервал разности двух интервалов: " + differenceArray[1].From + " - " + differenceArray[1].To);
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
