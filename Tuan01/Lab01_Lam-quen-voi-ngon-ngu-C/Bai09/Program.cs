using System;

namespace bai09
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("So thuc thu nhat: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("So thuc thu hai: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("So thuc thu ba: ");
            double c = double.Parse(Console.ReadLine());
            double max, min; 
            FindMaxMin(a, b, c, out max, out min); 
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Min: {min}");
        }
        static void FindMaxMin(double x, double y, double z, out double max, out double min)
        //FindMaxMin tra ve max, min
        {
            max = Math.Max(x, Math.Max(y, z));
            min = Math.Min(x, Math.Min(y, z));
        }
    }
}