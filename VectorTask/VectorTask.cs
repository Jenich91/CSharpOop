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

                double[] array1 = { 3, 0, -10.4 };
                vector1 = new Vector(array1);

                testResult = GetTestResultMessage((vector1.componets[0] == array1[0] && vector1.componets[1] == array1[1] && vector1.componets[2] == array1[2]), 3);
                Console.WriteLine(testResult);

                array1 = new double[] { 3.5, 45.53, 40.932 };
                vector1 = new Vector(4, array1);

                testResult = GetTestResultMessage((vector1.componets[0] == array1[0] && vector1.componets[1] == array1[1] && vector1.componets[2] == array1[2] && vector1.componets[3] == 0), 4);
                Console.WriteLine(testResult);

                // Метод getSize()

                array1 = new double[] { 5, 43, 32 };
                vector1 = new Vector(array1);

                testResult = GetTestResultMessage((vector1.GetSize() == array1.Length), 5);
                Console.WriteLine(testResult);

                // Метод toString()

                array1 = new double[] { 0, 99, -1000, 2.0 };
                vector1 = new Vector(array1);

                testResult = GetTestResultMessage((vector1.ToString() == ("{" + string.Join(",", array1) + "}")), 6);
                Console.WriteLine(testResult);

                // Тесты нестатических методов

                // Прибавление к вектору другого вектора

                array1 = new double[] { 20, 299, 0, 2.2 };
                double[] array2 = new double[] { 3, 35, -5 };

                vector1 = new Vector(array1);
                vector2 = new Vector(array2);

                vector1.Addition(vector2);

                int nMin = GetMinimalArrayLength(array1, array2);

                for (int i = 0; i < nMin; i++)
                {
                    array1[i] += array2[i];
                }

                testResult = GetTestResultMessage((vector1.ToString() == ("{" + string.Join(",", array1) + "}")), 7);
                Console.WriteLine(testResult);

                // Вычитание из вектора другого вектора

                vector1.Subtraction(vector2);

                nMin = GetMinimalArrayLength(array1, array2);

                for (int i = 0; i < nMin; i++)
                {
                    array1[i] -= array2[i];
                }

                testResult = GetTestResultMessage((vector1.ToString() == ("{" + string.Join(",", array1) + "}")), 8);
                Console.WriteLine(testResult);

                // Умножение вектора на скаляр

                int scalarValue = 2;
                vector1.ScalarMultiplication(scalarValue);

                int size = array1.Length;

                for (int i = 0; i < size; i++)
                {
                    array1[i] = array1[i] * scalarValue;
                }

                testResult = GetTestResultMessage((vector1.ToString() == ("{" + string.Join(",", array1) + "}")), 9);
                Console.WriteLine(testResult);

                // Разворот вектора

                vector1.Reverse();

                for (int i = 0; i < size; i++)
                {
                    array1[i] *= -1;
                }

                testResult = GetTestResultMessage((vector1.ToString() == ("{" + string.Join(",", array1) + "}")), 10);
                Console.WriteLine(testResult);

                // Получение длины вектора

                vector1.GetLength();

                double length = 0;

                for (int i = 0; i < size; i++)
                {
                    length += Math.Pow(array1[i], 2);
                }

                length = Math.Sqrt(length);

                testResult = GetTestResultMessage((vector1.GetLength() == length), 11);
                Console.WriteLine(testResult);

                //  Получение и установка компоненты вектора по индексу

                vector1[2] = 3;
                double vectorComponent = vector1[2];

                testResult = GetTestResultMessage((vector1[2] == vectorComponent), 12);
                Console.WriteLine(testResult);

                // Переопределить метод equals и hashCode

                vector2 = new Vector(vector1);

                testResult = GetTestResultMessage((vector1.Equals(vector2)), 13);


                // Тесты статических методов

                // Сложение двух векторов

                vector1 = new Vector(array1);
                vector2 = new Vector(array2);
                Vector vector3 = Vector.Summation(vector1, vector2);

                nMin = GetMinimalArrayLength(array1, array2);

                for (int i = 0; i < nMin; i++)
                {
                    array1[i] = array1[i] + array2[i];
                }

                testResult = GetTestResultMessage((vector3.ToString() == ("{" + string.Join(",", array1) + "}")), 14);
                Console.WriteLine(testResult);

                // Вычитание векторов

                vector1 = new Vector(array1);
                vector2 = new Vector(array2);
                vector3 = Vector.Subtraction(vector1, vector2);

                nMin = GetMinimalArrayLength(array1, array2);

                for (int i = 0; i < nMin; i++)
                {
                    array1[i] = array1[i] - array2[i];
                }

                testResult = GetTestResultMessage((vector3.ToString() == ("{" + string.Join(",", array1) + "}")), 15);
                Console.WriteLine(testResult);

                // Скалярное произведение векторов

                vector1 = new Vector(array1);
                vector2 = new Vector(array2);

                double scalarProduct1 = Vector.DotProduct(vector1, vector2);
                double scalarProduct2 = 0;

                nMin = GetMinimalArrayLength(array1, array2);

                for (int i = 0; i < nMin; i++)
                {
                    scalarProduct2 += (array1[i] * array2[i]);
                }

                testResult = GetTestResultMessage((scalarProduct1 == scalarProduct2), 16);
                Console.WriteLine(testResult);
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