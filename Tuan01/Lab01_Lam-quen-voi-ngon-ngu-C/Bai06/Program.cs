// Xây dựng lớp có phương thức tìm giá trị lớn nhất của ba số nguyên.
using System;

namespace bai06
{
    class Program
    {
        public static int Max(int a, int b, int c)
        {
            return (a > b && a > c) ? a : (b > c) ? b : c; //DK so lon nhat
        }
        static void Main(string[] args)
        {
            Console.WriteLine("So nguyen thu nhat: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("So nguyen thu hai: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("So nguyen thu ba: ");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("Max: " + Max(a, b, c)); 
        }
    }
}