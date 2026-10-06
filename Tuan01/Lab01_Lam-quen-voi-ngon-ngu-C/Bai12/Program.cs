using System;

namespace Bai12
{
    class Program
    {
        public static void Main()
        {
            Console.Write("Nhap chuoi: ");
            string text = Console.ReadLine();
            string chuoiThuong = text.ToLower();// Chuyen sang chua hoa va thuong
            string chuoiHoa = text.ToUpper();
            string[] danhSachTu = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); //Dem so tu trong chuoi
            int soTu = danhSachTu.Length;
            Console.WriteLine($"Chuoi chu thuong: {chuoiThuong}");
            Console.WriteLine($"Chuoi chu hoa: {chuoiHoa}");
            Console.WriteLine($"So tu trong chuoi: {soTu}");
        }
    }
}