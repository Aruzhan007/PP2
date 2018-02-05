using System;

namespace ComplexNum1
{
    class Complex
    {
        public int a;
        public int b;
        public int GCD(int x, int y)
        {
            while(x!=y)
            {
                if(x > y)
                {
                    x = x - y;
                }
                else
                {
                    y = y - x;
                }
            }
            return x;
        }
        public Complex(int _a,int _b)
        {
            a = _a;
            b = _b;
        }
        public Complex()
        { 
        }
        public void simplify()
        {
            int s = GCD(this.a, this.b);
            this.a = this.a / s;
            this.b = this.b / s;
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex n = new Complex();
            n.a = c1.a * c2.b + c2.a * c2.b;
            n.b = c1.b * c2.b;
            n.simplify();
            return n;
        }
        public static Complex operator -(Complex c1, Complex c2)
        {
            Complex n = new Complex();
            n.a = c1.a * c2.b - c2.a * c2.b;
            n.b = c1.b * c2.b;
            n.simplify();
            return n;
        }
        public override string ToString()
        {
            return a + "/" + b;
        }
    }
    class Program 
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(2, 4);
            Complex c2 = new Complex(5, 2);
            Complex add = c1 + c2;
            Complex sub = c1 - c2;

            Console.WriteLine(add);
            Console.WriteLine(sub);
            Console.ReadKey();
        }
    }
}
