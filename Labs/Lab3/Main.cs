using System;

namespace Labs.Lab3
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
                    Console.WriteLine("2. Working with Text Files");
                    Console.WriteLine("3. Implementation of Serialization and Deserialization");
                    Console.WriteLine("4. Creation of a Library that Provides Generic Functions for Working with Arrays and Lists");
                    Console.WriteLine("5. Creating Your Own Container");
                    Console.WriteLine("6. Working with Set");
                    Console.WriteLine("7. Working with Associative Array");
                    Console.WriteLine("8. Creating a \"Flexible\" Array (Advanced Task)\n");
                    Console.WriteLine("Input number of task('-1' to return): ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (num)
                    {
                        case 1:
                            break;
                        case 2:
                            TextFiles.Main.Run();
                            break;
                        case 3:
                            Serial.Main.Run();
                            break;
                        case 4:
                            GenLib.Main.Run();
                            break;
                        case 5:
                            Container.Main.Run();
                            break;
                        case 6:
                            Set.Main.Run();
                            break;
                        case 7:
                            break;
                        case 8:
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
