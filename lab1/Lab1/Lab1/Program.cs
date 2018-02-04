using System;

namespace Lab1
{
    class Program 
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] array = s.Split();
            for (int i = 0; i < array.Length;i++)
            {
                int n = int.Parse(array[i]);
                bool t = true;
                if(n==1)
                {
                    continue;    
                }
                for (int j = 2; j < Math.Sqrt(n);j++)
                {
                 if(n%j==0)
                    {
                        t = false;
                        break;
                    }
                }
                if(t==true){
                    Console.WriteLine(n);
                }

            }
            Console.ReadKey();
           
        }
    }
}
