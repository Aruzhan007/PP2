using System;
using System.IO;

namespace readwrite
{
    class MainClass
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"/Users/aruzan/Desktop/Calculus/a.txt");
            string ss = sr.ReadToEnd();
            sr.Close();
            string[]arg = ss.Split();
            int a = 999999;
            foreach(string s in arg)
            {
                bool b = true;
                    for (int i = 2; i < Math.Sqrt(int.Parse(s)); i++)
                        if (int.Parse(s) % i == 0)
                            b = false;
                    if (b == true && int.Parse(s) != 1)
                        a = Math.Min(a, int.Parse(s));
              
                }

            StreamWriter sw = new StreamWriter(@"/Users/aruzan/Desktop/Calculus/b.txt");
            sw.WriteLine(a);
            sw.Close();
        }
    }
}
