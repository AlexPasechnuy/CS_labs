using System;
using System.Collections.Generic;
using System.Text;

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
}
