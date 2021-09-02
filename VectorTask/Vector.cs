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

        public Vector(double[] vectors)
        {
            componets = new double[vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                this.componets[i] = vectors[i];
            }
        }

        public Vector(int n, double[] vectors)
        {
            componets = new double[n];

            int arraySize = vectors.Length;

            for (int i = 0; i < arraySize; i++)
            {
                this.componets[i] = vectors[i];
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

        public void Addition(Vector vectorB)
        {
            int nMin = GetMinimalArrayLength(this, vectorB);

            for (int i = 0; i < nMin; i++)
            {
                this.componets[i] = this.componets[i] + vectorB.componets[i];
            }
        }

        public int GetMinimalArrayLength(Vector vectorA, Vector vectorB)
        {
            int nVectorA = vectorA.GetSize();
            int nVectorB = vectorB.GetSize();
            return nVectorA < nVectorB ? nVectorB : nVectorB;
        }

        public void Subtraction(Vector vectorB)
        {
            int nMin = GetMinimalArrayLength(this, vectorB);

            for (int i = 0; i < nMin; i++)
            {
                this.componets[i] = this.componets[i] - vectorB.componets[i];
            }
        }

        public void Multiply(double scalarValue)
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

        public double Length()
        {
            double result = 0;
            int dimensionsNumber = this.GetSize();

            for (int i = 0; i < dimensionsNumber; i++)
            {
                result += Math.Pow(this.componets[i], 2);
            }

            return Math.Sqrt(result);
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


    }
}