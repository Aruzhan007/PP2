using System;

namespace Student1
{
    class Student 
    {
        public string name;
        public string sname;
        public int age;

        public Student()
        {
            name = "Aruzhan";
            sname = "Tlek";
            age = 17;
        }
        public Student(string n,string sn,int a)
        {
            name = n;
            sname = sn;
            age = a;
        }
        public override string ToString()
        {
            return name + " " + sname + " " + age;
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Student a = new Student("Arushka", "Tlek", 17);
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
