using System;

namespace Labs.Lab3.GenLib
{
    static class GenLib
    {
        public static void SwapGrp<T>(T[] arr, int firstStart, int firstEnd, int secStart, int secEnd)
        {
            if (firstStart < 0 || secEnd > arr.Length || firstStart > firstEnd || secStart > secEnd || secStart < firstEnd)
            {
                throw new ArgumentException();
            }
            int firstSize = firstEnd - firstStart + 1;
            int midSize = secStart - firstEnd - 1;
            int secSize = secEnd - secStart + 1;

            Object[] first = new Object[firstSize];
            Object[] mid = new Object[midSize];
            Object[] second = new Object[secSize];

            Array.Copy(arr, firstStart, first, 0, firstSize);
            Array.Copy(arr, firstEnd + 1, mid, 0, midSize);
            Array.Copy(arr, secStart, second, 0, secSize);

            Array.Copy(second, 0, arr, firstStart, secSize);
            Array.Copy(mid, 0, arr, firstStart + secSize, midSize);
            Array.Copy(first, 0, arr, firstStart + secSize + midSize, firstSize);
        }

        public static void SwapNeighb<T>(T[] arr)
        {
            T temp;
            for (int i = 0; i < ((arr.Length / 2) * 2); i += 2)
            {
                temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
            }
        }

        public static void Insert<T>(T[] from, int fromPos, ref T[] to, int toPos, int num)
        {
            if (fromPos + num > from.Length)
            {
                throw new ArgumentException();
            }
            Array.Resize(ref to, to.Length + num);
            Array.Copy(to, toPos, to, toPos + num, to.Length - toPos - num);
            Array.Copy(from, fromPos, to, toPos, num);
        }

        public static void Replace<T>(T[] from, int fromPos, T[] to, int toPos, int num)
        {
            if (toPos + num > to.Length || fromPos + num > from.Length)
            {
                throw new ArgumentException();
            }
            Array.Copy(from, fromPos, to, toPos, num);
        }

        public static void Print<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }

    class Main
    {
        public static void Run()
        {
            /////////////////////////////////////
            {
                Console.WriteLine("\n--Integers:\n");
                int[] arr1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                int[] arr2 = { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
                Console.Write("First array: ");
                GenLib.Print(arr1);
                Console.Write("Second array: ");
                GenLib.Print(arr2);
                Console.Write("First array with swapped groups: ");
                GenLib.SwapGrp(arr1, 2, 5, 7, 9);
                GenLib.Print(arr1);
                Console.Write("First array with swapped neighbours: ");
                GenLib.SwapNeighb(arr1);
                GenLib.Print(arr1);
                Console.Write("First array with elements, inserted from second array: ");
                GenLib.Insert(arr2, 3, ref arr1, 3, 3);
                GenLib.Print(arr1);
                Console.Write("First array with elements, replaced from second array: ");
                GenLib.Replace(arr2, 3, arr1, 5, 4);
                GenLib.Print(arr1);
            }
            /////////////////////////////////////
            {
                Console.WriteLine("\n--Double:\n");
                double[] arr1 = { 0.2, 1.2, 2.2, 3.2, 4.2, 5.2, 6.2, 7.2, 8.2, 9.2 };
                double[] arr2 = { 10.2, 11.2, 12.2, 13.2, 14.2, 15.2, 16.2, 17.2, 18.2, 19.2 };
                Console.Write("First array: ");
                GenLib.Print(arr1);
                Console.Write("Second array: ");
                GenLib.Print(arr2);
                Console.Write("First array with swapped groups: ");
                GenLib.SwapGrp(arr1, 2, 5, 7, 9);
                GenLib.Print(arr1);
                Console.Write("First array with swapped neighbours: ");
                GenLib.SwapNeighb(arr1);
                GenLib.Print(arr1);
                Console.Write("First array with elements, inserted from second array: ");
                GenLib.Insert(arr2, 3, ref arr1, 3, 3);
                GenLib.Print(arr1);
                Console.Write("First array with elements, replaced from second array: ");
                GenLib.Replace(arr2, 3, arr1, 5, 4);
                GenLib.Print(arr1);
            }
            /////////////////////////////////////
            {
                Console.WriteLine("\n--Characters:\n");
                char[] arr1 = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
                char[] arr2 = { 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't' };
                Console.Write("First array: ");
                GenLib.Print(arr1);
                Console.Write("Second array: ");
                GenLib.Print(arr2);
                Console.Write("First array with swapped groups: ");
                GenLib.SwapGrp(arr1, 2, 5, 7, 9);
                GenLib.Print(arr1);
                Console.Write("First array with swapped neighbours: ");
                GenLib.SwapNeighb(arr1);
                GenLib.Print(arr1);
                Console.Write("First array with elements, inserted from second array: ");
                GenLib.Insert(arr2, 3, ref arr1, 3, 3);
                GenLib.Print(arr1);
                Console.Write("First array with elements, replaced from second array: ");
                GenLib.Replace(arr2, 3, arr1, 5, 4);
                GenLib.Print(arr1);
            }
            Console.ReadKey();
        }
    }
}