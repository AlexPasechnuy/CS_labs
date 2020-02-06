using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab1.QuadrEq
{
    class QuadrEq
    {
        public static int Solve(double a, double b, double c,
                             out double? x1, out double? x2)
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

    class Main {

        public static void Run()
        {
            double? x1, x2;
            double a, b, c;
            Console.Write("Enter coeficients: ");
            string[] str = Console.ReadLine().Split();
            if (double.TryParse(str[0], out a) == true && double.TryParse(str[1], out b) == true
                && double.TryParse(str[2], out c) == true)
            {
                int res = QuadrEq.Solve(a, b, c, out x1, out x2);
                Console.WriteLine(res + " roots: " + x1 + " " + x2);
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
            Console.ReadKey();
        }
    }
}
