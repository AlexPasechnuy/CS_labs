using System;
using System.Collections.Generic;

namespace Labs.Lab3.Set
{
    class Main
    {
        public static void Run()
        {
            Random rand = new Random();
            int count, from, to;
            Console.Write("Enter count of set and range of numbers(inclusive): ");
            string[] str = Console.ReadLine().Split();
            if (int.TryParse(str[0], out count) == true && int.TryParse(str[1], out from) == true
    && int.TryParse(str[2], out to) == true && to > from && count < to - from + 1)
            {
                SortedSet<int> set = new SortedSet<int>();
                while (set.Count < count)
                {
                    set.Add(rand.Next(from, to));
                }
                foreach (int s in set)
                {
                    Console.Write(s + " ");
                }
            }
            else    //error messages show
            {
                Console.WriteLine("Wrong input");
            }
            Console.ReadKey();
        }
    }
}
