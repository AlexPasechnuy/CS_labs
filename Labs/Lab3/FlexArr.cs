using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab3.FlexArr
{
    class FlexArr<T>
    {
        private T[] arr = { };

        public T this[int index]
        {
            get
            {
                if (Length < index + 1)
                {
                    Array.Resize(ref arr, index + 1);
                }
                return arr[index];
            }
            set {
                if (Length < index + 1)
                {
                    Array.Resize(ref arr, index + 1);
                }
                arr[index] = value;
            }
        }

        public int Length
        {
            get { return arr.Length; }
        }

        public FlexArr()
        {
            arr = new T[0];
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T x in arr)
            {
                yield return x;
            }
        }

        public static implicit operator string(FlexArr<T> arr)
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
            this[Length - 1] = elem;
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
            Console.WriteLine("Using integers:");
            FlexArr<int> intArr = new FlexArr<int>();
            Console.WriteLine("Size = " + intArr.Length);
            Console.WriteLine("arr[5] = " + intArr[5] +" ;size = " + intArr.Length);
            intArr[9] = 14;
            Console.WriteLine("arr[9] was set to 14");
            Console.WriteLine(intArr + "; size: " + intArr.Length);
            ////////////////////////////////////////
            Console.WriteLine("\n\nUsing strings:");
            FlexArr<string> strArr = new FlexArr<string>();
            Console.WriteLine("Size = " + strArr.Length);
            Console.WriteLine("arr[5] = " + strArr[5] + " ;size = " + strArr.Length);
            strArr[9] = "nine";
            Console.WriteLine("arr[9] was set to 14");
            Console.WriteLine(strArr + "; size: " + strArr.Length);
            Console.ReadKey();
        }
    }
}
