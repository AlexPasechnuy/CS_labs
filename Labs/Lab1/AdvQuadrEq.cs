using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab1
{
    class AdvQuadrEq
    {
        private double a, b, c;
        private double? x1, x2;

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

        public double? X1
        {
            get
            {
                Solve();
                return x1;
            }
        }

        public double? X2
        {
            get
            {
                Solve();
                return x2;
            }
        }

        public double A
        {
            set
            {
                a = value;
            }
        }

        public double B
        {
            set
            {
                b = value;
            }
        }

        public double C
        {
            set
            {
                c = value;
            }
        }

        private int Solve()
        {
            x1 = x2 = null;
            if (a == 0 && b == 0 && c == 0)
            {
                return -1;
            }
            double d = b * b - 4 * a * c;
            if (d < 0)
            {
                return 0;
            }
            x1 = (-b - Math.Sqrt(d)) / (2 * a);
            if (d == 0)
            {
                return 1;
            }
            x2 = (-b + Math.Sqrt(d)) / (2 * a);
            return 2;
        }
    }
}
