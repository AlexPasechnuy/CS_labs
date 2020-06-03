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
        public abstract double Deter { get; }
        public abstract ref double Get(int i, int j);

        static double[,] getMatrixWithoutRowAndCol(double[,] matrix, int row, int col)
        {
            int size = matrix.GetLength(0);
            double[,] newMatrix = new double[size - 1, size - 1];
            int offsetRow = 0; //Смещение индекса строки в матрице
            int offsetCol = 0; //Смещение индекса столбца в матрице
            for (int i = 0; i < size - 1; i++)
            {
                //Пропустить row-ую строку
                if (i == row)
                {
                    offsetRow = 1; //Как только встретили строку, которую надо пропустить, делаем смещение для исходной матрицы
                }

                offsetCol = 0; //Обнулить смещение столбца
                for (int j = 0; j < size - 1; j++)
                {
                    //Пропустить col-ый столбец
                    if (j == col)
                    {
                        offsetCol = 1; //Встретили нужный столбец, проускаем его смещением
                    }

                    newMatrix[i, j] = matrix[i + offsetRow, j + offsetCol];
                }
            }
            return newMatrix;
        }

        protected static double GetDeter(double[,] matrix)
        {
            int size = matrix.GetLength(0);
            double det = 0;
            int degree = 1; // (-1)^(1+j) из формулы определителя

            //Условие выхода из рекурсии
            if (size == 1)
            {
                return matrix[0, 0];
            }
            //Условие выхода из рекурсии
            else if (size == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                //Матрица без строки и столбца
                double[,] newMatrix = new double[size - 1, size - 1];
                //Раскладываем по 0-ой строке, цикл бежит по столбцам
                for (int j = 0; j < size; j++)
                {
                    //Удалить из матрицы i-ю строку и j-ый столбец
                    //Результат в newMatrix
                    newMatrix = getMatrixWithoutRowAndCol(matrix, 0, j);

                    //Рекурсивный вызов
                    //По формуле: сумма по j, (-1)^(1+j) * matrix[0][j] * minor_j (это и есть сумма из формулы)
                    //где minor_j - дополнительный минор элемента matrix[0][j]
                    // (напомню, что минор это определитель матрицы без 0-ой строки и j-го столбца)
                    det = det + (degree * matrix[0, j] * GetDeter(newMatrix));
                    //"Накручиваем" степень множителя
                    degree = -degree;
                }
            }

            return det;
        }

        protected static double[,] GaussInverse(double[,] matrix)
        {
            double[,] res = new double[matrix.GetLength(0), matrix.GetLength(1) * 2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    res[i, j] = matrix[i, j];
                }
                res[i, i + matrix.GetLength(1)] = 1;
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
            double[,] inversed = new double[res.GetLength(0), res.GetLength(1) / 2];
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1) / 2; j++)
                {
                    inversed[i, j] = res[i, j + res.GetLength(1) / 2];
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
