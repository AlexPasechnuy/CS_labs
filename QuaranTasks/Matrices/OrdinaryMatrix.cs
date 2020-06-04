using System;
using System.Collections.Generic;
using System.Text;

namespace QuaranTasks.Matrices
{
    class OrdinaryMatrix : AbstrSquareMatrix
    {
        private double[,] matrix;

        public OrdinaryMatrix(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new SizeException(matrix.GetLength(0), matrix.GetLength(1));
            }
            this.matrix = matrix;
        }

        public AbstrSquareMatrix InverseMatrix()
        {
            return base.InverseMatrix();
        }

        public override AbstrSquareMatrix Create(int n)
        {
            return new OrdinaryMatrix(new double[n, n]);
        }

        public override int N
        {
            get { return matrix.GetLength(0); }
        }

        public override ref double Get(int i, int j)
        {
            return ref matrix[i, j];
        }
    }
}
