using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab2.Vector
{
    class Vector
    {
        double x, y;

        public Vector(double x, double y) {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector operator-(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector operator*(Vector v, double num)
        {
            return new Vector(v.x*num, v.y*num);
        }

        public static double operator*(Vector v1, Vector v2)
        {
            return v1.x*v2.x + v1.y*v2.y;
        }

        public static Vector operator/(Vector v, double num)
        {
            return new Vector(v.x / num, v.y / num);
        }
    }

    class Main
    {
        public static void Run()
        {
            double x1, y1, x2, y2;
            Console.Write("Enter 'x' and 'y' for first vector: ");
            string[] str1 = Console.ReadLine().Split();
            Console.Write("Enter 'x' and 'y' for second vector: ");
            string[] str2 = Console.ReadLine().Split();
            if (double.TryParse(str1[0], out x1) == true && double.TryParse(str1[1], out y1) == true
                && double.TryParse(str2[0], out x2) == true && double.TryParse(str2[1], out y2) == true)
            {
                Vector v1 = new Vector(x1, y1);
                Vector v2 = new Vector(x2, y2);
                Console.WriteLine("c1 + c2 = " + (v1 + v2));
                Console.WriteLine("c1 - c2 = " + (v1 - v2));
                Console.WriteLine("c1 * c2 = " + (v1 * v2));
                Console.WriteLine("c1 * 5 = " + (v1 * 5));
                Console.WriteLine("c1 / 3 = " + (v1 / 3));
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
            Console.ReadKey();
        }
    }
}
