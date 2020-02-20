using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab2.Equation
{
    namespace Abstract
    {
        abstract class Equation
        {
            public abstract double Solve(double x);

            public double[] FindRoots(double from, double to, double step)
            {
                double[] results = new double[0];
                double prev = Solve(from);
                if (prev == 0)
                {
                    Array.Resize(ref results, results.Length + 1);
                    results[results.Length - 1] = prev;
                }
                for (double i = from + step; i < to; i += step)
                {
                    double current = Solve(i);
                    if (current == 0)
                    {
                        Array.Resize(ref results, results.Length + 1);
                        results[results.Length - 1] = i;
                    }
                    if (prev * current < 0)
                    {
                        Array.Resize(ref results, results.Length + 1);
                        results[results.Length - 1] = (i+i-step)/2;
                    }
                    prev = current;
                }
                return results;
            }
        }

        class MyEq : Equation
        {
            public override double Solve(double x)
            {
                return 5 * x + 3;
            }
        }
    }

    namespace Interface
    {
        interface Equation
        {
            double Solve(double x);

            double[] FindRoots(double from, double to, double step);
        }

        class MyEq : Equation
        {
            public double Solve(double x)
            {
                return 5 * x + 3;
            }

            public double[] FindRoots(double from, double to, double step)
            {
                double[] results = new double[0];
                double prev = Solve(from);
                if (prev == 0)
                {
                    Array.Resize(ref results, results.Length + 1);
                    results[results.Length - 1] = prev;
                }
                for (double i = from + step; i < to; i += step)
                {
                    double current = Solve(i);
                    if (current == 0)
                    {
                        Array.Resize(ref results, results.Length + 1);
                        results[results.Length - 1] = i;
                    }
                    if (prev * current < 0)
                    {
                        Array.Resize(ref results, results.Length + 1);
                        results[results.Length - 1] = (i + i - step) / 2;
                    }
                    prev = current;
                }
                return results;
            }
        }
    }

    class Main
    {
        public static void Run()
        {
            Abstract.MyEq abs = new Abstract.MyEq();
            Interface.MyEq inter = new Interface.MyEq();
            Console.WriteLine(abs.Solve(-0.6));
            double[] absRes = abs.FindRoots(-10, 10, 0.1);
            double[] interRes = inter.FindRoots(-10, 10, 0.1);
            Console.WriteLine("Using abstract class: ");
            for (int i = 0; i < absRes.Length; i++)
            {
                Console.Write(absRes[i] + " ");
            }

            Console.WriteLine("\n\nUsing interface: ");
            for (int i = 0; i < interRes.Length; i++)
            {
                Console.Write(interRes[i] + " ");
            }

            Console.ReadKey();
        }
    }

}
