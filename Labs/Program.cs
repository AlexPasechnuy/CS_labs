using System;

namespace Labs
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Enter number of lab(1-6)('-1' to quit)('0' to quarantine tasks): ");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    switch (num)
                    {
                        case 0:
                            QuaranTasks.Main.Run();
                            break;
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
