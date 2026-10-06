using System;

namespace Bai11
{
    public class Program
    {
        public static string ChuoiDaoNguoc(string str)
        {
            char[] charArray = str.ToCharArray(); //Chuyen thanh chuoi ky tu
            Array.Reverse(charArray); //Dao nguoc mang ky tu
            return new string(charArray); 
        }

        public static void Main(string[] args)
        {
            Console.Write("Nhập chuỗi: ");
            string str = Console.ReadLine();
            str = ChuoiDaoNguoc(str); 
            Console.WriteLine("Chuỗi đảo ngược: " + str); 
        }
    }
}