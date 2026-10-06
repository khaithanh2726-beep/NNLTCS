using System;
namespace Bai14
{
    class NhanVien
    {
        public string HoTen;
        public double MucLuong;
        public int SoNgayVang;
        public void Nhap()
        {
            Console.Write("Nhap ho va ten: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap muc luong (VNĐ): ");
            MucLuong = double.Parse(Console.ReadLine());
            Console.Write("Nhap so ngay vang: ");
            SoNgayVang = int.Parse(Console.ReadLine());
        }
        public double TinhLuong()
        {
            return MucLuong - (SoNgayVang * 100000);
        }
        public void Xuat()
        {
            Console.WriteLine("\n--- THÔNG TIN LƯƠNG NHÂN VIÊN ---");
            Console.WriteLine($"Ho va ten:         {HoTen}");
            Console.WriteLine($"Muc luong goc:  {MucLuong:N0} VNĐ"); //N0 dinh danh so dau phan cach hang nghin
            Console.WriteLine($"So ngay vang:   {SoNgayVang}");
            Console.WriteLine($"Luong: {TinhLuong():N0} VNĐ"); //N0 dinh danh so dau phan cach hang nghin
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            NhanVien nv = new NhanVien();
            nv.Nhap();
            nv.Xuat();
        }
    }
}