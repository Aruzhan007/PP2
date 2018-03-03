using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MinMax
{
    class Program
    {
       static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"/Users/aruzan/Desktop/Calculus/a.txt");
            string text = System.IO.File.ReadAllText(@"/Users/aruzan/Desktop/Calculus/a.txt");
            args = text.Split();
            int[] n = new int[args.Count()];
            for (int i = 0; i < args.Length;i++)
            {
                n[i] = int.Parse(args[i]); 
            }
            Console.WriteLine(n.Max());

            Console.WriteLine(n.Min());

            Console.ReadKey();
        }
    }
}
