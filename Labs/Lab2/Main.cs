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
                Console.WriteLine("1. Expansion of String Class");
                Console.WriteLine("2. Expanding Library of Mathematical Functions (Advanced Task)");
                Console.WriteLine("3. Creation of Class \"Complex\"");
                Console.WriteLine("4. Creation of Class \"Vector\"");
                Console.WriteLine("5. Class Hierarchy");
                Console.WriteLine("6. Roots of an Equation");
                Console.WriteLine("7. 3D Point\n");
                Console.WriteLine("Input number of task('-1' to return): ");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    Console.Clear();
                    switch (num)
                    {
                        case 1:
                            StringExpansion.Main.Run();
                            break;
                        case 2:
                            MathExp.Main.Run();
                            break;
                        case 3:
                            ComplexNum.Main.Run();
                            break;
                        case 4:
                            Vector.Main.Run();
                            break;
                        case 5:
                            Hierarchy.Main.Run();
                            break;
                        case 6:
                            Equation.Main.Run();
                            break;
                        case 7:
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
