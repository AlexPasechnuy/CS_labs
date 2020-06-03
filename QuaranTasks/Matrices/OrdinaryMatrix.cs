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

        public OrdinaryMatrix(int n)
        {
            this.matrix = new double[n, n];
        }

        public OrdinaryMatrix InverseMatrix()
        {
            return new OrdinaryMatrix(AbstrSquareMatrix.GaussInverse(matrix));
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
            get { return GetDeter(matrix); }
        }

        public override ref double Get(int i, int j)
        {
            return ref matrix[i, j];
        }
    }
}
