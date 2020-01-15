using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab1.EvenElems
{
    class Main
    {
        public static void Run()
        {
            int[,] arr = { { 13,8,4,5 },
            { 11,5,58,3 },
            { 84,57,38,94} };
            int[][] res = new int[arr.GetLength(0)][];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int[] temp = new int[0];
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] % 2 == 0)
                    {
                        Array.Resize(ref temp, temp.Length + 1);
                        temp[temp.Length - 1] = arr[i, j];
                    }
                }
                res[i] = temp;
            }
            for (int i = 0; i < res.Length; i++)
            {
                for (int j = 0; j < res[i].Length; j++)
                {
                    Console.Write(res[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
