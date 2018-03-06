using System;
using System.Collections.Generic;

namespace GameRace
{
    public class Car
    {
        public int x, y, speed;
        public Car(int x = 0, int y = 0, int speed = 0)
        {
            this.x = x;
            this.y = y;
            this.speed = speed;

        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("****");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("*   *");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("*    **");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("*******");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("O  O");
        }
        public void Move()
        {
            x += speed;

        }
        public void up()
        {
            y--;
        }
        public void down()
        {
            y++; 
        }
    }
}
