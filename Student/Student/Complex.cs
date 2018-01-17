using System;
namespace Student
{
    public class Complex
    {
        public int a, b;
        public Complex(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public static Complex operator +(Complex c1, Complex c2) {
            Complex c = new Complex(c1.a + c2.a, c1.b + c2.b);
            return c;
        }
    }
}
