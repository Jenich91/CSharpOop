using System;

namespace RangeTask
{
    class RangeMain
    {
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

            Console.WriteLine("Введите число начало первого диапазона: ");
            double range1From = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите число конец диапазона: ");
            double range1To = Convert.ToDouble(Console.ReadLine());

            Range range1 = new Range(range1From, range1To);

            Console.WriteLine("Введите число начало второго диапазона: ");
            double range2From = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите число конец второго диапазона: ");
            double range2To = Convert.ToDouble(Console.ReadLine());

            Range range2 = new Range(range2From, range2To);

            Console.WriteLine("Расстояние между двумя диапозонами: " + Range.FindDistanceBetweenRanges(range1, range2));
            Console.WriteLine();

            // Part_2______________________________________________

            // Вводим числа первого диапазона
            Console.WriteLine("Введите число начало первого диапазона: ");
            double range3From = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите число конец первого диапазона: ");
            double range3To = Convert.ToDouble(Console.ReadLine());

            Range range3 = new Range(range3From, range3To);

            // Вводим числа второго диапазона
            Console.WriteLine("Введите число начало второго диапазона: ");
            double range4From = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите число конец второго диапазона: ");
            double range4To = Convert.ToDouble(Console.ReadLine());

            Range range4 = new Range(range4From, range4To);

            if (range3From < range3To || range4From < range4To)
            {
                // Пересечение
                Range intersection = range3.GetIntersection(range4);

                if (intersection != null)
                {
                    Console.WriteLine("Интервал пересечения двух интервалов: " + intersection);
                }
                else
                {
                    Console.WriteLine("Пересечение двух интервалов отсутвует");
                }

                // Объединение
                Range[] union = range3.GetUnion(range4);

                Console.Write("Интервал объединения двух интервалов: [");
                if (union != null)
                {
                    foreach (Range rangeObj in union)
                    {
                        Console.Write(String.Join(", ", rangeObj));
                    }
                }

                Console.WriteLine("]");

                // Разность
                Range[] difference = range3.GetDifference(range4);

                Console.Write("Интервал разности двух интервалов: [");

                if (difference != null)
                {
                    foreach (Range rangeObj in difference)
                    {
                        Console.Write(String.Join(", ", rangeObj));
                    }
                }

                Console.WriteLine("]");
            }
            else
            {
                Console.WriteLine("Неправильный ввод, начало интервала больше конца");
            }
        }
    }
}