using System;
using System.Windows.Forms;

namespace Bai07;

public partial class frmBai07 : Form
{
    private readonly MangSoNguyen mang = new MangSoNguyen();

    public frmBai07()
    {
        InitializeComponent();
        txtNhap.Focus();
    }

    private void txtSo_KeyPress(
        object? sender,
        KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) &&
            e.KeyChar != '-' &&
            e.KeyChar != '\b')
        {
            e.Handled = true;
            return;
        }

        if (e.KeyChar == '-' &&
            sender is TextBox textBox &&
            textBox.SelectionStart != 0)
        {
            e.Handled = true;
        }
    }

    private void HienThiMang()
    {
        txtMang.Text = string.Join(
            "   ",
            mang.LayMang());
    }

    private bool LaySo(
        TextBox textBox,
        out int value)
    {
        if (!int.TryParse(textBox.Text, out value))
        {
            errorProvider1.SetError(
                textBox,
                "Vui lòng nhập số nguyên hợp lệ.");

            return false;
        }

        errorProvider1.SetError(textBox, "");

        return true;
    }

    private bool LayViTri(
        TextBox textBox,
        out int viTri,
        bool choThem = false)
    {
        viTri = 0;

        if (!int.TryParse(
                textBox.Text,
                out viTri))
        {
            errorProvider1.SetError(
                textBox,
                "Vị trí phải là số nguyên.");

            return false;
        }

        int max = choThem
            ? mang.SoLuong
            : mang.SoLuong - 1;

        if (viTri < 0 || viTri > max)
        {
            string message = choThem
                ? $"Vị trí phải từ 0 đến {mang.SoLuong}."
                : $"Vị trí phải từ 0 đến {mang.SoLuong - 1}.";

            errorProvider1.SetError(
                textBox,
                message);

            return false;
        }

        errorProvider1.SetError(textBox, "");

        return true;
    }

    private bool KiemTraMangKhongRong()
    {
        if (mang.SoLuong == 0)
        {
            MessageBox.Show(
                "Mảng đang rỗng!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return false;
        }

        return true;
    }

    private void btnThem_Click(
        object? sender,
        EventArgs e)
    {
        if (!LaySo(
                txtNhap,
                out int so))
        {
            return;
        }

        mang.Them(so);

        HienThiMang();

        txtNhap.Clear();
        txtNhap.Focus();
    }

    private void btnTim_Click(
        object? sender,
        EventArgs e)
    {
        if (!KiemTraMangKhongRong())
        {
            return;
        }

        if (!LaySo(
                txtTim,
                out int giaTri))
        {
            return;
        }

        var ketQua = mang.TimKiem(giaTri);

        if (ketQua.Count == 0)
        {
            MessageBox.Show(
                $"Không tìm thấy {giaTri}.",
                "Kết quả",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }

        MessageBox.Show(
            $"Tìm thấy {giaTri} tại vị trí: " +
            $"{string.Join(", ", ketQua)}",
            "Kết quả",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void btnThemTaiViTri_Click(
        object? sender,
        EventArgs e)
    {
        if (!LayViTri(
                txtViTriThem,
                out int viTri,
                true))
        {
            return;
        }

        if (!LaySo(
                txtGiaTriThem,
                out int giaTri))
        {
            return;
        }

        mang.ThemTaiViTri(
            giaTri,
            viTri);

        HienThiMang();

        txtViTriThem.Clear();
        txtGiaTriThem.Clear();
        txtViTriThem.Focus();
    }

    private void btnThayThe_Click(
        object? sender,
        EventArgs e)
    {
        if (!KiemTraMangKhongRong())
        {
            return;
        }

        if (!LayViTri(
                txtViTri,
                out int viTri))
        {
            return;
        }

        if (!LaySo(
                txtGiaTriMoi,
                out int giaTriMoi))
        {
            return;
        }

        mang.ThayThe(
            viTri,
            giaTriMoi);

        HienThiMang();
    }

    private void btnSapTang_Click(
        object? sender,
        EventArgs e)
    {
        if (!KiemTraMangKhongRong())
        {
            return;
        }

        mang.SapXepTang();

        HienThiMang();
    }

    private void btnSapGiam_Click(
        object? sender,
        EventArgs e)
    {
        if (!KiemTraMangKhongRong())
        {
            return;
        }

        mang.SapXepGiam();

        HienThiMang();
    }

    private void btnTong_Click(
        object? sender,
        EventArgs e)
    {
        if (!KiemTraMangKhongRong())
        {
            return;
        }

        txtTong.Text =
            mang.Tong().ToString();
    }

    private void btnTongChan_Click(
        object? sender,
        EventArgs e)
    {
        if (!KiemTraMangKhongRong())
        {
            return;
        }

        txtTongChan.Text =
            mang.TongChan().ToString();
    }

    private void btnTongLe_Click(
        object? sender,
        EventArgs e)
    {
        if (!KiemTraMangKhongRong())
        {
            return;
        }

        txtTongLe.Text =
            mang.TongLe().ToString();
    }

    private void btnMax_Click(
        object? sender,
        EventArgs e)
    {
        if (!KiemTraMangKhongRong())
        {
            return;
        }

        txtMax.Text =
            mang.Max().ToString();
    }

    private void btnMin_Click(
        object? sender,
        EventArgs e)
    {
        if (!KiemTraMangKhongRong())
        {
            return;
        }

        txtMin.Text =
            mang.Min().ToString();
    }

    private void btnXoa_Click(
        object? sender,
        EventArgs e)
    {
        mang.Xoa();

        txtNhap.Clear();
        txtMang.Clear();
        txtTim.Clear();
        txtViTri.Clear();
        txtGiaTriMoi.Clear();
        txtViTriThem.Clear();
        txtGiaTriThem.Clear();

        txtTong.Clear();
        txtTongChan.Clear();
        txtTongLe.Clear();
        txtMax.Clear();
        txtMin.Clear();

        errorProvider1.Clear();

        txtNhap.Focus();
    }

    private void btnThoat_Click(
        object? sender,
        EventArgs e)
    {
        Close();
    }

    private void frmBai07_FormClosing(
        object? sender,
        FormClosingEventArgs e)
    {
        DialogResult result = MessageBox.Show(
            "Bạn có chắc muốn thoát không?",
            "Xác nhận",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.No)
        {
            e.Cancel = true;
        }
    }
}