using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
    class Program 
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ConsoleKeyInfo keyInf = Console.ReadKey();
                if (keyInf.Key == ConsoleKey.UpArrow)
                {
                    Console.WriteLine("Up");
                }
                if (keyInf.Key == ConsoleKey.DownArrow)
                {
                    Console.WriteLine("Down");
                }
                if (keyInf.Key == ConsoleKey.RightArrow)
                {
                    Console.WriteLine("Right");
                }
                if (keyInf.Key == ConsoleKey.LeftArrow)
                {
                    Console.WriteLine("Left");
                }
                if(keyInf.Key==ConsoleKey.Escape)
                {
                    break;
                }

            }
        }
    }
}
