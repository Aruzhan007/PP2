using System;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

using System.IO;

namespace RealSnake
{
    public class Wall
    {
        public char sign;
        public ConsoleColor color;
        public static List<Point> blocks;
        public Wall(int level)
        {
            sign = '#';
            color = ConsoleColor.Blue;
            blocks = new List<Point>();
            StreamReader sr = new StreamReader(string.Format("wall{0}.txt", level));
            int n = int.Parse(sr.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string s = sr.ReadLine();
                for (int j = 0; j < s.Length; j++)
                {
                    if (s[j] == '#')
                    {
                        blocks.Add(new Point(j, i));
                    }
                }
            }
            sr.Close();
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in blocks)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
    }
}
