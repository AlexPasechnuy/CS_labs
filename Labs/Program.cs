using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of lab(1-6): ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (num) {
                case 1:
                    Lab1.Main.Run();
                    break;
                case 2:
                    Lab2.Main.Run();
                    break;
                case 3:
                    Lab3.Main.Run();
                    break;
                case 4:
                    Lab4.Main.Run();
                    break;
                case 5:
                    Lab5.Main.Run();
                    break;
                case 6:
                    Lab6.Main.Run();
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    Console.ReadKey();
                    break;
            }

        }
    }
}
