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

            this.N = n;

            componets = new double[n];

            for (int i = 0; i < n; i++)
            {
                this.componets[i] = 0;
            }
        }

        public Vector(Vector vectorSource)
        {
            this.N = vectorSource.GetSize();

            if (this.componets == null)
            {
                this.componets = new double[N];
            }

            for (int i = 0; i < N; i++)
            {
                this.componets[i] = vectorSource.componets[i];
            }
        }

        public Vector(double[] array)
        {
            componets = new double[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                this.componets[i] = array[i];
            }
        }

        public Vector(int n, double[] array)
        {
            componets = new double[n];

            int arraySize = array.Length;

            for (int i = 0; i < arraySize; i++)
            {
                this.componets[i] = array[i];
            }

            if (arraySize < n)
            {
                for (int i = arraySize; i < n; i++)
                {
                    this.componets[i] = 0;
                }
            }
        }

        public Vector()
        {
            this.N = 0;
            componets = new double[0];
        }

        public int GetSize()
        {
            return this.componets.Length;
        }

        public override string ToString()
        {
            return "{" + string.Join(",", this.componets) + "}";
        }

        public void Addition(Vector otherVector)
        {
            int minimumVectorSize = GetMinimumVectorLength(this, otherVector);

            for (int i = 0; i < minimumVectorSize; i++)
            {
                this.componets[i] = this.componets[i] + otherVector.componets[i];
            }
        }

        public int GetMinimumVectorLength(Vector vectorA, Vector vectorB)
        {
            int sizeVectorA = vectorA.GetSize();
            int sizeVectorB = vectorB.GetSize();

            return sizeVectorA <= sizeVectorB ? sizeVectorA : sizeVectorB;
        }

        public void Subtraction(Vector vectorB)
        {
            int minimumVectorSize = GetMinimumVectorLength(this, vectorB);

            for (int i = 0; i < minimumVectorSize; i++)
            {
                this.componets[i] = this.componets[i] - vectorB.componets[i];
            }
        }

        public void ScalarMultiplication(double scalarValue)
        {
            int dimensionsNumber = this.GetSize();

            for (int i = 0; i < dimensionsNumber; i++)
            {
                this.componets[i] = this.componets[i] * scalarValue;
            }
        }

        public void Reverse()
        {
            int dimensionsNumber = this.GetSize();

            for (int i = 0; i < dimensionsNumber; i++)
            {
                this.componets[i] *= -1;
            }
        }

        public double GetLength()
        {
            double length = 0;
            int dimensionsNumber = this.GetSize();

            for (int i = 0; i < dimensionsNumber; i++)
            {
                length += Math.Pow(this.componets[i], 2);
            }

            return Math.Sqrt(length);
        }

        public double this[int i]
        {
            get
            {
                return this.componets[i];
            }
            set
            {
                this.componets[i] = value;
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
            hash.Add(this.N);
            hash.Add(this.componets);

            return hash.ToHashCode();
        }

        public static Vector Summation(Vector vector1, Vector vector2)
        {
            int sizeVector1 = vector1.GetSize();
            int sizeVector2 = vector2.GetSize();
            int maxVectorSize = sizeVector1 > sizeVector2 ? sizeVector1 : sizeVector2;

            Vector vectorResult = new Vector(maxVectorSize);

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
            int maxVectorSize = sizeVector1 > sizeVector2 ? sizeVector1 : sizeVector2;

            Vector vectorResult = new Vector(maxVectorSize);

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