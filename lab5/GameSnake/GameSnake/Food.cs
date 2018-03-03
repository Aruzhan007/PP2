using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
namespace GameSnake
{
    public class Food
    {
        public static char sign;
        public ConsoleColor color;
        static public Point body;
        public Food()
        {
            sign = '$';
            color = ConsoleColor.Green;
            int x = new Random().Next(1, 20);
            int y = new Random().Next(1, 20);
            body = new Point(x, y);
        }
        public static void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(body.x, body.y);
            Console.Write(sign);
        }
    }
}
