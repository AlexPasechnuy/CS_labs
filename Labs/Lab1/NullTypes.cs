using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab1.NullTypes
{
    class NullTypes
    {
        public static double? Sqrt(double num) {
            double? res = null;
            if (num >= 0) {
                res = Math.Sqrt(num);
            }
            return res;
        }
    }

    class Main {
        public static void Run()
        {
            Console.WriteLine("Input number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            double? res = NullTypes.Sqrt(num);
            if (res == null) { Console.Write("null"); }
            else { Console.Write(res); }
            Console.ReadKey();
        }
    }
}
