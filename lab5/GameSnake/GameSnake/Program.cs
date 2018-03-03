using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;


namespace GameSnake
{
    class Program
    {
        public static Thread Game = new Thread(new ThreadStart(Go));
        public static Wall wall;
        public static Food food;
        public static Snake snake;
        static void Main(string[] args)
        {
            Snake snake = new Snake();
            Food food = new Food();
            Wall wall = new Wall();
            Game.Start();
            while (true)
            {
                Snake.Draw();
                Food.Draw();
                Wall.Draw();
                switch (Snake.direc)
                {
                    case 'u':
                        if (Snake.direc != 'd')
                        {
                            Snake.move(0, -1);
                        }
                        break;
                    case 'd':
                        if (Snake.direc != 'u')
                        {
                            Snake.move(0, 1);
                        }
                        break;
                    case 'r':
                        if (Snake.direc != 'l')
                        {
                            Snake.move(1, 0);
                        }
                        break;
                    case 'l':
                        if (Snake.direc != 'r')
                        {
                            Snake.move(-1, 0);
                        }
                        break;
                }
                if (Snake.Eat() == true)
                {
                    bool ok = false;
                    while (!ok)
                    {
                        ok = true;
                        food = new Food();
                        for (int i = 0; i < Snake.body.Count; i++)
                            if (Food.body.x == Snake.body[i].x && Food.body.y == Snake.body[i].y)
                                ok = false;

                        for (int i = 0; i < Wall.body.Count; i++)
                            if (Food.body.x == Wall.body[i].x && Food.body.y == Wall.body[i].y)
                                ok = false;
                    }
                }
                Thread.Sleep(200);
                Console.Clear();
            }
        }
        private static void Go()
        {

            while (true)
            {
                ConsoleKeyInfo psk = Console.ReadKey();
                switch (psk.Key)
                {
                    case ConsoleKey.DownArrow:
                        //if(Snake.direc !='u')
                        Snake.direc = 'd';
                        break;
                    case ConsoleKey.UpArrow:
                        //if (Snake.direc != 'd')
                        Snake.direc = 'u';
                        break;
                    case ConsoleKey.RightArrow:
                        //if (Snake.direc != 'l')
                        Snake.direc = 'r';
                        break;
                    case ConsoleKey.LeftArrow:
                        //if (Snake.direc != 'r')
                        Snake.direc = 'l';
                        break;
                    case ConsoleKey.Escape:
                        //if (Snake.direc != 'r')
                        serialize();
                        break;
                    case ConsoleKey.Enter:
                        //if (Snake.direc != 'r')
                        Deserialize();
                        break;

                }
                Thread.Sleep(200);
            }
        }
        private static void serialize()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream srsnake = new FileStream("snake.ser", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(srsnake, snake);
            srsnake.Close();
            FileStream srFood = new FileStream("food.ser", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(srFood, food);
            srFood.Close();
            FileStream srwall = new FileStream("wall.ser", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(srwall, wall);
            srwall.Close();
        }
        private static void Deserialize()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream srsnake = new FileStream("snake.ser", FileMode.Open, FileAccess.Read);
            snake = bf.Deserialize(srsnake) as Snake;
            srsnake.Close();
            FileStream srFood = new FileStream("food.ser", FileMode.Open, FileAccess.Read);
            food = bf.Deserialize(srFood) as Food;
            srFood.Close();
            FileStream srwall = new FileStream("wall.ser", FileMode.Open, FileAccess.Read);
            wall = bf.Deserialize(srwall) as Wall;
            srwall.Close();
        }
    }
}
