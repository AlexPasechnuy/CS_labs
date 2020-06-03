using System;
using System.Collections.Generic;
using System.Text;

namespace QuaranTasks.Matrices
{
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
