using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SubFolders
{
    class Program
    {
        static void ShowAllInfo(DirectoryInfo directory,int cursor)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            FileSystemInfo[] file = directory.GetFileSystemInfos();

            for (int index = 0; index < file.Length; index++)
            {
                FileSystemInfo fileInfo = file[index];
                if (index == cursor)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                else
                    Console.BackgroundColor = ConsoleColor.Black;
                if (file.GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                Console.WriteLine(fileInfo.Name);
            }        
        }
        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"Users/aruzan / Documents / programming1");
            int cursor = 0;
            int n = dirInfo.GetFileSystemInfos().Length;
            ShowAllInfo(dirInfo,cursor);

            while(true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if(keyInfo.Key==ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor == n)
                        cursor = 0;
                    
                }
                if(keyInfo.Key==ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor == -1)
                        cursor = n - 1;
                }
                if(keyInfo.Key==ConsoleKey.Enter)
                {
                    if(dirInfo.GetFileSystemInfos()[cursor].GetType()==typeof(DirectoryInfo))
                    {
                        dirInfo = new DirectoryInfo(dirInfo.GetFileSystemInfos()[cursor].FullName);
                            cursor = 0;
                        n = dirInfo.GetFileSystemInfos().Length;
                    }
                    else
                    {
                        StreamReader sr = new StreamReader(dirInfo.GetFileSystemInfos()[cursor].FullName);
                        string s = sr.ReadToEnd();
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(s);
                        Console.ReadKey();
                    }
                }
                if(keyInfo.Key==ConsoleKey.Delete)
                {
                    if (dirInfo.Parent != null)
                    {
                        dirInfo = dirInfo.Parent;
                        cursor = 0;
                        n = dirInfo.GetFileSystemInfos().Length;
                    }
                    else
                        break;
                }
                ShowAllInfo(dirInfo,cursor);
            }
        }
    }
}
