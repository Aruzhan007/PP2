using System;

namespace lab
{
    class MainClass
    {
        static bool isPrime(int x){
            for (int i = 2; i <=Math.Sqrt(x); i++)
                if (x % i == 0) return false;
            return true;
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++) {
                Console.WriteLine(args[i]);
            }
                //if (isPrime(int.Parse(args[i])))
               //     Console.WriteLine(args[i]);
            Console.ReadKey();
        }
    }
}

// csc lab1.cs
// lab1.exe 4 5 6 

