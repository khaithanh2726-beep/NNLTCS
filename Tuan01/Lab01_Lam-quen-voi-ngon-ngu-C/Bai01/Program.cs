using System;

namespace Bai01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap ho ten cua ban: ");
            string hoTen = Console.ReadLine();
            Console.WriteLine($"Chao ban {hoTen}!");
            Console.ReadKey();
        }
    }
}