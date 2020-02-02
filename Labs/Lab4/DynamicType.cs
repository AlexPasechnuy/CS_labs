using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab4.DynamicType
{
    class SimpleFract
    {
        int num, denom;

        void Abbrev()
        {
            int sign;
            if (num * denom < 0)
                sign = -1;
            else
                sign = 1;
            num = Math.Abs(num);
            denom = Math.Abs(denom);
            int least;  //gets least from numerator and denominator
            if (num < denom)
                least = num;
            else
                least = denom;
            for (int i = least; i > 0; i--)
            {       //we cannot divide fraction by number which greater than 'least'
                if (num % i == 0 && denom % i == 0)
                {       //find biggest value by which we can divide fraction
                    denom /= i;
                    num /= i;
                    i = 0;
                }
            }
            num *= sign;
            return;
        }

        public SimpleFract(int num, int denom)
        {
            this.num = num;
            this.denom = denom;
        }

        public static SimpleFract operator +(SimpleFract n1, SimpleFract n2)
        {
            SimpleFract res = new SimpleFract(n1.num * n2.denom + n2.num * n1.denom, n1.denom * n2.denom);
            res.Abbrev();
            return res;
        }

        public static SimpleFract operator -(SimpleFract n1, SimpleFract n2)
        {
            SimpleFract res = new SimpleFract(n1.num * n2.denom - n2.num * n1.denom, n1.denom * n2.denom);
            res.Abbrev();
            return res;
        }

        public static SimpleFract operator *(SimpleFract n1, SimpleFract n2)
        {
            SimpleFract res = new SimpleFract(n1.num*n2.num,n1.denom*n2.denom);
            res.Abbrev();
            return res;
        }

        public static SimpleFract operator /(SimpleFract n1, SimpleFract n2)
        {
            SimpleFract res = new SimpleFract(n1.num * n2.denom,n1.denom*n2.num);
            res.Abbrev();
            return res;
        }

        public static SimpleFract operator /(SimpleFract n1, dynamic num)
        {
            SimpleFract res = new SimpleFract(n1.num, n1.denom * num);
            res.Abbrev();
            return res;
        }

        public static implicit operator string(SimpleFract fract)
        {
            return fract.num + "/" + fract.denom;
        }
    }

    static class MatArr
    {
        public static dynamic GetMean(dynamic[] arr)
        {
            dynamic sum = arr[0];
            for(int i = 1; i < arr.Length;i++)
            {
                sum += arr[i];
            }
            return sum / arr.Length;
        }

        public static dynamic GetProd(dynamic[] arr)
        {
            dynamic prod = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                prod *= arr[i];
            }
            return prod;
        }
    }

    class Main
    {
        public static void Run()
        {
            dynamic[] fractArr = {
                new SimpleFract(3,4),
                new SimpleFract(2,3),
                new SimpleFract(1,2),
                new SimpleFract(9,10)
            };
            dynamic[] doublArr = {3.2, 4.8, 7.2, 9.6};
            Console.WriteLine("Simple fractions: mean - " + MatArr.GetMean(fractArr) +
                " ; product - " + MatArr.GetProd(fractArr));
            Console.WriteLine("Doubles: mean - " + MatArr.GetMean(doublArr) +
                " ; product - " + MatArr.GetProd(doublArr));
            Console.ReadKey();
        }
    }
}
