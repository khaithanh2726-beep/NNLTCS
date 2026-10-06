using System.Collections.Generic;
using System.Linq;

namespace Bai07;

public class MangSoNguyen
{
    private readonly List<int> _mang;

    public MangSoNguyen()
    {
        _mang = new List<int>();
    }

    public int SoLuong
    {
        get { return _mang.Count; }
    }

    public void Them(int giaTri)
    {
        _mang.Add(giaTri);
    }

    public void Xoa()
    {
        _mang.Clear();
    }

    public int Tong()
    {
        return _mang.Sum();
    }

    public int TongChan()
    {
        return _mang
            .Where(x => x % 2 == 0)
            .Sum();
    }

    public int TongLe()
    {
        return _mang
            .Where(x => x % 2 != 0)
            .Sum();
    }

    public int Max()
    {
        return _mang.Max();
    }

    public int Min()
    {
        return _mang.Min();
    }

    public void SapXepTang()
    {
        _mang.Sort();
    }

    public void SapXepGiam()
    {
        _mang.Sort();
        _mang.Reverse();
    }

    public List<int> TimKiem(int giaTri)
    {
        return _mang
            .Select((value, index) => new { value, index })
            .Where(x => x.value == giaTri)
            .Select(x => x.index)
            .ToList();
    }

    public void ThemTaiViTri(int giaTri, int viTri)
    {
        _mang.Insert(viTri, giaTri);
    }

    public void ThayThe(int viTri, int giaTriMoi)
    {
        _mang[viTri] = giaTriMoi;
    }

    public List<int> LayMang()
    {
        return new List<int>(_mang);
    }
}