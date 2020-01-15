using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab2.StringExpansion
{
    public static class StringExpansion
    {
        public static string RemRedSpaces(this string str) {
            for (int i = 0; i < str.Length - 1; i++) {
                if (str[i] == ' ' && str[i + 1] == ' ')
                {
                    str = str.Remove(i, 1);
                    i--;
                }
            }
            return str;
        }
    }

    class Main
    {
        public static void Run() {
            Console.WriteLine("ads     qwe  ads ".RemRedSpaces() + ";");
            Console.ReadKey();
        }
    }
}
