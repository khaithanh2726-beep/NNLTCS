using System;

namespace bai10
{
    class Program
    {
        public static bool ChuoiDoiXUng(string str)
        {
            int left = 0;
            int right = str.Length - 1; 
            while (left < right) //Vong lap cho trai = phai
            {
                if (str[left] != str[right])
                {
                    return false; 
                }
                left++; 
                right--;
            }
            return true; 
        }
        public static void Main(string[] args)
        {
            Console.Write("Nhập chuỗi: ");
            string str = Console.ReadLine(); 
            if (ChuoiDoiXUng(str)) //Ktr chuoi doi xung
            {
                Console.WriteLine("Chuỗi đối xứng"); 
            }
            else
            {
                Console.WriteLine("Chuỗi không đối xứng"); 
            }
        }
    }
}