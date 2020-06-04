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

        public override AbstrSquareMatrix Create(int n)
        {
            double[][] newmatrix = new double[n][];
            for (int i = 0; i < n; i++)
            {
                newmatrix[i] = new double[n];
            }
            return new JaggedMatrix(newmatrix);
        }

        public override int N
        {
            get { return matrix.GetLength(0); }
        }

        public override ref double Get(int i, int j)
        {
            return ref matrix[i][j];
        }
    }
}
