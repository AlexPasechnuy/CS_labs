using System;
using System.Text;
using System.Text;
using System.IO;

namespace Labs.Lab3.TextFiles
{
    class TextFiles
    {
        public static void Rewrite(String from, String to, int length)
        {
            using (StreamReader reader = new StreamReader(from, Encoding.Default))
            {
                using (StreamWriter writer = new StreamWriter(to))
                {
                    string s;
                    while ((s = reader.ReadLine()) != null)
                    {
                        if(s.Length < length)
                        {
                            writer.WriteLine(s);
                        }
                    }
                }
            }
        }
    }

    class Main
    {
        public static void Run()
        {
            TextFiles.Rewrite("Files/Lab3/TextFiles/From.txt", "Files/Lab3/TextFiles/To.txt", 7);
        }
    }
}
