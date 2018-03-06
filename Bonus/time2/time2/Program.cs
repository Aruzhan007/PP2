using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace time2
{
    class Program
    {
        static Thread thr = new Thread(new ThreadStart(Go));
        static void Main(string[] args)
        {
            List<Point> lis = new List<Point>();
            StreamReader sr = new StreamReader(@"a.txt");
            string S = sr.ReadLine();
            int N = int.Parse(S);
            for (int i = 0; i < N; i++)
            {
                string ST = sr.ReadLine();
                for (int j = 0; j < ST.Length; j++)
                {
                    if (ST[j] == '*')
                    {
                        lis.Add(new Point(j, i));
                    }
                }

            }
            Console.ForegroundColor = ConsoleColor.Blue;
            thr.Start();
            List<Point> pi = new List<Point>();
            pi.Add(new Point(8, 0));
            pi.Add(new Point(6, 1));
            pi.Add(new Point(4, 2));
            pi.Add(new Point(2, 3));
            pi.Add(new Point(4, 4));
            pi.Add(new Point(6, 5));
            pi.Add(new Point(8, 6));
            pi.Add(new Point(10, 5));
            pi.Add(new Point(12, 4));
            pi.Add(new Point(14, 3));
            pi.Add(new Point(12, 2));
            pi.Add(new Point(10, 1));

            while (true)
            {
                foreach (Point P in lis)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(P.x, P.y);
                    Console.Write('*');

                }
            }
            while (true)
            {
                foreach (Point p in lis)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.SetCursorPosition(p.x, p.y);
                    Console.Write('*');

                    Thread.Sleep(100);
                    Console.Clear();
                }
            }
               
        }
                
        static void Go()
        {
            Thread.Sleep(200000);
        }
    }
}


   