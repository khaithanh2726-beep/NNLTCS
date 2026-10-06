using System;

namespace Bai05
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 0, y = 0;
            bool hasValues = false;
            int chon;

            do 
            {
                Console.WriteLine("\nMENU");
                Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
                Console.WriteLine("2. Tinh x^y");
                Console.WriteLine("3. Tinh can bac 2 cua x va y");
                Console.WriteLine("4. Thoat");
                Console.Write("Chon chuc nang: ");

                if (!int.TryParse(Console.ReadLine(), out chon)) continue;

                switch (chon)
                {
                    case 1:
                        Console.Write("Nhap x: "); x = double.Parse(Console.ReadLine());
                        Console.Write("Nhap y: "); y = double.Parse(Console.ReadLine());
                        hasValues = true;
                        break;
                    case 2:
                        if (hasValues) Console.WriteLine($"x^y = {Math.Pow(x, y)}");
                        else Console.WriteLine("Nhap x, y");
                        break;
                    case 3:
                        if (hasValues)
                        {
                            Console.WriteLine($"Can bac 2 cua x = {(x >= 0 ? Math.Sqrt(x).ToString() : "Khong ton tai")}");
                            Console.WriteLine($"Can bac 2 cua y = {(y >= 0 ? Math.Sqrt(y).ToString() : "Khong ton tai")}");
                        }
                        else Console.WriteLine("Nhap x, y");
                        break;
                    case 4:
                        Console.WriteLine("Thoat");
                        break;
                }
            } while (chon != 4);
        }
    }
}