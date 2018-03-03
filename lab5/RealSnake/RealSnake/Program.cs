using System;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RealSnake
{
    class MainClass
    {
        public static int level = 1;
        public static Wall wall;
        public static Snake snake;
        public static Food food;
        static Thread Game = new Thread(new ThreadStart(Go));
        public static bool inGame = true;

        public static void Main(string[] args)
        {
            wall = new Wall(++level);
            snake = new Snake();
            food = new Food();
            Game.Start();

            while(inGame==true)
            {
                Console.Clear();

                Console.Clear();
                snake.Draw();
                food.Draw();
                wall.Draw();
                switch (snake.direction)
                {
                    case 'd':
                     
                        snake.move(0, 1);
                      
                        break;
                    case 'u':
                        
                        snake.move(0, -1);
                        break;
                    case 'r':
                        snake.move(1, 0);
                        break;
                    case 'l':
                        
                        snake.move(-1, 0);
                        //}
                        break;
                    case '1':
                        serialize();
                        break;
                    case '2':
                        deserialize();
                        break;
                }
                if (snake.Eat() == true)
                {
                    bool ok = false;
                    while (!ok)
                    {
                        ok = true;
                        food = new Food();
                        for (int i = 0; i < snake.body.Count; i++)
                            if (Food.body.x == snake.body[i].x && Food.body.y == snake.body[i].y)
                                ok = false;

                        for (int i = 0; i < Wall.blocks.Count; i++)
                            if (Food.body.x == Wall.blocks[i].x && Food.body.y == Wall.blocks[i].y)
                                ok = false;
                    }
                }

                Thread.Sleep(200);
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
        private static void Go()
        {
            while (inGame == true)
            {
                ConsoleKeyInfo button = Console.ReadKey();
                switch (button.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (snake.direction != 'u')
                        {
                            snake.direction = 'd';
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (snake.direction != 'd')
                        {
                            snake.direction = 'u';

                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (snake.direction != 'l')
                        {
                            snake.direction = 'r';
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (snake.direction != 'r')
                        {
                            snake.direction = 'l';
                        }
                        break;
                    case ConsoleKey.F1:
                        snake.direction = '1';
                        break;
                    case ConsoleKey.F2:
                        snake.direction = '2';
                        break;
                }

                Thread.Sleep(20);

            }
        }


        private static void serialize()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fssnake = new FileStream("snake.ser", FileMode.OpenOrCreate, FileAccess.Write);
            FileStream fsfood = new FileStream("food.ser", FileMode.OpenOrCreate, FileAccess.Write);
            FileStream fswall = new FileStream("wall.ser", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(fswall, wall);
            bf.Serialize(fsfood, food);
            bf.Serialize(fssnake, snake);
            fssnake.Close();
            fsfood.Close();
            fswall.Close();
        }

        private static void deserialize()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fssnake = new FileStream("snake.ser", FileMode.Open, FileAccess.Read);
            FileStream fsfood = new FileStream("food.ser", FileMode.Open, FileAccess.Read);
            FileStream fswall = new FileStream("wall,ser", FileMode.Open, FileAccess.Read);
            wall = bf.Deserialize(fswall) as Wall;
            food = bf.Deserialize(fsfood) as Food;
            snake = bf.Deserialize(fssnake) as Snake;
        }
    }
}
