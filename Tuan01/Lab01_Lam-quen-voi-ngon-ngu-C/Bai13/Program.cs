using System;

namespace Bai13
{
    class SinhVien
    {
        public string MaSinhVien { get; set; } 
        public string HoTen { get; set; } 
        public string DiaChi { get; set; } 
        public int NamThu { get; set; } 
        public void NhapThongTin()
        {
            Console.Write("Nhap MSV: ");
            MaSinhVien = Console.ReadLine(); 
            Console.Write("Nhap ho va ten: ");
            HoTen = Console.ReadLine(); 
            Console.Write("Nhap dia chi: ");
            DiaChi = Console.ReadLine();
            Console.Write("Sinh vien nam: ");
            NamThu = int.Parse(Console.ReadLine());
        }
        public void XuatThongTin()
        {
            Console.WriteLine("MSV: " + MaSinhVien);
            Console.WriteLine("Ho va ten: " + HoTen);
            Console.WriteLine("Dia chi: " + DiaChi);
            Console.WriteLine("Sinh vien nam: " + NamThu);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SinhVien sv = new SinhVien(); 
            sv.NhapThongTin(); 
            sv.XuatThongTin(); 
        }
    }
}