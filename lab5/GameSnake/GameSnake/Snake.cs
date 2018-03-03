using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
namespace GameSnake
{
    class Snake
    {
        public static char sign;
        public static ConsoleColor color;
        public static List<Point> body;
        public static char direc;
        public Snake()
        {

            sign = '0';
            color = ConsoleColor.Red;
            body = new List<Point>();
            body.Add(new Point(5, 5));
        }
        public static void move(int dx, int dy)
        {
            body[0].x += dx;
            body[0].y += dy;
           
        }
        public static bool Eat()
        {
            if (body[0].x == Food.body.x && body[0].y == Food.body.y)
            {
                body.Add(new Point(Food.body.x, Food.body.y));
                return true;
            }
            return false;
        }
        public static void Collision()
        {
            for (int i = 0; i < Wall.body.Count; i++)
            {
                if (body[0].x == Wall.body[i].x && body[0].y == Wall.body[i].y)
                {
                    Console.Clear();
                    Console.WriteLine("Gameover");
                    Console.ReadKey();
                    break;
                }
            }
            for (int j = 1; j < body.Count; j++)
            {
                if (body[0].x == body[j].x && body[0].y == body[j].y)
                {

                    Console.Clear();
                    Console.WriteLine("Gameover");
                    Console.ReadKey();
                    break;
                }
            }

        }

        public static void Draw()
        {
            Console.ForegroundColor = color;
            for (int j = 0; j < body.Count; j++)
            {
                if (j == 0)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(body[j].x, body[j].y);
                Console.Write(sign);

            }

        }
    }
}