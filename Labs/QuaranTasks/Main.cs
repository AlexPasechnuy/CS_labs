using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.QuaranTasks
{
    class Main
    {
        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Martices(square matrix)");
                Console.WriteLine("2. Functions");
                Console.WriteLine("Input number of task('-1' to return): ");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    Console.Clear();
                    switch (num)
                    {
                        case 1:
                            Martices.Main.Run();
                            break;
                        case 2:
                            Functions.Main.Run();
                            break;
                        case -1:
                            return;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
