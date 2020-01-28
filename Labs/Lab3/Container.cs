using System;
using System.Collections.Generic;

namespace Labs.Lab3.Container
{
    class ArrFromIndex<T>
    {
        private T[] arr = { };
        private int fromIndex;

        public int FromIndex
        {
            get { return fromIndex; }
        }

        public int ToIndex
        {
            get { return fromIndex + arr.Length -1; }
        }
        
        public T this[int index]
        {
            get { return arr[index - fromIndex]; }
            set { arr[index - fromIndex] = value; }
        }
        
        public int Length
        {
            get { return arr.Length; }
        }
        
        public ArrFromIndex(int from, int to)
        {
            fromIndex = from;
            arr = new T[to - from + 1];
        }
        
        public ArrFromIndex(int fromIndex, params T[] arr)
        {
            this.fromIndex = fromIndex;
            this.arr = arr;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T x in arr)
            {
                yield return x;
            }
        }
        
        public static implicit operator string(ArrFromIndex<T> arr)
        {
            string s = "[";
            foreach (T elem in arr)
            {
                s += elem + ", ";
            }
            return s.Substring(0, s.Length - 2) + "]";
        }
        
        public void Add(T elem)
        {
            Array.Resize(ref arr, Length + 1);
            this[Length + fromIndex - 1] = elem;
        }
        
        public void RemoveLast()
        {
            if (arr.Length > 0)
            {
                Array.Resize(ref arr, Length - 1);
            }
        }
    }

    class Main
    {
        public static void Run()
        {

            ArrFromIndex<int> intArr = new ArrFromIndex<int>(3, 5);
            Console.WriteLine(intArr);
            intArr[3] = 5;
            intArr[4] = 7;
            intArr[5] = 9;
            intArr.Add(10);
            intArr.Add(12);
            intArr.RemoveLast();
            Console.WriteLine(intArr);
            foreach (int x in intArr)
            {
                Console.WriteLine(x);
            }
            string[] temp = { "five", "sixxx", "seven" };
            ArrFromIndex<string> strArr = new ArrFromIndex<string>(5, temp);
            strArr[6] = "six";
            strArr.Add("eight");
            strArr.Add("nine");
            strArr.RemoveLast();
            Console.WriteLine(strArr);
            Console.ReadKey();
        }
    }
}
