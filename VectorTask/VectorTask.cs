using System;

namespace VectorTask
{
    class VectorTask
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность вектора");
            //int n = Int32.Parse(Console.ReadLine());

            try
            {
                // Тесты конструкторов
                Vector vector1 = new Vector(2);

                string testResult = GetTestResultMessage((vector1.componets[0] == 0 && vector1.componets[1] == 0), 1);
                Console.WriteLine(testResult);

                Vector vector2 = new Vector(vector1);

                testResult = GetTestResultMessage(vector2.Equals(vector1), 2);
                Console.WriteLine(testResult);

                double[] array = { 3, 0, -10.4 };
                vector1 = new Vector(array);

                testResult = GetTestResultMessage((vector1.componets[0] == array[0] && vector1.componets[1] == array[1] && vector1.componets[2] == array[2]), 3);
                Console.WriteLine(testResult);

                array = new double[] { 3.5, 45.53, 40.932 };
                vector1 = new Vector(4, array);

                testResult = GetTestResultMessage((vector1.componets[0] == array[0] && vector1.componets[1] == array[1] && vector1.componets[2] == array[2] && vector1.componets[3] == 0), 4);
                Console.WriteLine(testResult);

                // Метод getSize()

                array = new double[] { 5, 43, 32 };
                vector1 = new Vector(array);

                testResult = GetTestResultMessage((vector1.GetSize() == array.Length), 5);
                Console.WriteLine(testResult);

                // Метод toString()

                array = new double[] { 0, 99, -1000, 2.0 };
                vector1 = new Vector(array);

                testResult = GetTestResultMessage((vector1.ToString() == ("{" + string.Join(",", array) + "}")), 6);
                Console.WriteLine(testResult);

                // Тесты методов

                // Прибавление к вектору другого вектора

                array = new double[] { 20, 299, 0, 2.20 };
                double[] array2 = new double[] { 3, 53.35, -5 };

                vector1 = new Vector(array);
                vector2 = new Vector(array2);

                vector1.Addition(vector2);

                int nMin = GetMinimalArrayLength(array, array2);

                for (int i = 0; i < nMin; i++)
                {
                    array[i] += array2[i];
                }

                testResult = GetTestResultMessage((vector1.ToString() == ("{" + string.Join(",", array) + "}")), 7);
                Console.WriteLine(testResult);

                // Вычитание из вектора другого вектора

                vector1.Subtraction(vector2);

                nMin = GetMinimalArrayLength(array, array2);

                for (int i = 0; i < nMin; i++)
                {
                    array[i] -= array2[i];
                }

                testResult = GetTestResultMessage((vector1.ToString() == ("{" + string.Join(",", array) + "}")), 8);
                Console.WriteLine(testResult);

                // Умножение вектора на скаляр

                int scalarValue = 2;
                vector1.Multiply(scalarValue);

                int size = array.Length;

                for (int i = 0; i < size; i++)
                {
                    array[i] = array[i] * scalarValue;
                }

                testResult = GetTestResultMessage((vector1.ToString() == ("{" + string.Join(",", array) + "}")), 9);
                Console.WriteLine(testResult);

                // Разворот вектора


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write("Метод: ");
                Console.WriteLine(ex.TargetSite);
                Console.Write("Вывод стека: ");
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static string GetTestResultMessage(bool testCase, int testId)
        {
            if (testCase)
            {
                return $"Test№" + testId + " - Ok";
            }
            else
            {
                return $"Test№" + testId + " - False";
            }
        }

        public static int GetMinimalArrayLength(double[] array1, double[] array2)
        {
            return array1.Length < array2.Length ? array1.Length : array2.Length;
        }
    }
}