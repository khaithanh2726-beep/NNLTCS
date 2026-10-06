using System;
namespace Bai04
{
    class Program
    {
        static void Main(string[] args) // Kiem tra so nguyen x va y nhap vao
        {
            int x, y;
            while (true)
            {
                Console.Write("Nhap so nguyen x: ");
                if (int.TryParse(Console.ReadLine(), out x))
                {
                    break; 
                }
                Console.WriteLine("Loi: Gia tri nhap vao khong phải la so nguyen! Vui long nhap lai.");
            }
            while (true)
            {
                Console.Write("Nhap so nguyen y: ");
                if (int.TryParse(Console.ReadLine(), out y))
                {
                    break;
                }
                Console.WriteLine("Loi: Gia tri nhap vao khong phải la so nguyen! Vui long nhap lai.");
            }
            double ketQua = Math.Pow(x, y);
            Console.WriteLine($"Ket qua {x} mu {y} la: {ketQua}");
            Console.ReadKey();
        }
    }
}