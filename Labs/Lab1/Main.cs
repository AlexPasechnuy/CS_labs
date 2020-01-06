﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab1
{
    class Main
    {
        public static void Run() {
            Console.WriteLine("1. Individual Task");
            Console.WriteLine("2. Nullable types");
            Console.WriteLine("3. Quadratic equation");
            Console.WriteLine("4. Class for Representation of a Quadratic Equation (Advanced Task)");
            Console.WriteLine("5. Working with Jagged Array\n");
            Console.WriteLine("Input number of task: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (num)
            {
                case 1:
                    break;
                case 2:
                    NullTypes.Run();
                    break;
                case 3:
                    QuadrEq.Run();
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
