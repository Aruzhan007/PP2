using System;
namespace rectungular
{
    class MainClass
    {

    }
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        Rectangle q = new Rectangle();
        Rectangle w = new Rectangle(a);
        Rectangle e = new Rectangle(b, c);
        Console.WriteLine(q);
        Console.WriteLine(w);
        Console.WriteLine(e);
        Console.ReadKey();
    }

}