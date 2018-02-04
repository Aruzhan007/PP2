using System;
using System.IO;

namespace FileDirectoryInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"/Users/aruzan/Documents/programming1");
            DirectoryInfo[] dget = directory.GetDirectories();
            FileInfo[] fget = directory.GetFiles();
            FileSystemInfo[] fss = directory.GetFileSystemInfos();
            foreach (FileSystemInfo f in fss)
            {
                if (f.GetType() == typeof(DirectoryInfo))
                {
                    Console.WriteLine("Directory:" + f.Name);
                }
                else
                {
                    Console.WriteLine("File:" + f.FullName);
                }
            }
            Console.ReadKey();
        }
    }
}