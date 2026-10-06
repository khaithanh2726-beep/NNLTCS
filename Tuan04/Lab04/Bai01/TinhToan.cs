namespace Bai01;

public class TinhToan
{
    private double _a;
    private double _b;

    public double A
    {
        get { return _a; }
        set { _a = value; }
    }

    public double B
    {
        get { return _b; }
        set { _b = value; }
    }

    public TinhToan()
    {
        _a = 0;
        _b = 0;
    }

    public TinhToan(double a, double b)
    {
        _a = a;
        _b = b;
    }

    public double Cong()
    {
        return _a + _b;
    }

    public double Tru()
    {
        return _a - _b;
    }

    public double Nhan()
    {
        return _a * _b;
    }

    public double Chia()
    {
        return _a / _b;
    }
}