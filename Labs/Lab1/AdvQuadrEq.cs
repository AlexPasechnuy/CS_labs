using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab1.AdvQuadrEq
{
    class AdvQuadrEq
    {

        public double? this[int index]
        {
            get
            {
                switch (index)
                {
                    case 1: return X1;
                    case 2: return X2;
                    default: return null;
                }
            }
        }

        public double? X1 { get; private set; }

        public double? X2 { get; private set; }

        public double A { get; set; }

        public double B { get; set; }

        public double C { get; set; }

        public int Solve()
        {
            X1 = X2 = null;
            if (A == 0 && B == 0 && C == 0)
            {
                return -1;
            }
            double d = B * B - 4 * A * C;
            if (d < 0)
            {
                return 0;
            }
            X1 = (-B - Math.Sqrt(d)) / (2 * A);
            if (d == 0)
            {
                return 1;
            }
            X2 = (-B + Math.Sqrt(d)) / (2 * A);
            return 2;
        }
    }

    class Main
    {
        public static void Run()
        {
            AdvQuadrEq eq = new AdvQuadrEq();
            Console.Write("Enter coeficients: ");
            string[] str = Console.ReadLine().Split();
            eq.A = Convert.ToInt32(str[0]);
            eq.B = Convert.ToInt32(str[1]);
            eq.C = Convert.ToInt32(str[2]);
            eq.Solve();
            Console.WriteLine(eq[1] + " " + eq[2]);
            Console.ReadKey();
        }
    }
}
