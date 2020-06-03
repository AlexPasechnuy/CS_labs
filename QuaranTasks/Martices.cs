using System;

namespace QuaranTasks.Martices
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

    class Main
    {
        private static void TestJagged()
        {
            //arrays initializaton
            double[][] arr1 =
            {
                new double[] {3.5,5.5,7.5,9.5 },
                new double[] { 1.5,2.5,4.5,9.5},
                new double[] {7.5,2.5,1.5,6.5 },
                new double[] { 8.5,7.5,3.5,5.5}
            };
            double[][] arr2 =
{
                new double[] {7.5, 0.5, 3.5, 1.5},
                new double[] {8.5,1.5,9.5,2.5},
                new double[] {7.5,5.5,6.5,2.5},
                new double[] {1.5,9.5,7.5,3.5}
            };
            double[][] arr3 =
{
                new double[] {8.5,2.5,7.5 },
                new double[] { 9.5,1.5,3.5},
                new double[] {1.7,7.9,3.1}
            };
            double[][] arr4 =
{
                new double[] {2.5, 10.5, 9.5},
                new double[] {7.2,2.4,5},
                new double[] {6.5,7.5,2.5}
            };
            JaggedMatrix a = new JaggedMatrix(arr1);
            JaggedMatrix b = new JaggedMatrix(arr2);
            JaggedMatrix c = new JaggedMatrix(arr3);
            JaggedMatrix d = new JaggedMatrix(arr4);
            //arrays printing
            Console.WriteLine("A:\n" + a + "B:\n" + b + "C:\n" + c + "D:\n" + d);
            //printing of determinants
            Console.WriteLine("Determinant of A: " + a.Deter +
                "\nDeterminant of B: " + b.Deter +
                "\nDeterminant of C: " + c.Deter +
                "\nDeterminant of D: " + d.Deter);
            //matrices multiplication
            Console.Write("\nA*B:\n" + a * b);
            Console.WriteLine("\nC*D:\n" + c * d);
            //inversed matrices
            JaggedMatrix inv = a.InverseMatrix();
            Console.WriteLine("Inversed A:\n" + inv);
            Console.WriteLine("Inversed A * A:\n" + (inv * a));
            inv = b.InverseMatrix();
            Console.WriteLine("Inversed B:\n" + inv);
            Console.WriteLine("Inversed B * B:\n" + (inv * b));
            inv = c.InverseMatrix();
            Console.WriteLine("Inversed C:\n" + inv);
            Console.WriteLine("Inversed C * C:\n" + (inv * c));
            inv = d.InverseMatrix();
            Console.WriteLine("Inversed D:\n" + inv);
            Console.WriteLine("Inversed D * D:\n" + (inv * d));
            //exceptions catchning
            Console.WriteLine("**Exceptions catching*********************");
            Console.WriteLine("Trying to create non-square matrix:");
            try
            {
                double[][] non_sq = {
                new double[] { 3.5, 5.5, 7.5},
                new double[] { 1.5, 2.5, 4.5},
                };
                JaggedMatrix bad = new JaggedMatrix(non_sq);

            }
            catch (AbstrSquareMatrix.SizeException ex)
            {
                Console.WriteLine("Non-square matrix!!!");
            }
            Console.WriteLine("Trying to multipply matrices with different N:");
            try
            {
                Console.WriteLine("\nA*C:\n" + a * c);
            }
            catch (AbstrSquareMatrix.SizeException ex)
            {
                Console.WriteLine("Sizes of matrices are different!!!");
            }
        }

        private static void TestOrdinary()
        {
            //arrays initializaton
            double[,] arr1 = { {3.5,5.5,7.5,9.5 },
                { 1.5,2.5,4.5,9.5},
                {7.5,2.5,1.5,6.5 },
                { 8.5,7.5,3.5,5.5}};
            double[,] arr2 = {{7.5, 0.5, 3.5, 1.5},
                {8.5,1.5,9.5,2.5},
                {7.5,5.5,6.5,2.5},
                {1.5,9.5,7.5,3.5} };
            double[,] arr3 = { {8.5,2.5,7.5 },
                { 9.5,1.5,3.5},
                {1.7,7.9,3.1}};
            double[,] arr4 = {{2.5, 10.5, 9.5},
                {7.2,2.4,5},
                {6.5,7.5,2.5}};
            OrdinaryMatrix a = new OrdinaryMatrix(arr1);
            OrdinaryMatrix b = new OrdinaryMatrix(arr2);
            OrdinaryMatrix c = new OrdinaryMatrix(arr3);
            OrdinaryMatrix d = new OrdinaryMatrix(arr4);
            //arrays printing
            Console.WriteLine("A:\n" + a + "B:\n" + b + "C:\n" + c + "D:\n" + d);
            //printing of determinants
            Console.WriteLine("Determinant of A: " + a.Deter +
                "\nDeterminant of B: " + b.Deter +
                "\nDeterminant of C: " + c.Deter +
                "\nDeterminant of D: " + d.Deter);
            //matrices multiplication
            Console.Write("\nA*B:\n" + a * b);
            Console.WriteLine("\nC*D:\n" + c * d);
            //inversed matrices
            OrdinaryMatrix inv = a.InverseMatrix();
            Console.WriteLine("Inversed A:\n" + inv);
            Console.WriteLine("Inversed A * A:\n" + (inv * a));
            inv = b.InverseMatrix();
            Console.WriteLine("Inversed B:\n" + inv);
            Console.WriteLine("Inversed B * B:\n" + (inv * b));
            inv = c.InverseMatrix();
            Console.WriteLine("Inversed C:\n" + inv);
            Console.WriteLine("Inversed C * C:\n" + (inv * c));
            inv = d.InverseMatrix();
            Console.WriteLine("Inversed D:\n" + inv);
            Console.WriteLine("Inversed D * D:\n" + (inv * d));
            //exceptions catchning
            Console.WriteLine("**Exceptions catching*********************");
            Console.WriteLine("Trying to create non-square matrix:");
            try
            {
                double[,] non_sq = {
                { 3.5, 5.5, 7.5},
                { 1.5, 2.5, 4.5}};
                OrdinaryMatrix bad = new OrdinaryMatrix(non_sq);

            }
            catch (AbstrSquareMatrix.SizeException ex)
            {
                Console.WriteLine("Non-square matrix!!!");
            }
            Console.WriteLine("Trying to multipply matrices with different N:");
            try
            {
                Console.WriteLine("\nA*C:\n" + a * c);
            }
            catch (AbstrSquareMatrix.SizeException ex)
            {
                Console.WriteLine("Sizes of matrices are different!!!");
            }
        }

        public static void Run()
        {
            Console.WriteLine("\n**Simple matrix***************************************************");
            TestOrdinary();
            Console.WriteLine("\n**Jagged matrix***************************************************");
            TestJagged();
            Console.ReadKey();
        }


    }
}
