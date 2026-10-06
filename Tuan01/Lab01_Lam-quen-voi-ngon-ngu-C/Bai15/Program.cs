using System;
using System.Globalization;

namespace Bai15
{
    public class Program
    {
        public static void Input(int[] arr) // Nhap mang gom n phan tu
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Nhap phan tu {i}: ");
                arr[i] = int.Parse(Console.ReadLine()); 
            }
        }
        public static void Output(int[] arr)
        {
            Console.Write("Mang: ");
            for (int i = 0; i < arr.Length; i++)
            { 
                Console.Write(arr[i] + " "); 
            }
        }
        public static int FindMax(int[] arr)
        {
            int max = arr[0]; //Max 
            for (int i = 0; i < arr.Length; i++) 
            {
                if (arr[i] > max) 
                {
                    max = arr[i]; //Max new
                }
            }
            return max;
        }
        public static int FindMin(int[] arr)
        {
            int min = arr[0]; //Min
            for (int i = 0; i < arr.Length; i++) 
            {
                if (arr[i] < min)  //Min new
                {
                    min = arr[i]; 
                }
            }
            return min;
        }
        public static bool IsPrime(int n)
        {
            if (n <= 1) return false; 
            else
            {
                for (int i = 2; i <= Math.Sqrt(n); i++) 
                {
                    if (n % i == 0) //Ktr so nguyen to
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public static int[] PrintPrimes(int[] arr)
        {
            int count = 0; //So luong so nguyen to trong mang
            for (int i = 0; i < arr.Length; i++)
            {
                if (IsPrime(arr[i]))
                {
                    count++;
                }
            }
            int[] primeArray = new int[count]; //Tao mang gom cac so nguyen to
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (IsPrime(arr[i])) 
                {
                    primeArray[index] = arr[i]; //Them vao mang moi
                    index++;
                }
            }

            return primeArray;
        }
        public static void Main(string[] args)
        {
            Console.Write("Nhap so luong phan tu: ");
            int n = int.Parse(Console.ReadLine()); 
            int[] Numbers = new int[n]; 
            Input(Numbers); 
            Output(Numbers); 
            Console.WriteLine("\nMax trong mang " + FindMax(Numbers)); //Max
            Console.WriteLine("Min trong mang " + FindMin(Numbers)); //Min
            int[] primeNumbers = PrintPrimes(Numbers);
            Console.Write("So nguyen to: ");

            for (int i = 0; i < primeNumbers.Length; i++)
            {
                Console.Write(primeNumbers[i] + " ");
            }
        }
    }
}