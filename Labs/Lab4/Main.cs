using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab4
{
    class Main
    {
        public static void Run()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("1. Individual task");
                    Console.WriteLine("2. Use dynamic data type");
                    Console.WriteLine("3. Working with the File System");
                    Console.WriteLine("4. Working with Delegates");
                    Console.WriteLine("5. Working with Menus and Data Tables");
                    Console.WriteLine("6. The Use of Graphics Features (Advanced Task)");
                    Console.WriteLine("Input number of task('-1' to return): ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (num)
                    {
                        case 1:
                            break;
                        case 2:
                            DynamicType.Main.Run();
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case -1:
                            return;
                        default:
                            break;
                    }
                }
                catch (System.FormatException)
                {
                }
            }
        }
    }
}
