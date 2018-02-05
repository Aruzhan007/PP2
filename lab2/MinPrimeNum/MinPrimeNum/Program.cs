using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MinPrimeNum
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<int> prime = new List<int>();
            string s = File.ReadAllText(@"/Users/aruzan/Desktop/Calculus/a.txt");
            string[] arr = s.Split(' ');
            int[] n = new int[arr.Count()];

            for (int i = 0; i < arr.Length; i++)
            {
                n[i] = int.Parse(args[i]);
                bool ok = true;

                for (int j = 2; j*j <= n[i]; j++);
                {
                    if (n[i] % i == 0)
                    {
                        ok = false;
                        break;
                    }

                }
                if (ok & n[i] != 1)
                {
                    prime.Add(n[i]);
                }

            }
            prime.Sort();
            if (prime.Count == 0)
            {
                File.WriteAllText(@"/Users/aruzan/Desktop/Calculus/b.txt", "There aren't primes");
            }
            else
            {
                File.WriteAllText(@"/Users/aruzan/Desktop/Calculus/b.txt", Convert.ToString(prime.Min()));

            }

            for (int i = 0; i < prime.Count; i++)
            {
                if (prime.Count > 0)
                {
                    File.WriteAllText(@"/Users/aruzan/Desktop/Calculus/b.txt", Convert.ToString(prime[i]));
                }
                break;
            }
            Console.ReadKey();
        }

    }

}
