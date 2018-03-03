using System;
namespace RealSnake
{
    public class Food
    {
        public char sign;
        public ConsoleColor color;
        public static Point body;
        public Food()
        {
            sign = '';
            color = ConsoleColor.Green;
            int x = new Random().Next(1, 10);
            int y = new Random().Next(1,10);
            body = new Point(x, y);
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(body.x,body.y);
            Console.CursorVisible = false;
            Console.Write(sign);
        }

    }
}
