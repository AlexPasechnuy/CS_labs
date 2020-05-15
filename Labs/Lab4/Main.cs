using System;

namespace Labs.Lab4
{
    class Main
    {
        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Individual task");
                Console.WriteLine("2. Use dynamic data type");
                Console.WriteLine("3. Working with the File System");
                Console.WriteLine("4. Working with Delegates");
                Console.WriteLine("5. Working with Menus and Data Tables");
                Console.WriteLine("6. The Use of Graphics Features (Advanced Task)");
                Console.WriteLine("Input number of task('-1' to return): ");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    Console.Clear();
                    switch (num)
                    {
                        case 1:
                            break;
                        case 2:
                            DynamicType.Main.Run();
                            break;
                        case 3:
                            FileSystem.Main.Run();
                            break;
                        case 4:
                            Delegates.Main.Run();
                            break;
                        case 5:
                            Menus.Main.Run();
                            break;
                        case 6:
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
