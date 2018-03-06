using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Shop
{
    class Program
    {
       
         static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("✿ Welcome to La Flore  ✿ Plese, enter your name ✿");
            string customername = Console.ReadLine();
            Console.WriteLine("✿ Please, enter your cash: ");
            int cash=int.Parse(Console.ReadLine());
            int balance = cash;
            Console.Clear();
          
            Product product = new Product();
            DirectoryInfo directory = new DirectoryInfo(@"shops");
            DirectoryInfo[] dirarr  = directory.GetDirectories(@"shops");
            List<Product> products = new List<Product>();
            Shop shop = new Shop(products);
            int cnt = 0;
            while (true)
            {

                for (int i = 0; i < dirarr.Length; i++)
                {
                    if (i == num)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(dirarr[i]);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(customername + ", your cash : " + cash + "$");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    num--;
                    if (num == -1)
                    {
                        num = dirarr.Length - 1;
                    }
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    num++;
                    if (num == dirarr.Length)
                    {
                        num = 0;
                    }
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    DirectoryInfo dirarr2 = new DirectoryInfo(dirarr[num].FullName);
                    FileInfo[] file = dirarr2.GetFiles();
                    num = 0;
                    while (true)
                    {

                        for (int i = 0; i < file.Length; i++)
                        {
                            if (num == i)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine(file[i].Name.Substring(0, file[i].Name.IndexOf('.')));
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(customername + ", your cash : " + cash + "$");
                        key = Console.ReadKey();
                        if (key.Key == ConsoleKey.UpArrow)

                        {
                            num--;
                            if (num == -1)
                            {
                                num = file.Length - 1;
                            }
                        }
                        if (key.Key == ConsoleKey.DownArrow)
                        {
                            num++;
                            if (num == file.Length)
                            {
                                num = 0;
                            }
                        }
                        if (key.Key == ConsoleKey.Enter)
                        {
                            StreamReader sr = new StreamReader(file[num].FullName);
                            Console.Clear();
                            string s = sr.ReadToEnd();
                            string[] shp = s.Split('\n');
                            for (int i = 0; i < shp.Length; i++)
                            {
                                Console.WriteLine(shp[i]);
                            }
                            int cost = int.Parse(shp[0].Substring(shp[0].IndexOf(' '), shp[0].Length - shp[0].IndexOf(' ')));
                            Console.WriteLine("1)If you want buy ➦ Enter");
                            Console.WriteLine("2)If you want exit ➦ BackSpace");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Enter)
                            {
                                if (cash >= cost)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Congratulations! You successfully bought the " + file[num].Name.Substring(0, file[cnt].Name.IndexOf('.')));
                                    product = new Product(file[num].Name, cost);

                                    shop.products.Add(product); 
                                    cnt++;
                                    cash -= cost;
                                    Console.ReadKey();
                                    num = 0;
                                }
                                else
                                   {
                                    Console.Clear();
                                    Console.WriteLine("Please, fund your account!");
                                    Console.ReadKey();
                                    num = 0;
                                   }
                                }
                                 if (key.Key == ConsoleKey.Escape)
                                {
                                Console.Clear();
                                num = 0;

                                 break;
                                }
                                Console.Clear();
                               }
                             }

                                Console.Clear();
                                if (key.Key == ConsoleKey.S)
                                {
                                  break;
                                }
                             }
                                num = 0;
                               int sum = 0;
                               while (true)
                                {
                                for (int i = 0; i < cnt; i++)
                                {
                                if (num == i)
                                {
                                Console.ForegroundColor = ConsoleColor.Red;
                              }
                               else
                              {
                            Console.ForegroundColor = ConsoleColor.White;
                              }
                            Console.WriteLine(shop.products[i]);
                              }
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(customername + ", your cash : " + cash + "$");
                            Console.WriteLine("1)If you want remove ➦ backspace");
                            Console.WriteLine("2)If you want exit ➦ Esc");
                            ConsoleKeyInfo keyinf = Console.ReadKey();
                            if (keyinf.Key == ConsoleKey.UpArrow)

                              {
                                num--;
                               if (num == -1)
                               {
                                  num = cnt - 1;
                               }
                    }
                    if (keyinf.Key == ConsoleKey.DownArrow)
                    {
                        num++;
                        if (num == cnt)
                        {
                            num = 0;
                        }
                    }

                    Console.Clear();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        foreach (Product b in shop.products)
                        {
                            sum += b.GetHashCode();
                        }
                        break;
                    }
                }

                Console.WriteLine("Thank you," + customername + "!!!");
                Console.WriteLine("Your cheque: " + sum);
                Console.WriteLine("Your reminder: " + (balance - sum));

                Console.ReadKey();
            }
        }
    }
}
        
    
