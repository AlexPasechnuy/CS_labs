using System;
using System.Collections.Generic;
using System.Text;

namespace QuaranTasks.Matrices
{
    class JaggedMatrix : AbstrSquareMatrix
    {
        private double[][] matrix;

        public JaggedMatrix(double[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i].Length != n)
                {
                    throw new SizeException(n, matrix[i].Length);
                }
            }
            this.matrix = matrix;
        }

        public JaggedMatrix(int n)
        {
            this.matrix = new double[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new double[n];
            }
        }

        public JaggedMatrix InverseMatrix()
        {
            return new JaggedMatrix(MatrixConverter.ToJaggedArray(AbstrSquareMatrix.GaussInverse(MatrixConverter.ToOrdinaryArray(matrix))));
        }

        public override AbstrSquareMatrix Create(int n)
        {
            return new JaggedMatrix(n);
        }

        public override int N
        {
            get { return matrix.GetLength(0); }
        }

        public override double Deter
        {
            get { return GetDeter(ToOrdinaryArray()); }
        }

        public override ref double Get(int i, int j)
        {
            return ref matrix[i][j];
        }

        private double[,] ToOrdinaryArray()
        {
            double[,] res = new double[N, N];
            var dest = new double[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    res[i, j] = Get(i, j);
                }
            }
            return res;
        }

    }
}
