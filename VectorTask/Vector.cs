using System;

namespace VectorTask
{
    public class Vector
    {
        public int N { get; set; }

        public double[] componets { get; set; }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Ошибка: размерность вектора должна быть больше 0");
            }

            N = n;

            componets = new double[n];

            for (int i = 0; i < n; i++)
            {
                componets[i] = 0;
            }
        }

        public Vector(Vector vectorSource)
        {
            N = vectorSource.GetSize();

            if (componets == null)
            {
                componets = new double[N];
            }

            for (int i = 0; i < N; i++)
            {
                componets[i] = vectorSource.componets[i];
            }
        }

        public Vector(double[] array)
        {
            componets = new double[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                componets[i] = array[i];
            }
        }

        public Vector(int n, double[] array)
        {
            componets = new double[n];

            int arraySize = array.Length;

            for (int i = 0; i < arraySize; i++)
            {
                componets[i] = array[i];
            }

            if (arraySize < n)
            {
                for (int i = arraySize; i < n; i++)
                {
                    componets[i] = 0;
                }
            }
        }

        public Vector()
        {
            N = 0;
            componets = new double[0];
        }

        public int GetSize()
        {
            return componets.Length;
        }

        public override string ToString()
        {
            return "{" + string.Join(",", componets) + "}";
        }

        public void Addition(Vector otherVector)
        {
            int minimumVectorSize = Math.Min(GetSize(), otherVector.GetSize());

            for (int i = 0; i < minimumVectorSize; i++)
            {
                componets[i] = componets[i] + otherVector.componets[i];
            }
        }

        public int GetMinimumVectorLength(Vector vectorA, Vector vectorB)
        {
            int sizeVectorA = vectorA.GetSize();
            int sizeVectorB = vectorB.GetSize();

            return sizeVectorA <= sizeVectorB ? sizeVectorA : sizeVectorB;
        }

        public void Subtraction(Vector otherVector)
        {
            int minimumVectorSize = Math.Min(GetSize(), otherVector.GetSize());

            for (int i = 0; i < minimumVectorSize; i++)
            {
                componets[i] = componets[i] - otherVector.componets[i];
            }
        }

        public void ScalarMultiplication(double scalarValue)
        {
            int dimensionsNumber = GetSize();

            for (int i = 0; i < dimensionsNumber; i++)
            {
                componets[i] = componets[i] * scalarValue;
            }
        }

        public void Reverse()
        {
            int dimensionsNumber = GetSize();

            for (int i = 0; i < dimensionsNumber; i++)
            {
                componets[i] *= -1;
            }
        }

        public double GetLength()
        {
            double length = 0;
            int dimensionsNumber = GetSize();

            for (int i = 0; i < dimensionsNumber; i++)
            {
                length += Math.Pow(componets[i], 2);
            }

            return Math.Sqrt(length);
        }

        public double this[int i]
        {
            get
            {
                return componets[i];
            }
            set
            {
                componets[i] = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj is null || GetType() != obj.GetType())
            {
                return false;
            }

            Vector vector = (Vector)obj;

            for (int i = 0; i < GetSize(); i++)
            {
                if (this[i] != vector[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(N);
            hash.Add(componets);

            return hash.ToHashCode();
        }

        public static Vector Summation(Vector vector1, Vector vector2)
        {
            int sizeVector1 = vector1.GetSize();
            int sizeVector2 = vector2.GetSize();
            Vector vectorResult = new Vector(Math.Max(sizeVector1, sizeVector2));

            if (sizeVector1 < sizeVector2)
            {
                for (int i = 0; i < sizeVector1; i++)
                {
                    vectorResult[i] = vector1[i] + vector2[i];
                }

                for (int i = sizeVector1; i < sizeVector2; i++)
                {
                    vectorResult[i] = vector2[i] + 0;
                }
            }
            else
            {
                for (int i = 0; i < sizeVector2; i++)
                {
                    vectorResult[i] = vector1[i] + vector2[i];
                }

                for (int i = sizeVector2; i < sizeVector1; i++)
                {
                    vectorResult[i] = vector1[i] + 0;
                }
            }

            return vectorResult;
        }

        public static Vector Subtraction(Vector vector1, Vector vector2)
        {
            int sizeVector1 = vector1.GetSize();
            int sizeVector2 = vector2.GetSize();
            Vector vectorResult = new Vector(Math.Max(sizeVector1, sizeVector2));

            if (sizeVector1 < sizeVector2)
            {
                for (int i = 0; i < sizeVector1; i++)
                {
                    vectorResult[i] = vector1[i] - vector2[i];
                }

                for (int i = sizeVector1; i < sizeVector2; i++)
                {
                    vectorResult[i] = vector2[i] + 0;
                }
            }
            else
            {
                for (int i = 0; i < sizeVector2; i++)
                {
                    vectorResult[i] = vector1[i] - vector2[i];
                }

                for (int i = sizeVector2; i < sizeVector1; i++)
                {
                    vectorResult[i] = vector1[i] - 0;
                }
            }

            return vectorResult;
        }

        public static double DotProduct(Vector vector1, Vector vector2)
        {
            int sizeVector1 = vector1.GetSize();
            int sizeVector2 = vector2.GetSize();
            double sum = 0;

            if (sizeVector1 < sizeVector2)
            {
                for (int i = 0; i < sizeVector1; i++)
                {
                    sum += (vector1[i] * vector2[i]);
                }

                for (int i = sizeVector1; i < sizeVector2; i++)
                {
                    sum += (vector1[i] * 0);
                }
            }
            else
            {
                for (int i = 0; i < sizeVector2; i++)
                {
                    sum += (vector1[i] * vector2[i]);
                }

                for (int i = sizeVector2; i < sizeVector1; i++)
                {
                    sum += (vector1[i] * 0);
                }
            }

            return sum;
        }
    }
}