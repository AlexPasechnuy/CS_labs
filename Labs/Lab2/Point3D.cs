using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab2.Point3D
{
    struct Point3D
    {
        double x, y, z;

        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double DistFromOrigin()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }
    }

    class Main
    {
        public static void Run()
        {
            double x, y, z;
            Console.Write("Enter coordinates of point: ");

            string[] str = Console.ReadLine().Split();
            if (double.TryParse(str[0], out x) == true && double.TryParse(str[1], out y) == true
                && double.TryParse(str[2], out z) == true)
            {
                Point3D point = new Point3D(x, y, z);
                Console.WriteLine(point.DistFromOrigin());
                Console.ReadKey();
            }
        }
    }
}
