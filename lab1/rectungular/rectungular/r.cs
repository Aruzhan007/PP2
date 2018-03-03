using System;
namespace rectungular
{
    public class r
    {
        public r()
        {
        }
        namespace rectungular
    {
        class Rectangle
        {
            public int width;
            public int height;
            public int area;
            public int perimeter;
            public Rectangle()
            {
                width = 1;
                height = 1;
                FindArea();
                FindPerimeter();
            }
            public Rectangle(int a, int b)
            {
                width = a;
                height = b;
                FindArea();
                FindPerimeter();
            }
            public Rectangle(int a)
            {
                width = a;
                height = a;
                FindArea();
                FindPerimeter();
            }
            public void FindArea()
            {
                area = width * height;
            }
            public void FindPerimeter()
            {
                perimeter = 2 * (width + height);
            }
            public override string ToString()
            {
                return area + " " + perimeter;
            }
        }
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
}
