using System;

namespace Labs.Lab4.Delegates
{
    public interface IRoot
    {
        double[] FindRoots(Func<double, double> func, double start, double fin);

        double? FindAverageValue(double[] values);
    }

    class Root : IRoot
    {
        public double[] FindRoots(Func<double, double> func, double start, double fin)
        {
            double[] roots = new double[0];
            int index = 0;
            bool isPositive = func(start) > 0;

            for (double i = start; i < fin; i += 0.001)
            {
                bool isPositivePrev = isPositive;

                isPositive = (func(i) > 0);
                if (isPositive != isPositivePrev)
                {
                    Array.Resize(ref roots, roots.Length + 1);
                    roots[index] = i;
                    index++;
                }
            }
            return roots;
        }

        public double? FindAverageValue(double[] values)
        {
            if (values.Length == 0)
            {
                return null;
            }

            double summaryValue = 0;

            foreach (double value in values)
            {
                summaryValue += value;
            }

            return summaryValue / values.Length;
        }
    }

    class Main
    {
        public static void Run()
        {
            Func<double, double> func = (double x) => -2 * Math.Pow(x, 2) + x + 7;
            double[] roots = new Root().FindRoots(func, -10, 10);

            Console.WriteLine("f(x) = -2 * x^2 + x + 7");
            if (roots.Length > 0)
            {
                Console.WriteLine("Result: ");
                foreach (double value in roots)
                {
                    Console.Write(value + " ");
                }

                Console.WriteLine("\nAverage of roots " + new Root().FindAverageValue(roots));
            }
            else
            {
                Console.WriteLine("No roots");
            }

            Console.ReadKey();
        }
    }
}
