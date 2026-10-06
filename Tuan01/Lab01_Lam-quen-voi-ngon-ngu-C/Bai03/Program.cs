using System;

namespace Bai03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nhhap x
            Console.Write("Nhap so nguyen x: ");
            int x = int.Parse(Console.ReadLine());
            // Nhap y
            Console.Write("Nhap so nguyen y: ");
            int y = int.Parse(Console.ReadLine());
            double ketQua = Math.Pow(x, y);
            Console.WriteLine($"Ket qua {x} mu {y} la: {ketQua}");
            Console.ReadKey();
        }
    }
}