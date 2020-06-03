using System;
using System.Collections.Generic;
using System.Text;

namespace QuaranTasks.Functions
{
    class Main
    {
        private static void PrintTable(double[,] src)
        {
            Console.WriteLine("Calculation results");
            Console.WriteLine("x         |y         |y'        |y''");
            for (int i = 0; i < src.GetLength(0); i++)
            {
                string tempStr = "";
                for (int j = 0; j < src.GetLength(1); j++)
                {
                    //Console.Write(Math.Round(src[i, j], 2) + " ");
                    tempStr += Math.Round(src[i, j], 2);
                    int lngth = tempStr.Length;
                    for (int k = 0; k < (j + 1) * 10 - lngth + j; k++) { tempStr += " "; }
                    tempStr += '|';
                }
                Console.WriteLine(tempStr);
            }
        }

        public static void Run()
        {
            double[] coefs = { 7, 2, 5, 9 };
            PolynWithDer withDer = new PolynWithDer()
            {
                Coefs = coefs
            };
            PolynWithoutDer withoutDer = new PolynWithoutDer()
            {
                Coefs = coefs
            };
            Console.WriteLine("Polynom with derivatives:");
            PrintTable(IFunction.Solve(-10, 10, 2, withDer));
            Console.WriteLine("Polynom without derivatives:");
            PrintTable(IFunction.Solve(-10, 10, 2, withoutDer));
            Console.ReadKey();
        }
    }
}
