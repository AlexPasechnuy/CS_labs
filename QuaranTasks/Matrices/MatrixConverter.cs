using System;
using System.Collections.Generic;
using System.Text;

namespace QuaranTasks.Matrices
{
    class MatrixConverter
    {
        public static double[,] ToOrdinaryArray(double[][] matrix)
        {
            int n = matrix.Length;
            double[,] res = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    res[i, j] = matrix[i][j];
                }
            }
            return res;
        }

        public static double[][] ToJaggedArray(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            double[][] res = new double[n][];
            for (int i = 0; i < n; i++)
            {
                res[i] = new double[n];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    res[i][j] = matrix[i, j];
                }
            }
            return res;
        }
    }
}
