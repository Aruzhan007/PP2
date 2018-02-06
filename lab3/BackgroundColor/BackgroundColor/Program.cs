using System;
using System.IO;


namespace BackgroundColor
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(@"/Users/aruzan/Documents/programming1");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();


            FileSystemInfo[] fget = d.GetFileSystemInfos();
            foreach(FileSystemInfo f in fget)
            {
                if(f.GetType()==typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;

                }
                if(f.GetType()==typeof(FileInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Red;
                }
            }

            Console.ReadKey();
        }
    }
}
