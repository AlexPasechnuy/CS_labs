using System;
using System.Collections.Generic;
using System.Text;

namespace QuaranTasks.Functions
{
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
}
