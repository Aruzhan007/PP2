using System;

namespace Student
{
    class Student
    {
        public string name, sname;
        public Student(string name1, string sname2)
        {
            name = name1;
            sname = sname2;
        }
        public override string ToString()
        {
            return name + " " + sname + "\n";
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] arr = s.Split();
            string[] s1 = arr[0].Split('/');
            string[] s2 = arr[1].Split('/');
            Complex a = new Complex(int.Parse(s1[0]), int.Parse(s1[1]));
            Complex b = new Complex(int.Parse(s2[0]), int.Parse(s2[1]));

            Complex c = a + b;
            Console.WriteLine(c);
            Console.ReadKey();

        }
    }
}