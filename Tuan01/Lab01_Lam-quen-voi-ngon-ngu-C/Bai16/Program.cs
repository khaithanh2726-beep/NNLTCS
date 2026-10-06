using System;

namespace Bai16
{
    public class Program
    {
        public static void Input(string[] arr) //Nhap mang
        {
            for (int i = 0; i < arr.Length; i++) 
            {
                Console.Write($"Nhap ho va ten thu {i + 1}: ");
                arr[i] = Console.ReadLine();
            }
        }
        public static void Output(string[] arr) //In mang
        {
            Console.WriteLine("Danh sach sau sap xep:"); 

            for (int i = 0; i < arr.Length; i++) 
            {
                Console.WriteLine(arr[i]);
            }
        }

        public static void Sort(string[] arr) //Sap xep mang
        {
            for (int i = 0; i < arr.Length - 1; i++) 
            {
                for (int j = i + 1; j < arr.Length; j++) 
                {
                    if (string.Compare(arr[i], arr[j]) > 0) //So sanh
                    {
                        string temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.Write("So luong nguoi: ");
            int n = int.Parse(Console.ReadLine()); 

            string[] names = new string[n]; //Mang ho ten

            Input(names);
            Sort(names);
            Output(names);
        }
    }
}