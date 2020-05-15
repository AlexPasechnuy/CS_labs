using System;
using System.IO;

namespace Labs.Lab4.FileSystem
{
    public static class DirectoryWorker
    {
        private static void GetDirectoryContent(DirectoryInfo directory, long fileLength)
        {
            FileInfo[] files = directory.GetFiles();

            Console.WriteLine("Directory: " + directory.FullName);
            foreach (FileInfo fileInfo in files)
            {
                if (fileInfo.Length > fileLength)
                {
                    Console.WriteLine("Full name - " + fileInfo.FullName);
                    Console.WriteLine("Length - " + fileInfo.Length);
                    Console.WriteLine("Extension - " + fileInfo.Extension);
                    Console.WriteLine("Last write time - " + fileInfo.LastWriteTimeUtc);
                }
            }
        }


        public static void GetSubdirectoriesContent(DirectoryInfo directory, long fileLength)
        {
            GetDirectoryContent(directory, fileLength);

            DirectoryInfo[] directoryes = directory.GetDirectories();

            foreach (DirectoryInfo dirInfo in directoryes)
            {
                GetSubdirectoriesContent(dirInfo, fileLength);
            }
        }
    }

    public class Main
    {
        public static void Run()
        {
            Console.WriteLine("Enter path to directory");
            string path = Console.ReadLine();

            Console.WriteLine("Enter length of file");
            long length = long.Parse(Console.ReadLine());

            try
            {
                DirectoryInfo directory = new DirectoryInfo(path);

                DirectoryWorker.GetSubdirectoriesContent(directory, length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
