using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab2.ComplexNum
{
    class ComplexNum
    {
        double a, b;

        public ComplexNum(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public static ComplexNum operator+(ComplexNum n1, ComplexNum n2)
        {
            return new ComplexNum(n1.a + n2.a, n1.b + n2.b);
        }

        public static ComplexNum operator-(ComplexNum n1, ComplexNum n2)
        {
            return new ComplexNum(n1.a - n2.a, n1.b - n2.b);
        }

        public static ComplexNum operator*(ComplexNum n1, ComplexNum n2)
        {
            return new ComplexNum(n1.a*n2.a - n1.b*n2.b, n1.a*n2.b + n2.a*n1.b);
        }

        public static ComplexNum operator/(ComplexNum n1, ComplexNum n2)
        {
            return new ComplexNum((n1.a*n2.a + n1.b*n2.b)/(Math.Pow(n2.a,2) + Math.Pow(n2.b, 2)), 
                (n1.b*n2.a - n1.a*n2.b)/(Math.Pow(n2.a,2)+ Math.Pow(n2.b,2)));
        }

        public static implicit operator string(ComplexNum num)
        {
            string res = num.a + "";
            if (num.b >= 0) {
                res += "+";
            }
            res += num.b + "i";
            return res;
        }
    }

    class Main {
        public static void Run()
        {
            double a1, b1, a2, b2;
            Console.Write("Enter 'a' and 'b' for first complex number: ");
            string[] str1 = Console.ReadLine().Split();
            Console.Write("Enter 'a' and 'b' for second complex number: ");
            string[] str2 = Console.ReadLine().Split();
            if (double.TryParse(str1[0], out a1) == true && double.TryParse(str1[1], out b1) == true
                && double.TryParse(str2[0], out a2) == true && double.TryParse(str2[1], out b2) == true)
            {
                ComplexNum c1 = new ComplexNum(a1, b1);
                ComplexNum c2 = new ComplexNum(a2, b2);
                Console.WriteLine("c1 + c2 = " + (c1 + c2));
                Console.WriteLine("c1 - c2 = " + (c1 - c2));
                Console.WriteLine("c1 * c2 = " + (c1 * c2));
                Console.WriteLine("c1 / c2 = " + (c1 / c2));
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
            Console.ReadKey();
        }
    }
}
