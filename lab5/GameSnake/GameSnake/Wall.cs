using System;

using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
namespace GameSnake
{
    public class Wall
    {

        public static char sign;
        public static ConsoleColor color;
        public static List<Point> body;
        public Wall()
        {
            sign = '#';
            color = ConsoleColor.Blue;
            body = new List<Point>();

            StreamReader sr = new StreamReader(@"a.txt");
            string str1 = sr.ReadLine();
            int n = int.Parse(str1);
            for (int i = 0; i < n; i++)
            {
                string str2 = sr.ReadLine();
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str2[j] == '#')
                    {
                        body.Add(new Point(j, i));
                    }
                }
            }
            sr.Close();
        }
        public static void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
    }
}
