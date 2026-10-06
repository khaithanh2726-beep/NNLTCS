using System;

namespace bai07
{
    class Program
    {
        public static bool IsPrime(int n) //Ktr so nguyen to
        {
            if (n <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.Write("Nhap mot so: ");
            int n = int.Parse(Console.ReadLine());
            if (IsPrime(n))
            {
                Console.WriteLine($"{n} La so nguyen to");
            }
            else
            {
                Console.WriteLine($"{n} Khong phai so nguyen to");
            }
        }
    }
}