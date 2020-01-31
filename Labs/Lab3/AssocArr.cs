using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab3.AssocArr
{
    class Main
    {
        public static void Run()
        {
            char[] letters = {'A', 'B', 'C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };
            SortedDictionary<char, int> lettersNum = new SortedDictionary<char, int>();
            Console.Write("Enter sentence: ");
            string sentence = Console.ReadLine();
            Console.WriteLine("\nLetter | Number of appereances");
            foreach (char sym in sentence)
            {
                char upperSym = char.ToUpper(sym);
                if (letters.Contains(upperSym))
                {
                    if (lettersNum.ContainsKey(upperSym))
                    {
                        lettersNum[upperSym]++;
                    }
                    else
                    {
                        lettersNum[upperSym] = 1;
                    }
                }
            }
            foreach (var pair in lettersNum)
            {
                Console.WriteLine("   " + pair.Key + "   |   " + pair.Value);
            }
            Console.ReadKey();
        }
    }
}
