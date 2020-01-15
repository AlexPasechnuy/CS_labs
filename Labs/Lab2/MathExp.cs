using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab2.MathExp
{
    class MathExp
    {
        public static uint? CycFibo(int num) {
            if (num < 1)
            {
                return null;
            }
            uint res = 1;
            if (num > 2) {
                uint prev, prevprev;
                prev = prevprev = 1;
                for (int i = 3; i <= num; i++) {
                    res = prevprev + prev;
                    prevprev = prev;
                    prev = res;
                }
            }
            return res;
        }

        public static uint? RecFibo(int num)
        {
            if (num < 1) {
                return null;
            }
            if (num <= 2) {
                return 1;
            }
            return RecFibo(num - 2) + RecFibo(num - 1);
        }
    }

    class Main {
        public static void Run() {
            Console.Write("Enter number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Using cycle: " + MathExp.CycFibo(num));
            Console.WriteLine("Using recursion: " + MathExp.RecFibo(num));
            Console.ReadKey();
        }
    }
}
