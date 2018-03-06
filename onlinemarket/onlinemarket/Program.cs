using System;
using System.Collections.Generic;

namespace onlinemarket
{
    
    public class Product
    {
        public static int cash;
        public static int purchase;
        public static string customername=Console.ReadLine();

        public static void Show(string s)
        {
            Console.Clear();
            Console.SetCursorPosition(20,10);
            Console.Write("Thank you for shoping with us!");
            Console.ReadKey();
            Console.Clear();
        }

        public static void cannotbuy()
        {
            Console.Clear();
            Console.SetCursorPosition(30, 10);
            Console.Write("Make deposit, please!");
            Console.ReadKey();
            Console.Clear();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("✿ Welcome to La Flore  ✿ Good shoping ✿");
            Console.CursorVisible = false;
            Product.cash = 100;
            Product.purchase = 0;
            Menu menu = new Menu();
            menu.Start();
        }
    }
}
