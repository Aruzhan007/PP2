using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.IO;
namespace RealSnake
{
    class Snake
    {
        public int n = 0;
        public char sign;
        public ConsoleColor color;
        public List<Point> body;
        public char direction;
        private int level;

        public Snake()
        {
            sign = '♥';
            color = ConsoleColor.Red;
            direction = 'd';
            body = new List<Point>();
            body.Add(new Point(20, 20));
        }
        public void move(int dx,int dy)
        {

            for (int i = body.Count() - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            int curX = body[0].x + dx;
            int curY = body[0].y + dy;
            if(curX>40)
            {
                body[0].x = 0;
            }
            else
            {
                if (curX < 0)
                    body[0].x = 40;
                else
                    body[0].x += dx;
            }
            if(curY>20)
            {
                body[0].y = 0;
            }
            else
            {
                if (curY < 0)
                    body[0].y = 20;
                else
                    body[0].y += dy;
            }
            for (int i = 1; i < body.Count();i++)
            {
                if(body[0].x==body[i].x && body[0].y==body[i].y)
                {
                    Console.Clear();
                    Console.SetCursorPosition(20,10);
                    Console.CursorVisible = false;
                    Console.WriteLine("GameOver");
                    Console.ReadKey();
                    break;
                }
            }
            for (int i = 1; i < Wall.blocks.Count - 1;++i)
            {
                if(body[0].x==Wall.blocks[i].x && body[0].y==Wall.blocks[i].y)
                {
                    Console.Clear();
                    Console.SetCursorPosition(20,10);
                    Console.CursorVisible = false;
                    Console.WriteLine("GameOver");
                    Console.ReadKey();
                    break;

                }
            }

        }
        public bool Eat()
        {
            if(body[0].x==Food.body.x && body[0].y==Food.body.y)
            {
                body.Add(new Point(Food.body.x,Food.body.y));
                n++;
                if(n==3)
                {
                    n = 0;
                    Wall wall = new Wall(++level);
                    Snake snake = new Snake();

                }
                return true;
            }
            return false;
        }
        public void Draw(){
            for (int i = 0; i < body.Count; i++)
            {
                if (i == 0)

                    Console.ForegroundColor = color;
                else
                    Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(body[i].x, body[i].y);
                Console.Write(sign);
            }
        }
    }
}
