using System;

namespace Labs.Lab2
{
    class Main
    {
        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Individual task");
                Console.WriteLine("2. Expansion of String Class");
                Console.WriteLine("3. Expanding Library of Mathematical Functions (Advanced Task)");
                Console.WriteLine("4. Creation of Class \"Complex\"");
                Console.WriteLine("5. Creation of Class \"Vector\"");
                Console.WriteLine("6. Class Hierarchy");
                Console.WriteLine("7. Roots of an Equation");
                Console.WriteLine("8. 3D Point\n");
                Console.WriteLine("Input number of task('-1' to return): ");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    Console.Clear();
                    switch (num)
                    {
                        case 1:
                            IndTask.Main.Run();
                            break;
                        case 2:
                            StringExpansion.Main.Run();
                            break;
                        case 3:
                            MathExp.Main.Run();
                            break;
                        case 4:
                            ComplexNum.Main.Run();
                            break;
                        case 5:
                            Vector.Main.Run();
                            break;
                        case 6:
                            Hierarchy.Main.Run();
                            break;
                        case 7:
                            Equation.Main.Run();
                            break;
                        case 8:
                            Point3D.Main.Run();
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
