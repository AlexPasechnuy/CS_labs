using System;
using System.Collections.Generic;

namespace QuaranTasks.Functions
{
    public interface IFunction
    {
        const double dx = 0.001;
        double F(double x);

        double F1(double x)
        {
            return (F(x + dx) - F(x)) / dx;
        }

        double F2(double x)
        {
            return (F1(x + dx) - F1(x)) / dx;
        }

        public static double[,] Solve(double from, double to, double step, IFunction func)
        {
            double x = from;
            List<List<double>> res = new List<List<double>>();

            while (x < to)
            {
                List<double> list = new List<double>();
                list.Add(x);
                list.Add(func.F(x));
                list.Add(func.F1(x));
                list.Add(func.F2(x));
                x += step;
                res.Add(list);
            }
            double[,] result = new double[res.Count, res[0].Count];
            for (int i = 0; i < res.Count; i++)
            {
                for (int j = 0; j < res[0].Count; j++)
                {
                    result[i, j] = res[i][j];
                }
            }
            return result;
        }
    }

    public class PolynWithDer : IFunction
    {
        public double[] Coefs { private get; set; }

        public PolynWithDer() { Coefs = new double[0]; }
        public double F(double x)
        {
            double result = 0;
            for (int i = 0; i < Coefs.Length; i++)
            {
                result += Math.Pow(x, i) * Coefs[i];
            }
            return result;
        }

        public double F1(double x)
        {
            double result = 0;
            for (int i = 1; i < Coefs.Length; i++)
            {
                result += Math.Pow(x, i - 1) * Coefs[i] * i;
            }
            return result;
        }

        public double F2(double x)
        {
            double result = 0;
            for (int i = 2; i < Coefs.Length; i++)
            {
                result += Math.Pow(x, i - 2) * Coefs[i] * i * (i - 1);
            }
            return result;
        }
    }

    public class PolynWithoutDer : IFunction
    {
        public double[] Coefs { private get; set; }

        public PolynWithoutDer() { Coefs = new double[0]; }

        public double F(double x)
        {
            double result = 0;
            for (int i = 0; i < Coefs.Length; i++)
            {
                result += Math.Pow(x, i) * Coefs[i];
            }
            return result;
        }

    }

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