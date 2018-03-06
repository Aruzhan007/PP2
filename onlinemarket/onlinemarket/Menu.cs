using System;
namespace onlinemarket
{
    
    public class Menu
    {
      string[] products= {"    Rose        ",
                          "    Peony       ",
                          "    Tulips      ",
                          "    Back        "};
        int[] price= 
                         {30,
                          50,
                          45,
                          0};
        int productscount = 4;
        int selectedproduct = 0;

        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(0,0);
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            bool ok = false;
            while(!ok)
            {
                Draw();
                key = Console.ReadKey();

                switch(key.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            selectedproduct--;
                            if (selectedproduct < 0) { selectedproduct = productscount; }
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            selectedproduct++;
                            if (selectedproduct >= productscount) { selectedproduct = 0; }
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            switch(selectedproduct)
                            {
                                case 0:
                                case 1:
                                case 2:
                                    {
                                        if(Product.cash>=price[selectedproduct])
                                        {
                                            Product.Show(products[selectedproduct]);
                                            Product.cash = Product.cash - price[selectedproduct];
                                            Product.purchase++;
                                        }
                                        else
                                        {
                                            Product.cannotbuy();
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        ok = true;
                                        Console.Clear();
                                        break;

                                    }
                            }
                            break;
                        }
                    default:
                        break;
                
                }
            }

        }

        void Draw()
        {
            Console.SetCursorPosition(60, 2);
            Console.Write("Your cash:" + Product.cash + "$");
            Console.SetCursorPosition(60, 3);
            Console.Write("Purchase:" + Product.purchase +" "+ "products");
            int curX = 0;
            int curY = 5;
            Console.SetCursorPosition(curX, curY);
            for (int i = 0; i < productscount; i++)
            {
                Console.SetCursorPosition(curX, curY + i);
                Console.Write("│");
                if (selectedproduct == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.Write(products[i]);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("│");
                if (price[i] != 0)
                {
                    Console.Write("   " + price[i] + " $  ");
                }
                if (selectedproduct == i)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(curX + 2, curY + i);
                    Console.Write(">>");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }

            }
        }
    }
}
