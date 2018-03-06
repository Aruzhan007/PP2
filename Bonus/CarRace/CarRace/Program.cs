using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;


namespace GameRace
{
    class Program
    {
       
        public static int n;
        public static void Readcars()
        {

            StreamReader sr = new StreamReader(@"in.txt");


            n = int.Parse(sr.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string s = sr.ReadLine();
                string[] a = s.Split();
                Car car = new Car(int.Parse(a[0]), int.Parse(a[1]), int.Parse(a[2]));
                Game.cars.Add(car);
            }
            Console.ReadKey();
            sr.Close();
        }

        public static double min ;

        public static int index = 0;

        public static void mincar()
        {
            for (int i = 1; i < n; i++)
            {
                if (min > Game.cars[i].speed)
                {
                    min =  Game.cars[i].speed;
                    index = i;
                }
            }
        }
        static void movecar()
        {
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < n; i++)
                {
                    Game.cars[i].Draw();
                    Game.cars[i].Move();
                    Thread.Sleep(1000);
                }
            }

        }
        static void Main(string[] args)
        {
            Game game = new Game();        
            Readcars();
            mincar();
            StreamWriter sw = new StreamWriter("out.txt");
            sw.Write(index);
            sw.Close();
            Thread movement = new Thread(movecar);
            movement.Start();

            while(true)
            {
                ConsoleKeyInfo keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.UpArrow)
                    Game.cars[2].up();
                if (keyinfo.Key == ConsoleKey.DownArrow)
                    Game.cars[2].down();
                if(keyinfo.Key==ConsoleKey.Enter)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = new FileStream("data.ser", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    bf.Serialize(fs, game);
                    fs.Close();
                } 
                if(keyinfo.Key==ConsoleKey.Escape)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream fs = new FileStream("data.ser", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    game = bf.Deserialize(fs) as Game;
                }
                }
        }
                                 
    }
}
