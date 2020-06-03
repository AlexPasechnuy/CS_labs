using System;
using System.Collections.Generic;
using System.Text;

namespace QuaranTasks.Functions
{
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
}
