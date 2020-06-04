using System;
using System.Collections.Generic;
using System.Text;

namespace QuaranTasks.Matrices
{
    abstract class AbstrSquareMatrix
    {
        public class SizeException : Exception
        {
            public SizeException(int firstSize, int secondSize)
            {
                FirstSize = firstSize;
                SecondSize = secondSize;
            }
            public int FirstSize { get; }

            public int SecondSize { get; }

        }

        public abstract AbstrSquareMatrix Create(int n);

        public abstract int N { get; }
        public abstract ref double Get(int i, int j);

        static double[,] CrossRowAndCol(double[,] matrix, int row, int col)
        {
            int size = matrix.GetLength(0);
            double[,] newMatrix = new double[size - 1, size - 1];
            int offsetRow = 0;
            for (int i = 0; i < size - 1; i++)
            {
                if (i == row)
                {
                    offsetRow = 1;
                }

                int offsetCol = 0;
                for (int j = 0; j < size - 1; j++)
                {
                    if (j == col)
                    {
                        offsetCol = 1;
                    }

                    newMatrix[i, j] = matrix[i + offsetRow, j + offsetCol];
                }
            }
            return newMatrix;
        }

        public double Determinant() 
        {
            double[,] matrix = new double[N, N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    matrix[i, j] = Get(i, j);
            return GetDeter(matrix);
        }

        private static double GetDeter(double[,] matrix)
        {
            int size = matrix.GetLength(0);
            double det = 0;
            int degree = 1;

            if (size == 1)
            {
                return matrix[0, 0];
            }
            else if (size == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                double[,] newMatrix = new double[size - 1, size - 1];
                for (int j = 0; j < size; j++)
                {
                    newMatrix = CrossRowAndCol(matrix, 0, j);

                    det += (degree * matrix[0, j] * GetDeter(newMatrix));
                    degree = -degree;
                }
            }
            return det;
        }

        public AbstrSquareMatrix InverseMatrix()
        {
            double[,] res = new double[N, N * 2];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    res[i, j] = Get(i, j);
                }
                res[i, i + N] = 1;
            }
            double[,] prev = new double[res.GetLength(0), res.GetLength(1)];
            for (int i = 0; i < res.GetLength(0); i++)
            {
                Array.Copy(res, prev, res.Length);
                for (int j = 0; j < res.GetLength(0); j++)
                {
                    for (int k = 0; k < res.GetLength(1); k++)
                    {
                        if (j == i)
                        {
                            res[j, k] /= prev[i, i];
                        }
                        else
                        {
                            res[j, k] -= (prev[j, i] * prev[i, k]) / prev[i, i];
                        }
                    }
                }
            }
            AbstrSquareMatrix inversed = Create(N);
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1) / 2; j++)
                {
                    inversed.Get(i, j) = res[i, j + res.GetLength(1) / 2];
                }
            }
            return inversed;
        }

        public static AbstrSquareMatrix operator *(AbstrSquareMatrix m1, AbstrSquareMatrix m2)
        {
            if (m1.N != m2.N)
            {
                throw new SizeException(m1.N, m2.N);
            }

            AbstrSquareMatrix matrixC = m1.Create(m1.N);

            for (var i = 0; i < m1.N; i++)
            {
                for (var j = 0; j < m2.N; j++)
                {
                    matrixC.Get(i, j) = 0;

                    for (var k = 0; k < m1.N; k++)
                    {
                        matrixC.Get(i, j) += m1.Get(i, k) * m2.Get(k, j);
                    }
                }
            }

            return matrixC;
        }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    res += Math.Round(Get(i, j), 3) + " ";
                }
                res += '\n';
            }
            return res;
        }
    }
}
