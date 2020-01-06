using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab1
{
    class NullTypes
    {
        public static void Run() {
            Console.WriteLine("Input number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            double? res = Sqrt(num);
            if (res == null) { Console.Write("null"); }
            else { Console.Write(Sqrt(num)); }
            Console.ReadKey();
        }

        public static double? Sqrt(double num) {
            double? res = null;
            if (num >= 0) {
                res = Math.Sqrt(num);
            }
            return res;
        }
    }
}
